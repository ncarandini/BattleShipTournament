using BattleshipTournament.Core.Models;
using BattleShipTournament.Emanuel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Emanuel
{
    public class AdmiralEmanuel : IAdmiral
    {
        public event Action<IAdmiral> FlottaAffondata;

        public string Nome => "Emanuel";

        Stratega stratega;
        Tattico tattico;

        Nave[] flotta;

        
        
        public AdmiralEmanuel()
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
            stratega.PosizionaNavi(flotta);
        }

        public EffettoSparo Rapporto(Coordinate sparo)
        {
            EffettoSparo effetto = stratega.RiceviColpoFaiRapporto(sparo);

            if ( effetto == EffettoSparo.Affondato && FleetIsDestroyed())
            {

                FlottaAffondata?.Invoke(this);    
            }                            
            return effetto;
        }

        private bool FleetIsDestroyed()
        {
            bool flottaAffontata = true;

            foreach (var nave in flotta)
            {
                if (!nave.Affondata()) {

                    flottaAffontata = false;
                    break;
                }

            }


            return flottaAffontata;
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
