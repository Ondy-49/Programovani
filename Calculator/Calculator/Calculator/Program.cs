using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * ZADANI
             * Vytvor program ktery bude fungovat jako kalkulacka. Kroky programu budou nasledujici:
             * 1) Nacte vstup pro prvni cislo od uzivatele (vyuzijte metodu Console.ReadLine() - https://learn.microsoft.com/en-us/dotnet/api/system.console.readline?view=netframework-4.8.
             * 2) Zkonvertuje vstup od uzivatele ze stringu do integeru - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number.
             * 3) Nacte vstup pro druhe cislo od uzivatele a zkonvertuje ho do integeru. (zopakovani kroku 1 a 2 pro druhe cislo)
             * 4) Nacte vstup pro ciselnou operaci. Rozmysli si, jak operace nazves. Muze to byt "soucet", "rozdil" atd. nebo napr "+", "-", nebo jakkoliv jinak.
             * 5) Nadefinuj integerovou promennou result a prirad ji prozatimne hodnotu 0.
             * 6) Vytvor podminky (if statement), podle kterych urcis, co se bude s cisly dit podle zadane operace
             *    a proved danou operaci - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements.
             * 7) Vypis promennou result do konzole
             * 
             * Rozsireni programu pro rychliky / na doma (na poradi nezalezi):
             * 1) Vypis do konzole pred nactenim kazdeho uzivatelova vstupu co po nem chces (aby vedel, co ma zadat)
             * 2) a) Kontroluj, ze uzivatel do vstupu zadal, co mel (cisla, popr. ciselnou operaci). Pokud zadal neco jineho, napis mu, co ma priste zadat a program ukoncete.
             * 2) b) To same, co a) ale misto ukonceni programu opakovane cti vstup, dokud uzivatel nezada to, co ma
             *       - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement
             * 3) Umozni uzivateli zadavat i desetinna cisla, tedy prekopej kalkulacku tak, aby umela pracovat s floaty
             */

            string promenna; //promenna ano/ne jestli uzivatel chce zadat promennou 
            double p = 0;  //hodnota promenne
            string nazevP = "***"; //aby vs nekricelo, ze je nedefinovana promenna
            double a = 0;  //prvni cislo/promenna
            Console.WriteLine("Chceš zadat promennou? (ano/ne)");
            promenna = Console.ReadLine();
            if (promenna == "ano")      //kontorla jestli uzivatel umi napsat ano/ne
            {
                Promenna();
            }
            else
            {
                if (promenna == "ne")
                {
                    Calculator();       //bez promenne
                }
                while (promenna != "ano")
                {
                    Console.WriteLine("Napsal si nesmysl, zadej ano/ne");
                    promenna = Console.ReadLine();
                    if (promenna == "ano")
                    {
                        Promenna();     //chci zadat promennou
                    }
                    else if (promenna == "ne") 
                    { 
                        Calculator();       //bez promenne 
                    }
                
                }
            }


            void Promenna()
            {
                bool promennaKontrolaBoolean; //promenny pro kontrolu jestli uzivatel zadal za promennou opravdu cislo
                string promennaKontrola;
                string promennaInput;
                bool promennaInputBoolean;

                Console.WriteLine("Jak se bude jmenovat?");
                nazevP = Console.ReadLine();
                Console.WriteLine("Jakou bude mít hodnotu?");
                promennaKontrola = Console.ReadLine();
                promennaKontrolaBoolean = double.TryParse(promennaKontrola, out p);

                if (promennaKontrolaBoolean == true)
                {
                    a = p;
                }
                else 
                {
                    while (true)
                    {
                        Console.WriteLine("Napsal si nesmysl, prosim zadej cislo");
                        promennaInput = (Console.ReadLine());
                        promennaInputBoolean = double.TryParse(promennaInput, out p);
                        if (promennaInputBoolean == true)
                        {
                            break;
                        }
                    }
                }

                Calculator();
            }

            
            void Calculator()
            {
                string input; //userInput
                double b = 0; //druheCislo
                string op; //operator
                double r = 0; //vysledek
                string inputB; //userInput pro druhe cislo
                string hexValue; //string pro prevod do hex soustavy
                bool userInputA; //porovnavani jestli uzivatel zadal cislo 1 spravne
                bool userInputB; //porovnani jestli uziivatel zadal cislo 2 spravne


                Console.WriteLine("Zadej první číslo/Proměnnou:");
                input = (Console.ReadLine());
                if (input == nazevP) //pokud jsem zvolil jako hodnotu predem definovanou promennou
                {
                    a = p;
                    Operator();
                }
                else
                {
                    userInputA = double.TryParse(input, out a);            //zjistuji, jestli uzivatel zadal cislo
                    while (userInputA == false && Convert.ToString(input) != nazevP)
                    {
                        Console.WriteLine("Napsal si nesmysl, prosim zadej cislo");
                        input = (Console.ReadLine());
                        userInputA = double.TryParse(input, out a);
                        if (userInputA == true)
                        {
                            break;
                        }
                        else if (Convert.ToString(input) == nazevP)
                        {
                            a = p;
                            break;
                        }
                    }
                }
                Operator();
                void Operator() { 

                Console.WriteLine("Vyber si jeden z operátorů: +, -, /, *, pro mocninu **, odmocninu //");
                op = Convert.ToString(Console.ReadLine());

                if (op == "//")
                {
                    r = Math.Sqrt(a);
                    Console.WriteLine("výsledek je " + r);
                    hexValue = Convert.ToInt64(r).ToString("X"); //prevod na hexadecimalni soustavu po konverci na int hodnotu, mene presne, jednodussi, zdroj: internet
                    Console.WriteLine("výsledek v hexadecimální soustavě je " + hexValue);
                }


                else if (op == "+")
                {

                    Console.WriteLine("Zadej druhé číslo/Proměnnou:");
                    inputB = Console.ReadLine();
                    if (inputB == nazevP) //pokud jsem i jako druhou hodnotu zvolil predem definovanou promennou
                    {
                        b = p;

                    }
                    else
                    {
                            userInputB = double.TryParse(inputB, out b);            //zjistuji, jestli uzivatel zadal cislo
                            while (userInputB == false && Convert.ToString(inputB) != nazevP)
                            {
                                Console.WriteLine("Napsal si nesmysl, prosim zadej cislo");
                                inputB = (Console.ReadLine());
                                userInputB = double.TryParse(inputB, out b);
                                if (userInputB == true) //zadal cislo
                                {
                                    break;
                                }
                                else if (Convert.ToString(inputB) == nazevP) //zadal nazev promenny 
                                {
                                    b = p;
                                    break;
                                }
                            }
                    }
                    r = a + b;
                    Console.WriteLine("výsledek je " + r);
                    hexValue = Convert.ToInt64(r).ToString("X"); //prevod na hexadecimalni soustavu po konverci na int hodnotu, mene presne a nastava problem s vyssimi cisly, jednodussi, zdroj: internet
                    Console.WriteLine("výsledek v hexadecimální soustavě je " + hexValue);
                }
                else if (op == "-")
                {
                    Console.WriteLine("Zadej druhé číslo/Proměnnou:");
                    inputB = Console.ReadLine();
                    if (inputB == nazevP)
                    {
                        b = p;

                    }
                        else
                        {
                            userInputB = double.TryParse(inputB, out b);            //zjistuji, jestli uzivatel zadal cislo
                            while (userInputB == false && Convert.ToString(inputB) != nazevP)
                            {
                                Console.WriteLine("Napsal si nesmysl, prosim zadej cislo");
                                inputB = (Console.ReadLine());
                                userInputB = double.TryParse(inputB, out b);
                                if (userInputB == true)
                                {
                                    break;
                                }
                                else if (Convert.ToString(inputB) == nazevP)
                                {
                                    b = p;
                                    break;
                                }
                            }
                        }
                        r = a - b;
                    Console.WriteLine("výsledek je " + r);
                    hexValue = Convert.ToInt64(r).ToString("X"); //prevod na hexadecimalni soustavu po konverci na int hodnotu, mene presne, jednodussi, zdroj: internet
                    Console.WriteLine("výsledek v hexadecimální soustavě je " + hexValue);
                }
                else if (op == "/")
                {
                    Console.WriteLine("Zadej druhé číslo/Proměnnou:");
                    inputB = Console.ReadLine();
                    if (inputB == nazevP)
                    {
                        b = p;

                    }
                        else
                        {
                            userInputB = double.TryParse(inputB, out b);            //zjistuji, jestli uzivatel zadal cislo
                            while (userInputB == false && Convert.ToString(inputB) != nazevP)
                            {
                                Console.WriteLine("Napsal si nesmysl, prosim zadej cislo");
                                inputB = (Console.ReadLine());
                                userInputB = double.TryParse(inputB, out b);
                                if (userInputB == true)
                                {
                                    break;
                                }
                                else if (Convert.ToString(inputB) == nazevP)
                                {
                                    b = p;
                                    break;
                                }
                            }
                        }
                        r = a / b;
                    Console.WriteLine("výsledek je " + r);
                    hexValue = Convert.ToInt64(r).ToString("X"); //prevod na hexadecimalni soustavu po konverci na int hodnotu, mene presne, jednodussi, zdroj: internet
                    Console.WriteLine("výsledek v hexadecimální soustavě je " + hexValue);
                }
                else if (op == "*")
                {
                    Console.WriteLine("Zadej druhé číslo/Proměnnou:");
                    inputB = Console.ReadLine();
                    if (inputB == nazevP)
                    {
                        b = p;

                    }
                        else
                        {
                            userInputB = double.TryParse(inputB, out b);            //zjistuji, jestli uzivatel zadal cislo
                            while (userInputB == false && Convert.ToString(inputB) != nazevP)
                            {
                                Console.WriteLine("Napsal si nesmysl, prosim zadej cislo");
                                inputB = (Console.ReadLine());
                                userInputB = double.TryParse(inputB, out b);
                                if (userInputB == true) //zadal cislo
                                {
                                    break;
                                }
                                else if (Convert.ToString(inputB) == nazevP) //zadal nazev promenny
                                {
                                    b = p;
                                    break;
                                }
                            }
                        }
                        r = a * b;
                    Console.WriteLine("výsledek je " + r);
                    hexValue = Convert.ToInt64(r).ToString("X"); //prevod na hexadecimalni soustavu po konverci na int hodnotu, mene presne, jednodussi, zdroj: internet
                    Console.WriteLine("výsledek v hexadecimální soustavě je " + hexValue);
                }
                else if (op == "**")
                {
                    Console.WriteLine("Zadej druhé číslo/Proměnnou:");
                    inputB = Console.ReadLine();
                    if (inputB == nazevP)
                    {
                        b = p;

                    }
                        else
                        {
                            userInputB = double.TryParse(inputB, out b);            //zjistuji, jestli uzivatel zadal cislo
                            while (userInputB == false && Convert.ToString(inputB) != nazevP)
                            {
                                Console.WriteLine("Napsal si nesmysl, prosim zadej cislo");
                                inputB = (Console.ReadLine());
                                userInputB = double.TryParse(inputB, out b);
                                if (userInputB == true)
                                {
                                    break;
                                }
                                else if (Convert.ToString(inputB) == nazevP)
                                {
                                    b = p;
                                    break;
                                }
                            }
                        }
                        r = Math.Pow(a, b);
                    Console.WriteLine("výsledek je " + r);
                    hexValue = Convert.ToInt64(r).ToString("X"); //prevod na hexadecimalni soustavu po konverci na int hodnotu, mene presne, jednodussi, zdroj: internet
                    Console.WriteLine("výsledek v hexadecimální soustavě je " + hexValue);
                }
                else
                    {
                        Operator(); //vracim se do voidu pro psani operatoru
                    }
                string repeat;
                Console.WriteLine("Chceš provést další výpočet? (ano/ne)");
                repeat = Console.ReadLine();
                if (repeat == "ano")
                {
                    a = 0;
                    Calculator(); //at nemusim zapinat program porad znovu, kdyz chci udelat dalsi vypocet
                }
                else 
                {
                Console.ReadKey(); //Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.
                Environment.Exit(0); //ukonceni programu
                }
            }
           
        }
    }
    }
}
