using System;

namespace BattleShipTournament.Nick.Models
{
    internal class Ship
    {
        ShipPartStatus[] shipParts;
        int length;

        public Ship(int length)
        {
            if (length < 1 || length > 5)
            {
                throw new ArgumentOutOfRangeException("Ship length must be in a range of 1..5.");
            }

            this.length = length;
            shipParts = new ShipPartStatus[length];

            // Vara nave
            for (int i = 0; i < length; i++)
            {
                shipParts[i] = ShipPartStatus.Good;
            }
        }

        public bool Colpita(int partIndex)
        {
            if (partIndex < 0 || partIndex >= length)
            {
                throw new ArgumentOutOfRangeException();
            }

            return Affondata();
        }

        public bool Affondata()
        {
            bool affondata = true;

            foreach (var item in shipParts)
            {
                if (item == ShipPartStatus.Good)
                {
                    affondata = false;
                    break;
                }
            }

            return affondata;
        }
    }
}