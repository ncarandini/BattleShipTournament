using BattleshipTournament.Core.Models;
using BattleShipTournament.Irvin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Irvin
{
    public class AdmiralIrvin : IAdmiral
    {
        public string Nome => "Irvin";

        Stratega stratega;
        Tattico tattico;

        Ship[] fleet;

        public event Action<IAdmiral> FlottaAffondata;

        public AdmiralIrvin()
        {
            stratega = new Stratega();
            tattico = new Tattico();

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
            stratega.PosizioneNavi(fleet);
        }

        public EffettoSparo Rapporto(Coordinate sparo)
        {
            EffettoSparo effetto = stratega.RiceviColpoFaiRapporto(sparo);

            if(FleetIsDestroyed())
            {
                FlottaAffondata?.Invoke(this);
            }

            return effetto;
        }

        private bool FleetIsDestroyed()
        {
            return false;
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