using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal abstract class BasePlayer
    {
        private int points;
        private List<BaseCard> cards = new List<BaseCard>();

        public int Points { 
            get { return points; }
            set { points = value; }
        }

        public abstract string Name
        {
            get;
        }

        public void AddCard(BaseCard card)
        {
            cards.Add(card);
            points++;
        }

        public virtual void InitName() { }

        public abstract int SelectCard(int max);

        public void PrintMyCards()
        {
            foreach (var card in cards)
            {
                card.PaintCard();
            }
        }

    }
}
