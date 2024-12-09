using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace _2D_Array_Playground
{
    internal class Program
    {
        static void SetArrayToDefault(int[,] field) 
        {
            for (int i = 0; i < field.GetLength(0); i++) //pocet radku
            {
                for (int j = 0; j < field.GetLength(1); j++) //pocet sloupcu
                {
                    field[i, j] = i * 5 + j + 1;
                }
            }
           
        }
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové 2D pole velikosti 5 x 5, naplň ho čísly od 1 do 25 a vypiš ho do konzole (5 řádků po 5 číslech).
            int[,] field = new int[5, 5];
            SetArrayToDefault(field);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++) 
                {
                    Console.Write(field[i, j] + " ");
                }
                Console.WriteLine("");
            }

            //TODO 2: Vypiš do konzole n-tý řádek pole, kde n určuje proměnná nRow.
            int nRow = 0;
            for (int i = 0; i < field.GetLength(nRow); i++)
            {
                Console.Write(field[nRow, i] + " ");
            }
            Console.WriteLine("");

            //TODO 3: Vypiš do konzole n-tý sloupec pole, kde n určuje proměnná nColumn.
            int nColumn = 0;
            for(int i = 0; i < field.GetLength(nColumn); i++)
            {
                Console.WriteLine(field[i, nColumn]);
            }

            //TODO 4: Prohoď prvek na souřadnicích [xFirst, yFirst] s prvkem na souřadnicích [xSecond, ySecond] a vypiš celé pole do konzole po prohození.
            //Nápověda: Budeš potřebovat proměnnou navíc, do které si uložíš první z prvků před tím, než ho přepíšeš druhým, abys hodnotou prvního prvku potom mohl přepsat druhý
            int xFirst = 0, yFirst = 0, xSecond = 0, ySecond = 0, FirstToChange = 0, SecondToChange = 0;
            
            Console.WriteLine("ktere cislo chces prohodit?");
            FirstToChange = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("za ktere cislo ho chces prohodit?");
            SecondToChange = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (field[i, j] == FirstToChange)
                    {
                        yFirst = i;
                        xFirst = j;
                    }
                    if (field[i, j] == SecondToChange)
                    {
                        ySecond = i;
                        xSecond = j;
                    }
                }  
            }
            field[yFirst, xFirst] = SecondToChange;
            field[ySecond, xSecond] = FirstToChange;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(field[i, j] + " ");
                }
                Console.WriteLine("");
            }


            //TODO 5: Prohoď n-tý řádek v poli s m-tým řádkem (n je dáno proměnnou nRowSwap, m mRowSwap) a vypiš celé pole do konzole po prohození.
            int nRowSwap = 0;
            int mRowSwap = 1;
            int nRowBackup = 0;

            SetArrayToDefault(field);

            for (int j = 0; j < field.GetLength(1); j++) //pocet sloupcu
            {
                nRowBackup = field[nRowSwap, j];
                field[nRowSwap, j] = field[mRowSwap, j];
                field[mRowSwap, j] = nRowBackup;
            } 

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(field[i, j] + " ");
                }
                Console.WriteLine("");
            }

            //TODO 6: Prohoď n-tý sloupec v poli s m-tým sloupcem (n je dáno proměnnou nColSwap, m mColSwap) a vypiš celé pole do konzole po prohození.
            int nColSwap = 0;
            int mColSwap = 1;

            //TODO 7: Otoč pořadí prvků na hlavní diagonále (z levého horního rohu do pravého dolního rohu) a vypiš celé pole do konzole po otočení.


            //TODO 8: Otoč pořadí prvků na vedlejší diagonále (z pravého horního rohu do levého dolního rohu) a vypiš celé pole do konzole po otočení.


            Console.ReadKey();
        }
    }
}
