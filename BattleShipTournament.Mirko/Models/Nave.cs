using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Mirko.Models
{
    // classe principale
    public class Nave
    {
        int lunghezza;
        StatusParteNave[] statusNave;
        
        // costruttore della classe nave
        public Nave(int lunghezza)
        {
            // assegno la lunghezza alla nave
            this.lunghezza = lunghezza;
            // definisco un nuovo vettore
            statusNave = new StatusParteNave[lunghezza];

            // associo ad ogni cella di memoria il valore Good
            for (int i=0; i < lunghezza; i++)
            {
                statusNave[i] = StatusParteNave.Good; //chiamo la classe StatusParteNave.Good per assegnare Good a statusNave[i]
            }
        }

        // metodo
        // per partIndex si intende l'indice delle parti della nave, 
        // se indicata una parte non esistente (tipo parte 2 quando in realtà la nave è grande 1) viene generata un'eccezione
        public bool Colpita (int partIndex)
        {

            if ((partIndex < 0) || (partIndex >= lunghezza)){
                // lancio un'eccezione che comunica che il valore testato esce dal range definito; 
                // potrei inserire un messaggio nelle parentesi ma non c'è bisogno
                throw new ArgumentOutOfRangeException(); 
            }

            statusNave[partIndex] = StatusParteNave.Damaged; // marco come colpita la parte della nave identificata da partIndex
            bool affondata = true;

            // cerco una parte della nave ancora intatta
            // se trovo una parte intatta, pongo affondata = false e blocco il foreach
            foreach (var statusParteNave in statusNave)
            {
                if (statusParteNave == StatusParteNave.Good) 
                {
                    affondata = false;
                    break;
                }
            }
            return affondata;
        }

        SeaCell[,] seaMap = new SeaCell[10, 10];
    }

}
