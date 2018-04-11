using BattleshipTournament.Core.Models;
using BattleShipTournament.GianPaolo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.GianPaolo
{
    public class AdmiralGianpaolo : IAdmiral
    {
        List<Nave> flotta = new List<Nave>()
        {
        new Nave("sottomarino",1),
        new Nave("corvetta",2),
        new Nave("fregata",3),
        new Nave("cacciatorpediniere",4),
        new Nave("portaerei",5)
        };

        public string Nome => "Gianpaolo";

        public event Action<IAdmiral> FlottaAffondata;
        public AdmiralGianpaolo()
        { }

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
