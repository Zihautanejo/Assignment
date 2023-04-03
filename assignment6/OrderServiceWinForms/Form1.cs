using OrderApp;
namespace OrderServiceWinForms
{
    public partial class Form1 : Form
    {
        public string str { set; get; }//第二个文本框中的string
        public string type { set; get; }
        public int idnum { set; get; }///第一个文本框中的id

        public OrderService ordser = new OrderService();
        public Form1()
        {
            InitializeComponent();
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");

            Goods milk = new Goods(1, "Milk", 69.9f);
            Goods eggs = new Goods(2, "eggs", 4.99f);
            Goods apple = new Goods(3, "apple", 5.59f);
            List<Goods> goodslist = new List<Goods>();
            goodslist.Add(milk);
            goodslist.Add(eggs);
            goodslist.Add(apple);

            Order order1 = new Order(1, customer1, new DateTime(2021, 3, 21));
            order1.AddDetails(new OrderDetail(apple, 8));
            order1.AddDetails(new OrderDetail(eggs, 10));

            Order order2 = new Order(2, customer2, new DateTime(2021, 3, 21));
            order2.AddDetails(new OrderDetail(eggs, 10));
            order2.AddDetails(new OrderDetail(milk, 10));

            Order order3 = new Order(3, customer2, new DateTime(2021, 3, 21));
            order3.AddDetails(new OrderDetail(milk, 100));

            ordser.AddOrder(order1);
            ordser.AddOrder(order2);
            ordser.AddOrder(order3);

            string str = "";
            string type = "";
            text.DataBindings.Add("Text", this, "str");
            item.DataBindings.Add("SelectedItem", this, "type");
            IDtext.DataBindings.Add("Text", this, "idnum");
            OrderbindingSource.DataSource = ordser.orders;
        }
        private void item_SelectedIndexChanged(object sender, EventArgs e) { }
        private void OrderbindingSource_CurrentChanged(object sender, EventArgs e) { }

        private void query_Click(object sender, EventArgs e)
        {
            //All

            if (idnum != 0)
            {
                OrderbindingSource.DataSource = ordser.GetById(idnum);
            }
            else
            {
                switch (type)
                {
                    case "CustomerName":
                        OrderbindingSource.DataSource = ordser.QueryByCustomerName(str);
                        break;
                    case "GoodsName":
                        OrderbindingSource.DataSource = ordser.QueryByGoodsName(str);
                        break;
                    case "OrderTotalPrice":
                        OrderbindingSource.DataSource = ordser.QueryByTotalPrice((float)Convert.ToDouble(str));
                        break;
                    case "All":
                        OrderbindingSource.DataSource = ordser.QueryAll();
                        break;
                    default:
                        MessageBox.Show("所选项无法进行查询，请重新选择");
                        break;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e){
        }

        private void creatorder_Click(object sender, EventArgs e)
        {
            Order neworder = new Order();
            if (ordser.GetById(idnum) != null)
            {
                MessageBox.Show("创建订单时，必需添加新的订单号");
            }
            neworder.Id = idnum;
            ordser.AddOrder(neworder);
            OrderbindingSource.ResetBindings(true);
        }

        private void CreatDetail_Click(object sender, EventArgs e)
        {
            Order ord = (Order)this.OrderbindingSource.Current;
            OrderDetail der = new OrderDetail();
            der = ord.Details.FirstOrDefault(o => o.Goods.Id == idnum);
            Goods goo = new Goods();
            if (der!=null)
            {
                MessageBox.Show("创建订单时，必需添加新订单明细的货物号");
            }
            else
            {
                if (type != "DetailTotalPrice" && Convert.ToInt64(text.Text)==null)
                {
                    MessageBox.Show("创建订单时，必需添加新订单明细的货物价格");
                }
                else
                {
                    der = new OrderDetail();
                    goo.Id = idnum;
                    goo.Price = Convert.ToInt64(text.Text);
                    der.Goods = goo;
                    ord.AddDetails(der);
                    ordser.Update(ord);
                    OrderbindingSource.ResetBindings(true);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (ordser.GetById(idnum)==null)
            {
                MessageBox.Show("请输入正确订单号");
            }
            ordser.RemoveOrder(idnum);
            OrderbindingSource.ResetBindings(true);
            MessageBox.Show("已删除订单号为" + idnum + "的订单");
        }

        private void sort_Click(object sender, EventArgs e)
        {
            ordser.Sort((o1, o2) => o1.Id.CompareTo(o2.Id));
            OrderbindingSource.ResetBindings(true);
        }

        private void modify_Click(object sender, EventArgs e)
        {
            switch (type)
            {
                case "CustomerName":
                Order ord = ordser.GetById(idnum);
                if (ord == null)
                {
                    MessageBox.Show("请输入正确订单号");
                }
                else
                {
                    Customer cus = new Customer();
                    cus.Name = str;
                    ord.Customer = cus;
                    ordser.Update(ord);
                }
                break;
                case "GoodsName":
                    Order ord1 = (Order)this.OrderbindingSource.Current;
                    if (ord1 == null)
                    {
                        MessageBox.Show("请选定要修改的order");
                    }
                    else {
                        OrderDetail der1 = new OrderDetail();
                        der1 = ord1.Details.FirstOrDefault(o => o.Goods.Id == idnum);
                        if (der1==null)
                        {
                            MessageBox.Show("请输入正确订单号");
                        }
                        else
                        {
                            ord1.Details.Remove(der1);
                            Goods goo = der1.Goods;
                            goo.Name = str;
                            der1.Goods = goo;
                            ord1.Details.Add(der1);
                            ordser.Update(ord1);
                        } 
                    }
                    break;
                case "Quantity":
                    Order ord2 = (Order)this.OrderbindingSource.Current;
                    if (ord2 == null)
                    {
                        MessageBox.Show("请选定要修改的order");
                    }
                    else
                    {
                        OrderDetail der2 = new OrderDetail();
                        der2 = ord2.Details.FirstOrDefault(o => o.Goods.Id == idnum);
                        if (der2 == null)
                        {
                            MessageBox.Show("请输入正确订单号");
                        }
                        else
                        {
                            ord2.Details.Remove(der2);
                            der2.Quantity = Convert.ToInt32(str);
                            ord2.Details.Add(der2);
                            ordser.Update(ord2);
                        }
                    }
                    break;
                default:
                    MessageBox.Show("所选项无法进行查询，请重新选择");
                    break;
            }
            OrderbindingSource.ResetBindings(true);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}