using BattleShipTournament.Sergio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Sergio

// metodo Affondata - bool vero, falso
// metodo Danneggiata (indice), restituisce falso (colpita ma non affondata) o vero (colpita e affondata)
// nel costruttore passare nome e lunghezza della nave
{
    internal class Ship
    {
        public string NameShip { get; private set; }
        StatusShipPart[] statusShip;
        int lenght;

        public Ship(int lenght, string NameShip)
        {
           if (lenght < 1 || lenght > 5)
            {
                
            }
            this.lenght = lenght;
            this.NameShip = NameShip;
            statusShip = new StatusShipPart[lenght];

            for(int i = 0; i < lenght; lenght++)
            {
                statusShip[i] = StatusShipPart.Good;
            }

        }       
    }
   
}
