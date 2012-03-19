using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace TextSimilitude
{
    public struct ResultTerm
    {
        public string Word;         //�ַ���
        public int POS;             //���Ա�־
        public string POSStr;       // ����˵��
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
        /// ��ȡICTCLASʵ��
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
        /// ���ı����зִ�
        /// </summary>
        /// <param name="str">Ҫ�ִʵ��ַ���</param>
        /// <returns>�ִʽ���б�</returns>
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
		/// ���ı����зִ�
		/// </summary>
		/// <param name="bytes">������ַ���byte����</param>
		/// <param name="enc">���뷽ʽ</param>
		/// <returns>�ִʽ���б�</returns>
        public List<ResultTerm> Segment(byte[] bytes, Encoding enc)
        {
            result_t[] result = new result_t[bytes.Length];
            int posStrArrLen = 0;
            byte[] bys = new byte[bytes.Length];
            int i = 0;
            int nWrdCnt = ICTCLAS_ParagraphProcessAW_B(bytes, result, getCodeType(enc), true);

            List<ResultTerm> returnResult = new List<ResultTerm>(nWrdCnt);

            result_t r;
            //ȡ�ַ�����ʵ����:
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
		/// �����û��ʵ�.
		/// ���ڸ�ʽ
		///   UTF-8������ļ�,��ʹ��BOM��ʶ��
		/// ���ڷ��庺��:
		///   ��UTF-8ģʽ�¿�ֱ�ӵ��뷱�庺��,
		///   ��GBK������,�뵼�뷱��ʶ�Ӧ�ļ��庺�� ���赼��"�n��ý�w" ������"����ý��"
		/// ע:[Issue]ĿǰICTCLAS 5.0 ��.ֻ�ܱ���һ���û��ʵ�,����û��ʵ��,֮ǰ���û��ʵ䶼��ʧ��.
		///    ����ʹ���ļ������û��ʵ�,�û����Լ�ά��һ���������û��ʵ�,ÿ��������.���������û��ʵ�.
		/// </summary>
		/// <param name="filename">Ҫ������ļ���</param>
		/// <param name="enc">�ļ�����</param>
		/// <returns>������û�������</returns>
        public int ImportUserDictFile(string filename, Encoding enc)
        {
            // �����û��ʵ��ļ�
            int result = ICTCLAS_ImportUserDictFile(filename, getCodeType(enc));

            // �����û��ʵ�
            ICTCLAS_SaveTheUsrDic();
            return result;
        }

        /// <summary>
        /// ����û��ʵ�(�˷���ͣ��)
		/// ע:[Issue]ĿǰICTCLAS 5.0 ��.ֻ�ܱ���һ���û��ʵ�,����û��ʵ��,֮ǰ���û��ʵ䶼��ʧ��.
		/// ����ʹ���ļ������û��ʵ�,�û����Լ�ά��һ���������û��ʵ�,ÿ��������.���������û��ʵ�.
        /// </summary>
        /// <param name="word">Ҫ��ӵ��û���</param>
        /// <param name="pos">����</param>
        public void AddUserDict(string word)
        {
            if (word.Length > 0)
            {
                // string term = string.Format("{0}", word, pos);
                byte[] bytes = Encoding.UTF8.GetBytes(word);
                // �ֹ�����û��ʵ� ��ʽ:[��][@@][����]
                ICTCLAS_ImportUserDict(bytes, bytes.Length, eCodeType.CODE_TYPE_UTF8);

                // �����û��ʵ�
                ICTCLAS_SaveTheUsrDic();
            }
            else
            {
                throw new ArgumentException("�´ʳ��Ȳ���Ϊ0!");
            }
        }

		/// <summary>
		/// ���浼����û��ʵ�
		/// ע:[Issue]ĿǰICTCLAS 5.0 ��.ֻ�ܱ���һ���û��ʵ�,����û��ʵ��,֮ǰ���û��ʵ䶼��ʧ��.
		///    ����ʹ���ļ������û��ʵ�,�û����Լ�ά��һ���������û��ʵ�,ÿ��������.���������û��ʵ�.
		/// </summary>
        public void SaveUserDict()
        {
            ICTCLAS_SaveTheUsrDic();
        }

		/// <summary>
		/// ��ȡ��������
		/// </summary>
		/// <param name="enc">����ı��뷽ʽ</param>
		/// <returns>ICTCLAS50��������</returns>
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
		/// ��ʼ�����Ա�ע·��.(�˷���ͣ��)
		/// </summary>
		/// <param name="path">Ҫ��ʼ���Ĵ��Ա�ע·��.</param>
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
		/// ��ô��� (�˷���ͣ��)
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
    
        #region IDisposable ��Ա
        public void  Dispose()
        {
            ICTCLAS_Exit();
        }
        #endregion
    }
}
