using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Mirko.Models
{
    internal class Stratega
    {
        SeaCell[,] seaMap;

        // costruttore della mappa
        public Stratega ()
        {
            // inizializza la mappa
            // chiama il costruttore vuoto di SeaCell
            // il quale si occupa di riempire le celle con il mare
            seaMap = new SeaCell[10,10];

            // posiziono A MANO le navi con un metodo orribile
            Nave n1 = new Nave(1); // sommergibile
            Nave n2 = new Nave(2); // fregata
            Nave n3 = new Nave(3); // ...
            Nave n4 = new Nave(4); // ...
            Nave n5 = new Nave(5); // ...

            seaMap[2, 1] = new SeaCell(n1, 0); // sommergibile posizionato alla riga 2, colonna 1

            seaMap[0, 2] = new SeaCell(n2, 0);
            seaMap[0, 3] = new SeaCell(n2, 1); // ecc ecc

            seaMap[1, 5] = new SeaCell(n3, 0);
            seaMap[2, 5] = new SeaCell(n3, 1);
            seaMap[3, 5] = new SeaCell(n3, 2);

            seaMap[4, 0] = new SeaCell(n4, 0);
            seaMap[5, 0] = new SeaCell(n4, 1);
            seaMap[6, 0] = new SeaCell(n4, 2);
            seaMap[7, 0] = new SeaCell(n4, 3);

            seaMap[6, 2] = new SeaCell(n5, 0);
            seaMap[6, 3] = new SeaCell(n5, 1);
            seaMap[6, 4] = new SeaCell(n5, 2);
            seaMap[6, 5] = new SeaCell(n5, 3);
            seaMap[6, 6] = new SeaCell(n5, 4);


        }

        // metodo per la gestione del colpo ricevuto
        // è di tipo EffettoSparo, definito nel Core
        public EffettoSparo RiceviColpoFaiRapporto (Coordinate sparo)
        {
            EffettoSparo risultato = EffettoSparo.Acqua;

            // identifico la cella su cui è arrivato il colpo
            // sparo è di tipo coordinate, la quale è composta da due variabili
            // ossia Riga e Colonna
            SeaCell seaCell = seaMap [sparo.Riga,sparo.Colonna];

            // testo la cella, verificando che NON sia vuota
            if (!seaCell.IsEmpty)
            {
                // visto che non c'è acqua, lo sparo è andato a segno
                risultato = EffettoSparo.Colpito;

                Nave nave = seaCell.Nave; // nave
                int partIndex = seaCell.PartIndex; // parte della nave che è stata colpita

                if(nave.Colpita(partIndex)) // comunico che la nave è stata colpita e verifico se è stata affondata
                {
                    risultato = EffettoSparo.Affondato;
                }
            }

            return risultato;
        }
    }
}
