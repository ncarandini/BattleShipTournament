using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Mirko
{
    public class AdmiralMirko : IAdmiral
    {

        public string Nome => "Mirko";

        public event Action<IAdmiral> FlottaAffondata;

        public void PosizionaFlotta()
        {

        }

        public EffettoSparo Rapporto (Coordinate sparo)
        {
            throw new NotImplementedException();
        }

        public void RiceviRapporto(EffettoSparo effettoSparo)
        {
            throw new NotImplementedException();
        }

        public Coordinate Spara()
        {
            throw new NotImplementedException();
        }
    }
}

