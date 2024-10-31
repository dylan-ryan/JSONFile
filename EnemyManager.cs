using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class EnemyManager
    {

        private Player player;
        private Map map;
        private Currency currency;
        public List<Enemy> enemies;

        public EnemyManager(Player player, Map map, Currency currency)
        {
            this.player = player;
            this.map = map;
            enemies = new List<Enemy>();
            this.currency = currency;
        }


        public void PlaceGoblins(int num)
        {
            Random random = new Random();

            for (int i = 0; i < num; i++)
            {
                while (true)
                {
                    int x = random.Next(8, map.width - 70);
                    int y = random.Next(16, map.height - 2);

                    if (map.map[y, x] == '`')
                    {
                        EnemyGoblin goblin = new EnemyGoblin(map, player,currency);
                        goblin.posX = x;
                        goblin.posY = y;
                        map.map[y, x] = goblin.Char;
                        enemies.Add(goblin);
                        break;
                    }
                }
            }
        }

        public void PlaceOrcs(int num)
        {
            Random random = new Random();

            for (int i = 0; i < num; i++)
            {
                while (true)
                {
                    int x = random.Next(60, map.width - 2);
                    int y = random.Next(10, map.height - 2);

                    if (map.map[y, x] == '`')
                    {
                        EnemyOrc orc = new EnemyOrc(map, player, currency);
                        orc.posX = x;
                        orc.posY = y;
                        map.map[y, x] = orc.Char;
                        enemies.Add(orc);
                        break;
                    }
                }
            }
        }

        public void PlaceMinotaurs(int num)
        {
            Random random = new Random();

            for (int i = 0; i < num; i++)
            {
                while (true)
                {
                    int x = random.Next(2, map.width - 30);
                    int y = random.Next(2, map.height - 13);

                    if (map.map[y, x] == '`')
                    {
                        EnemyMinotaur minotaur = new EnemyMinotaur(map, player,currency);
                        minotaur.posX = x;
                        minotaur.posY = y;
                        map.map[y, x] = minotaur.Char;
                        enemies.Add(minotaur);
                        break;
                    }
                }
            }
        }

        public void PlaceDragons(int num)
        {
            Random random = new Random();

            for (int i = 0; i < num; i++)
            {
                while (true)
                {
                    int x = random.Next(80, map.width - 2);
                    int y = random.Next(2, map.height - 2);

                    if (map.map[y, x] == '`')
                    {
                        EnemyDragon dragon = new EnemyDragon(map, player, currency);
                        dragon.posX = x;
                        dragon.posY = y;
                        map.map[y, x] = dragon.Char;
                        enemies.Add(dragon);
                        break;
                    }
                }
            }
        }


        public void UpdateEnemies()
        {
            if (player.freezeEnemies == false)
            {
                foreach (Enemy enemy in enemies)
                {
                    enemy.Update();
                }
            }
        }

        public void DrawEnemies()
        {
            foreach(Enemy enemy in enemies) 
            {
                enemy.Draw();
            }
        }


    }
}
