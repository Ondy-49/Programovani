using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace Deathroll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Jednoduchy program na procviceni podminek a cyklu (lze udelat i rekurzi).
             * 
             * Vytvor program, kde bude uzivatel hrat s pocitacem deathroll.
             * Pravidla deathrollu: Prvni hrac navrhne cislo (puvodne ve wowku pocet goldu, o ktere se hraci vsadi) a "rollne" navrhnute cislo, jinak receno je to stejne,
             * jako kdyby si hodil kostkou s tolika stenami, jako je navrhnute cislo. Prvnimu hraci "padne" nejake cislo a druhy hrac si "rollne" padnute cislo
             * (ktere uz je mensi nez to predesleho hrace).
             * Prohrava ten hrac, kteremu padne 1 jako prvnimu.
             * Ukazka hry: Hraci se shodnou na cisle 1000. Prvni hrac rollne 1-1000, padne mu 920. Druhy hrac rolluje 1-920, padne mu 235 atd. atd. az jednomu z hracu padne 1
             * a ten prohrava.
             * 
             * Struktura:
             * 
             * - nadefinuj promenne, ktere budes potrebovat po celou dobu hry, tedy aktualne rollovane cislo a stav "goldu" uzivatele i pocitace (oba zacinaji treba s 1000 goldu)
             * 
             * - uzivatel zada prvotni sazku, ktera musi byt maximalne tolik, kolik ma goldu
             * 
             * Opakuj dokud nepadne jednomu z hracu 1:
             * {
             *      Pokud je sude kolo:
             *      {
             *          - uzivatel zada hodnotu, kterou rolluje
             *          - kontroluj, ze uzivatel zadal spravnou hodnotu
             *          - uloz rollnute cislo
             *          - vypis uzivateli, co rollnul
             *      }
             *      Pokud je liche kolo:
             *      {
             *          - pocitac rollne nahodne cislo mezi 1 a aktualne rollovanym cislem
             *          - vypis uzivateli, co rollnul pocitac
             *      }
             * }
             * 
             * 
             * - posledni hrajici hrac prohral, protoze mu padla 1 a sazku bere druhy hrac
             * - vypis uzivateli kdo vyhral a stav goldu uzivatele i pocitace
             * 
             * ROZSIRENI:
             * - umozni uzivateli opakovat deathroll dokud ma nejake goldy
             */
            int userGold = 1000;
            int computerGold = 1000;
            int userBet = 0;
            Console.WriteLine("Pocitac i hrac maji oba 1000 goldu");
            while (userGold > 0 && computerGold > 0)
            {
            Console.WriteLine("Kolik chces vsadit");
            userBet = Convert.ToInt32(Console.ReadLine());
            int currentRoll = userBet;
            int currentRound = 0;
            Random roll = new Random();
            Console.WriteLine("Vsadil si " + userBet);
            while (currentRoll > 1)
            {

                if (currentRound % 2 == 0) //hraje uzivatel
                {
                    Console.WriteLine("Hod kostkou (enter)");
                    Console.ReadKey();

                    currentRoll = roll.Next(1, currentRoll + 1);
                    Console.WriteLine(currentRoll);
                }
                else
                {
                    Console.WriteLine("Hraje PC");
                    Console.ReadKey();
                    currentRoll = roll.Next(1, currentRoll + 1);
                    Console.WriteLine(currentRoll);
                }
                currentRound++;
            }
            if (currentRound % 2 == 0)
            {
                Console.WriteLine("Prohral si, prichazis o " + userBet);
                userGold = userGold - userBet;
                Console.WriteLine("Tvoje nova bilance je " + userGold);
                computerGold = computerGold + userBet;
                Console.WriteLine("Bilance pocitace je " + computerGold);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Vyhral si, ziskavas " + userBet);
                userGold = userGold + userBet;
                Console.WriteLine("Tvoje nova bilance je " + userGold);
                computerGold = computerGold - userBet;
                Console.WriteLine("Bilance pocitace je " + computerGold);
                Console.ReadKey();
            }
                
            }
            Console.WriteLine("Konec hry");
            Console.ReadKey();
        }
    }
}
