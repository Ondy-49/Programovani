using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    
    {
        
        static double Factorial(double currentValue)
        {
            if (currentValue == 0 || currentValue == 1) { 
               return 1;
            }
            else
            {
                return currentValue * Factorial(currentValue - 1);
                
            }
        }   

        static double Fibonacci(double currentValue)

        {
            if (currentValue == 1)
            {
                return 1;
            }
            else if (currentValue == 2)
            {
                return 2;
            }
            else 
            { 
                return Fibonacci(currentValue - 1) + Fibonacci(currentValue - 2);
            }
        }

        
        static void Main(string[] args)
        {
            string number;
            bool parseTrue;
            double a;
            double resultFactorial;
            double resultFibonacci;
            while (true) { 
            Console.WriteLine("Enter a number:");
            number = Console.ReadLine();
            parseTrue = double.TryParse(number, out a);

            if (parseTrue == true) 
            { 
                resultFactorial = Factorial(a);
                resultFibonacci = Fibonacci(a);
            }

            else
            {

                while (true)
                {
                    Console.WriteLine("opakuj vstup");
                    number = Console.ReadLine();
                    parseTrue = double.TryParse(number, out a);

                    if(parseTrue == true)
                    {
                        resultFactorial = Factorial(a);
                        resultFibonacci = Fibonacci(a);
                        break;
                    }
                }
            }
            

            Console.WriteLine("faktorial " + resultFactorial);
            Console.WriteLine("fibonacci " + resultFibonacci);
            Console.ReadKey();
            }
        }
    }
}
