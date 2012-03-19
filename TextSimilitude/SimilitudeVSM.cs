using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextSimilitude
{
    class SimilitudeVSM
    {
        private BaikeEntry entryA;
        private BaikeEntry entryB;
        private long innerProduct;
        private double normA;
        private double normB;

        public double similitude;

        private SimilitudeVSM()
        {
        }

        public SimilitudeVSM(BaikeEntry A, BaikeEntry B)
        {
            entryA = A;
            entryB = B;
            innerProduct = 0;
            normA = normB = 0.0;
            similitude = 0.0;

            ComputeCosine();
        }

        public void ComputeCosine()
        {
            foreach (KeyValuePair<string, int> dic in entryA.wordDic)
            {
                if (entryB.wordDic.ContainsKey(dic.Key))
                {
                    innerProduct += dic.Value * entryB.wordDic[dic.Key];
                    entryA.sameWordNum++;
                }
            }

            normA = Math.Sqrt(entryA.wordDic.Values.Aggregate<int, int>(0, (a, b) => a + b * b));
            normB = Math.Sqrt(entryB.wordDic.Values.Aggregate<int, int>(0, (a, b) => a + b * b));

            similitude = innerProduct / normA / normB;
        }


    }

}
