using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Walter.Models
{
    class CampoBattaglia
    {
        List<Coordinate> mare;

        public CampoBattaglia()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    mare.Add(new Coordinate(i, j));
        }

        public void posizionaNave(Nave nave, Coordinate posizioneIniziale)
        {

        }
    }
}
