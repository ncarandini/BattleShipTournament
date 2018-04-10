using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipTournament.ConsoleApp.Models
{
    interface IAdmiral
    {
        string Nome { get; }

        void PosizionaFlotta();

        Coordinate Spara();

        EffettoSparo Rapporto();

        event Action<IAdmiral> FlottaAffondata;
    }
}
