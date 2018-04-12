using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Irvin.Models
{
    public class Ship
    {
        private int lunghezza;

        private StatusParteNave[] statusNave;

        public Ship(int lunghezza)
        {
            this.lunghezza = lunghezza;
            statusNave = new StatusParteNave[lunghezza];

            for(int i = 0; i < lunghezza; i++)
            {
                statusNave[i] = StatusParteNave.Good;
            }
        }

        public bool Colpita(int partIndex)
        {
            if (partIndex < 0 || partIndex >= lunghezza)
            {
                throw new ArgumentOutOfRangeException();    // se ricevo un risultato minore o maggiore della misura di una qualsiasi nave, genero errore
            }

            statusNave[partIndex] = StatusParteNave.Damaged;

            bool affondata = true;

            foreach (var p in statusNave)   //cicla per ogni p in statusNave
            {
                if (p == StatusParteNave.Good)  //se p risulta almeno una parte della nave NON colpita
                {
                    affondata = false;  // la nave non è affondata
                    break;  // interrompo ciclo
                }
            }

            return affondata;   // ritorna che la nave è affondata
        }
    }
}