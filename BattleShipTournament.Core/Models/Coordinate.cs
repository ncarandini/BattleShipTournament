using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipTournament.Core.Models
{
    public struct Coordinate
    {
        public readonly int Riga;
        public readonly int Colonna;

        public Coordinate(int riga, int colonna)
        {
            Riga = riga;
            Colonna = colonna;
        }
    }
}
