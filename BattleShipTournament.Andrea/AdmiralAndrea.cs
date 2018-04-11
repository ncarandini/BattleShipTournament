using BattleshipTournament.Core.Models;
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

        Coordinate coordinateProva;



        public AdmiralAndrea()
        {
            InizializzaNavi();
            mappaGiocatore = new Mappa(DIMENSIONEMAPPA);
            mappaAvversario = new Mappa(DIMENSIONEMAPPA);

            coordinateProva = new Coordinate(5, 5);
            


        }

        public void PosizionaFlotta()
        {
            //prova di inserimento coordinata in una partenave
            flotta[1].GetParteNave(0).SetCoordinata(1, 2);

            bool[,] casellaUsata = new bool[DIMENSIONEMAPPA, DIMENSIONEMAPPA];

            foreach(Nave nave in flotta)
            {
                Random r = new Random();
                int direzione = r.Next(0, 1);    //0= barca da posizionare il orizzontale, 1= verticale
                if (direzione==0)
                {
                    int posizionamentoRiga = r.Next(0, DIMENSIONEMAPPA-1-nave.Lunghezza);
                    int posizionamentoColonna = r.Next(0, DIMENSIONEMAPPA-1);
                }
                else
                {
                    int posizionamentoRiga = r.Next(0, DIMENSIONEMAPPA - 1);
                    int posizionamentoColonna = r.Next(0, DIMENSIONEMAPPA - 1 - nave.Lunghezza);
                    
                }
                
                
                for (int i=0; i< nave.parteNave.Length;i++)
                {

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
