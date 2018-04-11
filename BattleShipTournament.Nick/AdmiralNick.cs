using BattleshipTournament.Core.Models;
using BattleShipTournament.Nick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Nick
{
    public class AdmiralNick : IAdmiral
    {
        public event Action<IAdmiral> FlottaAffondata;

        public string Nome => "Nick";

        StrategyManager strategyManager;
        TacticalManager tacticalManager;

        Ship[] fleet;

        public AdmiralNick()
        {
            strategyManager = new StrategyManager();
            tacticalManager = new TacticalManager();

            fleet = new Ship[5]
            {
                new Ship(1),
                new Ship(2),
                new Ship(3),
                new Ship(4),
                new Ship(5)
            };
        }

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
            // TODO
            return false;
        }

        public Coordinate Spara()
        {
            return tacticalManager.Spara();
        }

        public void RiceviRapporto(EffettoSparo effettoSparo)
        {
            tacticalManager.RisultatoSparo(effettoSparo);
        }
    }
}
