using BattleshipTournament.Core.Models;
using System;

namespace BattleshipTournament.Alessio
{
    public class AdmiralAlessio : IAdmiral
    {
        public string Nome => "Alessio";

        public AdmiralAlessio ()
        {
            
        }

        public event Action<IAdmiral> FlottaAffondata;

        public void PosizionaFlotta()
        {
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
