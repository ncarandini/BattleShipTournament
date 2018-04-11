using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Sergio
{
    public class AdmiralSergio : IAdmiral
    {
        public string Nome => "Sergio";

        public AdmiralSergio()
        {

        }
       
        public event Action<IAdmiral> FlottaAffondata;

        public void PosizionaFlotta()
        {
            throw new NotImplementedException();
        }

        public Coordinate Spara()
        {
            throw new NotImplementedException();
        }

        public EffettoSparo Rapporto(Coordinate sparo)
        {
            throw new NotImplementedException();
        }

        public void RiceviRapporto(EffettoSparo effettoSparo)
        {
            throw new NotImplementedException();
        }
    }
}
