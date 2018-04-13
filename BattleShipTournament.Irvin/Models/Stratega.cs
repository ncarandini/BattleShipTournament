using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Irvin.Models
{
    internal class Stratega
    {
        SeaCell[,] seaMap;

        public Stratega()
        {
            // Inizializza mare vuoto
            seaMap = new SeaCell[10, 10];

            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    seaMap[r, c] = new SeaCell();
                }
            }
        }

        public void PosizioneNavi(Ship[] fleet)
        {
            // Crea le navi
            Ship s1 = fleet[0];  //new ship (x) -> lunghezza nave
            Ship s2 = fleet[1];
            Ship s3 = fleet[2];
            Ship s4 = fleet[3];
            Ship s5 = fleet[4];

            // Metti le navi
            seaMap[2, 1] = new SeaCell(s1, 0);      //lo 0 si riferisce all'index della nave (cioè la parte della nave, sarebbe 1 ma l'indice parte da 0)

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

        public EffettoSparo RiceviColpoFaiRapporto(Coordinate coordinate)
        {
            EffettoSparo risultato = EffettoSparo.Acqua;

            SeaCell seaCell = seaMap[coordinate.Riga, coordinate.Colonna];

            if(!seaCell.IsEmpty)    //se non (!) è vuoto
            {
                risultato = EffettoSparo.Acqua;

                Ship ship = seaCell.Ship;
                int partIndex = seaCell.PartIndex;

                if(ship.Colpita(partIndex))
                {
                    risultato = EffettoSparo.Affondato;
                }
            }
            return risultato;
        }
    }
}