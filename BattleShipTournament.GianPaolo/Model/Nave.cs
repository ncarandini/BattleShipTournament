using BattleShipTournament.GianPaolo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.GianPaolo.Models
{
    class Nave
    {
        public int Lunghezza { get; set; }
        public string Nome { get; set; }
        public  List<ParteNave> PartiNave;
       

        public struct posizione
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        public Nave(string nome,int lunghezza)
        {
            this.Lunghezza = lunghezza;
            this.Nome = nome;
            PartiNave = new List<ParteNave>();
            for(int i=0; i<lunghezza;  i++ )
            {
                ParteNave Parte = new ParteNave
                {
                    Stato = "Intatto"
                };
                PartiNave.Add(Parte);
            }
        }

    }
}
