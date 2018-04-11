using BattleShipTournament.Sergio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Sergio
{
    internal class Ship
    {
        public string NameShip { get; private set; }
        StatusShipPart[] statusShip;
        int lunghezza;

        public Ship(int lunghezza)
        {
           if (lunghezza < 1 || lunghezza > 5)
            {
                
            }
            this.lunghezza = lunghezza;
            statusShip = new StatusShipPart[lunghezza];

            for(int i = 0; i < lunghezza; lunghezza++)
            {
                statusShip[i] = StatusShipPart.Sana;
            }

                
        }
    }
}
