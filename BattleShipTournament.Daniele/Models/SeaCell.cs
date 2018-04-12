using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Daniele.Models
{
    public class SeaCell
    {
        public bool IsEmpty
        {
            get { return (Nave == null); }
        }

        public Nave Nave { get; private set; }

        public int ParteIndex { get; private set; }

        // CREAZIONE DI UN COSTRUTTORE VUOTO
        public SeaCell()
        {

        }

        public SeaCell(Nave nave, int partIndex)
        {
            Nave = nave;
            ParteIndex = partIndex;
        

            //SeaCell[,] seaMap = new SeaCell[10, 10];
        }
    }

    
}
