using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Niko.Models

    // vede l'effetto sparo e ripete gli attacchi nelle vicinanze o meno a seconda dell'esito

{
    internal class StrategyManager
    {
        SeaCell[,] seaMap;

        public StrategyManager()
        {
            // inizializza mare vuoto 
            seaMap = new SeaCell[10, 10];
        }

        public void PosizionaNavi(Nave[] flotta)
        {
            // crea le navi
            Nave s1 = flotta[0];
            Nave s2 = flotta[1];
            Nave s3 = flotta[2];
            Nave s4 = flotta[3];
            Nave s5 = flotta[4];

            // metti le navi
            seaMap[2, 1] = new SeaCell(s1, 0);

            seaMap[0, 2] = new SeaCell(s2, 0);
            seaMap[0, 3] = new SeaCell(s2, 1);

            seaMap[1, 5] = new SeaCell(s3, 0);
            seaMap[2, 5] = new SeaCell(s3, 1);
            seaMap[3, 5] = new SeaCell(s3, 2);

            seaMap[4, 0] = new SeaCell(s4, 0);
            seaMap[5, 0] = new SeaCell(s4, 1);
            seaMap[6, 0] = new SeaCell(s4, 2);
            seaMap[7, 0] = new SeaCell(s4, 3);

            seaMap[6, 2] = new SeaCell(s5, 0);
            seaMap[6, 3] = new SeaCell(s5, 1);
            seaMap[6, 4] = new SeaCell(s5, 2);
            seaMap[6, 5] = new SeaCell(s5, 3);
            seaMap[6, 6] = new SeaCell(s5, 4);
        }

        public EffettoSparo RiceviColpoEFaiRapporto(Coordinate sparo)
        {
            EffettoSparo risultato = EffettoSparo.Acqua;

            SeaCell seaCell = seaMap[sparo.Riga, sparo.Colonna];

            if (!seaCell.IsEmpty)
            {
                risultato = EffettoSparo.Colpito;
                
                if (seaCell.Nave.Colpita(seaCell.PartIndex))
                {
                    risultato = EffettoSparo.Affondato;
                }
            }



            return risultato;
        }

    }
}
