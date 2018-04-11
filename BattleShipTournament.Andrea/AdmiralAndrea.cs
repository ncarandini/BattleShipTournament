﻿using BattleshipTournament.Core.Models;
using BattleShipTournament.Andrea.Models;
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
        

        int posizionamentoRiga;
        int posizionamentoColonna;
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

        public void PosizionaFlotta()
        {
            //prova di inserimento coordinata in una partenave
            flotta[1].GetParteNave(0).SetCoordinata(1, 2);

            casellaUsata = new bool[DIMENSIONEMAPPA+1, DIMENSIONEMAPPA+1];

            //foreach(Nave nave in flotta)

            for (int i=0;i<flotta.Length;)  // ciclo for su tutte le navi
            {
                RandomPosizioneEDirezione(flotta[i]);  //riempie direzione, posizionamentoRiga, posizionamentoColonna

                ControlloPostoLibero(flotta[i]);

                if(postoLibero)
                {
                    for (int j=0; i< flotta[i].parteNave.Length;i++)
                    {
                        if (direzione==0) // direzione orizzontale 
                        {
                            flotta[i].parteNave[j].SetCoordinata(posizionamentoRiga, posizionamentoColonna+ j); //inserisce coordinate nave nell'array di navi chiamato flotta.

                            mappaGiocatore.SetCasellaPiena(new CoordinataXY(posizionamentoRiga, posizionamentoColonna + j)); //riempie la mappa giocatore

                            casellaUsata[posizionamentoRiga, posizionamentoColonna + j] = true; //riempie array provvisiorio per controllare se successivamente posso inserire le navi.
                        }
                        else
                        {
                            flotta[i].parteNave[j].SetCoordinata(posizionamentoRiga+ j, posizionamentoColonna );
                            casellaUsata[posizionamentoRiga+ j, posizionamentoColonna ] = true;
                        }
                    }

                    i++; // aumenta contatore ciclo for per passare a nave successiva

                    postoLibero = false; // resetta posto libero per essere usato in un altra nave
                }
            }
        }  // posizionamento random della flotta.

        private void RandomPosizioneEDirezione(Nave nave)
        {
            Random r = new Random();
            direzione = r.Next(0, 1);    //0= barca da posizionare il orizzontale, 1= verticale
            if (direzione == 0)
            {
                posizionamentoRiga = r.Next(1, DIMENSIONEMAPPA  - nave.Lunghezza);
                posizionamentoColonna = r.Next(1, DIMENSIONEMAPPA );
            }
            else
            {
                posizionamentoRiga = r.Next(1, DIMENSIONEMAPPA);
                posizionamentoColonna = r.Next(1, DIMENSIONEMAPPA - nave.Lunghezza);
            }
        }  // crea numeri random per posizione e direzione

        private void ControlloPostoLibero(Nave nave) // controlla se la nave può essere posizionata
        {

            if (casellaUsata[posizionamentoRiga, posizionamentoColonna] == false)
            {
                for (int i = 0; i < nave.Lunghezza - 1; i++)
                {
                    if (casellaUsata[posizionamentoRiga, posizionamentoColonna] == false) //Controlla se la casella è già stata usata
                    {
                        if (direzione == 0) //direzione orizzontale
                        {
                            if (i == 0) //controllo sulla prima parte della barca da posizionare il orizzontale
                            {
                                if (casellaUsata[posizionamentoRiga, posizionamentoColonna - 1] == false ||
                                    casellaUsata[posizionamentoRiga - 1, posizionamentoColonna] == false ||
                                    casellaUsata[posizionamentoRiga + 1, posizionamentoColonna] == false)
                                {
                                    postoLibero = true;
                                }
                            }
                            else if (i == nave.Lunghezza - 1) // controllo sull'ultima parte della nave
                            {
                                if (casellaUsata[posizionamentoRiga, posizionamentoColonna + 1] == false ||
                                    casellaUsata[posizionamentoRiga - 1, posizionamentoColonna] == false ||
                                    casellaUsata[posizionamentoRiga + 1, posizionamentoColonna] == false)
                                {
                                    postoLibero = true;
                                }
                            }
                            else  // controllo sul resto della nave tranne prima ed ultima parte
                            {
                                if (casellaUsata[posizionamentoRiga - 1, posizionamentoColonna] == false ||
                                    casellaUsata[posizionamentoRiga + 1, posizionamentoColonna] == false)
                                {
                                    postoLibero = true;
                                }
                            }
                        }
                        else // controllo sulle navi da posizionare in verticale
                        {
                            if (i == 0) //controllo sulla prima parte della barca da posizionare il verticale
                            {
                                if (casellaUsata[posizionamentoRiga - 1, posizionamentoColonna] == false ||
                                    casellaUsata[posizionamentoRiga, posizionamentoColonna - 1] == false ||
                                    casellaUsata[posizionamentoRiga, posizionamentoColonna + 1] == false)
                                {
                                    postoLibero = true;
                                }
                            }
                            else if (i == nave.Lunghezza - 1) // controllo sull'ultima parte della nave
                            {
                                if (casellaUsata[posizionamentoRiga + 1, posizionamentoColonna] == false ||
                                    casellaUsata[posizionamentoRiga, posizionamentoColonna - 1] == false ||
                                    casellaUsata[posizionamentoRiga, posizionamentoColonna + 1] == false)
                                {
                                    postoLibero = true;
                                }
                            }
                            else  // controllo sul resto della nave tranne prima ed ultima parte
                            {
                                if (casellaUsata[posizionamentoRiga, posizionamentoColonna - 1] == false ||
                                    casellaUsata[posizionamentoRiga, posizionamentoColonna + 1] == false)
                                {
                                    postoLibero = true;
                                }
                            }
                        }
                    }
                }
            }
        }



        public EffettoSparo Rapporto(Coordinate sparo)
        {
            throw new NotImplementedException();
        }



        public Coordinate Spara()
        {
            throw new NotImplementedException();
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


    }
}
