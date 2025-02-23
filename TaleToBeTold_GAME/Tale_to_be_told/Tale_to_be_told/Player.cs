using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tale_to_be_told
{
    internal class Player
    {
        public string Name { get; set; }
        public double Health { get; set; }
        public double Armour { get; set; }
        public string WeaponType { get; set; }

        public Dictionary<string, int> Loot = new Dictionary<string, int>();
        public Player(string name, double health, double armour, string weaponType, Dictionary<string, int> loot)
        {
            Name = name;
            Health = health;
            Armour = armour;
            WeaponType = weaponType;
            Loot = loot;
        }
        

        public void LootToAdd(int multiplier)
        {
            Loot["gold"] += 10 * multiplier;
            Loot["iron"] += 5 * multiplier;
            Loot["leather"] += 5 * multiplier;
            Loot["ethernalEnergy"] += 5 * multiplier;
        }


        public void WriteStats(int armourLevel, int weaponLevel, int voidStaffLevel)
        {
            Console.WriteLine("Your current healt: " + Health);
            Console.WriteLine("Your current multiplier of recieved damage: " + Armour / armourLevel);
            Console.WriteLine("Your current melee weapon damage multiplier: " + weaponLevel);
            Console.WriteLine("Your current void staff damage multiplier: " + voidStaffLevel);
            Console.WriteLine("");
            foreach (KeyValuePair<string, int> item in Loot)
            {
                Console.WriteLine("Loot type: " + item.Key + "Amount: " + item.Value);
            }
        }

        Random rnd = new Random();

        public double PlayerStrikes(int weaponLevel)
        {
            double damage = 0;

            double minDamage = 10 * 0.5;
            double maxDamage = 10 * 2;
            damage = (minDamage + (rnd.NextDouble() * (maxDamage - minDamage))) * weaponLevel;
            return damage;
        }
        public void GetDamage(double enemyDamage, int armourMultiplier)
        {
            Health -= enemyDamage / armourMultiplier;
        }
        public bool IsAlive()
        {
            if (Health <= 0) return false;
            else return true;
        }
        public double GetHealth()
        {
            return Health;
        }
        public void SetHealth()
        {
            Health = 300;
        }
        public double VoidStrike(int staffLevel)
        {
            double damage = 0;

            double minDamage = 200 * 0.5;
            double maxDamage = 200 * 2;
            damage = (minDamage + (rnd.NextDouble() * (maxDamage - minDamage))) * staffLevel;

            return damage;
        }
    }
}
