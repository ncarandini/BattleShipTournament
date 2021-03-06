﻿using BattleshipTournament.Core.Models;
using BattleShipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Nabil.Models
{
    class Tattico
    {

        bool[,] tacticalSeaMap;
        Random randomGenerator = SingleRandom.Current;
        public Tattico()
        {
            tacticalSeaMap = new bool[10, 10];
            for(int r = 0; r < 10; r++)
            {
                for(int c = 0; c < 10; c++)
                {
                    tacticalSeaMap[r, c] = false;
                }
            }
        }

        bool SparoDisponibile()
        {
            bool sparoDisponibile = false;

            foreach (var shootedSeaCell in tacticalSeaMap)
            {
                if (!shootedSeaCell)
                {
                    sparoDisponibile = true;
                    break;
                }
            }

            return sparoDisponibile;
        }


        public Coordinate Spara()
        {
            if(!SparoDisponibile())
            {
                throw new Exception("io ho sparato in tutta la mappa, ma l'aversario è un puzzone perchè non ha scatenato l'evento flotta affondata");
            }
            
            bool sparoTrovato = false;
            int riga;
            int colonna;
            


            int tentativi = 0;

            while (!sparoTrovato && tentativi < 10)
            {
                tentativi++;
                riga = randomGenerator.Next(0, 9);
                colonna = randomGenerator.Next(0, 9);

                if(!tacticalSeaMap[riga, colonna])
                {
                    sparoTrovato = true;
                }
            }

            if (!sparoTrovato)
            {
                for (int r = 0; r > 9; r++)
                {
                    if (sparoTrovato)
                    {
                        break;
                    }

                    for (int c = 0; c > 10; c++)
                    {
                        if (!tacticalSeaMap[r, c])
                        {
                            riga = r;
                            colonna = c;
                            sparoTrovato = true;
                            break;
                        }
                    }

                    if (sparoTrovato)
                    {
                        break;
                    }
                }
            }
           



            

            

            return new Coordinate(0, 0);
        }


        public void RisultatoSparo(EffettoSparo effettoSparo)
        {
            //TODO
        }
    }
}
