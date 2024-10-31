using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class EnemyMinotaur : Enemy
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

        public EnemyMinotaur(Map map, Player player, Currency currency) : base(map, player, currency)
        {
            this.map = map;
            this.player = player;
            this.currency = currency;
            maxHealth = Settings.minotaurHealth;
            health = maxHealth;
            name = Settings.minotaurName;
            Char = Settings.minotaurChar;
            damage = Settings.minotaurDamage;
            dir = "down";
            isDead = false;
            healthSystem = new HealthSystem(health);
            quest = new Quests(currency);
        }


        public static int chaseDistance = 5;
        public override void Update()
        {
            if (Char != '`')
            {
                int diffX = player.posX - posX;
                int diffY = player.posY - posY;

                if (Math.Abs(diffX) <= chaseDistance && Math.Abs(diffY) <= chaseDistance)
                {
                    string nextDir = (Math.Abs(diffX) > Math.Abs(diffY)) ? ((diffX > 0) ? "right" : "left") : ((diffY > 0) ? "down" : "up");

                    Move((nextDir == "left") ? -1 : ((nextDir == "right") ? 1 : 0), (nextDir == "up") ? -1 : ((nextDir == "down") ? 1 : 0), null);
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
            currency.AddCurrency(2);
            player.LastKilledEnemy = "Minotaur";
            quest.UpdateQuestStatus("Minotaur");
            //enemyCount--;
        }


    }
}
