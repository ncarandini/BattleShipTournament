using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Daniele.Models
{
    public class Tattico
    {

        public Tattico()
        {
            tacticalSeaMap = new bool[10, 10];


            for (int r = 0; r < 10; r++)
            {


                for (int c = 0; c < 10; c++)
                {
                    tacticalSeaMap [r,c] = false;
                }


            }
        }

        bool[,] tacticalSeaMap;


        bool SparoDisponibile()
        {
            bool sparoDisponibile = false;

            foreach (var zonaColpita in tacticalSeaMap)
            {
                if (!zonaColpita)
                {
                    sparoDisponibile = true;
                    break;
                }
            }
            
            return sparoDisponibile;
        }




        public Coordinate Spara()
        {

            //EFFETTUA SPARI RANDOM

            if (!SparoDisponibile())
            {
                throw new Exception("io ho sparato in tutta la mappa ma l'avversario è della juve");                                                                                                                                              
            }


            //TROVA UNA ZONA A CASO CHE ANCORA NON E' STATA COLPITA
            //PROVANDOCI PER AL MASSIMO 10 VOLTE 
            
            bool sparoTrovato = false;
            int riga = 0;
            int colonna = 0;

            Random random = new Random();

            int tentativi = 0;

            while (!sparoTrovato && tentativi< 10)
            {
                tentativi++;
                 riga = random.Next(0, 9);
                 colonna = random.Next(0, 9);

                if (!tacticalSeaMap[riga,colonna])
                {
                    sparoTrovato = true;

                }
            }

            
            if (!sparoTrovato)
            {
             //TROVA UNA ZONA CHE ANCORA NON E' STATA COLPITA
                //SCANDENDO TUTTA LA MATRICE
                for (int r = 0; r < 10; r++)
                {
                   
                    
                    for (int c = 0; c < 10; c++)
                    {
                        if (!tacticalSeaMap[r,c])
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

        public void RisultatoSparo(EffettoSparo effettoSparo )
        {

        }
    }
}
