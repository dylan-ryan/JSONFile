using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class ItemHealth : Item
    {

        private Player player;
        private Map map;
        private UI ui;
        private int healAmount;

        public ItemHealth(Map map, Player player, UI ui) : base(map, player, ui)
        {
            this.map = map;
            this.player = player;
            this.ui = ui;
            name = Settings.healthPotionName;
            Char = Settings.healthPotionChar;
            healAmount = Settings.healthPotionHealAmount;
            delete = false;
        }


        public override void DoYourJob()
        {
            if (delete == false)
            {
                ui.lastItem = name;
                player.healthSystem.Heal(healAmount);
                delete = true;
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
