using BattleshipTournament.Core.Models;
using BattleShipTournament.Niko.Models;
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

        StrategyManager strategyManager;
        TacticalManager tacticalManager;

        Nave[] flotta;

        public AdmiralNiko()
        {
            strategyManager = new StrategyManager();
            tacticalManager = new TacticalManager();

            flotta = new Nave[5]
            {
                new Nave(1),
                new Nave(2),
                new Nave(3),
                new Nave(4),
                new Nave(5)
            };
        }

        public void PosizionaFlotta()
        {
            strategyManager.PosizionaNavi(flotta);
        }

        public EffettoSparo Rapporto(Coordinate sparo)
        {
            EffettoSparo effetto = strategyManager.RiceviColpoEFaiRapporto(sparo);

            if(effetto == EffettoSparo.Affondato && FleetIsDestroyed())
            {
                if (FlottaAffondata != null)
                {
                    FlottaAffondata?.Invoke(this);
                }
            }

            return effetto;
        }

        private bool FleetIsDestroyed()
        {
            bool flottaAffondata = true;

            foreach (var nave in flotta)
            {
                if(!nave.Affondata())
                {
                    flottaAffondata = false;
                    break;
                }
            }
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

        public EffettoSparo Rapporto()
        {
            throw new NotImplementedException();
        }
    }
}
