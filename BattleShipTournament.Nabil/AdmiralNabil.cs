using BattleshipTournament.Core.Models;
using BattleShipTournament.Nabil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Nabil
{
    public class AdmiralNabil : IAdmiral
    {
        public event Action<IAdmiral> FlottaAffondata;

        public string Nome => "Nabil";

        Stratega stratega;
        Tattico tattico;

        Nave[] fleet;

        public AdmiralNabil()
        {
            stratega = new Stratega();
            tattico = new Tattico();

            fleet = new Nave[5]
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
            stratega.PosizionaNavi(fleet);
        }

        public EffettoSparo Rapporto(Coordinate sparo)
        {
            EffettoSparo effetto = stratega.RiceviColpoFaiRapporto(sparo);
            if (effetto == EffettoSparo.Affondato && FleetIsDestroyed())
            {
                FlottaAffondata?.Invoke(this);
            }

            return effetto;
        }

        private bool FleetIsDestroyed()
        {
            bool flottaAffondata = true;

            foreach ( var nave in fleet)
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
