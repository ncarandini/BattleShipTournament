using BattleshipTournament.Core.Models;
using BattleShipTournament.GianPaolo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.GianPaolo
{
    public class AdmiralGianpaolo : IAdmiral
    {

        Mappa mappa = Mappa.Instanza();

        public string Nome => "Gianpaolo";

        public event Action<IAdmiral> FlottaAffondata;

        public AdmiralGianpaolo()
        { }


        public Coordinate Spara()
        {
            throw new NotImplementedException();
        }

        public void PosizionaFlotta()
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
