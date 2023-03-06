using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
//求指定数的所有素数因子
namespace assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[20];
            int[] b = new int[20];
            string s = Console.ReadLine();
            int n = Convert.ToInt32(s);
            int Anum = Factor(a, n);
            int Bnum =CheckPrime(a, b, Anum);
            for(int i = 0; i < Bnum; i++)
            {
                Console.Write(b[i]+" ");
            }
            Console.ReadKey();
        }
        static int Factor(int[] a,int n)//指定数字n，将因子存入数字a中
        {
            int m = 0; //m用于数组往里加数，确定位置
            a[m] = 1;m++;
            if (n % 2 == 0)
            {
                a[m] = 2;m++;
            }
            //当n为偶数的时候，其偶数因子除2外都不会是质数，只需验证奇数
            //当n为奇数的时候，其因子不会为偶数，只需验证奇数
            for(int i = 3; i < n + 1; i+=2)
            {
                 if (n % i == 0)
                 {
                     a[m] = i;
                     m++;
                 }
            }
            return m;
        }   
        
        static int CheckPrime(int[]a,int[] b,int n)//检验a是否为质数，存入b中
        {
            int numA = n;
            int numB = 0;
            bool checkit = true;
            for(int i = 0; i < numA; i++)
            {
                if (a[i] == 1)
                {
                    b[numB] = 1;numB++;i++;
                }
                if (a[i] == 2)
                {
                    b[numB] = 2;numB++;i++;
                }
                for (int j = 3; j < a[i]; j+=2)//a中没有偶数了1
                {
                    if (a[i] % j == 0)
                    {
                        checkit = false;
                        break;
                    }
                    
                }
                if (checkit == true)
                {
                    b[numB] = a[i];
                    numB++;
                }
            }
            return numB;
        }
    }
}
