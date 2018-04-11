using BattleShipTournament.GianPaolo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.GianPaolo.Model
{

    public class Mappa
    {
        private static Mappa instance;
        private  List<Nave> ListaNavi { get;set; }

        public Mappa() { }

        public static Mappa Instanza()
        {
            if(instance==null)
            {
                instance = new Mappa();
            }
            return instance;
        }

        public 
    }
}
