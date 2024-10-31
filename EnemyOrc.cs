using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class EnemyOrc : Enemy
    {

        private int nextPosX;
        private int nextPosY;
        private int lastPosX;
        private int lastPosY;
        private Player player;
        private Map map;
        public HealthSystem healthSystem;
        public Currency currency;
        public Quests quest;

        public EnemyOrc(Map map, Player player, Currency currency) : base(map, player, currency)
        {
            this.map = map;
            this.player = player;
            maxHealth = Settings.orcHealth;
            health = maxHealth;
            name = Settings.orcName;
            Char = Settings.orcChar;
            damage = Settings.orcDamage;
            dir = "down";
            isDead = false;
            healthSystem = new HealthSystem(health);
            this.currency = currency;
            quest = new Quests(currency);
        }


        private static Random rd = new Random();
        //Moves randomly
        public override void Update()
        {
            if (Char != '`')
            {

                int dir = rd.Next(0, 400);

                //Up
                if (dir <= 100)
                {
                    Move(0, -1, null);
                }
                //Left
                else if (dir > 100 && dir <= 200)
                {
                    Move(-1, 0, null);
                }
                //Down
                else if (dir > 200 && dir <= 300)
                {
                    Move(0, 1, null);
                }
                //Right
                else if (dir > 300)
                {
                    Move(1, 0, null);
                }
            }
        }

        public override void Draw()
        {
            map.map[lastPosY, lastPosX] = '`';
            map.map[posY, posX] = Char;
        }


        public void Move(int nextX, int nextY, string nextDir)
        {
            nextPosX = posX + nextX;
            nextPosY = posY + nextY;
            bool isWithinBounds = nextPosX >= 0 && nextPosX < map.width && nextPosY >= 0 && nextPosY < map.height;
            lastPosY = posY;
            lastPosX = posX;

            if (isWithinBounds)
            {
                if (health >  0)
                {
                    //Colides with player 
                    if (nextPosX == player.posX && nextPosY == player.posY)
                    {
                        player.healthSystem.TakeDamage(damage);
                        nextPosY = lastPosY;
                        nextPosX = lastPosX;
                    }
                    else if (map.map[nextPosY, nextPosX] == '`')
                    {
                        posX = nextPosX;
                        posY = nextPosY;
                    }
                    else
                    {
                        nextPosY = lastPosY;
                        nextPosX = lastPosX;
                        dir = nextDir;
                    }
                }
                else
                {
                    Die();
                }
            }
        }

        public void Die()
        {
            if (isDead == false)
            {
                player.attack += damage;
            }
            health = 0;
            map.map[posY, posX] = '`';
            Char = '`';
            map.DisplayMap();
            isDead = true;
            currency.AddCurrency(3);
            player.LastKilledEnemy = "Orc";
            quest.UpdateQuestStatus("Orc");
            //enemyCount--;
        }


    }
}
