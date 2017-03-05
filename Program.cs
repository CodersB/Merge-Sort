using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] arrayInput = new int[] { 9,6, 9,9,3,3, 6,7, 9,6, 5,7 };

            MergeSort mergeSort = new MergeSort();

            //var result = mergeSort.DivideAndConquer(arrayInput);
            //Console.WriteLine("Sort frequency..");
            //Console.WriteLine(mergeSort.PrintArray(result));

            var frequencyRes = mergeSort.FindRepeatedNumbers(arrayInput);
            //Console.WriteLine(mergeSort.PrintArray(frequencyRes));

            Console.WriteLine(mergeSort.PrintKeyValue(frequencyRes));

            var result = mergeSort.DivideAndConquer(frequencyRes.Keys.ToArray());
            Console.WriteLine(mergeSort.PrintArray(result));

            Console.WriteLine(mergeSort.TotalCalls);
            Console.WriteLine("Printing result array..");
            
            Console.ReadKey();

        }
    }
}
