﻿using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Nabil.Models
{
   internal class Stratega
    {
        SeaCell[,] seaMap;


        public Stratega()
        {
            //inizializza il mare vuoto
            seaMap = new SeaCell[10, 10];
        }

        public void PosizionaNavi(Nave[] fleet)
        {
            //mcrea le navi
            Nave n1 = fleet[0];
            Nave n2 = fleet[1];
            Nave n3 = fleet[2];
            Nave n4 = fleet[3];
            Nave n5 = fleet[4];
            //metti le navi
            seaMap[2, 1] = new SeaCell(n1, 0);

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

        public EffettoSparo RiceviColpoFaiRapporto(Coordinate sparo)
        {
            EffettoSparo risultato = EffettoSparo.Acqua;

            SeaCell seaCell = seaMap[sparo.Riga, sparo.Colonna];

            if (!seaCell.IsEmpty)
            {
                risultato = EffettoSparo.Colpito;
                Nave nave = seaCell.Nave;
                int partIndex = seaCell.PartIndex;

                if (nave.Colpita(partIndex))
                {
                    risultato = EffettoSparo.Affondato;
                }

            }


            return risultato;
        }
    }
}
