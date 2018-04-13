using BattleShipTournament.Nabil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Nabil
{
    public class Nave
    {
        int lunghezza;
        //creo l'arrey generico
        StatusParteNave[] StatusNave;
        //costruttore
        public Nave(int lunghezza)
        {
            this.lunghezza = lunghezza;
            StatusNave = new StatusParteNave[lunghezza];

            for (int i = 0; i < lunghezza; i++) {
                StatusNave[i] = StatusParteNave.Good;
            }

        }

        public bool Colpita(int PartIndex)
        {
            if(PartIndex < 0 || PartIndex >= lunghezza)
            {
                throw new ArgumentOutOfRangeException();
            }

            StatusNave[PartIndex] = StatusParteNave.Damaged;
            bool affondata = true;

            foreach (var statuspartenave in StatusNave)
            {
                if( statuspartenave == StatusParteNave.Good)
                {
                    affondata = false;
                    break;
                }
            }
            return affondata;
        }
    }
}
