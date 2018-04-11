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

        public string Id
        {
            get
            {
                return Name.Substring(0) + Name.Substring(Name.Length);
            }
        }

        public bool isDeath
        {
            get
            {
                bool isdeath = false;
                for (int i = 0; i < Parts.Length; i++)
                {
                    if (Parts[i] == true)
                        isdeath = true;
                    else
                        isdeath = false;
                }
                return isdeath;
            }
        }

        public bool[] Parts;


        public Nave(string nome, int lunghezza)
        {
            Name = nome;
            Length = lunghezza;
            Parts = new bool[Length];
        }

        public void DanneggiaNave(int indexParteNave)
        {
            Parts[indexParteNave] = true;
        }
    }
}
