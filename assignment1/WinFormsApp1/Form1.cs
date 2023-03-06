namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int operat = 0;
        public void oper1_Click(object sender, EventArgs e)
        {
            operat = 1;
        }
        public void oper2_Click_1(object sender, EventArgs e)
        {
            operat = 2;
        }
        public void oper3_Click_1(object sender, EventArgs e)
        {
            operat = 3;
        }
        public void oper4_Click_1(object sender, EventArgs e)
        {
            operat = 4;
        }
        public void calculator_Click(object sender, EventArgs e)
        {
            double n1 = Convert.ToInt32(textBox1.Text);
            double n2 = Convert.ToInt32(textBox2.Text);

            switch (operat)
            {
                case 0:
                    MessageBox.Show("尚未输入符号");
                    break;
                case 1:
                    MessageBox.Show("结果为" + (n1 + n2));
                    break;
                case 2:
                    MessageBox.Show("结果为" + (n1 - n2));
                    break;
                case 3:
                    MessageBox.Show("结果为" + (n1 * n2));
                    break;
                case 4:
                    MessageBox.Show("结果为" + (n1 / n2));
                    break;
                default:
                    break;

            }
        }
    }
}