using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Walter.Models
{
    internal static class GeneratoreCoordinateRandom
    {
        public static Coordinate generaCoordinata()
        {
            Random rand = new Random();
            int i = rand.Next(0, 10);
            int j = rand.Next(0, 10);
            return new Coordinate(i, j);
        }
    }
}
