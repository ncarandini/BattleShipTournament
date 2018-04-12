using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.GianPaolo.Model
{
    interface IMappa
    {
        String Sparo(int x, int y);
        String RiceviColpo(int x, int y);
        void Posiziona();


    }
}
