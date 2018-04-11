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
        private Dictionary<Coordinate, Boolean> pezziNave; //TRUE=integro FALSE=colpito
        private int lunghezza;

        public Nave(int lunghezza)
        {
            this.lunghezza = lunghezza;
            pezziNave = new Dictionary<Coordinate, Boolean>();
        }

        public List<Coordinate> impostaPosizione(Coordinate posizioneIniziale, bool verso) //TRUE=orizzonatale FALSE=verticale
        {
            List<Coordinate> posizioniOccupate = new List<Coordinate>();
            if(verso)
            {
                //metto come occupato il davanti e il dietro della nave
                Coordinate cornice1 = new Coordinate(posizioneIniziale.Riga, posizioneIniziale.Colonna - 1);
                Coordinate cornice2 = new Coordinate(posizioneIniziale.Riga, posizioneIniziale.Colonna +lunghezza);
                posizioniOccupate.Add(cornice1);
                posizioniOccupate.Add(cornice2);

                //mi preaparo ad occupare il resto dell'intorno
                cornice1 = new Coordinate(posizioneIniziale.Riga - 1, posizioneIniziale.Colonna);
                cornice2 = new Coordinate(posizioneIniziale.Riga + 1, posizioneIniziale.Colonna);

                int riga = posizioneIniziale.Riga;
                for(int i=0; i<lunghezza; i++)
                {
                    int colonna = posizioneIniziale.Colonna + i;
                    Coordinate pezzo = new Coordinate(riga, colonna);
                    pezziNave.Add(pezzo, true);
                    posizioniOccupate.Add(pezzo);

                    Coordinate c1 = new Coordinate(cornice1.Riga, cornice1.Colonna + i);
                    Coordinate c2 = new Coordinate(cornice2.Riga, cornice1.Colonna + i);
                    posizioniOccupate.Add(c1);
                    posizioniOccupate.Add(c2);
                }

            }
            else
            {
                //imposto occupato il davanti e il dietro della nave
                Coordinate cornice1 = new Coordinate(posizioneIniziale.Riga - 1, posizioneIniziale.Colonna);
                Coordinate cornice2 = new Coordinate(posizioneIniziale.Riga + lunghezza, posizioneIniziale.Colonna);
                posizioniOccupate.Add(cornice1);
                posizioniOccupate.Add(cornice2);

                //mi preparo ad occupare il resto dell'intorno
                cornice1 = new Coordinate(posizioneIniziale.Riga, posizioneIniziale.Colonna - 1);
                cornice2 = new Coordinate(posizioneIniziale.Riga, posizioneIniziale.Colonna + 1);

                int colonna = posizioneIniziale.Colonna;
                for(int j=0; j<lunghezza; j++)
                {
                    int riga = posizioneIniziale.Riga + j;
                    Coordinate pezzo = new Coordinate(riga, colonna);
                    pezziNave.Add(pezzo, true);
                    posizioniOccupate.Add(pezzo);

                    Coordinate c1 = new Coordinate(cornice1.Riga + j, cornice1.Colonna);
                    Coordinate c2 = new Coordinate(cornice2.Riga + j, cornice2.Colonna);
                    posizioniOccupate.Add(c1);
                    posizioniOccupate.Add(c2);
                }
            }
            return posizioniOccupate;
        }

    }
}
