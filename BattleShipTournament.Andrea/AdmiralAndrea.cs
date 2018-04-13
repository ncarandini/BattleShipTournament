using BattleshipTournament.Core.Models;
using BattleShipTournament.Andrea.Models;
using BattleShipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Andrea
{
    public class AdmiralAndrea : IAdmiral
    {
        private static int QUANTITANAVI = 5;
        private static int DIMENSIONEMAPPA = 10;
        public string Nome => "Andrea";

        public event Action<IAdmiral> FlottaAffondata;

        private Nave[] flotta;

        private Mappa mappaGiocatore;
        private Mappa mappaAvversario;

        Random randomGenerator = SingleRandom.Current;
        

        int posizionamentoRiga;
        int posizionamentoColonna;
        int controlloRiga;
        int controlloColonna;

        int direzione;

        bool postoLibero;
        bool[,] casellaUsata;

        public AdmiralAndrea()
        {
            InizializzaNavi();
            mappaGiocatore = new Mappa(DIMENSIONEMAPPA);
            mappaAvversario = new Mappa(DIMENSIONEMAPPA);

            PosizionaFlotta(); //?? da inserire nel costruttore o no??
        }

        public void PosizionaFlotta()  // posizionamento random della flotta.
        {
            //prova di inserimento coordinata in una partenave
            //flotta[1].GetParteNave(0).SetCoordinata(1, 2);

            casellaUsata = new bool[DIMENSIONEMAPPA+2, DIMENSIONEMAPPA+2]; //creazione di un array di bool di una dimensione maggiore del campo di battaglia da usare solo per il controllo delle navi gia inserite)

            //foreach(Nave nave in flotta)

            for (int i=0;i<flotta.Length;)  // ciclo for su tutte le navi
            {
                RandomPosizioneEDirezione(flotta[i]);  //riempie direzione, posizionamentoRiga, posizionamentoColonna

                ControlloPostoLibero(flotta[i]);

                if(postoLibero)
                {
                    for (int j=0; i< flotta[i].ParteNave.Length;i++)
                    {
                        if (direzione==0) // direzione orizzontale 
                        {
                            flotta[i].ParteNave[j].SetCoordinata(posizionamentoRiga, posizionamentoColonna+ j); //inserisce coordinate nave nell'array di navi chiamato flotta.

                            mappaGiocatore.SetCasellaPiena(new CoordinataXY(posizionamentoRiga, posizionamentoColonna + j)); //riempie la mappa giocatore

                            casellaUsata[controlloRiga, controlloColonna + j] = true; //riempie array provvisiorio per controllare se successivamente posso inserire le navi.
                            casellaUsata[controlloRiga+1, controlloColonna + j -1] = true;
                            casellaUsata[controlloRiga, controlloColonna + j -1] = true;
                            casellaUsata[controlloRiga -1, controlloColonna + j -1] = true;
                            casellaUsata[controlloRiga -1, controlloColonna + j ] = true;
                            casellaUsata[controlloRiga +1, controlloColonna + j +1] = true;
                            casellaUsata[controlloRiga, controlloColonna + j +1] = true;
                            casellaUsata[controlloRiga +1, controlloColonna + j +1] = true;
                            casellaUsata[controlloRiga + 1, controlloColonna + j ] = true;
                        }
                        else
                        {
                            flotta[i].ParteNave[j].SetCoordinata(posizionamentoRiga+ j, posizionamentoColonna );

                            casellaUsata[controlloRiga + j - 1, controlloColonna - 1] = true;
                            casellaUsata[controlloRiga + j - 1, controlloColonna] = true;
                            casellaUsata[controlloRiga + j - 1, controlloColonna + 1] = true;
                            casellaUsata[controlloRiga + j, controlloColonna + 1] = true;
                            casellaUsata[controlloRiga + j + 1, controlloColonna + 1] = true;
                            casellaUsata[controlloRiga + j + 1, controlloColonna] = true;
                            casellaUsata[controlloRiga + j + 1, controlloColonna - 1] = true;
                            casellaUsata[controlloRiga + j, controlloColonna - 1] = true;
                            casellaUsata[controlloRiga + j, controlloColonna] = true;

                        }
                    }

                    i++; // aumenta contatore ciclo for per passare a nave successiva

                    postoLibero = false; // resetta posto libero per essere usato in un altra nave
                }
            }
        }  

        private void RandomPosizioneEDirezione(Nave nave) // crea numeri random per posizione e direzione
        {
            //Random r = new Random();
            direzione = randomGenerator.Next(0, 1);    //0= barca da posizionare il orizzontale, 1= verticale


            if (direzione == 0)  //uso di random per selezionare le coordinate in base alla direzione e alla lunghezza della nave
            {
                posizionamentoRiga = randomGenerator.Next(0, DIMENSIONEMAPPA  - nave.Lunghezza);
                posizionamentoColonna = randomGenerator.Next(0, DIMENSIONEMAPPA );
                controlloRiga = posizionamentoRiga + 1;
                controlloColonna = posizionamentoColonna + 1;
            }
            else
            {
                posizionamentoRiga = randomGenerator.Next(0, DIMENSIONEMAPPA);
                posizionamentoColonna = randomGenerator.Next(0, DIMENSIONEMAPPA - nave.Lunghezza);
            }
        }  

        private void ControlloPostoLibero(Nave nave) // controlla se la nave può essere posizionata
        {
            
            if (casellaUsata[controlloRiga, controlloColonna] == false)  //Controlla se la casella è già stata usata
            {
                for (int i = 0; i < nave.Lunghezza - 1; i++)
                {
                    if (casellaUsata[controlloRiga, controlloColonna] == false)  // controllo inutile?? forse da togliere
                    {
                        if (direzione == 0) //direzione orizzontale
                        {
                            if (i == 0) //controllo sulla prima parte della barca da posizionare il orizzontale
                            {
                                if (casellaUsata[controlloRiga, controlloColonna - 1] == false &&
                                    casellaUsata[controlloRiga - 1, controlloColonna] == false &&
                                    casellaUsata[controlloRiga - 1, controlloColonna - 1] == false &&
                                    casellaUsata[controlloRiga + 1, controlloColonna - 1] == false &&
                                    casellaUsata[controlloRiga + 1, controlloColonna] == false)
                                {
                                    postoLibero = true;
                                }
                                else
                                {
                                    postoLibero = false;
                                }
                            }
                            else if (i == nave.Lunghezza - 1) // controllo sull'ultima parte della nave
                            {
                                if (casellaUsata[controlloRiga, controlloColonna + 1] == false &&
                                    casellaUsata[controlloRiga + 1, controlloColonna + 1] == false &&
                                    casellaUsata[controlloRiga - 1, controlloColonna + 1] == false &&
                                    casellaUsata[controlloRiga - 1, controlloColonna] == false &&
                                    casellaUsata[controlloRiga + 1, controlloColonna] == false)
                                {
                                    postoLibero = true;
                                }
                                else
                                {
                                    postoLibero = false;
                                }
                            }
                            else  // controllo sul resto della nave tranne prima ed ultima parte
                            {
                                if (casellaUsata[controlloRiga - 1, controlloColonna] == false &&
                                    casellaUsata[controlloRiga + 1, controlloColonna] == false)
                                {
                                    postoLibero = true;
                                }
                                else
                                {
                                    postoLibero = false;
                                }
                            }
                        }
                        else // controllo sulle navi da posizionare in verticale
                        {
                            if (i == 0) //controllo sulla prima parte della barca da posizionare il verticale
                            {
                                if (casellaUsata[controlloRiga , controlloColonna -1] == false &&
                                    casellaUsata[controlloRiga -1, controlloColonna - 1] == false &&
                                    casellaUsata[controlloRiga - 1, controlloColonna ] == false &&
                                    casellaUsata[controlloRiga - 1, controlloColonna + 1] == false &&
                                    casellaUsata[controlloRiga, controlloColonna + 1] == false)
                                {
                                    postoLibero = true;
                                }
                                else
                                {
                                    postoLibero = false;
                                }
                            }
                            else if (i == nave.Lunghezza - 1) // controllo sull'ultima parte della nave
                            {
                                if (casellaUsata[controlloRiga , controlloColonna -1] == false &&
                                    casellaUsata[controlloRiga + 1, controlloColonna -1] == false &&
                                    casellaUsata[controlloRiga + 1, controlloColonna ] == false &&
                                    casellaUsata[controlloRiga +1, controlloColonna + 1] == false &&
                                    casellaUsata[controlloRiga, controlloColonna + 1] == false)
                                {
                                    postoLibero = true;
                                }
                                else
                                {
                                    postoLibero = false;
                                }
                            }
                            else  // controllo sul resto della nave tranne prima ed ultima parte
                            {
                                if (casellaUsata[controlloRiga, controlloColonna - 1] == false &&
                                    casellaUsata[controlloRiga, controlloColonna + 1] == false)
                                {
                                    postoLibero = true;
                                }
                                else
                                {
                                    postoLibero = false;
                                }
                            }
                        }
                    }
                }
            }
        }



        public EffettoSparo Rapporto(Coordinate sparo)
        {
            CoordinataXY coordinataSparo = new CoordinataXY(sparo.Riga, sparo.Colonna);

            for(int i=0; i<flotta.Length;i++)
            {
                for (int j=0;j<flotta[i].ParteNave.Length;j++)
                {
                    if(!flotta[i].ParteNave[j].Distrutta)
                    {
                        flotta[i].ParteNave[j].Distrutta = true;
                        return EffettoSparo.Colpito;
                    }
                }
            }
            return EffettoSparo.Acqua;
        }


        public Coordinate Spara()
        {
                                      // da implementare il while true e fare un numero massimo di coordinate da cercare
            while (true)
            {
                CoordinataXY coordinataSparo = RandomSparo();
                if (!mappaAvversario.getCasella(coordinataSparo).Colpita) // controllo se ho già colpito la casella della mappa avversario
                {
                    return (new Coordinate(coordinataSparo.Riga, coordinataSparo.Colonna));
                }
            }
        }

            

        

        private CoordinataXY RandomSparo()
        {
            Random r = new Random();
            int sparoRiga = r.Next(0, DIMENSIONEMAPPA - 1);
            int sparoColonna = r.Next(0, DIMENSIONEMAPPA - 1);

            CoordinataXY coordinataSparo = new CoordinataXY(sparoRiga, sparoColonna);

            return coordinataSparo;

        }


        private void InizializzaNavi()
        {
            //da sistemare in base a quante navi devono essere inserite.

            flotta = new Nave[QUANTITANAVI];

            for (int i=0;i<flotta.Length;i++)
            {
                int aux = i + 1;
                flotta[i] = new Nave(aux);
            }
        }

        public void RiceviRapporto(EffettoSparo effettoSparo)
        {
            throw new NotImplementedException();
        }
    }
    
}
