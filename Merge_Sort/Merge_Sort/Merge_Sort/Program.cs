using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Sort
{
    internal class Program
    {
        static int[] SplitArray(int[] arrayToSplit)
        {
            if (arrayToSplit.Length == 1)
            {
                return arrayToSplit;
            }
            int center = arrayToSplit.Length / 2;
            int[] arrayOne = new int[center];
            for (int i = 0; i < center; i++)
            {
                arrayOne[i] = arrayToSplit[i];
            }
            int[] arrayTwo = new int[arrayToSplit.Length - center];
            for (int j = 0; j < arrayToSplit.Length-center; j++)
            {
                arrayTwo[j] = arrayToSplit[j+center];
            }
            arrayOne = SplitArray(arrayOne);
            arrayTwo = SplitArray(arrayTwo);
            return MergeArray(arrayOne, arrayTwo);
        }
        /*static int[] MergeArray(int[] arrayOne, int[] arrayTwo) 
        {
            int[] arrayFinal = new int[arrayOne.Length + arrayTwo.Length];
            int finalArrayLength = arrayOne.Length + arrayTwo.Length;
            int i = 0;
            int iOne = 0;
            int iTwo = 0;
            int lengthOne = arrayOne.Length;
            int lengthTwo = arrayTwo.Length;
            List<int> listOne = arrayOne.ToList();
            List<int> listTwo = arrayTwo.ToList();
            while(lengthOne != 0 && arrayTwo.Length != 0)
            {
                if (listOne[i] < listTwo[i])
                {
                    arrayFinal[finalArrayLength - i] = listTwo[iTwo];
                    
                    listTwo.RemoveAt(iTwo);
                    lengthTwo--;
                    iTwo++;
                }
                else 
                {
                    arrayFinal[finalArrayLength - i] = listOne[iOne];
                    
                    listOne.RemoveAt(iOne);
                    lengthOne--;
                    iOne++;
                }
                i++;
            }
            while(lengthOne != 0 && lengthTwo == 0)
            {
                arrayFinal[i] = listOne[iOne];
                iOne++;
                listOne.RemoveAt(iOne);
                i++;
                lengthOne--;
            } 
            while (lengthOne == 0 && lengthTwo != 0)
            {
                arrayFinal[i] = listTwo[iTwo];
                iTwo++;
                listTwo.RemoveAt(iTwo);
                i++;
                lengthTwo--;
            }

            return arrayFinal;
        }*/

        static int[] MergeArray(int[] arrayOne, int[] arrayTwo)
        {
            int[] arrayFinal = new int[arrayOne.Length + arrayTwo.Length];
            int iOne = 0, iTwo = 0, iFinal = 0;

            // Merge elements from both arrays in sorted order
            while (iOne < arrayOne.Length && iTwo < arrayTwo.Length)
            {
                if (arrayOne[iOne] <= arrayTwo[iTwo])
                {
                    arrayFinal[iFinal] = arrayOne[iOne];
                    iOne++;
                }
                else
                {
                    arrayFinal[iFinal] = arrayTwo[iTwo];
                    iTwo++;
                }
                iFinal++;
            }

            // Append remaining elements from arrayOne
            while (iOne < arrayOne.Length)
            {
                arrayFinal[iFinal] = arrayOne[iOne];
                iOne++;
                iFinal++;
            }

            // Append remaining elements from arrayTwo
            while (iTwo < arrayTwo.Length)
            {
                arrayFinal[iFinal] = arrayTwo[iTwo];
                iTwo++;
                iFinal++;
            }

            return arrayFinal;
        }
        static void Main(string[] args)
        {
            int[] array = new int[1000];
            //int a = 1000;
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0,1001);
                Console.Write(array[i] + ",");
            }
            int[] sortedArray = SplitArray(array);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            foreach (int i in sortedArray)
            {
                Console.Write(i + ",");

            }
            Console.ReadKey();
        }
    }
}
