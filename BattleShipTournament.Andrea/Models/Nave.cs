﻿using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Andrea.Models
{
    public class Nave
    {
        public int Lunghezza { get;private set; }
        public string Nome { get; private set; }

        public ParteNave[] ParteNave { get; set; }


        public Nave(int lunghezza)
        {
            if (lunghezza < 1 || lunghezza > 5)
            {
                throw new IndexOutOfRangeException("Lunghezza nave errata");
            }
            else
            {
                Lunghezza = lunghezza;
                Nome = NomeNave(lunghezza);
                ParteNave = new ParteNave[lunghezza];

                for(int i=0;i<lunghezza;i++)
                {
                    ParteNave[i] = new ParteNave();
                }

            }
        }

        public ParteNave GetParteNave(int parte)
        {
            return ParteNave[parte];
        }
        

        

        private string NomeNave(int lunghezza)
        {
            switch(lunghezza)
            {
                case 1:
                    return "Sottomarino";
                case 2:
                    return "Corvetta";
                case 3:
                    return "Fregata";
                case 4:
                    return "Cacciator pediniere";
                default:
                    return "Portaerei";
            }
        }

    }
}
