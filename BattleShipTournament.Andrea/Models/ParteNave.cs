using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Andrea.Models
{
    struct ParteNave
    {
        public Coordinate Coordinate { get; set; }
        public StatoParteNave StatoParteNave { get; set; }

        public ParteNave(Coordinate coordinate, StatoParteNave statoParteNave)
        {
            Coordinate = coordinate;
            StatoParteNave = statoParteNave;
        }



    }
}
