using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipTournament.Core.Models
{
    public interface IAdmiral
    {
        string Nome { get; }

        void PosizionaFlotta();

        Coordinate Spara();

        EffettoSparo Rapporto(Coordinate sparo);

        void RiceviRapporto(EffettoSparo effettoSparo);

        event Action<IAdmiral> FlottaAffondata;
    }
}
