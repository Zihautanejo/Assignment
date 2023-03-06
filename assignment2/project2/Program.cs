using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//求数组的最大，最小元素，平均值，和
namespace project2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数组内的数字，用逗号进行分隔");
            double[] b = new double[4];//用数组b存放各个计算值
            string s = Console.ReadLine();
            string[] ArrayNum = s.Split(',');//用逗号分隔输入的字符串
            int[] a = new int[ArrayNum.Length];
            for(int i = 0; i < ArrayNum.Length; i++)//进行类型转换
            {
                a[i] = Convert.ToInt32(ArrayNum[i]);
            }
            ArrayCalculate(a, b);
            Console.WriteLine("最小元素为：" + b[0]);
            Console.WriteLine("最大元素为：" + b[1]);
            Console.WriteLine("平均值为：" + b[2]);
            Console.WriteLine("和为：" + b[3]);
            Console.ReadKey();
        }
        static void ArrayCalculate(int[] a,double[] b)
        {
            int min = a[0], max = a[0], sum = 0;
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                }
                if (a[i] > max)
                {
                    max = a[i];
                }
                sum += a[i];
            }
            b[0] = min;
            b[1] = max;
            b[2] = ((double)sum / a.Length);//平均数取浮点数
            b[3] = sum;
        }
    }
}
