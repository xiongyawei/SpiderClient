using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SpiderClient
{
    public class Craw
    {
        private static List<string> visitList = new List<string>();
        private static List<string> visitImgList = new List<string>();

        private string path = string.Empty;
        private Action<string> FunSignLog;
        
        public Craw(string path,Action<string> FunSignLog) {
            this.path = path;
            this.FunSignLog = FunSignLog;
        }

        public void Crawling(string url, string host)
        {
            if (!visitList.Exists(e => e.Equals(url)))
            {
                visitList.Add(url);
                if (string.IsNullOrEmpty(host))
                {
                    host = GetHost(url);
                }
                if (string.IsNullOrEmpty(url) || url.Contains("javascript"))
                {
                    return;
                }
                else
                {
                    if (!url.Contains("http"))
                    {
                        url = host + url;
                    }
                }
                FunSignLog(string.Format("打开网址：{0}", url));

                string html = HttpHelper.GetPageHtml(url,this.FunSignLog);
                if (string.IsNullOrEmpty(html))
                {
                    return;
                }
                Regex regA = new Regex(@"<a[\s]+[^<>]*href=(?:""|')([^<>""']+)(?:""|')[^<>]*>[^<>]+</a>", RegexOptions.IgnoreCase);
                Regex regImg = new Regex(@"<img[\s]+[^<>]*src=(?:""|')([^<>""']+(?:jpg|jpeg|png|gif))(?:""|')[^<>]*>", RegexOptions.IgnoreCase);

                MatchCollection mcImg = regImg.Matches(html);
                foreach (Match item in mcImg)
                {
                    string imgUrl = item.Groups[1].Value;
                    if (!imgUrl.Contains("http"))
                    {
                        imgUrl = host + imgUrl;
                    }

                    //ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object obj)
                    //{
                    //    if (!visitImgList.Exists(l => l.Equals(imgUrl)))
                    //    {
                    //        visitImgList.Add(imgUrl);
                    //    }

                    //}));

                    Task.Run(() =>
                    {
                        if (!visitImgList.Exists(l => l.Equals(imgUrl)))
                        {
                            HttpHelper.DownloadFile(imgUrl, path, this.FunSignLog);
                            visitImgList.Add(imgUrl);

                        }
                    });
                }

                MatchCollection mcA = regA.Matches(html);
                foreach (Match item in mcA)
                {
                    string aUrl = item.Groups[1].Value;
                    //ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object obj)
                    //{
                    //    Crawling(aUrl, host);
                    //}));

                    Task.Run(() =>
                    {
                        Crawling(aUrl, host);
                    });
                }

            }
        }



        private string GetHost(string url)
        {
            Regex reg = new Regex(@"(?:http|https)://[a-z0-9\-\.:]+", RegexOptions.IgnoreCase);
            Match host = reg.Match(url);
            return host.Value;
        }
    }
}
