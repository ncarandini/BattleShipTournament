using BattleshipTournament.Core.Models;
using BattleShipTournament.Mirko.Models;
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

        Stratega stratega;
        Tattico tattico;

        // array di Navi
        Nave[] flotta;

        // costruttore in cui bisogna istanziare lo stratega, il tattico e realizzare la lista delle navi
        public AdmiralMirko()
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
            // non devo fare nulla dato che ci pensa lo stratega; in alternativa potrei anche ri-posizionare le navi
            stratega.PosizionaNavi(flotta);
        }

        public EffettoSparo Rapporto (Coordinate sparo)
        {
            // chiedo il rapporto, inviando le coordinate dello sparo
            EffettoSparo effetto = stratega.RiceviColpoFaiRapporto(sparo);

            if (effetto == EffettoSparo.Affondato && FleetIsDestroyed())
            {
                FlottaAffondata?.Invoke(this); // scatena l'evento FlottaAffondata
            }

            return effetto;
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
            // effettuo lo sparo
            return tattico.Spara();
        }

        public void RiceviRapporto(EffettoSparo effettoSparo)
        {
            // chiedo il rapporto, inviando effettoSparo
            tattico.RisultatoSparo(effettoSparo);
        }

    }
}

