using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Walter.Models
{
    internal class Nave
    {
        private List<Coordinate> pezziNave;
        private int lunghezza;

        public Nave(int lunghezza)
        {
            this.lunghezza = lunghezza;
            pezziNave = new List<Coordinate>();
        }

        public List<Coordinate> impostaPosizione(Coordinate posizioneIniziale, bool verso) //TRUE=orizzonatale FALSE=verticale
        {
            List<Coordinate> posizioniOccupate = new List<Coordinate>();
            int rigaIniziale = posizioneIniziale.Riga;
            int colonnaIniziale = posizioneIniziale.Colonna;

            if (verso) //la nave è posizionata in orizzontale
            {
                //metto come occupato il davanti e il dietro della nave
                Coordinate cornice1 = new Coordinate(rigaIniziale, colonnaIniziale - 1);
                Coordinate cornice2 = new Coordinate(rigaIniziale, colonnaIniziale + lunghezza);
                posizioniOccupate.Add(cornice1);
                posizioniOccupate.Add(cornice2);

                //occupo le posizioni della cornice
                for (int i = -1; i <= lunghezza; i++)
                {
                    cornice1 = new Coordinate(rigaIniziale - 1, colonnaIniziale + i);
                    cornice2 = new Coordinate(rigaIniziale + 1, colonnaIniziale + i);
                    posizioniOccupate.Add(cornice1);
                    posizioniOccupate.Add(cornice2);

                    //creo i pezzi della nave
                    if (i > -1 && i < lunghezza)
                    {
                        Coordinate pezzo = new Coordinate(rigaIniziale, colonnaIniziale + i);
                        pezziNave.Add(pezzo);
                        posizioniOccupate.Add(pezzo);
                    }
                }
            }
            else //la nave è posizionata in verticale
            {
                //imposto occupato il davanti e il dietro della nave
                Coordinate cornice1 = new Coordinate(rigaIniziale - 1, colonnaIniziale);
                Coordinate cornice2 = new Coordinate(rigaIniziale + lunghezza, colonnaIniziale);
                posizioniOccupate.Add(cornice1);
                posizioniOccupate.Add(cornice2);

                //occupo le posizione della cornice
                for (int j = -1; j <= lunghezza; j++)
                {
                    cornice1 = new Coordinate(rigaIniziale + j, colonnaIniziale - 1);
                    cornice2 = new Coordinate(rigaIniziale + j, colonnaIniziale + 1);
                    posizioniOccupate.Add(cornice1);
                    posizioniOccupate.Add(cornice2);

                    //creo i pezzi della nave
                    if (j > -1 && j < lunghezza)
                    {
                        Coordinate pezzo = new Coordinate(rigaIniziale + j, colonnaIniziale);
                        pezziNave.Add(pezzo);
                        posizioniOccupate.Add(pezzo);
                    }
                }
            }
            return posizioniOccupate;
        }

        public EffettoSparo ControlloDanni(Coordinate zonaColpita)
        {
            EffettoSparo effetto = EffettoSparo.Acqua;
            //controllo se sono stato colpito
            if(pezziNave.Contains(zonaColpita))
            {
                pezziNave.Remove(zonaColpita);
                if (pezziNave.Any())
                    effetto = EffettoSparo.Affondato;
                else
                    effetto = EffettoSparo.Colpito;
            }
            return effetto;
        }

    }
}
