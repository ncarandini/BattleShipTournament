using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Emanuel.Models
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

        bool SparoDispobibile()
        {
            bool sparoDisponibile = false;

            foreach (var shootedSeaCell in tacticalSeaMap)
            {
                if (!shootedSeaCell) {

                    sparoDisponibile = true;
                    break;
                }
            }
                 return sparoDisponibile;


        }

        public Coordinate Spara() {

            if (!SparoDispobibile())
            {
                throw new Exception("Io ho già sparato in tutta la mappa, ma l'avversario è un puzzone perché non ha scatenato l'evento flotta affondata!");
            }


            int tentativi = 0;
            bool sparoTrovato = false;
            int riga = 0;
            int colonna = 0;

            // Trova una zona a caso che ancora non è stata colpita
            // provandoci per al massimo dieci volte
            Random random = new Random();

            while (!sparoTrovato && tentativi < 10)
            {
                tentativi++;
                riga = random.Next(0, 9);
                colonna = random.Next(0, 9);

                if (!tacticalSeaMap[riga, colonna])
                {
                    sparoTrovato = true;
                }

            }
            // Trova una zona che ancora non è stata colpita
            // Scandendo tutta la matrice
            if (!sparoTrovato)
            {
                for (int r = 0; r < 10; r++)
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
            
        }
    }
}