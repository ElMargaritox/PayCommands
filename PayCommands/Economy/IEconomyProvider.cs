using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCommands.Economy
{
    public interface IEconomyProvider
    {
        void IncrementBalance(string playerId, decimal amount);
        decimal GetBalance(string playerId);
    }
}
