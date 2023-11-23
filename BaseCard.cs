using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal abstract class BaseCard
    {
        private bool isShown;
        private bool isFirst;

        public bool IsFirst { get { return isFirst; } }
        public bool IsShown { 
            get { return isShown; } 
            set { isShown = value; }
        }

        public abstract override bool Equals(object? obj);

        public void Paint()
        {
            if (!isShown)
            {
                Console.WriteLine("😈");
            }
            else { PaintCard(); }
        }

        public abstract void PaintCard();

        public abstract BaseCard clone();

    }
}
