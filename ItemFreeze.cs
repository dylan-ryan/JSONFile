using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class ItemFreeze : Item
    {

        private Player player;
        private Map map;
        private UI ui;
        private int effectTime;

        public ItemFreeze(Map map, Player player, UI ui) : base(map, player, ui)
        {
            this.map = map;
            this.player = player;
            this.ui = ui;
            name = Settings.freezeName;
            Char = Settings.freezeChar;
            delete = false;
            effectTime = Settings.freezeEffectTime;
        }


        public async override void DoYourJob()
        {
            if (delete == false)
            {
                ui.lastItem = name;
                delete = true;
                player.freezeEnemies = true;
                //UI.lastItem = "Invincibility";
                await Task.Delay(effectTime);
                player.freezeEnemies = false;
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
