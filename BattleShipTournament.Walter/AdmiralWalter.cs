﻿using BattleshipTournament.Core.Models;
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

        public void PosizionaFlotta()
        {
            throw new NotImplementedException();
        }

        public EffettoSparo Rapporto()
        {
            throw new NotImplementedException();
        }

        public Coordinate Spara()
        {
            throw new NotImplementedException();
        }
    }
}
