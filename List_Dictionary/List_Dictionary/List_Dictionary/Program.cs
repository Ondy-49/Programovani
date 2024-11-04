using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Dictionary
{
    internal class Program
    {
        static void PrintList(List<string> stringList)
        {
            foreach (string name in stringList)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("");
        }
        static void Main(string[] args)
        {
            List<int> myList = new List<int>();
            for (int i = 0; i < 10; i++)
            {
            myList.Add(i);
            }
            for (int i = 0;i < 9; i++) {
            
                Console.Write(myList[i] + ",");
            }
            Console.Write(myList[9]);
            Console.WriteLine("");
            Console.WriteLine("");
            //List
            List<string> stringList = new List<string>();
            stringList.Add("Skoda");
            stringList.Add("Lada");
            stringList.Add("Koenigsegg");
            stringList.Add("Smart");
            stringList.Add("McMurty");

            PrintList(stringList);
            stringList.Remove("Lada");
            PrintList(stringList);

            /*if (stringList.Exists(brand => brand.StartsWith("M")))
            {

            }
            
            else 
            { 
            }*/
            Dictionary<string, string> germanToCzech = new Dictionary<string, string>();
            germanToCzech["Wasser"] = "Voda";
            germanToCzech["Krankenhaus"] = "Nemocnice";
            germanToCzech["Naturwissenschaft"] = "Veda";
            germanToCzech["Zigeuner"] = "Cigan";

            foreach (KeyValuePair<string, string> translation in germanToCzech) 
            { 
            string germanWord = translation.Key;
            string czechWord = translation.Value;
                Console.WriteLine("preklad slova " + germanWord + " do cestiny je " + czechWord);
            }

            Console.ReadKey();
        }
    }
}
