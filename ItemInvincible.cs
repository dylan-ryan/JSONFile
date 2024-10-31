using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class ItemInvincible : Item
    {

        private Player player;
        private Map map;
        private UI ui;
        private int effectTime;

        public ItemInvincible(Map map, Player player, UI ui) : base(map, player, ui)
        {
            this.map = map;
            this.player = player;
            this.ui = ui;
            name = Settings.invincibilityName;
            Char = Settings.invincibilityChar;
            delete = false;
            effectTime = Settings.invincibilityEffectTime;
        }


        public async override void DoYourJob()
        {
            if (delete == false)
            {
                delete = true;
                if (player.healthSystem.health < 98999999)
                {
                    ui.lastItem = name;
                    int originalHealth = player.healthSystem.health;
                    player.healthSystem.health = 99999999;
                    //UI.lastItem = "Invincibility";
                    await Task.Delay(effectTime);
                    player.healthSystem.health = originalHealth;
                }
            }
        }

        public override void Update()
        {
            if (delete == true)
            {
                map.map[posY, posX] = '`';
                Char = '`';
            }
        }

        public override void Draw()
        {
            map.map[posY, posX] = Char;
        }

    }
}

        /*
        public static int originalShield = Player.shield;

        public static new char itemChar = Settings.invincibilityChar;

        public static int effectTime = Settings.invincibilityEffectTime;

        public static string name = Settings.invincibilityName;

        public static async Task Invincibility()
        {
            int originalHealth = Player.shield;

            Player.shield = 99999999;

            UI.lastItem = "Invincibility";

            await Task.Delay(effectTime);

            Player.shield = originalShield;
        }
    }
}
*/