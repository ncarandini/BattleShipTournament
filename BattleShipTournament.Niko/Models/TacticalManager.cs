using BattleshipTournament.Core.Models;
using BattleShipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Niko.Models

    // vede le coordinate e posiziona le navi in base ai dettagli delle navi

{
    public class TacticalManager
    {
        bool[,] tacticalSeaMap;
        Random randomGenerator = SingleRandom.Current;

        public TacticalManager()
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
            if (!SparoDisponibile())
            {
                throw new Exception("Io ho sparato in tutta la mappa, ma l'avversario è un ebreo perché non ha scatenato l'evento flotta affondata");
            }
            
            bool sparoTrovato = false;
            int riga = 0;
            int colonna = 0;

            // Trova una zona a caso che ancora non è stata colpita
            // Provandoci al massimo per 10 volte.
            
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

            if(!sparoTrovato)
            { 
                // Trova una zona che ancora non è stata colpita
                // Scandendo tutta la matrice.
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
            // TODO
        }

    }
}
