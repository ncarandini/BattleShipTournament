using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Andrea.Models
{
    class Mappa
    {
        Casella[,] mappa;
        public Mappa(int dimensione)
        {
            mappa = new Casella[dimensione, dimensione];
        }

        public Casella getCasella(CoordinataXY coordinate)
        {
            return mappa[coordinate.Riga, coordinate.Colonna];
        }

        public void SetCasellaPiena(CoordinataXY coordinata)
        {
            mappa[coordinata.Riga, coordinata.Colonna].Piena = true;
        }
    }
}
