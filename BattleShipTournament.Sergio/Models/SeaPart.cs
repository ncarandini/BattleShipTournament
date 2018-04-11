using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Sergio.Models
{
    internal class SeaPart
    {
        bool HasShip => Ship != null;
        public Ship Ship { get; private set; }
        public int PartIndex { get; private set; }
        
        public SeaPart(Ship ship = null, int partIndex = -1)
        {
            Ship = ship;
            PartIndex = partIndex;
        }
    }
    
}
