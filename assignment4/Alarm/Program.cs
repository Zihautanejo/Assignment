using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

//使用事件机制，模拟实现一个闹钟功能。闹钟可以有嘀嗒（Tick）事件和响铃（Alarm）两个事件。
//在闹钟走时时或者响铃时，在控制台显示提示信息。

namespace Alarm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Clock c = new Clock();
            Time AlarmTime = new Time() { Minute = 16, Hour = 11 };
            Time TickTime = new Time() { Minute = 1, Hour = 0 };
            c.Work(AlarmTime, TickTime);
            Console.ReadKey();
        }
    }
    public delegate void ClockHandler(object clocker, Time AlarmTime,Time TickTime);
    public class Time
    {
        private int min, hou;
        public int Minute
        {
            get { return min; }
            set
            {
                if (value >= 0 && value <= 60)
                    min = value;
                else
                    throw new Exception("时间的分钟设置出错");
            }
        }
        public int Hour {
            get { return hou; }
            set
            {
                if (value >= 0 && value <= 24)
                    hou = value;
                else
                    throw new Exception("时间的时钟设置出错");
            }
        }
    }
    public class Clock
    {
        static Time time;
        static bool whether = false;
        public event ClockHandler OnWork;
        public static Time endtime = new Time() { Minute = 60,Hour = 24};
        public void Work(Time AlarmTime,Time TickTime)
        //设定闹钟此时的时间,设定要响铃的时间,时隔多少响铃的时间
        {
            time = GetTime();
            while (GetTime() != endtime)
            {
                //OnWork += new ClockHandler(Alarm);
                //OnWork += Tick;
                //OnWork(this, AlarmTime, TickTime);//谁声明，谁触发
                Alarm(this, AlarmTime, TickTime);
                Tick(this, AlarmTime, TickTime);
            }
        }
        public static void Tick(object cloker,Time AlarmTime,Time TickTime)
        {
            if (time.Minute + TickTime.Minute == GetTime().Minute &&
                time.Hour + TickTime.Hour == GetTime().Hour)
            {
                Console.WriteLine("Tick! Now the time is " + GetTime().Hour + ":" + GetTime().Minute);
                time = GetTime();
            } 
        }
        public static void Alarm(object cloker,Time AlarmTime,Time TickTime)
        {   
            //保证只响一次
            if (GetTime().Minute == AlarmTime.Minute &&
                GetTime().Hour == AlarmTime.Hour && whether == false)
            {
                whether = true;
                Console.WriteLine("Alarm! Now the time is " + AlarmTime.Hour + ":" + AlarmTime.Minute);
            }
        }
        public static Time GetTime() //获取系统的时间
        {
            Time time = new Time();
            string s = System.DateTime.Now.ToString("t");
            time.Hour = Int32.Parse(s.Substring(0,2));
            time.Minute = Int32.Parse(s.Substring(3, 2));
            return time;
        }
    }
}
