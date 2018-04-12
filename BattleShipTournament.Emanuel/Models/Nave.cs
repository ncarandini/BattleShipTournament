using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Emanuel.Models
{
    public class Nave
    {
        private int lenght;

        private StatusParteNave[] statusNave;

        public Nave(int lunghezza)
        {
            lenght = lunghezza;
            statusNave = new StatusParteNave[lunghezza];

            for (int i = 0; i < lunghezza; i++)
            {
                statusNave[i] = StatusParteNave.Good;
            }

        }

        public bool Colpita(int partIndex) {

            if (partIndex < 0 || partIndex >= lenght)
            {
                throw new ArgumentOutOfRangeException();
            }

            statusNave[partIndex] = StatusParteNave.Damaged;

            bool affondata = true;
            foreach (var parteNave in statusNave)
            {
                if (parteNave == StatusParteNave.Good)
                {

                    affondata = false;
                    break;
                }
                
            }
            return affondata;


        }

        
       
        
        
    }
}
