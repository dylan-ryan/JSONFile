using System;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Shop
    {
        private Currency currency;
        private Player player;
        private Map map;
        private UI ui;
        public int shopPosX;
        public int shopPosY;

        private string[] items = { "1. Health Potion", "2. Enemy Freeze", "3. Invincibility" };
        private int[] prices = { 1, 2, 3 };  // Set the prices for items
        private bool isOpen = false;

        public Shop(Currency currency, Player player, Map map, UI ui, int x, int y)
        {
            this.currency = currency;
            this.player = player;
            this.map = map;
            this.ui = ui;
            this.shopPosX = x;  // Shop position on the map
            this.shopPosY = y;
        }

        public void Update()
        {
            // Check if player is at the shop's location ('$')
            if (player.posX == shopPosX && player.posY == shopPosY && !isOpen)
            {
                OpenShop();
            }
        }

        public void OpenShop()
        {
            isOpen = true;
            DisplayShop();
        }

        public void DisplayShop()
        {
            int shopStartPosX = 45;
            int shopStartPosY = 9;

            // Hardcoded display lines for the shop
            Console.SetCursorPosition(shopStartPosX, shopStartPosY);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("      SHOP       ");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(shopStartPosX, shopStartPosY + 2);
            Console.WriteLine("1. Health Potion - 1 coin");
            Console.SetCursorPosition(shopStartPosX, shopStartPosY + 3);
            Console.WriteLine("2. Enemy Freeze - 2 coins");
            Console.SetCursorPosition(shopStartPosX, shopStartPosY + 4);
            Console.WriteLine("3. Invincibility - 3 coins");

            Console.SetCursorPosition(shopStartPosX, shopStartPosY + 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(shopStartPosX, shopStartPosY + 6);
            Console.WriteLine("Currency: " + currency.currency);
            Console.SetCursorPosition(shopStartPosX, shopStartPosY + 7);
            Console.WriteLine("Select an item (1-3) or press ESC to exit.");
        }

        public void HandleInput(ConsoleKeyInfo input)
        {
            if (isOpen)
            {
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        BuyHealth();
                        break;
                    case ConsoleKey.D2:
                        BuyFreeze();
                        break;
                    case ConsoleKey.D3:
                        BuyInvincibility();
                        break;
                    case ConsoleKey.Escape:
                        isOpen = false;
                        ClearShop(9, 17);
                        break;
                    default:
                        Console.SetCursorPosition(45, 17);
                        Console.WriteLine("Invalid input                                               ");
                        break;
                }
            }
        }

        private void BuyHealth()
        {
            Console.SetCursorPosition(45, 17);
            if (currency.currency >= prices[0])
            {
                currency.LoseCurrency(prices[0]);
                Console.WriteLine("You bought a Health Potion!");

                ItemHealth healthPotion = new ItemHealth(map, player, ui);
                healthPotion.DoYourJob();
            }
            else
            {
                Console.WriteLine("Not enough currency to buy Health Potion.      ");
            }
        }

        private void BuyFreeze()
        {
            Console.SetCursorPosition(45, 17);
            if (currency.currency >= prices[1])
            {
                currency.LoseCurrency(prices[1]);
                Console.WriteLine("You bought Freeze!");

                ItemFreeze freeze = new ItemFreeze(map, player, ui);
                freeze.DoYourJob();
            }
            else
            {
                Console.WriteLine("Not enough currency to buy Enemy Freeze.        ");
            }
        }

        private void BuyInvincibility()
        {
            Console.SetCursorPosition(45, 17);
            if (currency.currency >= prices[2])
            {
                currency.LoseCurrency(prices[2]);
                Console.WriteLine("You bought Invincibility!");

                ItemInvincible invincibility = new ItemInvincible(map, player, ui);
                invincibility.DoYourJob();
            }
            else
            {
                Console.WriteLine("Not enough currency to buy Invincibility.             ");
            }
        }

        // Draw the shop as '$' on the map
        public void DrawShop()
        {
            map.map[shopPosY, shopPosX] = '$';
        }

        public bool IsShopOpen()
        {
            return isOpen;
        }

        public void ClearShop( int startY, int endY)
        {
            for (int y = startY; y <= endY; y++)
            {
                Console.SetCursorPosition(45, y); // Always set the cursor to X=45
                Console.Write(new string(' ', Console.WindowWidth - 45)); // Clear the line from X=45 to the end of the console
            }
        }
    }
}
