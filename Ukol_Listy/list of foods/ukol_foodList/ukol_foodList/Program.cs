using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ukol_foodList
{
    internal class Program
    {
        static void FoodListItteration(List<string> favFoods)
        {
            foreach (string food in favFoods)
            {
                Console.WriteLine(food);
            }
        }
        static void Main(string[] args)
        {
            string userInput;
            string userFoodInput;
            bool foodExists;
            List<string> favFoods = new List<string>();
            favFoods.Add("fries");
            favFoods.Add("sushi");
            favFoods.Add("rice");
            FoodListItteration(favFoods);
            while (true)
            {
                Console.WriteLine("to add food type: +     to remove food type: -        to stop editing your list type: stop");
                userInput = Console.ReadLine();
                if (userInput == "+")
                {
                    Console.WriteLine("enter food:");
                    userFoodInput = Console.ReadLine();
                    favFoods.Add(userFoodInput);
                    FoodListItteration(favFoods);
                }
                else if (userInput == "-")
                {
                    Console.WriteLine("enter food you wish to remove:");
                    userFoodInput = Console.ReadLine();
                    if (foodExists = favFoods.Contains(userFoodInput))
                    {
                        favFoods.Remove(userFoodInput);
                    }
                    else
                    {
                        Console.WriteLine("food you are trying to remove is not in your list");
                    }
                    FoodListItteration(favFoods);

                }
                else if (userInput == "stop")
                {
                    Console.WriteLine("your final food list is as follows:");
                    FoodListItteration(favFoods);
                    break;
                }
                else 
                {
                    Console.WriteLine("repeat input");
                }
            }

            Console.ReadKey();
        }
    }
}
