using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class LetterCard
        :BaseCard
    {
        private char letter;

        public LetterCard(char letter)
        {
            Letter = letter;
        }

        public LetterCard(LetterCard card)
        {
            Letter=card.Letter;
        }
        public char Letter
        {
            get { return letter; }
            private set => letter = value;
        }

        public override LetterCard clone()
        {
            return new LetterCard(Letter);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            LetterCard card = obj as LetterCard;
            if (card == null) return false;
            if (Letter == card.Letter) return true;
            return false;
        }

        public override void PaintCard()
        {
            Console.WriteLine(Letter);
        }
    }
}
