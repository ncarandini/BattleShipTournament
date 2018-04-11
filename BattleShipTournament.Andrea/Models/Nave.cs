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

        ParteNave[] partiNave;


        public Nave(int lunghezza)
        {
            if (lunghezza < 1 || lunghezza > 5)
            {

            }
            else
            {
                Lunghezza = lunghezza;
                Nome = NomeNave(lunghezza);
                partiNave = new ParteNave[lunghezza];

            }
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
