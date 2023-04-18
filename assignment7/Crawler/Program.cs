using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Crawlering
{
    class Crawler
    {
        private Hashtable urls = new Hashtable();//无序的
        //用dictionary进行俩个类型的连接
        //用事件，在解析成功或失败时，报出信息
        private int count = 0;
        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();
            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl = args[0];
            myCrawler.urls.Add(startUrl, false);//加入初始页面
            new Thread(myCrawler.Crawl).Start();
        }

        private void Crawl()
        {
            Console.WriteLine("开始爬行了.... ");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }

                if (current == null || count > 10) break;
                string html = DownLoad(current); // 下载全网页文本
                urls[current] = true;
                count++;
                //if(Regex.IsMatch(current, @".(html|htm|aspx|php|jsp)")==true)
                Parse(html,current);//解析,并加入新的链接
                if (Regex.IsMatch(current, @".(html|htm|aspx|php|jsp)") == true)
                {
                    Console.WriteLine("爬行" + current + "页面!");
                    Console.WriteLine("爬行结束");
                }
            }
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        private void Parse(string html,string current)
        {
            string strRef = @"(href|HREF)\s*=\s*[""'](?<url>[^""'#>]+)[""']";
            //string urlParseRegex = @"^(?<site>(?<protocal>https?)://(?<host>[\w\d.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#?]*)";
            //出现了href，[]表示空格，等同于\s,[""']表示单个双引号和单引号，在这里表示俩对引号之间，非“‘#>的内容
            MatchCollection matches = new Regex(strRef).Matches(html);
            Uri baseurl = new Uri(current);
            foreach (Match match in matches)
            {
                string relatedurl = match.Groups["url"].Value;
                //转绝对路径
                Uri absolutedurl = new Uri(baseurl,relatedurl);
                //Match linkUrlMatch = Regex.Match(absolutedurl.ToString(), urlParseRegex);
                if (absolutedurl.ToString().Length == 0) continue;
                if (urls[absolutedurl.ToString()] == null) urls[absolutedurl.ToString()] = false;
            }
        }
    }
}
