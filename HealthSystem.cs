using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class HealthSystem
    {


        public int health;

        public HealthSystem(int health)
        {
            this.health = health;
        }

        public void TakeDamage(int hit)
        {
            health -= hit;
        }

        public void Heal(int heal)
        {
            health += heal;
        }



    }
}
