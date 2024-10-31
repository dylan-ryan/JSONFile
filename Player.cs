using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Player
    {
        public char playerChar;
        public int moves;
        public int health;
        public int attack;
        public int posX;
        public int posY;
        public int nextPosX;
        public int nextPosY;
        public int lastPosX;
        public int lastPosY;
        public bool freezeEnemies;
        private Map map;
        private EnemyManager enemyManager;
        private ItemManager itemManager;
        public HealthSystem healthSystem;
        private UI ui;

        public string LastKilledEnemy { get; set; }

        public void SetStuff(Map map, EnemyManager enemyManager, UI ui, ItemManager itemManager)
        {
            this.map = map;
            this.enemyManager = enemyManager;
            this.itemManager = itemManager;
            this.ui = ui;
            health = Settings.playerHealth;
            healthSystem = new HealthSystem(health);
            moves = 0;
            attack = Settings.playerAttack;
            playerChar = Settings.playerChar;
            posX = Settings.playerStartPosX;
            posY = Settings.playerStartPosY;
            freezeEnemies = false;
            LastKilledEnemy = null;
        }

        public void Update(ConsoleKeyInfo input)
        {
            if (input.Key == ConsoleKey.W)
            {
                Move(0, -1);
            }
            else if (input.Key == ConsoleKey.A)
            {
                Move(-1, 0);
            }
            else if (input.Key == ConsoleKey.S)
            {
                Move(0, 1);
            }
            else if (input.Key == ConsoleKey.D)
            {
                Move(1, 0);
            }
        }

        // Moves the player
        public void Move(int nextX, int nextY)
        {
            moves++;

            nextPosX = posX + nextX;
            nextPosY = posY + nextY;

            lastPosY = posY;
            lastPosX = posX;

            CheckNextMove();

            posY = nextPosY;
            posX = nextPosX;
        }

        public void Draw()
        {
            map.map[lastPosY, lastPosX] = '`';
            map.map[posY, posX] = playerChar;
        }

        public void CantMove()
        {
            nextPosY = lastPosY;
            nextPosX = lastPosX;
        }

        public void CheckNextMove()
        {
            if (posX != map.width - 1 && posY != map.height - 1 && posX != 0 && posY != 0)
            {
                if (map.map[posY, nextPosX] == '^' || map.map[nextPosY, posX] == '^')
                {
                    CantMove();
                }
                else if (map.map[posY, nextPosX] == '~' || map.map[nextPosY, posX] == '~')
                {
                    CantMove();
                }
                else if (map.map[posY, nextPosX] == '#' || map.map[nextPosY, posX] == '#')
                {
                    CantMove();
                }

                CheckForEnemies();
                CheckForItems();
            }
        }

        public void CheckForEnemies()
        {
            foreach (var enemy in enemyManager.enemies)
            {
                if ((posY == enemy.posY && nextPosX == enemy.posX) || (nextPosY == enemy.posY && posX == enemy.posX))
                {
                    if (enemy.health > 0)
                    {
                        CantMove();
                        enemy.healthSystem.health = 0;
                        enemy.healthSystem.TakeDamage(attack);
                        enemy.health += enemy.healthSystem.health;

                        if (enemy.health <= 0)
                        {
                            LastKilledEnemy = enemy.GetType().Name;
                        }

                        Console.SetCursorPosition(0, map.cameraHeight + 22);
                        ui.UpdateHUD(enemy);
                    }
                }
            }
        }

        public void CheckForItems()
        {
            foreach (var item in itemManager.items)
            {
                if ((posY == item.posY && nextPosX == item.posX) || (nextPosY == item.posY && posX == item.posX))
                {
                    item.DoYourJob();
                }
            }
        }
    }
}
