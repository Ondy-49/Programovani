using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace SortingPlayground
{
    internal class Program
    {
        //Pokud si nejsi jistý/á, co dělat, podívej se do prezentace, na videa na YT, co jsem doporučoval, googluj a nebo mě zavolej a já ti poradím.

        static int[] BubbleSort(int[] array)
        {
            int[] sortedArray = (int[])array.Clone(); // Řaď v tomto poli, ve kterém je výchoze zkopírováno všechno ze vstupního pole.
            /*
             * TODO: Naimplementuj bubble sort.
             */
            int smallerNumber;
            int biggerNumber;
            for(int i = 0; i < sortedArray.Length; i++)
            {
                for (int j = 0; j < sortedArray.Length - 1; j++)        //postupne porovnavam dvojice 
                {
                    if (sortedArray[j] >= sortedArray[j+1])
                    {
                        smallerNumber = sortedArray[j + 1];
                        biggerNumber = sortedArray[j];
                        sortedArray[j] = smallerNumber;
                        sortedArray[j + 1] = biggerNumber;
                    }                   
                }
            }
            return sortedArray;
        }

        static int[] SelectionSort(int[] array)
        {
            int[] sortedArray = (int[])array.Clone(); // Řaď v tomto poli, ve kterém je výchoze zkopírováno všechno ze vstupního pole.
            /*
             * TODO: Naimplementuj selection sort.
             */            
            int index = 0;
            int swap;
            int min = int.MaxValue;
            int j;
            for (int i = 0; i < sortedArray.Length; i++)
            {
                for (j = i; j < sortedArray.Length; j++) //prochazeni pole a hledani nejnizsi hodnoty
                {
                    if (sortedArray[j] <= min)
                    {
                        min = sortedArray[j];
                        index = j;
                    }
                }
                swap = sortedArray[i];              //vymena nejnizi hodnoty na prvni pozici v poli a hodnoty elementu puvodne na prvnim miste za misto, kde bylo minimum
                sortedArray[i] = min;
                sortedArray[index] = swap;
                min = int.MaxValue;                
            }
            return sortedArray;
        }

        static int[] InsertionSort(int[] array)
        {
            int[] sortedArray = (int[])array.Clone(); // Řaď v tomto poli, ve kterém je výchoze zkopírováno všechno ze vstupního pole.
            /*
             * TODO: Naimplementuj insertion sort.
             */
            int smallerNumber;
            int biggerNumber;
            for (int i = 1; i < sortedArray.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if(sortedArray[j] <= sortedArray[j-1])      //prochazeni pole az od pozice i (j=i), protoze elementy s indexem < i jsou sezarene 
                    {
                        smallerNumber = sortedArray[j];
                        biggerNumber = sortedArray[j-1];
                        sortedArray[j] = biggerNumber;
                        sortedArray[j-1] = smallerNumber;
                    }                
                }  
            }           
            return sortedArray;
        }

        //Naplní pole náhodnými čísly mezi 1 a velikostí pole.
        static void FillArray(int[] array)
        {
            Random rng = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rng.Next(1, array.Length + 1);
            }
        }

        //Vypíše pole do konzole.
        static void WriteArrayToConsole(int[] array, string arrayName)
        {
            Console.Write(arrayName + " = [");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("]\n\n");
        }

        //Zavolá postupně Bubble sort, Selection sort a Insertion sort pro zadané pole (a vypíše jeho jméno pro přehlednost)
        static void SortArray(int[] array, string arrayName)
        {
            Console.WriteLine($"Řadím {arrayName}:");
            int[] sortedArray;

            sortedArray = BubbleSort(array);
            WriteArrayToConsole(sortedArray, arrayName + " seřazené Bubble sortem");

            sortedArray = SelectionSort(array);
            WriteArrayToConsole(sortedArray, arrayName + " seřazené Selection sortem");

            sortedArray = InsertionSort(array);
            WriteArrayToConsole(sortedArray, arrayName + " seřazené Insertion sortem");

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] smallArray = new int[10];
            FillArray(smallArray);

            int[] mediumArray = new int[100];
            FillArray(mediumArray);

            int[] largeArray = new int[1000];
            FillArray(largeArray);

            WriteArrayToConsole(smallArray, "Malé pole");
            SortArray(smallArray, "Malé pole");

            WriteArrayToConsole(mediumArray, "Střední pole");
            SortArray(mediumArray, "Střední pole");

            //WriteArrayToConsole(largeArray, "Velké pole");
            //SortArray(largeArray, "Velké pole");

            Console.ReadKey();
        }
    }
}
