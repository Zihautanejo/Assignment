using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ListCalculate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            //传入list的数据
            list.Add(1); list.Add(3); list.Add(5);
            //lambda表达式，用局部变量来传结果
            int sum = 0;int min = list.Head.Data;int max = list.Head.Data;
            GenericList<int>.Calculate(list, m=>Console.WriteLine(m.Data));
            GenericList<int>.Calculate(list, m => sum+=m.Data);
            GenericList<int>.Calculate(list, m => max=Math.Max(max,m.Data));
            GenericList<int>.Calculate(list, m => min=Math.Min(min, m.Data));
            Console.WriteLine("该链表的总和为" + sum);
            Console.WriteLine("该链表的最大值为" + max);
            Console.WriteLine("该链表的最小值为" + min);
            Console.ReadKey();
        }
    }
    //泛型节点类
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }
    //泛型链表类
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }

        }
        public static void Calculate(GenericList<T> list, Action<Node<T>> action) {
            Node<T> p = list.head;
            while (p!= null)
            {
                action(p);
                p = p.Next;
            }
        }
    } 
}
