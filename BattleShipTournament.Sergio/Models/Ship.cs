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
        int lenght;

        public Ship(int lenght, string NameShip)
        {

            this.lenght = lenght;
            this.NameShip = NameShip;
            statusShip = new StatusShipPart[lenght];

            for (int i = 0; i < lenght; lenght++)
            {
                statusShip[i] = StatusShipPart.Good;
            }

        }

        public bool Colpita(int partIndex)
        {
            if (partIndex < 0 || partIndex >= lenght)
            {
                throw new ArgumentOutOfRangeException();
            }

            statusShip[partIndex] = StatusShipPart.Damaged;

            return Affondata();
        }

        public bool Affondata()
        {
            bool affondata = true;
            foreach (var parte in statusShip)
            {
                if (parte == StatusShipPart.Good)
                {
                    affondata = false;
                    break;
                }

            }

            return affondata;
        }
    }

}
