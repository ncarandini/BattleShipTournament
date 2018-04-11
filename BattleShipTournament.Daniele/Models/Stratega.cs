using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Daniele.Models
{
    internal class Stratega
    {
        //CREAZIONE DI UN ARRAY BIDIMENSIONALE
        SeaCell[,] seaMap;

        //COSTRUTTORE
        public Stratega()
        {
            //inizializza mare vuoto 

            seaMap = new SeaCell[10, 10];

        }

        public void PosiozionaNavi(Nave[]flotta)
        {
            //creazione le navi 
            Nave n1 = flotta[0];
            Nave n2 = flotta[1];
            Nave n3 = flotta[2];
            Nave n4 = flotta[3];
            Nave n5 = flotta[4];

            //creazione spazio prima nave
            seaMap[2, 1] = new SeaCell(n1, 0);

            //creazione spazio seconda nave
            seaMap[4, 1] = new SeaCell(n2, 0);
            seaMap[5, 1] = new SeaCell(n2, 1);

            //creazione spazio terza nave
            seaMap[7, 1] = new SeaCell(n3, 0);
            seaMap[8, 1] = new SeaCell(n3, 1);
            seaMap[9, 1] = new SeaCell(n3, 2);

            //creazione spazio quarta nave
            seaMap[0, 3] = new SeaCell(n4, 0);
            seaMap[1, 3] = new SeaCell(n4, 1);
            seaMap[2, 3] = new SeaCell(n4, 2);
            seaMap[3, 3] = new SeaCell(n4, 3);

            //creazione spazio quinta nave

            seaMap[6, 4] = new SeaCell(n5, 0);
            seaMap[7, 4] = new SeaCell(n5, 1);
            seaMap[8, 4] = new SeaCell(n5, 2);
            seaMap[9, 4] = new SeaCell(n5, 3);
            seaMap[10, 4] = new SeaCell(n5, 4);
        }


        //CREAZIONE METODO
        public EffettoSparo RiceviColpoEFaiRapporto(Coordinate sparo)
        {
            EffettoSparo risultato = EffettoSparo.Acqua;

            SeaCell seaCell = seaMap[sparo.Riga,sparo.Colonna];


            //se non è IsEmpty procedi con l'IF 
            if (!seaCell.IsEmpty)
            {
                Nave nave = seaCell.Nave;
                int partIndex = seaCell.ParteIndex;

                if (nave.Colpita(partIndex))
                {
                    risultato = EffettoSparo.Affondato;
                }
            }


            return risultato;
        }

    }
}
