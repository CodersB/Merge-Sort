using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class MergeSort
    {
        public int TotalCalls
        { get; set; }

        List<int> frequentList = new List<int>();
        Dictionary<int, int> dictFreq = new Dictionary<int, int>();

        public int IdentifyFrequency(int[] arr)
        {
            int n = arr.Length;
            int k = 2; //arr.Length;

            for (int i = 0; i < n; i++)
                arr[arr[i] % k] += k;

            // Find index of the maximum repeating element
            int max = arr[0], result = 0;
            for (int i = 1; i < n; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    result = i;
                }
            }

            return result;

            //return DivideAndConquer(inputArr);
        }

        public int[] DivideAndConquer(int[] inputArr)
        {
            TotalCalls++;

            if (inputArr.Length <= 1)
                return inputArr;

            int midPos = inputArr.Length / 2;

            int[] leftArr = new int[midPos];

            int rightLen = inputArr.Length - midPos;
            int[] rightArr = new int[rightLen];

            Array.Copy(inputArr, 0, leftArr, 0, midPos);
            Array.Copy(inputArr, midPos, rightArr, 0, rightLen);
            
            Console.WriteLine(string.Format("Print : {0} | {1}", PrintArray(leftArr), PrintArray(rightArr)));

            //if (leftArr.Length > 1)
            leftArr = DivideAndConquer(leftArr);

            //if (rightArr.Length > 1)
            rightArr = DivideAndConquer(rightArr);

            //Console.WriteLine("Sort");
            var r = SortArray(leftArr, rightArr);

            //var r = FindRepeatedNumbers(leftArr, rightArr);

            //if (leftArr.Length > 0 && rightArr.Length > 0)
            //    if (leftArr[0] == rightArr[0] && (!frequentList.Contains(leftArr[0])))
            //        frequentList.Add(leftArr[0]);

            Console.WriteLine("Result : " + PrintArray(r));

            return r;
        }

        public int[] SortArray(int[] left, int[] right)
        {
            Console.WriteLine(string.Format("Sort : L - {0}, R - {1}.", PrintArray(left), PrintArray(right)));
            var tempL = left.ToList();
            var tempR = right.ToList();
        
            List<int> sortList = new List<int>();

            while (tempL.Count > 0 || tempR.Count > 0)
            {
                if (tempL.Count > 0 && tempR.Count > 0)
                {
                    if (tempL[0] == tempR[0] && (!frequentList.Contains(tempL[0])))
                        frequentList.Add(tempL[0]);

                    if (tempL[0] <= tempR[0])
                    {
                        sortList.Add(tempL[0]);
                        

                        tempL.RemoveAt(0);
                    }                    
                    else
                    {
                        sortList.Add(tempR[0]);
                        tempR.RemoveAt(0);
                    }
                }
                else if (tempL.Count > 0)
                {
                    
                    sortList.Add(tempL[0]);
                    tempL.RemoveAt(0);
                }
                else if (tempR.Count > 0)
                {

                    sortList.Add(tempR[0]);
                    tempR.RemoveAt(0);
                }
            }

            Console.WriteLine(string.Format("Sorted : {0}", PrintArray(sortList.ToArray())));
            Console.WriteLine(string.Format("Frquency : {0}", PrintArray(frequentList.ToArray())));

            return sortList.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputArr"></param>
        /// <returns></returns>
        public Dictionary<int,int> FindRepeatedNumbers(int[] inputArr)
        {
            List<int> inputList = inputArr.ToList();

            for (int i = 0; i < inputArr.Length; i++)
            {
                if (!dictFreq.ContainsKey(inputArr[i]))
                    {
                    for (int j = i + 1; j < inputArr.Length; j++)
                    {
                        if (inputArr[i] == inputArr[j])
                        {
                            //if (frequentList.Contains(inputArr[i]))
                            if (dictFreq.ContainsKey(inputArr[j]))
                            {
                                dictFreq[inputArr[j]] = dictFreq[inputArr[j]] + 1;
                            }
                            else
                            {
                                dictFreq.Add(inputArr[i], 2);

                            }
                        }
                    }
                }
            }

            // for (int i = 0; i < inputList.Count; i++)
            //while (inputList.Count>0)
            //{
            //    for (int i = 0; i < inputArr.Length; i++)
            //    {
            //        for (int j = i+1; j < inputArr.Length; j++)
            //        {
            //            if (inputArr[j] == inputArr[j ])
            //            {
            //                //if (frequentList.Contains(inputArr[i]))
            //                if (dictFreq.ContainsKey(inputList[j]))
            //                {
            //                    dictFreq[inputArr[j]] = dictFreq[inputList[j]] + 1;
            //                    inputList.Remove(inputList[j]);
            //                }
            //                else
            //                {
            //                    dictFreq.Add(inputList[j], 1);
            //                }
            //            }
            //        }
            //    }



            //}

            //    for (int i = 0; i < inputArr.Length; i++)
            //{
            //    for (int j = i + 1; j < inputArr.Length; j++)
            //    {
            //        if (inputArr[i] == inputArr[j])
            //        {
            //            //if (frequentList.Contains(inputArr[i]))
            //            if (dictFreq.ContainsKey(inputArr[j]))
            //            {
            //                dictFreq[inputArr[j]] = dictFreq[inputArr[j]] + 1;
            //            }
            //            else
            //            {
            //                dictFreq.Add(inputArr[i], 1);

            //            }
            //        }
            //    }
            //}

            //Console.WriteLine(string.Format("Sorted : {0}", PrintArray(sortList.ToArray())));
            Console.WriteLine(string.Format("Frquency : {0}", PrintArray(frequentList.ToArray())));

            return dictFreq;
            //return frequentList.ToArray();
        }

        internal string PrintArray(int[] inputArr)
        {
            StringBuilder strBuilder = new StringBuilder();
            foreach (int a in inputArr)
                strBuilder.Append(string.Format("{0} ", a));

            return strBuilder.ToString().Trim();

        }

        internal string PrintKeyValue(Dictionary<int,int> pInput)
        {
            StringBuilder strBuilder = new StringBuilder();
            foreach (var a in pInput)
                strBuilder.Append(string.Format("{0}({1}) ", a.Key, a.Value));

            return strBuilder.ToString().Trim();

        }
    }
}
