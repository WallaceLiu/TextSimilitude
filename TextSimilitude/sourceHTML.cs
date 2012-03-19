using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;

namespace TextSimilitude
{
    /************************************************************************/
    /* GetBaidu 和 GetHudong
     *   如果成功读取到页面，BaikeEntry.errExist设置为false（初始值为true)  
    /************************************************************************/
    public static class SourceHTML
    {
        private static Encoding GB18030 = Encoding.GetEncoding("GB18030");   // GB18030兼容GBK和GB2312
        private static Encoding UTF8    = Encoding.UTF8;

        //查询百度百科词条时需跳转一次才能到达词条页面
        public static void GetBaidu(BaikeEntry baidu)
        {
            string url     = "http://baike.baidu.com/searchword/?word=" + HttpUtility.UrlEncode(baidu.entryName, GB18030) + "&pic=1";
            string content = GetUrlHTML(url, GB18030);

            if (content.Length != 0 && !content.Contains("210.77.16.29"))
            {
                //提取词条的真实url
                string pattern = @"(?is)view.*?htm";
                Match m = Regex.Match(content, pattern);
                if (m.Success)
                {
                    url = "http://baike.baidu.com/" + m.ToString();
                    baidu.url = url;
                    baidu.sourceHTML = GetUrlHTML(url, GB18030);    //百度百科网页编码为GB2312
                    if (baidu.sourceHTML.Length != 0)
                        baidu.errExist= false;
                    else
                        baidu.errMsg = "百度百科词条页面读取失败!";
                }
                else
                    baidu.errMsg = "百度百科中不存在该词条!";
            }
            else
                baidu.errMsg = "不能访问百度百科，请检查网络!";
        }

        public static void GetHudong(BaikeEntry hudong)
        {
            string url        = "http://www.hudong.com/wiki/" + HttpUtility.UrlEncode(hudong.entryName, UTF8);
            hudong.url        = url;
            hudong.sourceHTML = GetUrlHTML(url, UTF8);  //互动百科网页编码为UTF8

            if (hudong.sourceHTML.Length != 0 && !hudong.sourceHTML.Contains("210.77.16.29"))
            {
                bool entryNotExist = hudong.sourceHTML.Contains("您要访问的页面不存在")
                    || hudong.sourceHTML.Contains("尚未收录词条")
                    || hudong.sourceHTML.Contains("词条名字为空");

                if (!entryNotExist)
                    hudong.errExist = false;
                else
                    hudong.errMsg = "互动百科中不存在该词条!";
            }
            else
                hudong.errMsg = "不能访问互动百科，请检查网络!";
        }

        private static string GetUrlHTML(string url, Encoding en)
        {
            //数据包头部
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method         = "GET";
            request.Accept         = "*/*";
            request.UserAgent      = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1)";

            //服务器返回的内容
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader sr = new StreamReader(response.GetResponseStream(), en);
                return sr.ReadToEnd();
            }

            return "";
        }

    }

}
