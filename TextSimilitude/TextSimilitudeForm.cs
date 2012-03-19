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
                AllTextReset();   //清除上一次查询的信息
                BaikeEntry baidu  = new BaikeEntry("baidu", termName);
                BaikeEntry hudong = new BaikeEntry("hudong", termName);

                GetBaiduDetails(baidu);
                GetHudongDetails(hudong);

                if (!baidu.errExist && !hudong.errExist)
                    ComputeSimilitude(baidu, hudong);

                if (checkBoxPreview.Checked)
                {
                    webBrowserBaidu.DocumentText  = baidu.preview;
                    webBrowserHudong.DocumentText = hudong.preview;
                }
                

                /*********************  测试  *****************************/
                //richTextBoxBaiduText.Text  = baidu.preview;
                //richTextBoxHudongText.Text = hudong.preview;
            }

        }

        //清空所有文本控件的内容 
        private void AllTextReset()
        {
            //清除百度文本控件内容
            textBoxBaidu.Text             = "";
            richTextBoxBaiduText.Text     = "";
            richTextBoxBaiduTermFreq.Text = "";
            labelBaiduTextNum.Text        = "";
            labelBaiduWordNum.Text        = "";

            //清除互动文本控件内容
            textBoxHudong.Text             = "";
            richTextBoxHudongText.Text     = "";
            richTextBoxHudongTermFreq.Text = "";
            labelHudongTextNum.Text        = "";
            labelHudongWordNum.Text        = "";

            labelSimilitude.Text  = "";
            labelSameWordNum.Text = "";
        }

        private void GetBaiduDetails(BaikeEntry baidu)
        {
            /************************************************************************/
            /* 1.搜索百科词条
            /*    errExist：此处用来判断词条是否存在,SourceHTML会修改其值
            /************************************************************************/
            SourceHTML.GetBaidu(baidu);
            if (baidu.errExist)
            {
                textBoxBaidu.Text = baidu.errMsg;
                return;
            }
            textBoxBaidu.Text = baidu.url;
            baidu.errExist    = true;

            /************************************************************************/
            /* 2.提取网页正文            
             *    errExist：此处用来判断是否正确提取到正文
            /************************************************************************/
            TextExtract baiduText = new TextExtract(baidu);
            if (baidu.errExist)
            {
                textBoxBaidu.Text = baidu.url + " (" + baidu.errMsg + ")";
                return;
            }
            richTextBoxBaiduText.Text = baidu.text;
            labelBaiduTextNum.Text    = baidu.text.Length.ToString();

            /************************************************************************/
            /* 3.分词                                                                */
            /************************************************************************/
            TermFrequence baiduTermFreq   = new TermFrequence(baidu);
            richTextBoxBaiduTermFreq.Text = baidu.allWordFreq;
            labelBaiduWordNum.Text        = baidu.wordDic.Count.ToString();

        }

        private void GetHudongDetails(BaikeEntry hudong)
        {
            /************************************************************************/
            /* 1.搜索百科词条       
             *    errExist：此处用来判断词条是否存在,SourceHTML会修改其值
            /************************************************************************/
            SourceHTML.GetHudong(hudong);
            if (hudong.errExist)
            {
                textBoxHudong.Text = hudong.errMsg;
                return;
            }
            textBoxHudong.Text = hudong.url;
            hudong.errExist    = true;

            /************************************************************************/
            /* 2.提取网页正文          
             *    errExist：此处用来判断是否正确提取到正文
            /************************************************************************/
            TextExtract HudongText = new TextExtract(hudong);
            if (hudong.errExist)
            {
                textBoxHudong.Text = hudong.url + " (" + hudong.errMsg + ")";
                return;
            }
            richTextBoxHudongText.Text = hudong.text;
            labelHudongTextNum.Text    = hudong.text.Length.ToString();

            /************************************************************************/
            /* 3.分词                                                                */
            /************************************************************************/
            TermFrequence HudongTermFreq   = new TermFrequence(hudong);
            richTextBoxHudongTermFreq.Text = hudong.allWordFreq;
            labelHudongWordNum.Text        = hudong.wordDic.Count.ToString();

        }

        private void ComputeSimilitude(BaikeEntry baidu, BaikeEntry hudong)
        {
            SimilitudeVSM simCos  = new SimilitudeVSM(baidu, hudong);
            labelSimilitude.Text  = simCos.similitude.ToString("F5");
            labelSameWordNum.Text = baidu.sameWordNum.ToString();
        }

    }
}
