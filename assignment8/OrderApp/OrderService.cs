using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace OrderApp
{

    public class OrderService
    {


        private readonly List<Order> orders = new List<Order>();

        public OrderService()
        {
        }

        //添加订单
        public void AddOrder(Order order)
        {
            using (var context = new OrderContext())
            {
                var addorder = context.Orders.FirstOrDefault(o => o.Id == order.Id);
                if (addorder!=null)
                {
                    throw new ApplicationException($"the order {order.Id} already exists!");
                }
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

        //更新订单
        public void Update(Order order)
        {
            using (var context = new OrderContext())
            {
                /*int idx = orders.FindIndex(o => o.Id == order.Id);
                if (idx < 0)
                {
                    throw new ApplicationException($"the order {order.Id} doesn't exist!");
                }
                orders.RemoveAt(idx);
                orders.Add(order);*/
                var update = context.Orders.FirstOrDefault(o => o.Id == order.Id);
                if (update != null)
                {
                    context.Orders.Remove(update);
                    context.Orders.Add(order);
                    context.SaveChanges();
                }

            }
        }

        //根据Id查询订单
        public Order GetById(int orderId)
        {
            using (var context = new OrderContext())
            {
                return context.Orders.Include("Details").Include("Customer").Include("Details.Goods").SingleOrDefault(o => o.Id == orderId);
            }
        }

        //根据Id删除订单
        public void RemoveOrder(int orderId)
        {
            using (var context = new OrderContext())
            {
                /**
                int idx = orders.FindIndex(o => o.Id == orderId);
                if (idx >= 0)
                {
                    orders.RemoveAt(idx);
                }
                
                orders.RemoveAll(o => o.Id == orderId);
                */
                var order = context.Orders.Include(o=>o.Details).FirstOrDefault(o => o.Id == orderId);
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
            }
        }

        //查询所有订单
        public List<Order> QueryAll()
        {
            using (var context = new OrderContext())
            {
                //分页
                /*int currentPage=2, pageSize=10;
                var query = context.Orders
                    .OrderBy(o => o.Id)
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize);
                return query.ToList();*/
                return context.Orders.Include("Details").Include("Customer").Include("Details.Goods").ToList();
            }
        }

        //根据客户名查询
        public List<Order> QueryByCustomerName(string customerName)
        {
            using (var context = new OrderContext())
            {
                var query = context.Orders.Include("Details").Include("Customer").Include("Details.Goods")
                    .Where(o => o.Customer.Name == customerName);
                    //.OrderBy(o => o.TotalPrice);//无法解决
                return query.ToList();
            }
        }

        //根据货物名查询
        public List<Order> QueryByGoodsName(string goodsName)
        {
            using (var context = new OrderContext())
            {
                var query = context.Orders.Include("Details").Include("Customer").Include("Details.Goods")
                    .Where(o => o.Details.Any(d => d.Goods.Name == goodsName));
                    //.OrderBy(o => o.TotalPrice);
                return query.ToList();

                /** 其他方法
                var query2 = orders.Where(
                  o => o.Details.Exists(d => d.Goods.Name == goodsName))
                    .OrderBy(o => o.TotalPrice);

                var query3 = orders.Where(
                 o => o.Details.Where(d => d.Goods.Name == goodsName).Count()>0)
                   .OrderBy(o => o.TotalPrice);

                var query4 = orders.Where(
                 o => HasGoods(o,goodsName)) //写一个HasGoods方法，来检查o中是否包含名为goodName的货物
                   .OrderBy(o => o.TotalPrice); 
                **/
            }
        }

        //根据总价查询
        public List<Order> QueryByTotalPrice(float totalPrice)
        {
            using (var context = new OrderContext())
            {
                var query = context.Orders.Include("Details").Include("Customer").Include("Details.Goods")
                    .Where(o => o.TotalPrice >= totalPrice);
                    //.OrderBy(o => o.TotalPrice);
                return query.ToList();
            }
        }


        //对orders中的数据进行排序
        /*public void Sort(Comparison<Order> comparison)
        {
            orders.Sort(comparison);
        }*/

        //根据传入的条件进行查询
        /*public IEnumerable<Order> Query(Predicate<Order> condition)
        {
            using (var context = new OrderContext())
            {
                return context.Orders.Include("details").Where(o => condition(o)).OrderBy(o => o.TotalPrice);
            }
        }
        */
    }
}
