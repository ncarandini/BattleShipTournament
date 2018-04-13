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
            
            // inizializza la mappa chiama il costruttore vuoto di SeaCell il quale si occupa di riempire le celle con il mare
            seaMap = new SeaCell[10, 10];

            for (int riga = 0; riga < 10; riga++)
            {
                for (int colonna = 0; colonna < 10; colonna++)
                {
                    seaMap[riga, colonna] = new SeaCell();
                }
            }
        }
        
        // metodo per il posizionamento delle navi che pongo come publico per far si che possa essere chiamato da AdmiralMirko
        public void PosizionaNavi(Nave[] flotta)
        {
            // posiziono A MANO le navi con un metodo orribile
            Nave n1 = flotta[0];
            Nave n2 = flotta[1];
            Nave n3 = flotta[2];
            Nave n4 = flotta[3];
            Nave n5 = flotta[4];

            seaMap[2, 1] = new SeaCell(n1, 0); // sommergibile posizionato alla riga 2, colonna 1

            seaMap[0, 2] = new SeaCell(n2, 0);
            seaMap[0, 3] = new SeaCell(n2, 1); 

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

        // metodo per la gestione del colpo ricevuto è di tipo EffettoSparo, definito nel Core
        public EffettoSparo RiceviColpoFaiRapporto (Coordinate sparo)
        {
            EffettoSparo risultato = EffettoSparo.Acqua;

            // identifico la cella su cui è arrivato il colpo sparo è di tipo coordinate, la quale è composta da due variabili ossia Riga e Colonna
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
