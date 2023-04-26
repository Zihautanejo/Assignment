using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;

namespace OrderWeb.models
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
            this.Database.EnsureCreated(); //自动建库建表
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
