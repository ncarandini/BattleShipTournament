using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipTournament.Alessio.Models
{
    internal class Mappa
    {
        private List<Nave> navi;
        private string [,] mappa;
        private AdmiralAlessio admiral;

        public Mappa()
        {
            mappa = new string[10, 10];
            admiral = new AdmiralAlessio();
        }

        /// <summary>
        /// Metodo che posiziona la nave in base alle coordinate e alla posizione data (orrizzontale o verticale)
        /// </summary>
        /// <param name="nave">Tipo di nave</param>
        /// <param name="coordinate">Coordinate x, y</param>
        /// <param name="position">Metodo di posizionamento h (orrizontale) / v (verticale)</param>
        /// <returns></returns>
        public bool PosizionaNave(Nave nave, Coordinate coordinate, char position)
        {
            bool disponibilita = false;
            if (position == 'h')
            {
                if (mappa.Length - coordinate.Riga > mappa.Length)
                {
                    return disponibilita;
                }
                else
                {
                    int[] arrayPosizionamento = new int[nave.Length];
                    for (int i = 0; i < arrayPosizionamento.Length; i++)
                    {
                        arrayPosizionamento[i] = coordinate.Riga + i;
                    }

                    int posPrima = arrayPosizionamento[0] - 1;
                    int posDopo = arrayPosizionamento[nave.Length] + 1;

                    if (posPrima > 0 && mappa[posPrima, coordinate.Colonna] == string.Empty)
                    {
                        if (posDopo < mappa.Length && mappa[posDopo, coordinate.Colonna] == string.Empty)
                        {
                            for (int i = coordinate.Riga, j = 1; i < nave.Length; i++, j++)
                            {
                                mappa[i, coordinate.Colonna] = nave.Id + j;
                                disponibilita = true;
                                break;
                            }
                        }
                    }
                    else
                        return disponibilita;
                }
            }
            else if (position == 'v')
            {
                if (mappa.Length - coordinate.Colonna > mappa.Length)
                {
                    return disponibilita;
                }
                else
                {
                    int[] arrayPosizionamento = new int[nave.Length];
                    for (int i = 0; i < arrayPosizionamento.Length; i++)
                    {
                        arrayPosizionamento[i] = coordinate.Colonna + i;
                    }

                    int posPrima = arrayPosizionamento[0] - 1;
                    int posDopo = arrayPosizionamento[nave.Length] + 1;

                    if (posPrima > 0 && mappa[posPrima, coordinate.Colonna] == string.Empty)
                    {
                        if (posDopo < mappa.Length && mappa[posDopo, coordinate.Colonna] == string.Empty)
                        {
                            for (int i = coordinate.Colonna, j = 1; i < nave.Length; i++, j++)
                            {
                                mappa[coordinate.Riga, i] = nave.Id + j;
                                navi.Add(nave);
                                disponibilita = true;
                                break;
                            }
                        }
                    }
                    else
                        return disponibilita;
                }
            }
            return disponibilita;
        }

        /// <summary>
        /// Metodo che restituisce il risultato dello sparo in base alle coordinate date
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public EffettoSparo VerificaSparo(Coordinate coordinate)
        {
            EffettoSparo risultato = EffettoSparo.Acqua;
            if (mappa[coordinate.Riga, coordinate.Colonna] == string.Empty)
                mappa[coordinate.Riga, coordinate.Colonna] = EffettoSparo.Acqua.ToString();
            else if (mappa[coordinate.Riga, coordinate.Colonna] != EffettoSparo.Acqua.ToString())
            {
                var navePosizionata = navi.Where(x => x.Id == mappa[coordinate.Riga, coordinate.Colonna]);
                Nave nave = (Nave) navePosizionata;
                nave.DanneggiaNave(Convert.ToInt32(mappa[coordinate.Riga, coordinate.Colonna].Last()));
                if (!nave.isDeath)
                    risultato = EffettoSparo.Colpito;
                else
                    risultato = EffettoSparo.Affondato;
            }
            return risultato;
        }
    }
}
