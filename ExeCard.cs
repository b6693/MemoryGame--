using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class ExeCard
        :BaseCard
    {
        private int num1;
        private int num2;
        private char operation;
        
        public int Num1
        {
            get { return num1; }
            private set { num1 = value; }
        }
        public int Num2
        {
            get { return num2; }
            private set { num2 = value; }
        }

        public char Operation
        {
            get { return operation; }
            private set { operation = value; }
        }

        public int Solution
        {
            get
            {
                int solution = 0;
                switch (Operation)
                {
                    case '+':
                        solution = num1 + num2;
                        break;
                    case '-':
                        solution = num1 - num2;
                        break;
                }
                return solution;
            }
        }

        public ExeCard(int num1,int num2,char op)
        {
            Num1 = num1;
            Num2 = num2;
            Operation = op;
        }

        public ExeCard(ExeCard card)
        {
            Num1 = card.Num1;
            Num2 = card.Num2;
            Operation = card.Operation;
        }

        public override BaseCard clone()
        {
            return new ExeCard(this);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            ExeCard card = obj as ExeCard;
            if (card != null)
            {
                if (Solution == card.Solution) return true;
                return false;
            }
            return false;
        }

        public override void PaintCard()
        {
            if (IsFirst)
            {
                Console.WriteLine($"{Num1} {Operation} {Num2} =");
            }
            else Console.WriteLine(Solution);
        }
    }
}
