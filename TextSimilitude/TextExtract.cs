using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace TextSimilitude
{
    class TextExtract
    {
        private const int blockHeight = 3;    // 行快大小
        private const int threshold   = 150;  // 阈值

        private BaikeEntry baikeEntry;
        private int textStart;       // 网页正文开始行数
        private int textEnd;         // 网页正文结束行数
        private string textBody;     // 提取到的<body>标签内的内容
        private string[] lines;      // 按行存储textBody的内容
        private List<int> blockLen;  // 每个行快的总字数

        // 隐藏默认构造函数
        private TextExtract()
        {
        }

        // 构造函数,参数为HTML源码
        public TextExtract(BaikeEntry newBaikeEntry)
        {
            baikeEntry = newBaikeEntry;
            textStart  = 0;
            textEnd    = 0;
            textBody   = "";
            blockLen   = new List<int>();

            extract();
        }

        // 提取网页正文
        public void extract()
        {
            extractTitle();  // 提取标题
            extractBody();   // 提取<body>标签中的内容
            removeTags();    // 去除textBody中的HTML标签
            optimizeBody();
            extractText();   // 提取网页正文
            extractPreview();  //提取预览页面的HTML代码

            baikeEntry.textTmp = textBody;
        }

        private void extractTitle()
        {
            string pattern = @"(?is)<title>(.*?)</title>";
            Match m = Regex.Match(baikeEntry.sourceHTML, pattern);
            if (m.Success)
            {
                baikeEntry.title = m.Groups[1].Value;
                baikeEntry.title = Regex.Replace(baikeEntry.title, @"(?is)\s*", "");
            }
        }

        private void extractBody()
        {
            string pattern = @"(?is)<body.*?</body>";
            Match m = Regex.Match(baikeEntry.sourceHTML, pattern);
            if (m.Success)
                textBody = m.ToString();
        }

        private void removeTags()
        {
            string docType = @"(?is)<!DOCTYPE.*?>";
            string comment = @"(?is)<!--.*?-->";
            string js = @"(?is)<script.*?>.*?</script>";
            string css = @"(?is)<style.*?>.*?</style>";
            string specialChar = @"&.{2,8};|&#.{2,8};";
            string otherTag = @"(?is)<.*?>";

            textBody = Regex.Replace(textBody, docType, "");
            textBody = Regex.Replace(textBody, comment, "");
            textBody = Regex.Replace(textBody, js, "");
            textBody = Regex.Replace(textBody, css, "");
            textBody = Regex.Replace(textBody, specialChar, "");
            textBody = Regex.Replace(textBody, otherTag, "");
        }

        private void optimizeBody()
        {
            int begin = 0;
            int end   = 0;

            if (baikeEntry.siteName == "baidu")
            {
                begin = textBody.IndexOf("百科名片");
                end = textBody.IndexOf("词条图册更多图册");
            }
            else
            {
                begin = textBody.IndexOf("本词条由");
                begin = textBody.IndexOf("目录", begin>0?begin:0);
                end = textBody.LastIndexOf("上传图片");
                end = textBody.LastIndexOf("附图", end>0?end:0);
            }
            if (begin < end && begin>0 && end >0)
                textBody = textBody.Substring(begin, end - begin);
        }

        private void extractText()
        {
            // 统计去除空白字符后每个行块所含总字数
            lines = textBody.Split('\n');
            for (int i = 0; i < lines.Length; i++)
                lines[i] = Regex.Replace(lines[i], @"(?is)\s*", "");

            // 去除上下紧邻行为空,且该行字数小于30的行
            for (int i = 1; i < lines.Length - 1; i++)
            {
                if (lines[i].Length < 30 && lines[i-1].Length == 0 && lines[i+1].Length == 0)
                    lines[i] = "";
            }

            for (int i = 0; i < lines.Length - blockHeight; i++)
            {
                int len = 0;
                for (int j = 0; j < blockHeight; j++)
                    len += lines[i + j].Length;
                blockLen.Add(len);
            }

            // 寻找正文起始和结束行,并拼接
            textStart = FindTextStart(0);

            if (textStart == 0)
                baikeEntry.errMsg = "未能提取到正文！";
            else
            {
                while (textEnd < lines.Length)
                {
                    textEnd = FindTextEnd(textStart);
                    baikeEntry.text += GetText();
                    textStart = FindTextStart(textEnd);
                    if (textStart == 0)
                        break;
                    textEnd = textStart;
                }

            }
        }

        private void extractPreview()
        {
            baikeEntry.preview = Regex.Replace(baikeEntry.sourceHTML, @"(?is)<[^>]*jpg.*?>", "");
            baikeEntry.preview = Regex.Replace(baikeEntry.preview, @"(?is)<[^>]*gif.*?>", "");
            baikeEntry.preview = Regex.Replace(baikeEntry.preview, @"(?is)<[^>]*js.*?>", "");
        }

        // 如果一个行块大小超过阈值,且紧跟其后的1个行块大小都不为0,则此行块为起始点
        private int FindTextStart(int index)
        {
            for (int i = index; i < blockLen.Count - 1; i++)
            {
                if (blockLen[i] > threshold
                    && blockLen[i + 1] > 0)
                    return i;
            }
            return 0;
        }

        // 起始点之后,如果2个连续行块大小都为0,则认为其是结束点
        private int FindTextEnd(int index)
        {
            for (int i = index + 1; i < blockLen.Count - 1; i++)
            {
                if (blockLen[i] == 0 && blockLen[i + 1] == 0)
                    return i;
            }
            return lines.Length - 1;
        }

        private string GetText()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = textStart; i < textEnd; i++)
            {
                if (lines[i].Length != 0)
                    sb.Append(lines[i]).Append("\n\n");
            }
            baikeEntry.errExist = false;
            return sb.ToString();
        }
    }
}
