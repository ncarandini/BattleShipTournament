using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Andrea
{
    public class AdmiralAndrea : IAdmiral
    {
        public string Nome => "Andrea";

        public event Action<IAdmiral> FlottaAffondata;



        public AdmiralAndrea()
        {

        }

        public void PosizionaFlotta()
        {

        }

        public EffettoSparo Rapporto()
        {
            throw new NotImplementedException();
        }

        public Coordinate Spara()
        {
            throw new NotImplementedException();
        }
    }
}
