using BattleshipTournament.Core.Models;
using BattleShipTournament.Walter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Walter
{
    public class AdmiralWalter : IAdmiral
    {
        public string Nome => "Walter";

        public event Action<IAdmiral> FlottaAffondata;

        private List<Nave> laMiaFlotta;
        private IAdmiral enemyAdmiral;

        public AdmiralWalter(IAdmiral enemyAdmiral)
        {
            //creo le mie navi
            laMiaFlotta = new List<Nave>();
            for (int i = 1; i <= 5; i++)
                laMiaFlotta.Add(new Nave(i));
            //creo il mio campo di battaglia
            //creo il campo di battaglia nemico
            //setto l'ammiraglio avversario
            this.enemyAdmiral = enemyAdmiral;
        }

        public void PosizionaFlotta()
        {
            //setto il mio campo di battaglia
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
