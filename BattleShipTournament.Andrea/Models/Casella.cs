using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Andrea.Models
{
    struct Casella
    {
        public bool Colpita { get; set; }
        public bool Piena { get; set; }

        public int NumeroNaveInCasella { get; set; }
    }
}
