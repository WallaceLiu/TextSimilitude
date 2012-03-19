using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TextSimilitude
{
    public partial class TextSimilitudeForm : Form
    {
        public TextSimilitudeForm()
        {
            InitializeComponent();
            AllTextReset();
        }
    
        private void buttonCompare_Click(object sender, EventArgs e)
        {
            string termName = Regex.Replace(textBoxTermName.Text, @"(?is)\s*", "");
            if (termName.Length == 0)
                MessageBox.Show("请输入词条名称", "提示");
            else
            {
                AllTextReset();
                BaikeEntry baidu = new BaikeEntry("baidu", textBoxTermName.Text);
                BaikeEntry hudong = new BaikeEntry("hudong", textBoxTermName.Text);
                GetBaiduDetails(baidu);
                GetHudongDetails(hudong);
                if (!baidu.errExist && !hudong.errExist)
                    ComputeSimilitude(baidu, hudong);

                //webBrowserBaidu.DocumentText = baidu.preview;
                //webBrowserHudong.DocumentText = hudong.preview;

                //测试
                
                //richTextBoxBaiduText.Text = baidu.textTmp;
                //richTextBoxHudongText.Text = hudong.textTmp;
            }
        }

        private void AllTextReset()
        {
            textBoxBaidu.Text = "";
            richTextBoxBaiduText.Text = "";
            richTextBoxBaiduTermFreq.Text = "";
            labelBaiduTextNum.Text = "";
            labelBaiduWordNum.Text = "";

            textBoxHudong.Text = "";
            richTextBoxHudongText.Text = "";
            richTextBoxHudongTermFreq.Text = "";
            labelHudongTextNum.Text = "";
            labelHudongWordNum.Text = "";

            labelSimilitude.Text = "";
            labelSameWordNum.Text = "";
        }

        private int GetBaiduDetails(BaikeEntry baidu)
        {
            /************************************************************************/
            /* 1搜索百科词条                                                        */
            /************************************************************************/
            SourceHTML.GetBaidu(baidu);
            if (baidu.errExist)
            {
                textBoxBaidu.Text = baidu.errMsg;
                return -1;
            }
            textBoxBaidu.Text = baidu.url;
            baidu.errExist = true;

            /************************************************************************/
            /* 2提取网页正文                                                        */
            /************************************************************************/
            TextExtract baiduText = new TextExtract(baidu);
            if (baidu.errExist)
            {
                textBoxBaidu.Text = baidu.errMsg;
                return -1;
            }
            richTextBoxBaiduText.Text = baidu.text;
            labelBaiduTextNum.Text = baidu.text.Length.ToString();

            /************************************************************************/
            /* 3分词                                                                */
            /************************************************************************/
            TermFrequence baiduTermFreq = new TermFrequence(baidu);
            richTextBoxBaiduTermFreq.Text = baidu.allWordFreq;
            labelBaiduWordNum.Text = baidu.wordDic.Count.ToString();

            return 0;
        }

        private int GetHudongDetails(BaikeEntry hudong)
        {
            /************************************************************************/
            /* 1搜索百科词条                                                        */
            /************************************************************************/
            SourceHTML.GetHudong(hudong);
            if (hudong.errExist)
            {
                textBoxHudong.Text = hudong.errMsg;
                return -1;
            }
            textBoxHudong.Text = hudong.url;
            hudong.errExist = true;

            /************************************************************************/
            /* 2提取网页正文                                                        */
            /************************************************************************/
            TextExtract HudongText = new TextExtract(hudong);
            if (hudong.errExist)
            {
                textBoxHudong.Text = hudong.errMsg;
                return -1;
            }
            richTextBoxHudongText.Text = hudong.text;
            labelHudongTextNum.Text = hudong.text.Length.ToString();

            /************************************************************************/
            /* 3分词                                                                */
            /************************************************************************/
            TermFrequence HudongTermFreq = new TermFrequence(hudong);
            richTextBoxHudongTermFreq.Text = hudong.allWordFreq;
            labelHudongWordNum.Text = hudong.wordDic.Count.ToString();

            return 0;
        }

        private void ComputeSimilitude(BaikeEntry baidu, BaikeEntry hudong)
        {
            SimilitudeVSM simCos = new SimilitudeVSM(baidu, hudong);
            labelSimilitude.Text = simCos.similitude.ToString("F5");
            labelSameWordNum.Text = baidu.sameWordNum.ToString();
        }

    }
}
