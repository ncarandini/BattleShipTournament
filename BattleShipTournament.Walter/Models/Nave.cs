using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Walter.Models
{
    internal class Nave
    {
        private List<Coordinate> posizioni;
        private int lunghezza;

        public Nave(int lunghezza)
        {
            this.lunghezza = lunghezza;
        }

    }
}
