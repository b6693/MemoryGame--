using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class ComputerPlayer
        :BasePlayer
    {
        private const string name = "Computer";

        public override string Name { get { return name; } }

        public override int SelectCard(int max)
        {
            Random rand = new Random();
            return rand.Next(max);
        }
    }
}
