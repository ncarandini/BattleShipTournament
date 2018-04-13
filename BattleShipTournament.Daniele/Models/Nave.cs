using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Daniele.Models
{
     public class Nave
    {
        
        private int lunghezza;

        //DICHIARAZIONE VETTORE 
        private StatusParteNave[] statusNave;


        //CREAZIONE COSTRUTTORE
        public Nave(int lunghezza)
        {
            this.lunghezza = lunghezza;

            //CREAZIONE DEL VETTORE 
            statusNave = new StatusParteNave[lunghezza];

            for (int i = 0; i < lunghezza; i++)
            {
                statusNave[i] = StatusParteNave.Good;
            }
        }

        int partIndex;

        public bool Colpita(int partIndex)
        {
            if (partIndex < 0 || partIndex >= lunghezza - 1)
            {
                //CALCOLO DI UN ECCEZIONE 
                throw new ArgumentOutOfRangeException();
            }

            statusNave[partIndex] = StatusParteNave.Damaged;

            bool affondata = Affondata();

            return affondata;
        }

        public bool Affondata()
        {
            bool affondata = true;


            //CICLE OGNI PARTENAVE IN PARTENAVE 
            foreach (var parteNave in statusNave)
            {

                //SE PARTENAVE NON E STATA COLPITA 
                if (parteNave == StatusParteNave.Good)
                {
                    //LA NAVE NON E' STATA AFFONDATA 
                    affondata = false;

                    //ESCI DEL CICLO 
                    break;
                }
            }

            return affondata;
        }
    }
}
