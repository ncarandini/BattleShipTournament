using BattleshipTournament.Alessio.Models;
using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;

namespace BattleshipTournament.Alessio
{
    public class AdmiralAlessio : IAdmiral
    {
        public string Nome => "Alessio";
        private Mappa map;
        private static AdmiralAlessio current;

        public static AdmiralAlessio Current
        {
            get
            {
                if (current == null)
                    current = new AdmiralAlessio();

                return current;
            }
        }
        //private List<string> rapportiSpari;


        public AdmiralAlessio ()
        {
            map = new Mappa();
            //rapportiSpari = new List<string>();
        }

        public event Action<IAdmiral> FlottaAffondata;

        public void PosizionaFlotta()
        {
            List<Nave> listaNavi = new List<Nave>
            {
                new Nave("Nave1", 1),
                new Nave("Nave2", 2),
                new Nave("Nave3", 3),
                new Nave("Nave4", 4),
                new Nave("Nave5", 5)
            };

            List<Coordinate> coordinatePosizionamento = new List<Coordinate>
            {
                new Coordinate(GetRandomNumber(), GetRandomNumber()),
                new Coordinate(GetRandomNumber(), GetRandomNumber()),
                new Coordinate(GetRandomNumber(), GetRandomNumber()),
                new Coordinate(GetRandomNumber(), GetRandomNumber()),
                new Coordinate(GetRandomNumber(), GetRandomNumber()),
            };

            listaNavi.ForEach(x =>
            {
                coordinatePosizionamento.ForEach(y => 
                {
                    if (!map.PosizionaNave(x, y, GetRandomPosizionamento()))
                    {
                        throw new PosizionamentoException("Errore nel posizionamento di una nave... Riprova");
                    }
                });
            });
        }

        public Coordinate Spara()
        {
            Random random = new Random();
            int riga = random.Next(0, 9);
            int colonna = random.Next(0, 9);
            Coordinate coordinate = new Coordinate(riga, colonna);
            return coordinate;
        }

        public EffettoSparo Rapporto(Coordinate sparo)
        {
            return map.VerificaSparo(sparo);
        }

        public void RiceviRapporto (EffettoSparo effettoSparo)
        {
            Console.WriteLine($"Risultato sparo = {GetRisultatoSparo(effettoSparo)}");
        }

        private char GetRandomPosizionamento()
        {
            string posizionamento = "hv";
            Random rand = new Random();
            int index = rand.Next(0, posizionamento.Length - 1);
            return posizionamento[index];
        }

        private string GetRisultatoSparo(EffettoSparo effettoSparo)
        {
            string risultato = string.Empty;
            switch (effettoSparo)
            {
                case EffettoSparo.Acqua:
                    risultato = "Acqua";
                    break;
                case EffettoSparo.Colpito:
                    risultato = "Colpito";
                    break;
                case EffettoSparo.Affondato:
                    risultato = "Affondato";
                    break;
            }
            return risultato;
        }

        private int GetRandomNumber()
        {
            int number = 0;
            Random random = new Random();
            number = random.Next(0, 9);
            return number;
        }
    }
}
