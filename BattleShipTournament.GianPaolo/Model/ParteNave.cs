using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.GianPaolo.Model
{
    public struct  ParteNave
    {
        public int X { get; set; }
        public int Y { get; set; }
        public String Stato { get; set; }
        public void SetStato(string s)
        {
            Stato = s;
        }
    }
}
