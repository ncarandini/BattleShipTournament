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

        public event Action<IAdmiral> FlottaAffondata;

        private List<Nave> laMiaFlotta;
        private List<Coordinate> posizioniOccupate;
        private List<Coordinate> campoNemico;
        

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
                int riga = rand.Next(0, 10);
                int colonna = rand.Next(0, 10);

                Nave naveDaPosizionare = laMiaFlotta[indice];
                Coordinate posizioneIniziale = new Coordinate(riga, colonna);

                //provo a posizionare la nave
                bool flag = true;
                List<Coordinate> prova = naveDaPosizionare.impostaPosizione(posizioneIniziale, versoNave);
                foreach (Coordinate c in prova)
                    if (posizioniOccupate.Contains(c))
                        flag = false;
                // se tutte le posizioni sono libere la nave è posizionata con successo
                if (flag)
                {
                    indice++;
                    foreach (Coordinate c in prova)
                        posizioniOccupate.Add(c);
                }
            }
        }


        public EffettoSparo Rapporto()
        {
            EffettoSparo effettoSparo= EffettoSparo.Acqua;
            foreach(Nave n in laMiaFlotta)
            {
                //effettoSparo = n.ControlloDanni();
                if (effettoSparo.Equals(EffettoSparo.Acqua))
                    continue;
                else
                    break;
            }
            return effettoSparo;
        }

        public Coordinate Spara()
        {
            Random rand = new Random();
            Coordinate sparo;

            while(true)
            {
                int riga = rand.Next(0, 10);
                int colonna = rand.Next(0, 10);
                sparo = new Coordinate(riga, colonna);
                //se non ho già provato a sparare in questa posizione
                if(!campoNemico.Contains(sparo))
                {
                    campoNemico.Add(sparo);
                    break;
                }
            }

            return sparo;
        }
    }
}
