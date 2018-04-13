using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Core.Models
{
    public static class SingleRandom
    {
        // Current restituisce una istanza singleton di Random

        static Random current;
        public static Random Current
        {
            get
            {
                if(current == null)
                {
                    current = new Random();
                }
                return current;
            }
        }

    }
}
