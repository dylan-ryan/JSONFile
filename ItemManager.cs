using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class ItemManager
    {

        private Player player;
        private Map map;
        private UI ui;
        public List<Item> items;

        public ItemManager(Player player, Map map, UI ui)
        {
            this.player = player;
            this.map = map;
            this.ui = ui;
            items = new List<Item>();
        }


        public void PlaceHealthPotions(int num)
        {
            Random random = new Random();

            for (int i = 0; i < num; i++)
            {
                while (true)
                {
                    int x = random.Next(2, map.width - 2);
                    int y = random.Next(2, map.height - 2);

                    if (map.map[y, x] == '`')
                    {
                        ItemHealth healthPotion = new ItemHealth(map, player, ui);
                        healthPotion.posX = x;
                        healthPotion.posY = y;
                        map.map[y, x] = healthPotion.Char;
                        items.Add(healthPotion);
                        break;
                    }
                }
            }
        }

        public void PlaceInvincibility(int num)
        {
            Random random = new Random();

            for (int i = 0; i < num; i++)
            {
                while (true)
                {
                    int x = random.Next(2, map.width - 2);
                    int y = random.Next(2, map.height - 2);

                    if (map.map[y, x] == '`')
                    {
                        ItemInvincible invincible = new ItemInvincible(map, player, ui);
                        invincible.posX = x;
                        invincible.posY = y;
                        map.map[y, x] = invincible.Char;
                        items.Add(invincible);
                        break;
                    }
                }
            }
        }

        public void PlaceFreeze(int num)
        {
            Random random = new Random();

            for (int i = 0; i < num; i++)
            {
                while (true)
                {
                    int x = random.Next(2, map.width - 2);
                    int y = random.Next(2, map.height - 2);

                    if (map.map[y, x] == '`')
                    {
                        ItemFreeze freeze = new ItemFreeze(map, player, ui);
                        freeze.posX = x;
                        freeze.posY = y;
                        map.map[y, x] = freeze.Char;
                        items.Add(freeze);
                        break;
                    }
                }
            }
        }



        public void UpdateItems()
        {
            foreach (Item item in items)
            {
                item.Update();
            }
        }

        public void DrawItems()
        {
            foreach (Item item in items)
            {
                item.Draw();
            }
        }



    }
}
