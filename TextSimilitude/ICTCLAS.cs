using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace TextSimilitude
{
    public struct ResultTerm
    {
        public string Word;         //字符串
        public int POS;             //词性标志
        public string POSStr;       // 词性说明
    }

    enum eCodeType
    {
        CODE_TYPE_UNKNOWN,//type unknown
        CODE_TYPE_ASCII,//ASCII
        CODE_TYPE_GB,//GB2312,GBK,GB10380
        CODE_TYPE_UTF8,//UTF-8
        CODE_TYPE_BIG5//BIG5
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct result_t
    {
        [FieldOffset(0)]
        public int start;
        [FieldOffset(4)]
        public int length;
        [FieldOffset(8),MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] sPos;
        [FieldOffset(16)]
        public int POS_id;
        [FieldOffset(20)]
        public int word_ID;
        [FieldOffset(24)]
        public int word_type;
        [FieldOffset(28)]
        public int weight;
    }

    public class ICTCLAS
    {
        const string path = @"ICTCLAS50.dll";

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "ICTCLAS_Init")]
        private static extern bool ICTCLAS_Init(String sInitDirPath);

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "ICTCLAS_Exit")]
        private static extern bool ICTCLAS_Exit();

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "ICTCLAS_ParagraphProcessAW")]
        private static extern int ICTCLAS_ParagraphProcessAW(String sParagraph, [Out, MarshalAs(UnmanagedType.LPArray)]result_t[] result, eCodeType eCT, int bPOSTagged);

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "ICTCLAS_ParagraphProcessAW")]
        private static extern int ICTCLAS_ParagraphProcessAW_B(byte[] sParagraph, [Out, MarshalAs(UnmanagedType.LPArray)]result_t[] result, eCodeType eCT, bool bPOSTagged);

        //[DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "ICTCLAS_ParagraphProcess")]
        //private static extern int ICTCLAS_ParagraphProcess(String sParagraph, int nPaLen, eCodeType eCt, bool bPOStagged, [Out, MarshalAs(UnmanagedType.LPArray)]String sResult);

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "ICTCLAS_ImportUserDict")]
        private static extern int ICTCLAS_ImportUserDict(byte[] sWord, int nLength, eCodeType eCT);

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "ICTCLAS_ImportUserDictFile")]
        private static extern int ICTCLAS_ImportUserDictFile(String fileName, eCodeType eCT);

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "ICTCLAS_FileProcess")]
        private static extern double ICTCLAS_FileProcess(String sSrcFilename, String sDsnFilename, eCodeType eCt, bool bPOStagged);

        [DllImport(path, CharSet = CharSet.Ansi, EntryPoint = "ICTCLAS_SaveTheUsrDic")]
        private static extern int ICTCLAS_SaveTheUsrDic();

        private static ICTCLAS _instance;
        private List<string> POSList = new List<string>();

        private ICTCLAS(string path)
        {
            if (!ICTCLAS_Init(path))
            {
                throw new Exception("Init ICTCLAS50 failed!");
            }
            initPos(path);
        }

        /// <summary>
        /// 获取ICTCLAS实例
        /// </summary>
        /// <returns></returns>
        public static ICTCLAS GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ICTCLAS(AppDomain.CurrentDomain.BaseDirectory);
            }
            return _instance;
        }

        /// <summary>
        /// 对文本进行分词
        /// </summary>
        /// <param name="str">要分词的字符串</param>
        /// <returns>分词结果列表</returns>
        public List<ResultTerm> Segment(string str)
        {
            result_t[] result = new result_t[str.Length];
            int posStrArrLen = 0;
            result_t r;
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            int nWrdCnt = ICTCLAS_ParagraphProcessAW_B(bytes, result, eCodeType.CODE_TYPE_UTF8, true);
            List<ResultTerm> returnResult = new List<ResultTerm>(nWrdCnt);

            for (int i = 0; i < result.Length; i++)
            {
                r = result[i];

                if (r.length != 0)
                {
                    posStrArrLen =0;
                    for(int l = 0; l<8 ;l++)
                    {
                        if (r.sPos[l]==0 )
                        {
                            posStrArrLen = l;
                            break;
                        }
                    }

                    ResultTerm word = new ResultTerm();
                    word.Word = Encoding.UTF8.GetString(bytes, r.start, r.length);
                    word.POS = r.POS_id;
                    word.POSStr = Encoding.ASCII.GetString(r.sPos, 0, posStrArrLen);
                    returnResult.Add(word);
                }
            }
            result = null;
            return returnResult;
        }

		/// <summary>
		/// 对文本进行分词
		/// </summary>
		/// <param name="bytes">输入的字符串byte数组</param>
		/// <param name="enc">编码方式</param>
		/// <returns>分词结果列表</returns>
        public List<ResultTerm> Segment(byte[] bytes, Encoding enc)
        {
            result_t[] result = new result_t[bytes.Length];
            int posStrArrLen = 0;
            byte[] bys = new byte[bytes.Length];
            int i = 0;
            int nWrdCnt = ICTCLAS_ParagraphProcessAW_B(bytes, result, getCodeType(enc), true);

            List<ResultTerm> returnResult = new List<ResultTerm>(nWrdCnt);

            result_t r;
            //取字符串真实长度:
            byte[] gbbytes = bytes;  // enc.GetBytes(str);

            for (i = 0; i < result.Length; i++)
            {
                r = result[i];

                if (r.length != 0)
                {
                    posStrArrLen = 0;
                    for (int l = 0; l < 8; l++)
                    {
                        if (r.sPos[l] == 0)
                        {
                            posStrArrLen = l;
                            break;
                        }
                    }

                    ResultTerm word = new ResultTerm();
                    word.Word = enc.GetString(gbbytes, r.start, r.length);
                    word.POS = r.POS_id;
                    word.POSStr = Encoding.ASCII.GetString(r.sPos, 0, posStrArrLen);
                    returnResult.Add(word);
                }
            }
            result = null;

            return returnResult;
        }

		/// <summary>
		/// 导入用户词典.
		/// 关于格式
		///   UTF-8编码的文件,请使用BOM标识符
		/// 关于繁体汉字:
		///   在UTF-8模式下可直接导入繁体汉字,
		///   在GBK编码下,请导入繁体词对应的简体汉字 如需导入"韓國媒體" 请输入"韩国媒体"
		/// 注:[Issue]目前ICTCLAS 5.0 中.只能保存一份用户词典,添加用户词典后,之前的用户词典都丢失了.
		///    建议使用文件导入用户词典,用户需自己维护一份完整的用户词典,每次新增后.导入完整用户词典.
		/// </summary>
		/// <param name="filename">要导入的文件名</param>
		/// <param name="enc">文件编码</param>
		/// <returns>导入的用户词数量</returns>
        public int ImportUserDictFile(string filename, Encoding enc)
        {
            // 导入用户词典文件
            int result = ICTCLAS_ImportUserDictFile(filename, getCodeType(enc));

            // 保存用户词典
            ICTCLAS_SaveTheUsrDic();
            return result;
        }

        /// <summary>
        /// 添加用户词典(此方法停用)
		/// 注:[Issue]目前ICTCLAS 5.0 中.只能保存一份用户词典,添加用户词典后,之前的用户词典都丢失了.
		/// 建议使用文件导入用户词典,用户需自己维护一份完整的用户词典,每次新增后.导入完整用户词典.
        /// </summary>
        /// <param name="word">要添加的用户词</param>
        /// <param name="pos">词性</param>
        public void AddUserDict(string word)
        {
            if (word.Length > 0)
            {
                // string term = string.Format("{0}", word, pos);
                byte[] bytes = Encoding.UTF8.GetBytes(word);
                // 手工添加用户词典 格式:[词][@@][词性]
                ICTCLAS_ImportUserDict(bytes, bytes.Length, eCodeType.CODE_TYPE_UTF8);

                // 保存用户词典
                ICTCLAS_SaveTheUsrDic();
            }
            else
            {
                throw new ArgumentException("新词长度不能为0!");
            }
        }

		/// <summary>
		/// 保存导入的用户词典
		/// 注:[Issue]目前ICTCLAS 5.0 中.只能保存一份用户词典,添加用户词典后,之前的用户词典都丢失了.
		///    建议使用文件导入用户词典,用户需自己维护一份完整的用户词典,每次新增后.导入完整用户词典.
		/// </summary>
        public void SaveUserDict()
        {
            ICTCLAS_SaveTheUsrDic();
        }

		/// <summary>
		/// 获取编码类型
		/// </summary>
		/// <param name="enc">输入的编码方式</param>
		/// <returns>ICTCLAS50编码类型</returns>
        private eCodeType getCodeType(Encoding enc)
        {
            if (enc.BodyName.StartsWith("gb"))
                return eCodeType.CODE_TYPE_GB;
            else if (enc.BodyName == "big5")
                return eCodeType.CODE_TYPE_BIG5;
            else if (enc.BodyName == "utf-8")
                return eCodeType.CODE_TYPE_UTF8;
            return eCodeType.CODE_TYPE_UNKNOWN;
        }

		/// <summary>
		/// 初始化词性标注路径.(此方法停用)
		/// </summary>
		/// <param name="path">要初始化的词性标注路径.</param>
        private void initPos(string path)
        {
            string mapPath = path;
            if (path == null)
                mapPath = @".\data\ICTPOS.map";
            else
                mapPath = path + @"\data\ICTPOS.map";
            StreamReader reader = new StreamReader(mapPath);
            string line = reader.ReadLine();
            while (line != null)
            {
                POSList.Add(line);
                line = reader.ReadLine();
            }
            reader.Close();
        }

		/// <summary>
		/// 获得词性 (此方法停用)
		/// </summary>
		/// <param name="pos"></param>
		/// <returns></returns>
        public string GetPos(int pos)
        {
            if (pos < POSList.Count)
            {
                return POSList[pos];
            }
            else
                return string.Empty;
        }

        ~ICTCLAS()
        {
            Dispose();
        }
    
        #region IDisposable 成员
        public void  Dispose()
        {
            ICTCLAS_Exit();
        }
        #endregion
    }
}
