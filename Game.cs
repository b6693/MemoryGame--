using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class Game
    {
        private List<BasePlayer> playersList = new List<BasePlayer>();
        private Dictionary<Type, List<BaseCard>> cardCollection = new Dictionary<Type, List<BaseCard>>();
        private int currentPlayer;
        private Type typeGame;
        private Board myBoard;

        private void InitCardCollection()
        {
            cardCollection.Add(typeof(SymbolCard), new List<BaseCard>());
            cardCollection[typeof(SymbolCard)].Add(new SymbolCard('!', ConsoleColor.Green));
            cardCollection[typeof(SymbolCard)].Add(new SymbolCard('@', ConsoleColor.Green));
            cardCollection[typeof(SymbolCard)].Add(new SymbolCard('#', ConsoleColor.Green));
            cardCollection[typeof(SymbolCard)].Add(new SymbolCard('$', ConsoleColor.Green));
            cardCollection[typeof(SymbolCard)].Add(new SymbolCard('%', ConsoleColor.Green));
            cardCollection[typeof(SymbolCard)].Add(new SymbolCard('^', ConsoleColor.Green));
            cardCollection[typeof(SymbolCard)].Add(new SymbolCard('&', ConsoleColor.Green));
            cardCollection[typeof(SymbolCard)].Add(new SymbolCard('*', ConsoleColor.Green));
            cardCollection[typeof(SymbolCard)].Add(new SymbolCard('~', ConsoleColor.Green));
            cardCollection[typeof(SymbolCard)].Add(new SymbolCard('?', ConsoleColor.Green));
            cardCollection.Add(typeof(LetterCard), new List<BaseCard>());
            cardCollection[typeof(LetterCard)].Add(new LetterCard('A'));
            cardCollection[typeof(LetterCard)].Add(new LetterCard('B'));
            cardCollection[typeof(LetterCard)].Add(new LetterCard('C'));
            cardCollection[typeof(LetterCard)].Add(new LetterCard('D'));
            cardCollection[typeof(LetterCard)].Add(new LetterCard('E'));
            cardCollection[typeof(LetterCard)].Add(new LetterCard('F'));
            cardCollection[typeof(LetterCard)].Add(new LetterCard('G'));
            cardCollection[typeof(LetterCard)].Add(new LetterCard('H'));
            cardCollection[typeof(LetterCard)].Add(new LetterCard('I'));
            cardCollection[typeof(LetterCard)].Add(new LetterCard('J'));
            cardCollection.Add(typeof(ExeCard), new List<BaseCard>());
            cardCollection[typeof(ExeCard)].Add(new ExeCard(1,2,'+'));
            cardCollection[typeof(ExeCard)].Add(new ExeCard(5, 3, '+'));
            cardCollection[typeof(ExeCard)].Add(new ExeCard(2, 4, '+'));
            cardCollection[typeof(ExeCard)].Add(new ExeCard(7, 1, '+'));
            cardCollection[typeof(ExeCard)].Add(new ExeCard(3, 6, '+'));
            cardCollection[typeof(ExeCard)].Add(new ExeCard(9, 2, '-'));
            cardCollection[typeof(ExeCard)].Add(new ExeCard(7, 3, '-'));
            cardCollection[typeof(ExeCard)].Add(new ExeCard(8, 4, '-'));
            cardCollection[typeof(ExeCard)].Add(new ExeCard(6, 2, '-'));
            cardCollection[typeof(ExeCard)].Add(new ExeCard(5, 1, '-'));
        }
        private void InitPlayersList()
        {
            Console.WriteLine("Would you like to play with computer? (Y/N)");
            char answer = char.ToUpper(Console.ReadKey().KeyChar);
            if (answer == 'Y') playersList.Add(new ComputerPlayer());
            Console.WriteLine("How many Players in this Game?");
            int num = Convert.ToInt32(Console.ReadLine());
            while (num > 0)
            {
                playersList.Add(new UserPlayer());
                num--;
            }
        }

        private void InitSetting()
        {
            Console.WriteLine("Which game do you choose to play?\npress S to SymbolCards\npress L to LetterCards\npress E to ExerciseCards");
            char answer = char.ToUpper(Console.ReadKey().KeyChar);
            switch (answer)
            {
                case 'S':
                    typeGame = typeof(SymbolCard);
                    break;
                case 'L':
                    typeGame = typeof(LetterCard);
                    break ;
                case 'E':
                    typeGame = typeof(ExeCard);
                    break;
            }
        }

        public void InitGame()
        {
            InitCardCollection();
            InitPlayersList();
            InitSetting();
            Console.WriteLine("How many pairs in this game? (num between 6-10");
            int num = Convert.ToInt32(Console.ReadLine());
            myBoard = new Board(num);
            myBoard.InitBoard(cardCollection[typeGame]);
        }

        public void FindPair(BasePlayer player, int card1, int card2)
        {
            player.AddCard(myBoard.Cards[card1]);
            player.AddCard(myBoard.Cards[card2]);
            player.Points++;
        }

        public BasePlayer FindWinner()
        {
            int points = 0;
            BasePlayer winner = null;
            foreach(BasePlayer player in playersList)
            {
                if(player.Points> points)
                {
                    points = player.Points;
                    winner = player; 
                }
            }
            return winner;
        }

        public bool IsGameOver()
        {
            for(int i = 0; i < myBoard.Cards.Length; i++)
            {
                if (!myBoard.Cards[i].IsShown)
                {
                    return false;
                }
            }
            return true;
        }

        public void StartGame()
        {
            while (!IsGameOver())
            {
                foreach (BasePlayer player in playersList)
                {
                    Console.WriteLine($"---current player is: {player.Name}");
                    myBoard.PaintBoard();
                    Console.WriteLine($"{player.Name}, please choose your first card!");
                    int num1 = player.SelectCard(myBoard.Cards.Length);
                    while (!myBoard.IsValid(num1))
                    {
                        Console.WriteLine($"{player.Name}, please choose again your first card!");
                        num1 = player.SelectCard(myBoard.Cards.Length);
                    }
                    myBoard.Cards[num1].IsShown = true;
                    myBoard.PaintBoard();
                    Console.WriteLine($"{player.Name}, please choose your second card!");
                    int num2 = player.SelectCard(myBoard.Cards.Length);
                    while (!myBoard.IsValid(num2))
                    {
                        Console.WriteLine($"{player.Name}, please choose again your second card!");
                        num2 = player.SelectCard(myBoard.Cards.Length);
                    }
                    myBoard.Cards[num2].IsShown = true;
                    myBoard.PaintBoard();
                    if (myBoard.Cards[num1].Equals(myBoard.Cards[num2]))
                    {
                        Console.WriteLine($"{player.Name}, good job!");
                        FindPair(player, num1, num2);
                    }
                    else
                    {
                        Console.WriteLine($"sorry, you lose. try again later");
                        myBoard.Cards[num1].IsShown = false;
                        myBoard.Cards[num2].IsShown = false;

                    }
                } 
            }
            Console.WriteLine("---game over---");
            Console.WriteLine($"The winner is: {FindWinner().Name}");
            FindWinner().PrintMyCards();
        }
    }
}
