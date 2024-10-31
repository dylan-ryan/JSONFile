using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Quests
    {
        private int goblinsKilled;
        private int minotaursKilled;
        private int orcsKilled;
        private bool dragonKilled;
        private Currency currency;

        private bool quest1Completed;
        private bool quest2Completed;
        private bool quest3Completed;
        private bool quest4Completed;

        public Quests(Currency currency)
        {
            this.currency = currency;
            goblinsKilled = 0;
            minotaursKilled = 0;
            orcsKilled = 0;
            dragonKilled = false;

            quest1Completed = false;
            quest2Completed = false;
            quest3Completed = false;
            quest4Completed = false;
        }

        public void UpdateQuestStatus(string enemyType)
        {
            switch (enemyType)
            {
                case "Goblin":
                    goblinsKilled++;
                    if (!quest1Completed) CheckQuest1();
                    break;
                case "Minotaur":
                    minotaursKilled++;
                    if (!quest2Completed) CheckQuest2();
                    break;
                case "Orc":
                    orcsKilled++;
                    if (!quest3Completed) CheckQuest3();
                    break;
                case "Dragon":
                    if (!quest4Completed) CheckQuest4();
                    break;
            }
        }

        private void CheckQuest1()
        {
            if (goblinsKilled >= 3)
            {
                quest1Completed = true;
                Console.SetCursorPosition(0, 35);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Quest 1 Complete: Kill 3 Goblins! Reward: 10 currency.");
                Console.ForegroundColor = ConsoleColor.White;
                currency.AddCurrency(10);
            }
        }

        private void CheckQuest2()
        {
            if (minotaursKilled >= 3)
            {
                quest2Completed = true;
                Console.SetCursorPosition(0, 36);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Quest 2 Complete: Kill 3 Minotaurs! Reward: 15 currency.");
                Console.ForegroundColor = ConsoleColor.White;
                currency.AddCurrency(15);
            }
        }

        private void CheckQuest3()
        {
            if (orcsKilled >= 3)
            {
                quest3Completed = true;
                Console.SetCursorPosition(0, 37);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Quest 3 Complete: Kill 3 Orcs! Reward: 20 currency.");
                Console.ForegroundColor = ConsoleColor.White;
                currency.AddCurrency(20);
            }
        }

        private void CheckQuest4()
        {
            quest4Completed = true;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Quest 4 Complete: Kill the Dragon! YOU WIN!");
            Console.WriteLine("Press any key to exit.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Environment.Exit(0);
        }

        // Display quest progress on the screen
        public void DisplayQuests()
        {
            if (!quest1Completed)
            {
                Console.SetCursorPosition(0, 35);
                Console.WriteLine($"Quest 1: Kill 3 Goblins ({goblinsKilled}/3)                                         ");
            }
            else
            {
                Console.SetCursorPosition(0, 35);
                Console.WriteLine($"Quest 1: Completed! Rewarded 10 Currency.                                              ");
            }

            if (!quest2Completed)
            {
                Console.SetCursorPosition(0, 36);
                Console.WriteLine($"Quest 2: Kill 3 Minotaurs ({minotaursKilled}/3)                 ");
            }
            else
            {
                Console.SetCursorPosition(0, 36);
                Console.WriteLine($"Quest 2: Completed! Rewarded 15 Currency.                                   ");
            }

            if (!quest3Completed)
            {
                Console.SetCursorPosition(0, 37);
                Console.WriteLine($"Quest 3: Kill 3 Orcs ({orcsKilled}/3)                                   ");
            }
            else
            {
                Console.SetCursorPosition(0, 37);
                Console.WriteLine($"Quest 3: Completed! Rewarded 20 Currency.                                ");
            }

            if (!quest4Completed)
            {
                Console.SetCursorPosition(0, 38);
                Console.WriteLine("Quest 4: Kill the Dragon to Win!                                             ");
            }
            else
            {
                Console.SetCursorPosition(0, 38);
                Console.WriteLine("Quest 4: Completed! YOU WIN!                                       ");
            }
        }
    }
}
