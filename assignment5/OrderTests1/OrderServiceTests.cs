using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        public void TestInitialize(OrderService service)
        {
            Order o1 = new Order(123, 2030, "Momo", "computer");
            Order o2 = new Order(83, 635, "Leeteuk", "perfume");
            Order o3 = new Order(168, 31, "SJ", "pill");
            service.orderlist.Add(o1);
            service.orderlist.Add(o2);
            service.orderlist.Add(o3);
        }
        [TestMethod()]
        public void CreatTest1()
        {
            OrderService service = new OrderService();
            TestInitialize(service);
            Order o4 = new Order(70, 95, "JYP", "record");
            List<Order> testlist = service.orderlist;
            testlist.Add(o4);
            service.Creat(o4);
            CollectionAssert.AreEqual(testlist, service.orderlist);
            //先判断IsNotNull
            //错误境况，检查是否抛出异常 ExpectedExpected
            //CollectAssert.Contain
            //一般查询返回数量就够了
        }
        public void DeleteTest1()
        {
            OrderService service = new OrderService();
            TestInitialize(service);
            List<Order> testlist = service.orderlist;
            Order o1 = new Order(123, 2030, "Momo", "computer");
            testlist.Remove(o1);
            service.Delete(1, 123);
            CollectionAssert.AreEqual(testlist, service.orderlist);
        }
        public void ModifyTest1()
        {
            OrderService service = new OrderService();
            TestInitialize(service);
            List<Order> testlist = service.orderlist;
            Order o1 = new Order(123, 2030, "Momo", "computer");
            testlist.Remove(o1);
            o1 = new Order(123, 2050, "Momo", "computer");
            testlist.Add(o1);
            service.Modify(1, 123,2,2050);
            CollectionAssert.AreEqual(testlist, service.orderlist);
        }
        public void QueryTest1()
        {
            OrderService service = new OrderService();
            TestInitialize(service);
            Order o1 = new Order(123, 2030, "Momo", "computer");
            List<Order> testlist = new List<Order>();
            testlist.Add(o1);
            List<Order>anslist=service.Query(1, 123);
            CollectionAssert.AreEqual(testlist,anslist);
        }
    }
}