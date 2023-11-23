using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class SymbolCard
        : BaseCard
    {
        private char symbol;
        private ConsoleColor color;

        public SymbolCard(char symbol, ConsoleColor color)
        {
            Symbol = symbol;
            Color = color;
        }

        public SymbolCard(SymbolCard card)
        {
            Symbol = card.symbol;
            Color = card.color;
        }

        public char Symbol { 
            get { return symbol; } 
            private set { symbol = value; }
        }
        public ConsoleColor Color { 
            get { return color;}
            private set { color = value; }
        }


        public override BaseCard clone()
        {
            return new SymbolCard(this);
        }

        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                SymbolCard card = obj as SymbolCard;
                if (card != null)
                {
                    return Symbol == card.Symbol && Color == card.Color;
                }
                return false;
            }
            return false;
        }

        public override void PaintCard()
        {
          //  ConsoleColor prevColor = Console.ForegroundColor ;
          //  if (this.color != null)
          //      Console.ForegroundColor = this.color;
          // Console.Write(this.symbol);
          //  Console.ForegroundColor = prevColor;
            Console.WriteLine(Symbol);
        }
    }
}
