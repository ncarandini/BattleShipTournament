using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipTournament.Alessio.Models
{
    internal class Nave
    {
        public string Name { get; private set; }
        public int Length { get; private set; }
        public bool[] Parts;

        public Nave(string nome, int lunghezza)
        {
            Name = nome;
            Length = lunghezza;
            Parts = new bool[Length];
        }

        public string ValutaDanni()
        {
            string situazioneDanni = string.Empty;
            int puntiVita = Length;
            for (int i = 0; i < Parts.Length; i++)
            {
                if (Parts[i] == true)
                    --puntiVita;
            }
            situazioneDanni = string.Format("La nave {0} ha {1} punti vita su {2}", Name, puntiVita, Length);
            return situazioneDanni;
        }
    }
}
