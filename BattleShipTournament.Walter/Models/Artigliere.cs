using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Walter.Models
{
    internal class Artigliere
    {
        private List<Coordinate> campoNemico;
        private Coordinate ultimoSparo;
        private Coordinate ultimoSparoASegno;
        private bool bersagliColpito = false;

        public Artigliere()
        {
            campoNemico = new List<Coordinate>();
        }

        public Coordinate spara()
        {
            Coordinate sparo;

            //se l'ultimo colpo è andato a segno
            if (bersagliColpito)
            {
                int riga = ultimoSparoASegno.Riga;
                int colonna = ultimoSparoASegno.Colonna;

                Coordinate c;
                int i = 0;
                while(true)
                {
                    c = rosaDiColpi(i);
                    if (controllaCampoNemico(c))
                        break;
                    else
                        i++;

                    //se si dovesse bloccare per qualche motivo faccio random
                    if (i>3)
                    {
                        c = GeneratoreCoordinateRandom.generaCoordinata();
                        if(controllaCampoNemico(c))
                            break;
                    }
                }
                sparo = c;

            }

            //se l'ultimo colpo è andato a vuoto genero random
            else
            {
                while (true)
                {
                    sparo = GeneratoreCoordinateRandom.generaCoordinata();
                    if (controllaCampoNemico(sparo))
                    {
                        break;
                    }
                }
            }
            return sparo;
        }

        public void verificaUltimoSparo(EffettoSparo effetto)
        {
            if (effetto.Equals(EffettoSparo.Colpito))
            {
                ultimoSparoASegno = ultimoSparo;
                bersagliColpito = true;
            }
            else if (effetto.Equals(EffettoSparo.Affondato) || effetto.Equals(EffettoSparo.Acqua))
            {
                bersagliColpito = false;
            }
        }

        private bool controllaCampoNemico(Coordinate sparo)
        {
            bool viaLibera=false;

            if (!campoNemico.Contains(sparo))
            {
                campoNemico.Add(sparo);
                ultimoSparo = sparo;
                viaLibera = true;
            }
            return viaLibera;
        }

        private Coordinate rosaDiColpi(int i)
        {
            Coordinate c;
            int riga = ultimoSparoASegno.Riga;
            int colonna = ultimoSparoASegno.Colonna;

            if (i == 0 && riga + 1 < 10)
            {
                c = new Coordinate(riga + 1, colonna);
            }
            else if (i == 1 && riga - 1 >= 0)
            {
                c = new Coordinate(riga - 1, colonna);
            }
            else if (i == 2 && colonna + 1 < 10)
            {
                c = new Coordinate(riga, colonna + 1);

            }
            else //if (i == 3 && colonna - 1 >= 0)
            {
                c = new Coordinate(riga, colonna - 1);
            }

            return c;
           
        }
    }
}
