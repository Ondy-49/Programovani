using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace ArrayPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové pole a naplň ho pěti libovolnými čísly.
            int[] MyArray = { 3, 4, 10, 2, 13 };

            //TODO 2: Vypiš do konzole všechny prvky pole, zkus jak klasický for, kde i využiješ jako index v poli, tak foreach.
            for (int i = 0; i < MyArray.Length; i++)
            {
                Console.WriteLine("Element " + i + " = " + MyArray[i]);
            }

            foreach (int a in MyArray)
            {
                Console.WriteLine("Element " + a);
            }

            //TODO 3: Spočti sumu všech prvků v poli a vypiš ji uživateli.
            double sum = 0;
            for (int i = 0; i < MyArray.Length; i++)
            {
                sum += MyArray[i];
            }
            Console.WriteLine("Sum = " + sum);

            //TODO 4: Spočti průměr prvků v poli a vypiš ho do konzole.
            double average = 0;
            for (int i = 0; i < MyArray.Length; i++)
            {
                average = sum / MyArray.Length;
            }
            Console.WriteLine("Average = " + average);

            //TODO 5: Najdi maximum v poli a vypiš ho do konzole.
            int max = MyArray[0];
            for (int i = 0; i < MyArray.Length; i++)
            {
                if (MyArray[i] >= max)
                {
                    max = MyArray[i];
                }
            }
            Console.WriteLine("Max = " + max);

            //TODO 6: Najdi minimum v poli a vypiš ho do konzole.
            int min = int.MaxValue;
            for (int i = 0; i < MyArray.Length; i++)
            {
                if (MyArray[i] <= min)
                {
                    min = MyArray[i];
                }
            }
            Console.WriteLine("Min = " + min);

            //TODO 7: Vyhledej v poli číslo, které zadá uživatel, a vypiš index nalezeného prvku do konzole.
            Console.WriteLine("napis cislo");
            int numberToFind = Convert.ToInt32(Console.ReadLine());
            int index;
            bool numberFound = false;
            for (int i = 0; i < MyArray.Length; i++)
            {
                if (numberToFind == MyArray[i])
                {
                    numberFound = true;
                    Console.WriteLine("Number found with index " + i);
                    break;
                }
            }
            if (!numberFound)
            {
                Console.WriteLine("Number hasnt been found");
            }


            //TODO 8: Přepiš pole na úplně nové tak, že bude obsahovat 100 náhodně vygenerovaných čísel od 0 do 9.
            Random rng = new Random();
            int[] MyArrayNew = new int[100];
            for (int i = 0; i < MyArrayNew.Length; i++)
            {
                MyArrayNew[i] = rng.Next(0, 10);
                Console.Write(MyArrayNew[i]);
            }

            //TODO 9: Spočítej kolikrát se každé číslo v poli vyskytuje a spočítané četnosti vypiš do konzole.
            int[] counts = new int[10];
            foreach (int i in MyArrayNew)
            {
                counts[i]++;
            }
            for (int i = 0; i < counts.Length; i++) 
            { 
                Console.Write("Cetnost cislice " + i + " = " + counts[i]);
            }

            //TODO 10: Vytvoř druhé pole, do kterého zkopíruješ prvky z prvního pole v opačném pořadí.
            int[] MyArrayNew1 = new int[100];
            for (int i= 0; i < MyArrayNew.Length; i++ ) {
                MyArrayNew1[100-i-1] = MyArrayNew[i];
            }

            for (int i = 0; i < MyArrayNew1.Length; i++) 
            {
                Console.Write(MyArrayNew1[i]);
            }


            //Zkus is dál hrát s polem dle své libosti. Můžeš třeba prohodit dva prvky, ukládat do pole prvky nějaké posloupnosti (a pak si je vyhledávat) nebo cokoliv dalšího tě napadne

            Console.ReadKey();
        }
    }
}
