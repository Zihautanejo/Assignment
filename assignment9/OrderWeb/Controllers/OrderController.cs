using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderWeb.models;


namespace OrderWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext orderDb;
        public OrderController(OrderContext context)
        {
            this.orderDb = context;
        }

        [HttpGet("Id")]
        //[HttpGet({"Id"})]
        public ActionResult<Order> GetOrder(string id)
        {
            var order = orderDb.Orders
                       //.Include(o => o.Details.Select(d => d.GoodsItem))
                       //.Include(o => o.Customer)
                       .Include("Details").Include("Details.GoodsItem").Include("Customer")
                       .SingleOrDefault(o => o.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpGet("GoodsName")]
        public ActionResult<List<Order>> QueryOrdersByGoodsName(string goodsName)
        {
            var order = OrdersByGoodsName(goodsName);
            return order.ToList();
        }

        [HttpGet("CustomerName")]
        public ActionResult<List<Order>> QueryOrdersByCustomerName(string customerName)
        {
            var order = OrdersByCustomerName(customerName);
            return order.ToList();
        }

        [HttpGet("TotalAmount")]
        public ActionResult<List<Order>> QueryOrdersByTotalAmount(float amount)
        {
            var order = OrdersByTotalAmount(amount);
            return order.ToList();
        }


        //分页
        /*
        [HttpGet("pageQuery")]
        public ActionResult<List<Order>> queryOrder(string goodsName, int skip, int take)
        {
            var order = OrdersByGoodsName(goodsName).Skip(skip).Take(take);
            return order.ToList();
        }
        */

        private IQueryable<Order> OrdersByGoodsName(string goodsName)
        {
            IQueryable<Order> query = orderDb.Orders;
            if (goodsName != null)
            {
                query = query
                  //.Include(o => o.Details.Select(d => (d as OrderDetail).GoodsItem))
                  //.Include(o => o.Customer)
                  .Include("Details").Include("Details.GoodsItem").Include("Customer")
                  .Where(order => order.Details.Any(item => (item as OrderDetail).GoodsItem.Name == goodsName));
            }
            return query;
        }
        

        private IQueryable<Order> OrdersByCustomerName(string customerName)
        {
            IQueryable<Order> query = orderDb.Orders;
            if (customerName != null)
            {
                query = query
                  .Include("Details").Include("Details.GoodsItem").Include("Customer")
                  .Where(order => order.Customer.Name == customerName);
            }
            return query;
        }

        private IQueryable<Order> OrdersByTotalAmount(float amout)
        {
            IQueryable<Order> query = orderDb.Orders;
            if (amout!=0)
            {
                query = query
                  //.Include(o => o.Details.Select(d => d.GoodsItem))
                  //.Include("Customer")
                  .Include("Details").Include("Details.GoodsItem").Include("Customer")
                  .Where(order => order.Details.Sum(d => d.Quantity * d.GoodsItem.Price) > amout);
            }
            return query;
        }


        [HttpPost]
        public ActionResult<Order> AddOrder(Order order)
        {
            try
            { 
                //FixOrder(order);
                orderDb.Orders.Add(order);
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return order;
        }

        [HttpPut("id")]
        public ActionResult<Order> PutOrder(string id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest("Id cannot be modified!");
            }
            try
            {
                var ord = orderDb.Orders
                    .Include("Details").Include("Details.GoodsItem").Include("Customer")
                    .FirstOrDefault(o => o.OrderId == id);
                FixOrder(ord);
                orderDb.Remove(ord);
                orderDb.Add(order);
                //有外键的约束，不好改
                //orderDb.Entry(order).State = EntityState.Modified;
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }

        [HttpDelete("id")]
        public ActionResult DeleteTodoItem(string id)
        {
            try
            {
                var order = orderDb.Orders
                    .Include("Details").Include("Details.GoodsItem").Include("Customer")
                    .FirstOrDefault(o => o.OrderId == id);
                if (order != null)
                {
                    FixOrder(order);
                    orderDb.Remove(order);
                    orderDb.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }
        private static void FixOrder(Order newOrder)
        {
            newOrder.CustomerId = newOrder.Customer.Id;
            newOrder.Customer = null;
            newOrder.Details.ForEach(d => {
                d.GoodsId = d.GoodsItem.Id;
                d.GoodsItem = null;
            });
        }
    }
}
