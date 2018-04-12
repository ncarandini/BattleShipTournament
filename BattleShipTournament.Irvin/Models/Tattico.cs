using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Irvin.Models
{
    public class Tattico
    {
        bool[,] tacticalSeaMap;

        public Tattico()
        {
            tacticalSeaMap = new bool[10, 10];

            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
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
                if(!shootedSeaCell)
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
                throw new Exception("Io ho già sparato in tutta la mappa, ma l'avversario è un minchione!");
            }

            //trova una zona random che non sia ancora stata colpita, provandoci per al max 10 volte

            Random random = new Random();
            int tentativi = 0;
            bool sparoTrovato = false;
            int riga = 0;
            int colonna = 0;

            while (!sparoTrovato && tentativi < 10)
            {
                tentativi++;
                riga = random.Next(0, 9);
                colonna = random.Next(0, 9);

                if(!tacticalSeaMap[riga, colonna])  //se NON è colpita
                {
                    sparoTrovato = true;
                }
            }

            //trova una zona che non sia ancora stata colpita, scandendo tutto l'array
            if(!sparoTrovato)
            {
                for(int r = 0; r < 10; r++)
                {
                    for (int c = 0; c < 10; c++)
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

            tacticalSeaMap[riga, colonna] = true;
            return new Coordinate(riga, colonna);
        }

        public void RisultatoSparo(EffettoSparo effettoSparo)
        {
            //TO DO
        }
    }
}