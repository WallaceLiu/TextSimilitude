using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextSimilitude
{
    public class BaikeEntry
    {
        public string siteName;     //网站名字
        public string entryName;    //词条名称
        public string url;          //词条网址
        public string sourceHTML;   //完整的网页源文件
        public string preview;      //网页预览的源文件（去除js,jpg,gif)
        public string title;        //网页标题
        public string text;         //网页正文
        public string allWordFreq;  //所有词项及其词频
        public int    sameWordNum;  //相同词项的个数
        public string textTmp;  //测试文本

        //词项列表和字典（筛选条件：词频和词项长度都大于1）
        public List<WordFreq>          wordList;  //根据词频排序后的列表
        public Dictionary<string, int> wordDic;   //字典(筛选后的）

        //错误信息
        public bool   errExist;
        public string errMsg;
        
        private BaikeEntry()
        {
        }

        public BaikeEntry(string newSiteName, string newEntryName)
        {
            siteName     = newSiteName;
            entryName    = newEntryName;
            url          = "";
            sourceHTML   = "";
            preview      = "";
            title        = "";  
            text         = "";      
            allWordFreq  = "";
            sameWordNum  = 0;

            wordList     = new List<WordFreq>();
            wordDic      = new Dictionary<string, int>();

            errExist     = true;
            errMsg       = "发生错误";
        }

    }

    //每个单词的名字和词频
    public class WordFreq
    {
        public string name;
        public int freq;

        private WordFreq()
        {
        }

        public WordFreq(string n, int f)
        {
            name = n;
            freq = f;
        }
    }

}