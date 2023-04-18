using System.Web;

namespace CrawlerForm
{
    public partial class Form1 : Form
    {

        public Crawler crawler = new Crawler();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = resultBindingSource;
            crawler.Downloaded += Crawler_PageDownloaded;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Crawler_PageDownloaded(Crawler crawler, string url, string info)
        {
            var pageInfo = new
            {
                Index = resultBindingSource.Count + 1,
                URL = url,
                Status = info
            };
            Action action = () => { resultBindingSource.Add(pageInfo); };
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string startUrl = textBox1.Text;
            crawler.urls.Add(startUrl, false);//加入初始页面
            new Thread(crawler.Crawl).Start();
        }
    }
}