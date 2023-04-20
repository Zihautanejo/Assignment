using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{

    /**
     **/
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        public Goods Goods { get; set; }

        public int Quantity { get; set; }

        public float TotalPrice
        {
            get => Goods.Price * Quantity;
        }

        public Order order { get; set; }
        public OrderDetail() { }

        public OrderDetail(int id,Goods goods, int quantity)
        {
            this.OrderDetailId = id;
            this.Goods = goods;
            this.Quantity = quantity;
            using (var context = new OrderContext())
            {
                context.Goods.Add(goods);
                context.SaveChanges();
            }
        }

        public override bool Equals(object obj)
        {
            var detail = obj as OrderDetail;
            return detail != null &&
                   EqualityComparer<Goods>.Default.Equals(Goods, detail.Goods);
        }

        public override int GetHashCode()
        {
            return 785010553 + EqualityComparer<Goods>.Default.GetHashCode(Goods);
        }

        public override string ToString()
        {
            return $"OrderDetail:{Goods},{Quantity}";
        }
    }
}
