using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TextSimilitude
{
    class TermFrequence
    {
        public string[] stopWords;   //停用词表

        public BaikeEntry baikeEntry;

        private TermFrequence()
        {
        }

        public TermFrequence(BaikeEntry newBaikeEntry)
        {
            baikeEntry = newBaikeEntry;

            GetTermDic();
            RemoveStopWords();
            GetTermList();  //只保留词频大于1且词项字数大于1的词项
            UpdateTermDic();
            GetTermShow();
        }

        private void GetTermDic()
        {
            ICTCLAS clas = ICTCLAS.GetInstance();
            List<ResultTerm> terms = clas.Segment(baikeEntry.text);

            baikeEntry.wordDic.Clear();
            foreach (ResultTerm term in terms)
            {
                if (baikeEntry.wordDic.ContainsKey(term.Word))
                    baikeEntry.wordDic[term.Word] += 1;
                else
                    baikeEntry.wordDic.Add(term.Word, 1);
            }
        }

        private void RemoveStopWords()
        {
            //获取停用词表
            StreamReader sr = new StreamReader("stopWords.txt", Encoding.UTF8);
            string tmp = sr.ReadToEnd();
            stopWords = Regex.Split(tmp, @"\r\n");

            //去除停用词
            foreach (string str in stopWords)
            {
                if (baikeEntry.wordDic.ContainsKey(str))
                    baikeEntry.wordDic.Remove(str);
            }

            //去除其他字符
            Dictionary<string, int> newDic = new Dictionary<string, int>();
            foreach (KeyValuePair<string, int> dic in baikeEntry.wordDic)
            {
                if (Regex.Replace(dic.Key, @"(?is)\s*", "").Length != 0)
                {
                    newDic.Add(dic.Key, dic.Value);
                }
                
            }
            baikeEntry.wordDic = newDic;
        }

        private void GetTermList()
        {
            baikeEntry.wordList.Clear();
    
            foreach (KeyValuePair<string, int> dic in baikeEntry.wordDic)
            {
                if (dic.Value > 1 && dic.Key.Length > 1)
                    baikeEntry.wordList.Add(new WordFreq(dic.Key, dic.Value));
            }
            baikeEntry.wordList.Sort((a, b) => { return b.freq - a.freq; });
        }

        private void UpdateTermDic()
        {
            baikeEntry.wordDic.Clear();
            foreach (WordFreq t in baikeEntry.wordList)
                baikeEntry.wordDic.Add(t.name, t.freq);
        }

        private void GetTermShow()
        {
            foreach (WordFreq tf in baikeEntry.wordList)
            {
                baikeEntry.allWordFreq += string.Format("{0}:{1}\n", tf.name, tf.freq);
            }
        }
    }
}
