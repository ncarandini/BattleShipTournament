using BattleShipTournament.GianPaolo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BattleShipTournament.GianPaolo.Models
{
    class Nave
    {
        int Lunghezza { get; set; }
        string Nome { get; set; }
        public List<ParteNave> PartiNave { get;  set; }
        Posizione posizione = new Posizione();
        //usata nel metodo RRiceviCoordinateSparo in Mappa
        public bool NaveAffondata = false;
        Guid guid;
        public Nave(string nome,int lunghezza)
        {
           
            this.Lunghezza = lunghezza;
            this.Nome = nome;
            PartiNave = new List<ParteNave>();
            for(int i=0; i<lunghezza;  i++ )
            {

                guid = new Guid();
                ParteNave Parte = new ParteNave
                {                 
                    Stato = "Intatta"
                };
                PartiNave.Add(Parte);
            }         
        }
        public void posizionaNave(int x,int y)
        {
            posizione.X = x;
            posizione.Y = y;
        }

        public int  GetLunghezza()
        { return Lunghezza; }

        //usato nella mappa nel metodo RiceviCoordinateSparo Mappa
        public bool Affondata()
        {
            int numpart = 0;
          
            foreach(ParteNave parte in PartiNave)
            {
                if(parte.Stato=="colpita")
                { ++numpart; }
            }
            if (numpart == Lunghezza)
            {
                this.NaveAffondata = true;
            }
            return this.NaveAffondata;
        }
       
    }
}
