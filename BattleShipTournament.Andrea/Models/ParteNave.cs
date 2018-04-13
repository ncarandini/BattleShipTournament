using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Andrea.Models
{
    public class ParteNave
    {
        CoordinataXY coordinata;

        public bool Distrutta { get; set; }

        public ParteNave()
        {
        }

        public void SetCoordinata(int riga, int colonna)
        {
            coordinata = new CoordinataXY(riga, colonna);
        }
        public CoordinataXY GetCoordinata()
        {
            return coordinata;
        }

        public void Colpito()
        {
            Distrutta = true;
        }



    }
}
