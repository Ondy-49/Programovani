using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tale_to_be_told
{
    abstract class Enemy
    {
        public string Type { get; set; }
        public double Health { get; set; }
        public double Damage { get; set; }
        public double Armour { get; set; }
        public int LootMultiplier { get; set; }
        public Enemy(string type, double health, double damage, double armour, int lootMultiplier)
        {
            Type = "bandit";
            Health = 40;
            Damage = 8;
            Armour = 1;
            LootMultiplier = 1;
        }
        public virtual double EnemyStrikes()
        {
            return Damage;
        }
        public virtual double GetHealth()
        {
            return Health;
        }
        public virtual void GetDamage(double playerDamage)
        {
        }
        public virtual bool IsAlive()
        {
            return true;
        }
        public virtual void SetHealth()
        {
            Health = Health;
        }
        public virtual bool BossFight()
        {
            return false;
        }
    }

    class Bandit : Enemy
    {
        public Bandit() : base("bandit", 80, 8, 1, 1) { }
        Random rnd = new Random();
        public override double EnemyStrikes()
        {
            double damage = 0;
            double minDamage = 8 * 0.5;
            double maxDamage = 8 * 2;
            damage = minDamage + (rnd.NextDouble() * (maxDamage - minDamage));
            return damage;
        }
        public override void GetDamage(double playerDamage)
        {
            Health = Health - playerDamage;
        }
        public override double GetHealth()
        {
            return Health;
        }
        public override bool IsAlive()
        {
            if (Health <= 0) return false;
            else return true;
        }
        public override void SetHealth()
        {
            Health = 40;
        }
    }
    class Knight : Enemy
    {
        public Knight() : base("knight", 2000, 200, 0.3, 5) { }
        Random rnd = new Random();
        public override double EnemyStrikes()
        {
            double damage = 0;
            double minDamage = 200 * 0.5;
            double maxDamage = 200 * 2;
            damage = minDamage + (rnd.NextDouble() * (maxDamage - minDamage));
            return damage;
        }
        public override void GetDamage(double playerDamage)
        {
            Health = Health - playerDamage * 0.3;
        }
        public override double GetHealth()
        {
            return Health;
        }
        public override bool IsAlive()
        {
            if (Health <= 0) return false;
            else return true;
        }
        public override void SetHealth()
        {
            Health = 2000;
        }
    }
    class Vampire : Enemy
    {
        public Vampire() : base("vampire", 500, 100, 1, 0) { }
        Random rnd = new Random();
        public override double EnemyStrikes()
        {
            double damage = 0;
            double minDamage = 100 * 0.5;
            double maxDamage = 100 * 2;
            damage = minDamage + (rnd.NextDouble() * (maxDamage - minDamage));
            return damage;
        }
        public override void GetDamage(double playerDamage)
        {
            Health = Health - playerDamage * 1;
        }
        public override double GetHealth()
        {
            return Health;
        }
        public override bool IsAlive()
        {
            if (Health <= 0) return false;
            else return true;
        }
        public override void SetHealth()
        {
            Health = 500;
        }
    }
    class Wizard : Enemy
    {
        public Wizard() : base("wizard", 1000, 100, 0.7, 3) { }
        Random rnd = new Random();
        public override double EnemyStrikes()
        {
            double damage = 0;
            double minDamage = 100 * 0.5;
            double maxDamage = 100 * 2;
            damage = minDamage + (rnd.NextDouble() * (maxDamage - minDamage));
            return damage;
        }
        public override void GetDamage(double playerDamage)
        {
            Health = Health - playerDamage * 0.7;
        }
        public override double GetHealth()
        {
            return Health;
        }
        public override bool IsAlive()
        {
            if (Health <= 0) return false;
            else return true;
        }
        public override void SetHealth()
        {
            Health = 1000;
        }
    }
    class Dragon : Enemy
    {
        public Dragon() : base("dragon", 30000, 1000, 0.5, 0) { }
        Random rnd = new Random();
        public override double EnemyStrikes()
        {
            double damage = 0;
            double minDamage = 1000 * 0.5;
            double maxDamage = 1000 * 2;
            damage = minDamage + (rnd.NextDouble() * (maxDamage - minDamage));
            return damage;
        }
        public override void GetDamage(double playerDamage)
        {
            Health = Health - playerDamage * 0.5;
        }
        public override double GetHealth()
        {
            return Health;
        }
        public override bool IsAlive()
        {
            if (Health <= 0) return false;
            else return true;
        }
        public override void SetHealth()
        {
            Health = 30000;
        }

    }
}
