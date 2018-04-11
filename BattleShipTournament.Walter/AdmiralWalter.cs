using BattleshipTournament.Core.Models;
using BattleShipTournament.Walter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Walter
{
    public class AdmiralWalter : IAdmiral
    {
        public string Nome => "Walter";

        public event Action<IAdmiral> FlottaAffondata; //TODO

        private List<Nave> laMiaFlotta;
        private List<Coordinate> posizioniOccupate; //le posizioni occupate dalla mia flotta
        private List<Coordinate> campoNemico;       //le posizioni in cui ho sparato
        

        public AdmiralWalter()
        {
            //creo le mie navi
            Nave sottomarino = new Nave(1);
            Nave corvetta = new Nave(2);
            Nave fregata = new Nave(3);
            Nave cacciatorpediniere = new Nave(4);
            Nave portaerei = new Nave(5);
            laMiaFlotta.Add(sottomarino);
            laMiaFlotta.Add(corvetta);
            laMiaFlotta.Add(fregata);
            laMiaFlotta.Add(cacciatorpediniere);
            laMiaFlotta.Add(portaerei);

            //creo il mio campo di battaglia
            posizioniOccupate= new List<Coordinate>();

            //creo il campo di battaglia nemico
            campoNemico = new List<Coordinate>();
           
        }

        public void PosizionaFlotta()
        {
            //setto il mio campo di battaglia
            int indice = 0;
            while(indice<laMiaFlotta.Count)
            {
                //genero random il verso della nave
                Random rand = new Random();
                bool versoNave = rand.Next() % 2 == 0;

                //genero random la posizione iniziale della nave
                Nave naveDaPosizionare = laMiaFlotta[indice];
                Coordinate posizioneIniziale = generaCoordinataRandom();
                //provo a posizionare la nave
                bool flag = true;
                List<Coordinate> prova = naveDaPosizionare.impostaPosizione(posizioneIniziale, versoNave);
                foreach (Coordinate c in prova)
                    if (posizioniOccupate.Contains(c))
                    {
                        flag = false;
                        break;
                    }
                        
                // se tutte le posizioni sono libere la nave è posizionata con successo
                if (flag)
                {
                    indice++;
                    foreach (Coordinate c in prova)
                        posizioniOccupate.Add(c);
                }
            }
        }


        public EffettoSparo Rapporto(Coordinate sparo)
        {
            EffettoSparo effettoSparo= EffettoSparo.Acqua;
            foreach(Nave n in laMiaFlotta)
            {
                effettoSparo = n.ControlloDanni(sparo);
                if (effettoSparo.Equals(EffettoSparo.Acqua))
                    continue;
                else if (effettoSparo.Equals(EffettoSparo.Affondato))
                {
                    //rimuovo la nave dalla lista una volta affondata. lista vuota = game over
                    laMiaFlotta.Remove(n);
                    break;
                }  
                else if(effettoSparo.Equals(EffettoSparo.Colpito))
                    break;
            }
            return effettoSparo;
        }

        public Coordinate Spara()
        {
            Coordinate sparo;

            while(true)
            {               
                sparo = generaCoordinataRandom();
                //se non ho già provato a sparare in questa posizione
                if(!campoNemico.Contains(sparo))
                {
                    campoNemico.Add(sparo);
                    break;
                }
            }

            return sparo;
        }

        private Coordinate generaCoordinataRandom()
        {
            Random random = new Random();
            int riga = random.Next(0, 10);
            int colonna = random.Next(0, 10);
            Coordinate coordinata = new Coordinate(riga, colonna);
            return coordinata;

        }
    }
}
