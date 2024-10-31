using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Currency
    {
        public int currency;
        public void AddCurrency(int value)
        {
            currency += value;
        }

        public void LoseCurrency(int value)
        {
            currency -= value;
        }
    }
}
