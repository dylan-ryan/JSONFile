using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Settings
    {
        //---------------
        //Camera Settings
        //---------------
        public static int cameraWidth = 40;
        public static int cameraHeight = 15;
        //---------------
        //Player Settings
        //---------------
        public static char playerChar = 'P';
        public static int playerHealth = 100000000;
        public static int playerAttack = 100;
        public static int playerStartPosX = 4;
        public static int playerStartPosY = 20;
        //-------------
        //Item Settings
        //-------------
        //Health Potion Settings
        public static char healthPotionChar = '@';
        public static string healthPotionName = "Health Potion";
        public static int healthPotionHealAmount = 30;
        //Invincibility Settings
        public static char invincibilityChar = '!';
        public static string invincibilityName = "Invincibility";
        public static int invincibilityEffectTime = 4000;
        //Freeze Settings
        public static char freezeChar = '*';
        public static string freezeName = "Freeze";
        public static int freezeEffectTime = 4000;
        //--------------
        //Enemy Settings
        //--------------
        //Dragon Settings
        public static char dragonChar = 'D';
        public static string dragonName = "Dragon";
        public static int dragonHealth = 10000;
        public static int dragonDamage = 100;
        //Goblin Settings
        public static char goblinChar = 'G';
        public static string goblinName = "Goblin";
        public static int goblinHealth = 150;
        public static int goblinDamage = 20;
        public static string goblinDir = "down";
        //Orc Settings
        public static char orcChar = 'O';
        public static string orcName = "Orc";
        public static int orcHealth = 200;
        public static int orcDamage = 40;
        //Minotaur Settings
        public static char minotaurChar = '}';
        public static string minotaurName = "Minotaur";
        public static int minotaurHealth = 400;
        public static int minotaurDamage = 50;

    }
}
