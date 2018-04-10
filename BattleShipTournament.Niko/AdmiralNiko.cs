using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Niko
{
    public class AdmiralNiko : IAdmiral
    {
        public string Nome => "Niko";

        public event Action<IAdmiral> FlottaAffondata;

        public AdmiralNiko()
        {

        }

        public void PosizionaFlotta()
        {
            throw new NotImplementedException();
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
