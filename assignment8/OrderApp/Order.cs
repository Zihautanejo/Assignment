using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Org.BouncyCastle.Asn1.X509;

namespace OrderApp
{

    /**
     **/
    public class Order : IComparable<Order>
    {

        private readonly List<OrderDetail> details = new List<OrderDetail>();
        
        [Key]
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public DateTime CreateTime { get; set; }

        public float TotalPrice
        {
            get//不是ieum...的接口，不能用sum
            {
                float sum=0;
                int len = Details.Count;
                for(int i = 0; i < len; i++)
                {
                    sum += Details[i].TotalPrice;
                }
                return sum;
            }
        }

        public List<OrderDetail> Details => details; 

        public Order()
        {
            CreateTime = DateTime.Now;
        }

        public Order(int orderId, Customer customer, DateTime creatTime)
        {
            Id = orderId;
            Customer = customer;
            CreateTime = creatTime;
            using (var context = new OrderContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public void AddDetails(OrderDetail orderDetail)
        {
            //冗余数据
            /*if (Details.Contains(orderDetail))//在EF框架中不能用contains来做
            {
                throw new ApplicationException($"The goods ({orderDetail.Goods.Name}) exist in order {Id}");
            }
            Details.Add(orderDetail);*/
            
            //添加到数据库里去
            using (var context = new OrderContext())
            {
                var od = context.OrderDetails.FirstOrDefault(o => o.OrderDetailId == orderDetail.OrderDetailId);
                if (od!=null)
                {
                    throw new ApplicationException($"The goods ({orderDetail.Goods.Name}) exist in order {Id}");
                }
                context.OrderDetails.Add(orderDetail);
                Details.Add(orderDetail);
                context.SaveChanges();
            }
        }

        public int CompareTo(Order other)
        {
            return (other == null) ? 1 : Id - other.Id;
        }

        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null && Id == order.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public void RemoveDetails(int num)
        {
            Details.RemoveAt(num);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"orderId:{Id}, customer:({Customer})");
            Details.ForEach(detail => result.Append("\n\t" + detail));
            return result.ToString();
        }

    }
}
