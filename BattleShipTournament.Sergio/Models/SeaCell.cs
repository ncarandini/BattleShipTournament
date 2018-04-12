using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Sergio.Models
{
    internal class SeaCell
    {
        public bool isEmpty => Ship == null;
        public Ship Ship { get; private set; }
        public int PartIndex { get; private set; }

        public SeaCell()
        {

        }

        public SeaCell(Ship ship, int partIndex)
        {
            Ship = ship;
            PartIndex = partIndex;
        }
    }

}
