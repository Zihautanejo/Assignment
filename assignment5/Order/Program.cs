using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderService s = new OrderService();
            
            //s.orderlist.Sort((o1, o2) => (o1.money - o2.money));
            Order o1 = new Order(123, 2030, "Momo","computer");
            Order o2 = new Order(83, 635, "Leeteuk","perfume");
            s.Creat(o1);
            Console.ReadKey();
        }
    }

    //客户和货物类
    public class Client
    {
        private string name;
        public string Name { get; set; }
        public override string ToString()
        {
            return "Client's name is" + name;
        }
        public Client(string s = "")
        {
            Name = s;
        }
    }
    public class Goods
    {
        private string type;
        public string Type { get; set; }
        public override string ToString()
        {
            return "Goods is" + type;
        }
        public Goods(string s = "")
        {
            Type = s;
        }
    }

    public class Order : IComparable//IComparable<Order>,只能和order比较
    {
        public int number, money;//金额总值，用detail.sum(d=>d.totalprice)来算，别写冗余数据
        public string client, goods;//public Client Client{get;set;}
        public List<OrderDetails> orderdetail = new List<OrderDetails>();
        //还要写一个无参的
        //publi Order (){...}
        public Order(int num = 0, int mon = 0, string cli = "", string good = "")
        {
            number=num;
            money=mon;
            client = new Client(cli).Name;
            goods = new Goods(good).Type;
        }
        public int CompareTo(object a)
        {
            Order or = a as Order;
            if (or == null)
                throw new System.ArgumentException();
            return this.number.CompareTo(or.number);
            //return (a==null)?1:number-a.number;
        }
        public override string ToString()
        {
            return "Order's number is" + number + ",the amount is" + money + ",the client's name is" + client + ",the goods is" + goods+".";
        }
        //多个用循环来做，注意拼接还是strongbuild

        public override bool Equals(object obj)
        {
            Order ord = obj as Order;
            return ord!=null && ord.number==number &&
                ord.money==money && ord.client == client && ord.goods==goods;
        }
        public override int GetHashCode()
        {
            return number;
        }
    }

    public class OrderDetails
    {
        public int number, amount,monovalent;
        public string type;
        public OrderDetails(int num=0,int amou=0,string typ="",int mono=0)
            //能传对象传对象，直接传商品类goods
        {
            number = num;
            amount = amou;
            type = typ;
            monovalent = mono;
        }
        public override string ToString()
        {
            return "There are a tatal of" + amount + type + "involved in" +
                "Order" + number + ",the unit price of each is" + monovalent;
        }
        public override bool Equals(object obj)
        {
            OrderDetails ordde = obj as OrderDetails;
            return ordde != null && ordde.number == number &&
                ordde.type == type && ordde.amount == amount;
        }
        public override int GetHashCode()
        {
            return number;
        }
    }

    public class OrderService
    {
        //用private readonly来写
        public List<Order> orderlist =new List<Order>();//订单list
        //排序   orderlist.Sort();
        //public void Sort (Compera<Order> condition)
        //predicate<Order> condition
        //创建订单
        public void Creat(Order neworder)
        {
            List<OrderDetails> newodde = neworder.orderdetail;
            List<OrderDetails> odde;
            foreach (Order order in orderlist)
            {
                odde = order.orderdetail;
                if (order.Equals(neworder) && odde.Equals(newodde)) {
                    throw new Exception("The entered order has already existed.");
                }//直接用orderlist.Contain(),会缺省equals方法
            }
            orderlist.Add(neworder);
            Console.WriteLine("Creat a new order，" + neworder+newodde); 
        }
        //更新订单
        //findindex
        //删除订单
        public void Delete(int choice, object a)
        {
            List<Order> deletelist = Query(choice, a);
            if (deletelist == null)
            {
                throw new Exception("Didn't find the order which need delete");
            }
            foreach(Order or in deletelist)
            {
                deletelist.Remove(or);
            }
        }
        //修改订单
        public void Modify(int choice,object a,int select,object b)
            //选择项目序号choice为a值的所有项目，将他们的项目序号select改为b值
        {
            List<Order> modifylist = Query(choice,a);
            if (modifylist == null) { 
                throw new Exception("Didn't find the order which need modify"); 
            }
            switch (select)
            {
                case 1://number
                    foreach (Order or in modifylist) { or.number=(int)b; }
                    break;
                case 2://money
                    foreach (Order or in modifylist) { or.money = (int)b; }
                    break;
                case 3://client
                    foreach (Order or in modifylist) { or.client = (string)b; }
                    break;
                case 4://goods
                    foreach (Order or in modifylist) { or.goods = (string)b; }
                    break;
                default:
                    throw new Exception("The modify num is illegal.");
            }
        }
        //查询订单
        public List<Order> Query(int choice,object a)
        {
            List<Order> querylist = new List<Order>();//查询结果
            switch (choice)
            {
                case 1://number
                    var orderNum = orderlist.Where(s => s.number == (int)a)
                                            .OrderBy(s => s.money);
                    foreach(Order or in orderNum) { querylist.Add(or); }
                    break;
                case 2://money
                    var orderMon = orderlist.Where(s => s.money == (int)a)
                                            .OrderBy(s => s.money);
                    foreach (Order or in orderMon) { querylist.Add(or); }
                    break;
                case 3://client
                    var orderCli = orderlist.Where(s => s.client == (string)a)
                                            .OrderBy(s => s.money);
                    foreach (Order or in orderCli) { querylist.Add(or); }
                    break;
                case 4://goods
                    var orderGoo = orderlist.Where(s => s.goods == (string)a)
                                            .OrderBy(s => s.money);
                    foreach (Order or in orderGoo) { querylist.Add(or); }
                    break;
                default:
                    throw new Exception("The entered num is illegal.");
            }
            return querylist;
        }
        //FirstOrDefault方法 找不到返回空
        //RemoveAll(o=>o.number==ordernumber)
        //foreach循环中，只读，不能删除，添加订单，但可以修改订单中的某些字段
        //Any方法
    }
}
