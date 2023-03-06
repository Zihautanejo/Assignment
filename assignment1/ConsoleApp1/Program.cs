using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Calculator(s);
            Console.ReadKey();
        }
        static void Calculator(string s)
        {
            char oper;
            int i = 0, n1 = 0, n2 = 0;
            while (s[i] < '9' && s[i] > '0')
            {
                n1 = n1 * 10 + s[i] - '0';
                i++;
            }
            oper = s[i];
            i++;
            while (i < s.Length && s[i] < '9' && s[i] > '0')
            {
                n2 = n2 * 10 + (int)s[i] - '0';
                i++;
            }
            switch (oper)
            {
                case '+':
                    Console.WriteLine(n1 + n2);
                    break;
                case '-':
                    Console.WriteLine(n1 - n2);
                    break;
                case '*':
                    Console.WriteLine(n1 * n2);
                    break;
                case '/':
                    Console.WriteLine(n1 / n2);
                    break;
                default:
                    break;

            }
        }
    }
}
