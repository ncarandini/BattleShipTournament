using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Mirko.Models
{
    public class Tattico
    {
        bool[,] tacticalSeaMap;

        // costruttore della classe
        public Tattico()
        {
            // preparo la mappa tattica, effettuando una new
            tacticalSeaMap = new bool[10, 10];

            // pongo ogni cella della mappa tattica, a false
            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    {
                        tacticalSeaMap[r, c] = false;
                    }
                }
            }
        }

        //metodo per controllare se è possibile sparare ulteriormente
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
        // metodo per sparare
        public Coordinate Spara ()
        {
            if (!SparoDisponibile())
            {
                throw new Exception("Io ho sparato in tutta la mappa, ma l'avversario è un puzzone, perchè non ha scatenato l'evento flotta affondata!");
            }
           
            bool sparoTrovato = false;
            int riga = 0;
            int colonna = 0;

            // trova una zona a caso che non è stata ancora colpita, provandoci al massimo 10 volte
            Random random = new Random();
            int tentativi = 0;
            while (!sparoTrovato && tentativi < 9)
            {
                tentativi++;
                riga = random.Next(0, 9);
                colonna = random.Next(0, 9);

                if (!tacticalSeaMap[riga, colonna])
                {
                    sparoTrovato = true;

                }
            }

            if (!sparoTrovato)
            {            
                // trova una zona che non è stata ancora colpita, scandendo tutto la matrice
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

        // metodo
        public void RisultatoSparo (EffettoSparo effettoSparo)
        {
            //TODO
        }
    }
}
