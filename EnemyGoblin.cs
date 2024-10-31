using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{

    internal class EnemyGoblin : Enemy
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

        public EnemyGoblin(Map map, Player player, Currency currency) : base(map, player, currency) 
        {
            this.map = map;
            this.player = player;
            this.currency = currency;
            maxHealth = Settings.goblinHealth;
            health = maxHealth;
            name = Settings.goblinName;
            Char = Settings.goblinChar;
            damage = Settings.goblinDamage;
            dir = "down";
            isDead = false;
            healthSystem = new HealthSystem(health);
            quest = new Quests(currency);
        }


        public override void Update()
        {
            if (Char != '`')
            {
                //Up
                if (dir == "up")
                {
                    Move(0, -1, "down");
                }
                //Down
                else if (dir == "down")
                {
                    Move(0, 1, "up");
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
            currency.AddCurrency(1);
            player.LastKilledEnemy = "Goblin";
            quest.UpdateQuestStatus("Goblin");
        }


    }
}
