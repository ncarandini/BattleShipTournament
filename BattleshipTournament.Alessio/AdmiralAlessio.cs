using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;

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
            List<Coordinate> coordinate = new List<Coordinate>
            {
                new Coordinate(3, 9),
                new Coordinate(6, 4),
                new Coordinate(2, 1),
                new Coordinate(8, 8),
                new Coordinate(4, 2)
            };
        }

        public Coordinate Spara()
        {
            throw new NotImplementedException();
        }

        public EffettoSparo Rapporto()
        {
            throw new NotImplementedException();
        }
    }
}
