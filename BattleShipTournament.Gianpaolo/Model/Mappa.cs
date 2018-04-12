using BattleShipTournament.GianPaolo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.GianPaolo.Model
{

    public class Mappa:IMappa
    {
        private static Mappa instance;
        List<Nave>  ListaNavi = new List<Nave>()
        {
        new Nave("sottomarino",1),
        new Nave("corvetta",2),
        new Nave("fregata",3),
        new Nave("cacciatorpediniere",4),
        new Nave("portaerei",5)
        };

        public static Mappa Instanza()
        {
           
            if(instance==null)
            {
                instance = new Mappa();
            }
            return instance;
        }

        public void Posiziona()
        {
            throw new NotImplementedException();
        }

        public string RiceviColpo(int x, int y)
        {
            return CoordinateColpoRicevuto(x, y);
        }

        public String CoordinateColpoRicevuto(int x,int y)
        { String message = "acqua";
            bool trovato = false;
            foreach(Nave n in ListaNavi)
            {
                for(int j=0; j<n.PartiNave.Count; j++)
                {
                    if(n.PartiNave[j].X==x && n.PartiNave[j].Y==y)
                    {
                        n.PartiNave[j].SetStato("colpita");
                        message = "colpita";                      
                        trovato = true;
                        break;
                    }
                    if (n.Affondata())
                    { message = "colpita e affondata"; }
                }
                if(trovato)
                { break; }
            }
            return message;
        }

        public string Sparo(int x, int y)
        {
            return "";
        }
    }
}
