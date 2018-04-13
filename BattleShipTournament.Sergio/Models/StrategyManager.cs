using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Sergio.Models
{
    internal class StrategyManager
    {
        SeaCell[,] seaMap;
        public StrategyManager()

        {

            seaMap = new SeaCell[10, 10];

            for (int riga = 0; riga < 10; riga++)
            {
                for (int colonna = 0; colonna < 10; colonna++)
                {
                    seaMap[riga, colonna] = new SeaCell();
                }
            }

        }

        public void PosizionaNavi(Ship[] fleet)
        {

            Ship s1 = fleet[0];
            Ship s2 = fleet[1];
            Ship s3 = fleet[2];
            Ship s4 = fleet[3];
            Ship s5 = fleet[4];

            seaMap[9, 5] = new SeaCell(s1, 0);

            seaMap[10, 2] = new SeaCell(s2, 0);
            seaMap[10, 3] = new SeaCell(s2, 1);

            seaMap[5, 3] = new SeaCell(s3, 0);
            seaMap[6, 3] = new SeaCell(s3, 1);
            seaMap[7, 3] = new SeaCell(s3, 2);

            seaMap[4, 9] = new SeaCell(s4, 0);
            seaMap[5, 9] = new SeaCell(s4, 1);
            seaMap[6, 9] = new SeaCell(s4, 2);
            seaMap[7, 9] = new SeaCell(s4, 3);

            seaMap[2, 4] = new SeaCell(s5, 0);
            seaMap[2, 5] = new SeaCell(s5, 1);
            seaMap[2, 6] = new SeaCell(s5, 2);
            seaMap[2, 7] = new SeaCell(s5, 3);
            seaMap[2, 8] = new SeaCell(s5, 4);
        }

        public EffettoSparo RiceviColpoFaiRapporto(Coordinate sparo)
        {
            EffettoSparo risultato = EffettoSparo.Acqua;
            SeaCell seaCell = seaMap[sparo.Riga, sparo.Colonna];

            if (!seaCell.isEmpty)
            {
                risultato = EffettoSparo.Colpito;
                Ship ship = seaCell.Ship;
                int partIndex = seaCell.PartIndex;
                if (ship.Colpita(partIndex))
                {
                    risultato = EffettoSparo.Affondato;
                }
            }




            return risultato;
        }
    }
}
