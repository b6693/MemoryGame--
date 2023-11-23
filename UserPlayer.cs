using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class UserPlayer
        :BasePlayer
    {
        private string name;

       public override string Name { 
            get { return name; }
        }

        public UserPlayer()
        {
            InitName();
        }

        public override void InitName()
        {
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
        }

        public override int SelectCard(int max)
        {
            Console.WriteLine("please select the card you want to switch!");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
