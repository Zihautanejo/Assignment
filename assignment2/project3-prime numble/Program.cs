using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project3_prime_numble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[] a = new bool[101];//初始化bool为false，系统默认赋值
            Sieve(a);
            for(int i = 2; i < 101; i++)
            {
                if (a[i] == false)
                    Console.WriteLine(i);
            }
            Console.ReadKey();
        }
        //思路，埃式筛法，bool类型的数组，当n被筛掉，a[n]为true
        static void Sieve(bool[] a)
        {
            //筛除时最大是从i的2倍开始的，而50的2倍已经为100，因此i最大为50
            for(int i = 2; i < 51; i++)
            {
                int j = 2;
                while (i * j <= 100)
                {
                    a[i * j] = true;
                    j++;
                }
            }
        }
    }
}
