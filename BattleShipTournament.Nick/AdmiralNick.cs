using BattleshipTournament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipTournament.Nick
{
    public class AdmiralNick : IAdmiral
    {
        public event Action<IAdmiral> FlottaAffondata;

        readonly string nome;
        public string Nome { get { return nome; } }

        public AdmiralNick(string nome)
        {
            this.nome = nome;
        }

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
