using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tale_to_be_told
{
    internal class Program
    {
        public class BlacksmithVariables
        {
            public static int weaponCost = 1;    //multipliers pro upgrade gearu
            public static int armourCost = 1;
            public static int voidStaffCost = 1;
            public static int weaponLevel = 1;
            public static int armourLevel = 1;
            public static int voidStaffLevel = 1;
        }

        static void IntroCutScene()
        {
            Console.WriteLine();
            string[] texts = { "The sun hung low over the quiet village of Eldermere as Rowan, a humble farmer, wiped the sweat from his brow. His days were spent tending fields, his thoughts never straying beyond the rolling hills—until today.",
                                "A rustling in the nearby woods caught his attention. From the shadows emerged a figure draped in a tattered cloak, her golden hair glinting in the evening light. She stepped forward, urgency in her voice.",
                                "“You must listen to me,” she said. “I am Princess Evelyne, held captive by the dragon of Blackspire Keep. I escaped only briefly, but I cannot flee forever. You are the only one who can save me.”",
                                "Rowan took a step back, wide-eyed. “Me? I’m just a farmer. What can I do against a dragon?”",
                                "The princess placed a hand on his arm, determination in her gaze. “You must grow stronger. Forge new armor, sharpen your blade, and seek the wisdom of the elders. Only then will you stand a chance.”",
                                "Rowan swallowed hard. He had never wielded more than a rusted sickle—but looking into the princess’s desperate eyes, he knew his quiet life was about to change forever."};

            for (int i = 0; i < texts.Length; i++) //aby to bylo vypsany hezky a hrac to mel lepsi sanci stihnout precist
            {
                foreach (char c in texts[i])
                {
                    Console.Write(c);
                    Thread.Sleep(12);
                }
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static void Blacksmith(int repetitions, Player player)
        {
            bool wantToUpgrade = true;
            if (repetitions <= 0)
            {
                Console.Clear();
                string[] texts = { "”If you're looking to make that gear of yours stronger,” he grunts, eyeing your weapons, ”I can help—for a price.”",
                                    "He gestures to the forge. ”Iron for your sword or mace, leather for your armor, and eternal energy for your void staff. But upgrades ain't free—gold is what gets the work done.”",
                                    "He crosses his arms, waiting. ”So, what’ll it be?”"};

                for (int i = 0; i < texts.Length; i++) //aby to bylo vypsany hezky a hrac to mel lepsi sanci stihnout precist
                {
                    foreach (char c in texts[i])
                    {
                        Console.Write(c);
                        Thread.Sleep(12);
                    }
                    Console.ReadKey();
                    Console.WriteLine();
                    Console.WriteLine();
                }
                repetitions++;
                Console.WriteLine("Press any button to get to upgrading!");
                Console.WriteLine();
                Console.ReadKey();
            }
            Console.WriteLine("Your current loot:");
            foreach (KeyValuePair<string, int> item in player.Loot)
            {
                Console.WriteLine("Loot type: " + item.Key + "Amount: " + item.Value);
            }
            Console.WriteLine();

            while (wantToUpgrade)
            {
                Console.WriteLine("You need " + 5 * BlacksmithVariables.weaponCost + " of iron and " + 5 * BlacksmithVariables.weaponCost + " of gold");
                Console.WriteLine("You need " + 5 * BlacksmithVariables.voidStaffCost + " of eternal energy and " + 5 * BlacksmithVariables.voidStaffCost + " of gold");
                Console.WriteLine("You need " + 5 * BlacksmithVariables.armourCost + " of leather and " + 5 * BlacksmithVariables.armourCost + " of gold");
                Console.WriteLine("What do you wish to upgrade?    W - Weapon    A - Armour    S - Void Staff    E - to stop upgrading");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        if (player.Loot["gold"] >= BlacksmithVariables.weaponCost * 5 && player.Loot["iron"] >= BlacksmithVariables.weaponCost * 5)
                        {
                            player.Loot["gold"] -= BlacksmithVariables.weaponCost * 5;
                            player.Loot["iron"] -= BlacksmithVariables.weaponCost * 5;
                            BlacksmithVariables.weaponLevel = BlacksmithVariables.weaponLevel * 2;
                            BlacksmithVariables.weaponCost = BlacksmithVariables.weaponCost * 2;

                        }
                        else
                        {
                            string prdel = "”You’re outta gold or don’t have the right materials. What do you expect me to do, magic it into existence?”" +
                                "”Come back when you’re better prepared.”";
                            foreach (char c in prdel)
                            {
                                Console.Write(c);
                                //Thread.Sleep(12);
                            }
                            Console.WriteLine();

                        }
                        break;
                    case ConsoleKey.S:
                        if (player.Loot["gold"] >= BlacksmithVariables.voidStaffCost * 5 && player.Loot["ethernalEnergy"] >= BlacksmithVariables.voidStaffCost * 5)
                        {
                            player.Loot["gold"] -= BlacksmithVariables.voidStaffCost * 5;
                            player.Loot["ethernalEnergy"] -= BlacksmithVariables.voidStaffCost * 5;
                            BlacksmithVariables.voidStaffLevel = BlacksmithVariables.voidStaffLevel * 2;
                            BlacksmithVariables.voidStaffCost = BlacksmithVariables.voidStaffCost * 2;

                        }
                        else
                        {
                            string prdel = "”You’re outta gold or don’t have the right materials. What do you expect me to do, magic it into existence?”" +
                                "”Come back when you’re better prepared.”";
                            foreach (char c in prdel)
                            {
                                Console.Write(c);
                                //Thread.Sleep(12);
                            }
                            Console.WriteLine();
                        }
                        break;
                    case ConsoleKey.A:
                        if (player.Loot["gold"] >= BlacksmithVariables.armourCost * 5 && player.Loot["leather"] >= BlacksmithVariables.armourCost * 5)
                        {
                            player.Loot["gold"] -= BlacksmithVariables.armourCost * 5;
                            player.Loot["leather"] -= BlacksmithVariables.armourCost * 5;
                            BlacksmithVariables.armourLevel = BlacksmithVariables.armourLevel * 2;
                            BlacksmithVariables.armourCost = BlacksmithVariables.armourCost * 2;

                        }
                        else
                        {
                            string prdel = "”You’re outta gold or don’t have the right materials. What do you expect me to do, magic it into existence?”" +
                                "”Come back when you’re better prepared.”";
                            foreach (char c in prdel)
                            {
                                Console.Write(c);
                                //Thread.Sleep(12);
                            }
                            Console.WriteLine();
                        }
                        break;
                    case ConsoleKey.E:
                        wantToUpgrade = false;
                        break;
                }

            }
        }

        static void DragonCutScene()
        {
            string[] texts = { "Rowan, battered but victorious, turns to see the princess stepping forward, her eyes wide with gratitude. ”You did it,” she breathes, her voice filled with awe. ”You actually did it.”",
                                "”Thank you, Rowan. You risked everything to save me, and I will never forget it.”",
                                "As they step out of the cavern together, the first light of dawn breaks over the horizon, casting a golden glow over the land. The kingdom will tell tales of this day, of the villager who faced a dragon—and won."};

            for (int i = 0; i < texts.Length; i++) //aby to bylo vypsany hezky a hrac to mel lepsi sanci stihnout precist
            {
                foreach (char c in texts[i])
                {
                    Console.Write(c);
                    Thread.Sleep(12);
                }
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO THE GAME TALE TO BE TOLD!");
            Console.WriteLine("Press any button to continue");
            Console.ReadKey();
            //BasicInfoPrint();
            IntroCutScene();
            Dictionary<string, int> Loot = new Dictionary<string, int>{
            { "gold", 0 },
            { "iron", 0 },
            { "leather", 0 },
            { "ethernalEnergy", 0 }
            };

            Player player = new Player("Rowan", 300, 1, "sword", Loot); //pridani hrace a typu nepratel (samotnou tridu pro kovare jsem nedelal)
            Enemy bandit = new Bandit();
            Enemy knight = new Knight();
            Enemy vampire = new Vampire();
            Enemy wizard = new Wizard();
            Enemy dragon = new Dragon();
            bool gameEnd = false;
            int blacksmithRepetitions = 0; //int aby se mi neobjevovala intro hlaska od kovare pokazdy, ale jen jednou
            int shieldCount = 0;
            int voidCount = 0;
            while (!gameEnd)
            {
                bool userInput = true; //bool pro ukonceni moznych operaci pred duelem
                bool bothAlive = true; //bool pro urceni jestli oba z duelu jsou nazivu

                while (userInput)
                {
                    Console.WriteLine("Press S - to show stats    B - to summon blacksmith   R - to duel the dragon   E - to look for a new enemy");
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.S:
                            player.WriteStats(BlacksmithVariables.armourLevel, BlacksmithVariables.weaponLevel, BlacksmithVariables.voidStaffLevel);
                            Console.WriteLine("");
                            Console.WriteLine("You have " + shieldCount + " shields");
                            Console.WriteLine("You have " + voidCount + " void charges");
                            break;
                        case ConsoleKey.B:
                            Blacksmith(blacksmithRepetitions, player);
                            blacksmithRepetitions++;
                            break;
                        case ConsoleKey.R:
                            dragon.SetHealth();
                            double playerStrikes = 0;
                            double voidDamage = 0;
                            while (bothAlive)
                            {
                                bool userCantPressCorrectButtons = true;
                                while (userCantPressCorrectButtons)
                                {
                                    Console.WriteLine("Do you wish to use your voidStaff charge?   W - yes   E - no");
                                    ConsoleKeyInfo keyInfo2 = Console.ReadKey(true);
                                    switch (keyInfo2.Key)
                                    {
                                        case ConsoleKey.W:
                                            if (voidCount > 0)
                                            {
                                                voidDamage = Math.Round(player.VoidStrike(BlacksmithVariables.voidStaffLevel), 2);
                                                voidCount--;
                                                dragon.GetDamage(voidDamage);
                                                Console.WriteLine("Player strikes for: " + voidDamage);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Gg boa, you aint got no void charges left boa");
                                                playerStrikes = Math.Round(player.PlayerStrikes(BlacksmithVariables.weaponLevel), 2);
                                                dragon.GetDamage(playerStrikes);
                                                Console.WriteLine("Player strikes for: " + playerStrikes);
                                            }
                                            userCantPressCorrectButtons = false;
                                            break;
                                        case ConsoleKey.E:
                                            userCantPressCorrectButtons = false;
                                            playerStrikes = Math.Round(player.PlayerStrikes(BlacksmithVariables.weaponLevel), 2);
                                            dragon.GetDamage(playerStrikes);
                                            Console.WriteLine("Player strikes for: " + playerStrikes);
                                            break;

                                    }
                                }
                                //double playerStrikes = Math.Round(player.PlayerStrikes(BlacksmithVariables.weaponLevel), 2);

                                Console.WriteLine("Dragons current health is: " + dragon.GetHealth());
                                if (!dragon.IsAlive())
                                {
                                    DragonCutScene();
                                    bothAlive = false;
                                    gameEnd = true;
                                    Console.ReadKey();
                                    Environment.Exit(0);
                                    break;
                                }
                                double dragonStrikes = Math.Round(dragon.EnemyStrikes(), 2);
                                Console.WriteLine("Dragon fires a FIREBALL: " + dragonStrikes);
                                bool userCantPressCorrectButtons1 = true;
                                while (userCantPressCorrectButtons1)
                                {
                                    Console.WriteLine("If you want to block this attack press Q, if you want to tank it like a champ press W");
                                    ConsoleKeyInfo keyInfo1 = Console.ReadKey(true);
                                    switch (keyInfo1.Key)
                                    {
                                        case ConsoleKey.Q:
                                            if (shieldCount > 0)
                                            {
                                                player.GetDamage(0, 1);
                                                shieldCount--;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Gg boa, you aint got no shields left boa");
                                                player.GetDamage(dragonStrikes, BlacksmithVariables.armourLevel);
                                            }
                                            userCantPressCorrectButtons1 = false;
                                            break;
                                        case ConsoleKey.W:

                                            player.GetDamage(dragonStrikes, BlacksmithVariables.armourLevel);
                                            userCantPressCorrectButtons1 = false;
                                            break;

                                    }
                                }
                                Console.WriteLine("Rowans current health is: " + Math.Round(player.GetHealth()), 2);
                                if (!player.IsAlive())
                                {
                                    Console.WriteLine("Rowan was defeated and the princess kept in the prison under the surveillance of the cruel dragon");
                                    bothAlive = false;
                                    gameEnd = true;
                                    Console.ReadKey();
                                    Environment.Exit(0);
                                    break;
                                }
                                Console.WriteLine();
                            }

                            break;
                        case ConsoleKey.E:
                            userInput = false;
                            break;
                    }


                }
                if (gameEnd) break;
                Random random = new Random();
                int rnd = random.Next(0, 6);
                //int rnd = 0;
                bool correctInput = true;   //bool pro keyboard input hrace
                switch (rnd)
                {
                    case 0:
                        bandit.SetHealth();

                        while (correctInput)
                        {

                            Console.Clear();
                            Console.WriteLine("You met a bandit");
                            Console.WriteLine("Press E: to pass this enemy.    Press W: to attack");
                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                            switch (keyInfo.Key)
                            {
                                case ConsoleKey.E:

                                    correctInput = false;
                                    break;

                                case ConsoleKey.W:

                                    //correctInput = false;
                                    while (bothAlive)
                                    {
                                        double playerStrikes = Math.Round(player.PlayerStrikes(BlacksmithVariables.weaponLevel), 2);
                                        Console.WriteLine("Player strikes for: " + playerStrikes);
                                        bandit.GetDamage(playerStrikes);
                                        Console.WriteLine("Bandits current health is: " + Math.Round(bandit.GetHealth(), 2));
                                        if (!bandit.IsAlive())
                                        {
                                            Console.WriteLine("Bandit was defeated!");
                                            bothAlive = false;
                                            player.LootToAdd(1);
                                            userInput = true;
                                            /*Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey(); // Pause before finding a new enemy*/
                                            break;
                                        }
                                        double banditStrikes = Math.Round(bandit.EnemyStrikes(), 2);
                                        Console.WriteLine("Bandit strikes for: " + banditStrikes);
                                        bool userCantPressCorrectButtons = true;
                                        while (userCantPressCorrectButtons)
                                        {
                                            Console.WriteLine("If you want to block this attack press Q, if you want to tank it like a champ press W");
                                            ConsoleKeyInfo keyInfo1 = Console.ReadKey(true);
                                            switch (keyInfo1.Key)
                                            {
                                                case ConsoleKey.Q:
                                                    if (shieldCount > 0)
                                                    {
                                                        player.GetDamage(0, 1);
                                                        shieldCount--;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Gg boa, you aint got no shields left boa");
                                                        player.GetDamage(banditStrikes, BlacksmithVariables.armourLevel);
                                                    }
                                                    userCantPressCorrectButtons = false;
                                                    break;
                                                case ConsoleKey.W:

                                                    player.GetDamage(banditStrikes, BlacksmithVariables.armourLevel);
                                                    userCantPressCorrectButtons = false;
                                                    break;

                                            }
                                        }

                                        Console.WriteLine("Rowans current health is: " + Math.Round(player.GetHealth()), 2);
                                        if (!player.IsAlive())
                                        {
                                            Console.WriteLine("Rowan was defeated!");
                                            bothAlive = false;
                                            gameEnd = true;
                                            break;
                                        }
                                        Console.WriteLine();
                                    }
                                    break;
                            }

                        }
                        break;
                    case 1:
                        bandit.SetHealth();

                        while (correctInput)
                        {
                            Console.Clear();
                            Console.WriteLine("You met a bandit");
                            Console.WriteLine("Press E: to pass this enemy.    Press W: to attack");
                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                            switch (keyInfo.Key)
                            {
                                case ConsoleKey.E:

                                    correctInput = false;
                                    break;

                                case ConsoleKey.W:

                                    correctInput = false;
                                    while (bothAlive)
                                    {
                                        double playerStrikes = Math.Round(player.PlayerStrikes(BlacksmithVariables.weaponLevel), 2);
                                        Console.WriteLine("Player strikes for: " + playerStrikes);
                                        bandit.GetDamage(playerStrikes);
                                        Console.WriteLine("Bandits current health is: " + bandit.GetHealth());
                                        if (!bandit.IsAlive())
                                        {
                                            Console.WriteLine("Bandit was defeated!");
                                            bothAlive = false;
                                            player.LootToAdd(1);
                                            userInput = true;
                                            break;
                                        }
                                        double banditStrikes = Math.Round(bandit.EnemyStrikes(), 2);
                                        Console.WriteLine("Bandit strikes for: " + banditStrikes);
                                        bool userCantPressCorrectButtons = true;
                                        while (userCantPressCorrectButtons)
                                        {
                                            Console.WriteLine("If you want to block this attack press Q, if you want to tank it like a champ press W");
                                            ConsoleKeyInfo keyInfo1 = Console.ReadKey(true);
                                            switch (keyInfo1.Key)
                                            {
                                                case ConsoleKey.Q:
                                                    if (shieldCount > 0)
                                                    {
                                                        player.GetDamage(0, 1);
                                                        shieldCount--;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Gg boa, you aint got no shields left boa");
                                                        player.GetDamage(banditStrikes, BlacksmithVariables.armourLevel);
                                                    }
                                                    userCantPressCorrectButtons = false;
                                                    break;
                                                case ConsoleKey.W:

                                                    player.GetDamage(banditStrikes, BlacksmithVariables.armourLevel);
                                                    userCantPressCorrectButtons = false;
                                                    break;

                                            }
                                        }

                                        Console.WriteLine("Rowans current health is: " + Math.Round(player.GetHealth()), 2);
                                        if (!player.IsAlive())
                                        {
                                            Console.WriteLine("Rowan was defeated!");
                                            bothAlive = false;
                                            gameEnd = true;
                                            break;
                                        }
                                        Console.WriteLine();
                                    }
                                    break;
                            }

                        }
                        break;
                    case 2:
                        bandit.SetHealth();

                        while (correctInput)
                        {
                            Console.Clear();
                            Console.WriteLine("You met a bandit");
                            Console.WriteLine("Press E: to pass this enemy.    Press W: to attack");
                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                            switch (keyInfo.Key)
                            {
                                case ConsoleKey.E:

                                    correctInput = false;
                                    break;

                                case ConsoleKey.W:

                                    correctInput = false;
                                    while (bothAlive)
                                    {
                                        double playerStrikes = Math.Round(player.PlayerStrikes(BlacksmithVariables.weaponLevel), 2);
                                        Console.WriteLine("Player strikes for: " + playerStrikes);
                                        bandit.GetDamage(playerStrikes);
                                        Console.WriteLine("Bandits current health is: " + bandit.GetHealth());
                                        if (!bandit.IsAlive())
                                        {
                                            Console.WriteLine("Bandit was defeated!");
                                            bothAlive = false;
                                            player.LootToAdd(1);
                                            userInput = true;
                                            break;
                                        }
                                        double banditStrikes = Math.Round(bandit.EnemyStrikes(), 2);
                                        Console.WriteLine("Bandit strikes for: " + banditStrikes);
                                        bool userCantPressCorrectButtons = true;
                                        while (userCantPressCorrectButtons)
                                        {
                                            Console.WriteLine("If you want to block this attack press Q, if you want to tank it like a champ press W");
                                            ConsoleKeyInfo keyInfo1 = Console.ReadKey(true);
                                            switch (keyInfo1.Key)
                                            {
                                                case ConsoleKey.Q:
                                                    if (shieldCount > 0)
                                                    {
                                                        player.GetDamage(0, 1);
                                                        shieldCount--;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Gg boa, you aint got no shields left boa");
                                                        player.GetDamage(banditStrikes, BlacksmithVariables.armourLevel);
                                                    }
                                                    userCantPressCorrectButtons = false;
                                                    break;
                                                case ConsoleKey.W:

                                                    player.GetDamage(banditStrikes, BlacksmithVariables.armourLevel);
                                                    userCantPressCorrectButtons = false;
                                                    break;

                                            }
                                        }
                                        Console.WriteLine("Rowans current health is: " + Math.Round(player.GetHealth()), 2);
                                        if (!bandit.IsAlive())
                                        {
                                            Console.WriteLine("Rowan was defeated!");
                                            bothAlive = false;
                                            gameEnd = true;
                                            break;
                                        }
                                        Console.WriteLine();
                                    }
                                    break;
                            }

                        }
                        break;
                    case 3:
                        knight.SetHealth();

                        while (correctInput)
                        {
                            Console.Clear();
                            Console.WriteLine("You met a knight");
                            Console.WriteLine("Press E: to pass this enemy.    Press W: to attack");
                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                            switch (keyInfo.Key)
                            {
                                case ConsoleKey.E:

                                    correctInput = false;
                                    break;

                                case ConsoleKey.W:

                                    correctInput = false;
                                    while (bothAlive)
                                    {
                                        double playerStrikes = Math.Round(player.PlayerStrikes(BlacksmithVariables.weaponLevel), 2);
                                        Console.WriteLine("Player strikes for: " + playerStrikes);
                                        knight.GetDamage(playerStrikes);
                                        Console.WriteLine("Knights current health is: " + knight.GetHealth());
                                        if (!knight.IsAlive())
                                        {
                                            Console.WriteLine("Knight was defeated!");
                                            bothAlive = false;
                                            player.LootToAdd(5);
                                            shieldCount++;
                                            userInput = true;
                                            break;
                                        }
                                        double knightStrikes = Math.Round(knight.EnemyStrikes(), 2);
                                        Console.WriteLine("Knight strikes for: " + knightStrikes);
                                        bool userCantPressCorrectButtons = true;
                                        while (userCantPressCorrectButtons)
                                        {
                                            Console.WriteLine("If you want to block this attack press Q, if you want to tank it like a champ press W");
                                            ConsoleKeyInfo keyInfo1 = Console.ReadKey(true);
                                            switch (keyInfo1.Key)
                                            {
                                                case ConsoleKey.Q:
                                                    if (shieldCount > 0)
                                                    {
                                                        player.GetDamage(0, 1);
                                                        shieldCount--;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Gg boa, you aint got no shields left boa");
                                                        player.GetDamage(knightStrikes, BlacksmithVariables.armourLevel);
                                                    }
                                                    userCantPressCorrectButtons = false;
                                                    break;
                                                case ConsoleKey.W:

                                                    player.GetDamage(knightStrikes, BlacksmithVariables.armourLevel);
                                                    userCantPressCorrectButtons = false;
                                                    break;

                                            }
                                        }
                                        Console.WriteLine("Rowans current health is: " + Math.Round(player.GetHealth()), 2);
                                        if (!player.IsAlive())
                                        {
                                            Console.WriteLine("Rowan was defeated!");
                                            bothAlive = false;
                                            gameEnd = true;
                                            break;
                                        }
                                        Console.WriteLine();
                                    }
                                    break;
                            }

                        }
                        break;
                    case 4:
                        vampire.SetHealth();

                        while (correctInput)
                        {
                            Console.Clear();
                            Console.WriteLine("You met a vampire");
                            Console.WriteLine("Press E: to pass this enemy.    Press W: to attack");
                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                            switch (keyInfo.Key)
                            {
                                case ConsoleKey.E:

                                    correctInput = false;
                                    break;

                                case ConsoleKey.W:

                                    correctInput = false;
                                    correctInput = false;
                                    while (bothAlive)
                                    {
                                        double playerStrikes = Math.Round(player.PlayerStrikes(BlacksmithVariables.weaponLevel), 2);
                                        Console.WriteLine("Player strikes for: " + playerStrikes);
                                        vampire.GetDamage(playerStrikes);
                                        Console.WriteLine("Vampires current health is: " + vampire.GetHealth());
                                        if (!vampire.IsAlive())
                                        {
                                            Console.WriteLine("Vampire was defeated!");
                                            bothAlive = false;
                                            player.LootToAdd(0);
                                            player.SetHealth();
                                            userInput = true;
                                            break;
                                        }
                                        double vampireStrikes = Math.Round(vampire.EnemyStrikes(), 2);
                                        Console.WriteLine("Vampire strikes for: " + vampireStrikes);
                                        bool userCantPressCorrectButtons = true;
                                        while (userCantPressCorrectButtons)
                                        {
                                            Console.WriteLine("If you want to block this attack press Q, if you want to tank it like a champ press W");
                                            ConsoleKeyInfo keyInfo1 = Console.ReadKey(true);
                                            switch (keyInfo1.Key)
                                            {
                                                case ConsoleKey.Q:
                                                    if (shieldCount > 0)
                                                    {
                                                        player.GetDamage(0, 1);
                                                        shieldCount--;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Gg boa, you aint got no shields left boa");
                                                        player.GetDamage(vampireStrikes, BlacksmithVariables.armourLevel);
                                                    }
                                                    userCantPressCorrectButtons = false;
                                                    break;
                                                case ConsoleKey.W:

                                                    player.GetDamage(vampireStrikes, BlacksmithVariables.armourLevel);
                                                    userCantPressCorrectButtons = false;
                                                    break;

                                            }
                                        }
                                        Console.WriteLine("Rowans current health is: " + Math.Round(player.GetHealth()), 2);
                                        if (!player.IsAlive())
                                        {
                                            Console.WriteLine("Rowan was defeated!");
                                            bothAlive = false;
                                            gameEnd = true;
                                            break;
                                        }
                                        Console.WriteLine();
                                    }
                                    break;
                            }

                        }
                        break;
                    case 5:
                        wizard.SetHealth();
                        //
                        while (correctInput)
                        {
                            Console.Clear();
                            Console.WriteLine("You met a wizard");
                            Console.WriteLine("Press E: to pass this enemy.    Press W: to attack");
                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                            switch (keyInfo.Key)
                            {
                                case ConsoleKey.E:

                                    correctInput = false;
                                    break;

                                case ConsoleKey.W:

                                    correctInput = false;
                                    while (bothAlive)
                                    {
                                        double playerStrikes = Math.Round(player.PlayerStrikes(BlacksmithVariables.weaponLevel), 2);
                                        Console.WriteLine("Player strikes for: " + playerStrikes);
                                        wizard.GetDamage(playerStrikes);
                                        Console.WriteLine("Wizards current health is: " + wizard.GetHealth());
                                        if (!wizard.IsAlive())
                                        {
                                            Console.WriteLine("Wizard was defeated!");
                                            bothAlive = false;
                                            player.LootToAdd(3);
                                            random = new Random();
                                            if (random.Next(0, 3) == 0)
                                            {
                                                voidCount++;
                                            }
                                            userInput = true;
                                            break;
                                        }
                                        double wizardStrikes = Math.Round(vampire.EnemyStrikes(), 2);
                                        Console.WriteLine("Wizard strikes for: " + wizardStrikes);
                                        bool userCantPressCorrectButtons = true;
                                        while (userCantPressCorrectButtons)
                                        {
                                            Console.WriteLine("If you want to block this attack press Q, if you want to tank it like a champ press W");
                                            ConsoleKeyInfo keyInfo1 = Console.ReadKey(true);
                                            switch (keyInfo1.Key)
                                            {
                                                case ConsoleKey.Q:
                                                    if (shieldCount > 0)
                                                    {
                                                        player.GetDamage(0, 1);
                                                        shieldCount--;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Gg boa, you aint got no shields left boa");
                                                        player.GetDamage(wizardStrikes, BlacksmithVariables.armourLevel);
                                                    }
                                                    userCantPressCorrectButtons = false;
                                                    break;
                                                case ConsoleKey.W:

                                                    player.GetDamage(wizardStrikes, BlacksmithVariables.armourLevel);
                                                    userCantPressCorrectButtons = false;
                                                    break;

                                            }
                                        }
                                        Console.WriteLine("Rowans current health is: " + Math.Round(player.GetHealth()), 2);
                                        if (!player.IsAlive())
                                        {
                                            Console.WriteLine("Rowan was defeated!");
                                            bothAlive = false;
                                            gameEnd = true;
                                            break;
                                        }
                                        Console.WriteLine();
                                    }
                                    break;
                            }

                        }
                        break;
                }
            }


            Console.ReadKey();
        }
    }
}
