using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS.HiScores
{
    public class PlayerNotFoundException : Exception
    {

        public string Name { get; init; }

        public Mode Mode { get; init; }

        public PlayerNotFoundException(string name, Mode mode) : base($"Player {name} not found in mode {mode}.")
        {

        }
    }
}
