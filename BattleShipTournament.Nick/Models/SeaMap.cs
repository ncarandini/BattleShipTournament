using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Nick.Models
{
    class SeaMap
    {
        SeaCell[,] FleetMap;

        public SeaMap()
        {
            FleetMap = new SeaCell[10, 10];
        }
    }
}
