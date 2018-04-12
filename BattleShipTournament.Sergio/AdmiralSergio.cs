using BattleshipTournament.Core.Models;
using BattleShipTournament.Sergio.Models;
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

        StrategyManager strategyManager;
        TacticalManager tacticalManager;
        Ship[] fleet;


        public AdmiralSergio()
        {
            strategyManager = new StrategyManager();
            tacticalManager = new TacticalManager();
            fleet = new Ship[5]
            {
                new Ship(1, "Sottomarino"),
                new Ship(2, "Corvetta"),
                new Ship(3, "Fregata"),
                new Ship(4, "Cacciatorpediniere"),
                new Ship(5, " Portaerei")
            };


        }

        public event Action<IAdmiral> FlottaAffondata;

        public void PosizionaFlotta()
        {
            strategyManager.PosizionaNavi(fleet);
        }

        public EffettoSparo Rapporto(Coordinate sparo)
        {
            EffettoSparo effetto = strategyManager.RiceviColpoFaiRapporto(sparo);
            if(FleetIsDestroyed())
            {
                FlottaAffondata?.Invoke(this);
            }
            return effetto;
        }

        private bool FleetIsDestroyed()
        {
            //TODO
            return false;
        }

        public void RiceviRapporto(EffettoSparo effettoSparo)
        {
            return tacticalManager.Spara();
        }


        public void RiceviRapporto(EffettoSparo effettoSparo)
        {
            tacticalManager.RisultatoSparo(effettoSparo);
        }
    }
}

