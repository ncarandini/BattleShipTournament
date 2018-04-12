using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Mirko.Models
{
    public class SeaCell
    {
        // metodo per verificare se la cella è vuota, in tal caso faccio una get e restituisco null
        public bool IsEmpty
        {
            get { return (Nave == null); }
        }

        // creo una proprietà di tipo Nave, per effettuare il get e modificarne privatamente i campi
        public Nave Nave { get; private set; }

        // creo una proprietà intera partIndex per effettuare il get e modificarne privatamente il valore
        public int PartIndex { get; private set; }

        // costruttore vuoto da definire in ogni caso per definire una cella che non ha nave
        public SeaCell()
        {

        }

        // costruttore per associare alla cella identificata da partIndex una parte di una nave e l'indice in cui viene posizionata
        public SeaCell (Nave nave, int partIndex)
        {
            Nave = nave;
            PartIndex = partIndex;
        }

    }
}
