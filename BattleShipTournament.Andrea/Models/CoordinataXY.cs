using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Andrea.Models
{
    public struct CoordinataXY
    {
        public int Riga { get; set; }
        public int Colonna { get; set; }

        public CoordinataXY(int riga, int colonna)
        {
            Riga = riga;
            Colonna = colonna;
        }

    }
}
