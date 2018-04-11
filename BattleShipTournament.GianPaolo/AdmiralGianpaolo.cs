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


        public EffettoSparo Rapporto()
        {
            
        }

        public Coordinate Spara()
        {
            
        }

        public void PosizionaFlotta()
        {
            throw new NotImplementedException();
        }
    }
}
