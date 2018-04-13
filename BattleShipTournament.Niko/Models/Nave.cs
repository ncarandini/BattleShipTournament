using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Niko.Models

    // è composta da piu parti di nave in base alla propria lunghezza

{
    public class Nave
    {
        int lunghezza;

        StatusParteNave[] statusNave;

        public Nave(int l)
        {
            lunghezza = l;
            statusNave = new StatusParteNave[l];

            for (int i = 0; i < l; i++)
            {
                statusNave[i] = StatusParteNave.Good;
            }
        }

        public bool Colpita (int partIndex)
        {
            if (partIndex < 0 || partIndex >= lunghezza)
            {
                throw new ArgumentOutOfRangeException();
            }

            statusNave[partIndex] = StatusParteNave.Damaged;

            bool affondata = Affondata();

            return affondata;
        }

        public bool Affondata()
        {
            bool affondata = true;

            foreach (var statusParteNave in statusNave)
            {
                if (statusParteNave == StatusParteNave.Good)
                {
                    affondata = false;
                    break;
                }
            }

            return affondata;
        }
    }
    
}
