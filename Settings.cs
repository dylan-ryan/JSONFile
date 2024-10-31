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
        // Camera Settings
        public int CameraWidth { get; set; }
        public int CameraHeight { get; set; }

        // Player Settings
        public char PlayerChar { get; set; }
        public int PlayerHealth { get; set; }
        public int PlayerAttack { get; set; }
        public int PlayerStartPosX { get; set; }
        public int PlayerStartPosY { get; set; }

        // Item Settings
        public char HealthPotionChar { get; set; }
        public string HealthPotionName { get; set; }
        public int HealthPotionHealAmount { get; set; }
        public char InvincibilityChar { get; set; }
        public string InvincibilityName { get; set; }
        public int InvincibilityEffectTime { get; set; }
        public char FreezeChar { get; set; }
        public string FreezeName { get; set; }
        public int FreezeEffectTime { get; set; }

        // Enemy Settings
        public char DragonChar { get; set; }
        public string DragonName { get; set; }
        public int DragonHealth { get; set; }
        public int DragonDamage { get; set; }
        public char GoblinChar { get; set; }
        public string GoblinName { get; set; }
        public int GoblinHealth { get; set; }
        public int GoblinDamage { get; set; }
        public string GoblinDir { get; set; }
        public char OrcChar { get; set; }
        public string OrcName { get; set; }
        public int OrcHealth { get; set; }
        public int OrcDamage { get; set; }
        public char MinotaurChar { get; set; }
        public string MinotaurName { get; set; }
        public int MinotaurHealth { get; set; }
        public int MinotaurDamage { get; set; }

        public static Settings Load(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Settings>(json);
        }
    }
}