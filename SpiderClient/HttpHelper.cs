using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpiderClient
{
    public class HttpHelper
    {
        public static object obj = new object();
        /// <summary>
        /// 请求网页
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetPageHtml(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                Stream st = response.GetResponseStream();
                StreamReader reader = new StreamReader(st);
                string content = reader.ReadToEnd();
                return content;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url"></param>
        public static void DownloadFile(string url,string path,Action<string> FunSignLog)
        {
            int pos = url.LastIndexOf("/") + 1;
            string fileName = url.Substring(pos);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filePathName = path + "\\" + fileName;
            lock (obj)
            {
                if (File.Exists(filePathName))
                {
                    return;
                }
                try
                {
                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    Stream stream = response.GetResponseStream();

                    var img = Image.FromStream(stream);

                    //排除100*100以下的图片
                    if (img.Width * img.Width >= 100 * 100)
                    {
                        img.Save(filePathName);
                        FunSignLog(string.Format("下载图片：{0}", fileName));
                    }

                    stream.Close();

                }
                catch (Exception ex)
                {
                    FunSignLog(string.Format("图片{0}下载失败", fileName));
                }
            }
        }

    }
}
