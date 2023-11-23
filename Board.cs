using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class Board
    {
        private int numOfPairs;
        private BaseCard[] cards;

        public BaseCard[] Cards { get { return cards; } }

        public Board(int numOfPairs)
        {
            this.numOfPairs = numOfPairs;
            cards = new BaseCard[numOfPairs*2];
        }

        public void InitBoard(List<BaseCard> posCards)
        {
            int index = 0;
            List<BaseCard> sortCards = new List<BaseCard>();
            foreach (var card in posCards)
            {
                if(sortCards.Count< cards.Length)
                {
                    sortCards.Add(card);
                    sortCards.Add(card);
                }
            }
            Random rand = new Random();
            for (int i = 0; i < cards.Length; i++)
            {
                index = rand.Next(sortCards.Count);
                cards[i] = sortCards[index].clone();
                sortCards.RemoveAt(index);
            }
        }

        public void PaintBoard()
        {
            foreach (var card in cards)
            {
                card.Paint();
            }
        }

        public bool IsValid(int place)
        {
            return place < cards.Length && !cards[place].IsShown;
        }

        public bool IsEmpty()
        {
            for(int i = 0;i < cards.Length; i++)
            {
                if(!cards[i].IsShown) return false;
            }
            return true;
        }
    }
}
