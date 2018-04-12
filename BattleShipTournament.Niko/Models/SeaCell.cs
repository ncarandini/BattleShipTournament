using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Niko.Models
{
    internal class SeaCell
    {
        public bool IsEmpty
        {
            get { return Nave == null; }
        }

        public Nave Nave { get; private set; }

        public int PartIndex { get; private set; }

        public SeaCell()
        {
        }

        public SeaCell(Nave nave, int partIndex)
        {
            Nave = nave;
            PartIndex = partIndex;
        }
    }
}

