using BattleshipTournament.Core.Models;
using BattleShipTournament.Daniele.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Daniele
{
    public class AdmiralDaniele : IAdmiral
    {
        public string Nome => "Daniele";

        Stratega stratega;
        Tattico tattico;


        public event Action<IAdmiral> FlottaAffondata;

        Nave[] flotta;


        //costruttore ammiraglio
        public AdmiralDaniele()
        {
            stratega = new Stratega();
            tattico = new Tattico();

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
            stratega.PosiozionaNavi(flotta);
        }

        public EffettoSparo Rapporto(Coordinate sparo)
        {
            EffettoSparo effetto = stratega.RiceviColpoEFaiRapporto(sparo);

            if (effetto == EffettoSparo.Affondato && FleetIsDestroyed())
            {
                FlottaAffondata?.Invoke(this);

            }
            return stratega.RiceviColpoEFaiRapporto(sparo);
        }

        private bool FleetIsDestroyed()
        {
            bool flottaAffondata = true;


            foreach (var nave in flotta)
            {
                if (!nave.Affondata())
                {
                    flottaAffondata = false;
                    break;
                }
            }
            
            return flottaAffondata;
        }

        public Coordinate Spara()
        {
            return tattico.Spara();
        }

        public void RiceviRapporto(EffettoSparo effettoSparo)
        {
            tattico.RisultatoSparo(effettoSparo);
        }
    }
}
