using System;

namespace PrincessGame
{
    public class Game
    {
        private string[,] Field { get; set; }
        private int Rows { get; set; }
        private int Columns { get; set; }

        private const int buttonForLooseOrWin = 1;
        private const string border = "| |";
        private const string princessSymbol = "P";
        private const int princessPositionOx = 10;
        private const int princessPositionOy = 10;
        private const string trapSymbol = "T";
        private int trapOx = 12;
        private int trapOy = 12;

        Output output = new Output();

        public void LooseGame(ref bool firstСondition, ref bool secondСondition, ref int numericСondition)
        {
            Console.Clear();
            output.LooseMessage();
            while (!int.TryParse(Console.ReadLine(), out numericСondition))
            {
                output.ErrorMessage();
            }
            if (numericСondition == buttonForLooseOrWin)
            {
                secondСondition = false;
                firstСondition = true;
            }
            else
            {
                secondСondition = false;
                firstСondition = false;
            }
        }

        public void WinGame(ref bool firstСondition, ref bool secondСondition, ref int numericСondition)
        {
            Console.Clear();
            output.WinMessage();
            while (!int.TryParse(Console.ReadLine(), out numericСondition))
            {
                output.ErrorMessage();
            }
            if (numericСondition == buttonForLooseOrWin)
            {
                secondСondition = false;
                firstСondition = true;
            }
            else
            {
                secondСondition = false;
                firstСondition = false;
            }
        }

        public void CreateField()
        {
            Field = new string[trapOx, trapOy];
            Rows = Field.GetUpperBound(0) + 1;
            Columns = Field.Length / Rows;
            for (int i = 1; i < Rows - 1; i++)
            {
                for (int j = 1; j < Columns - 1; j++)
                {
                    Field[i, j] = border;
                }
            }
        }

        public void RestartGame(ref bool firstСondition, ref bool secondСondition, ref int numericСondition, ref int x, ref int y, ref int HP)
        {
            x = 1;
            y = 1;
            HP = 10;
            if (numericСondition == buttonForLooseOrWin)
            {
                secondСondition = true;
                firstСondition = true;
            }
            else
            {
                secondСondition = false;
                firstСondition = false;
            }
        }

        public void StartGame()
        {
            Game game = new Game();
            Person person = new Person();
            Trap trap = new Trap();
            Output output = new Output();

            bool firstСondition = true;
            bool secondСondition = true;
            int numericСondition = 0;
            int x = 1;
            int y = 1;
            int HP = person.HP;

            while (firstСondition)
            {
                output.GreetingPlayer();
                game.CreateField();
                trap.MiningTheField();

                while (secondСondition)
                {
                    person.ToMovePlayer(ref x, ref y);
                    game.Field[y, x] = person.Player;

                    Console.Clear();

                    if (person.Player == trap.Traps[y, x])
                    {
                        game.Field[y, x] = trapSymbol;
                    }
                    game.Field[princessPositionOx, princessPositionOy] = princessSymbol;
                    Console.WriteLine("Твой HP: " + HP);

                    for (int i = 0; i < game.Rows; i++)
                    {
                        for (int j = 0; j < game.Columns; j++)
                        {
                            Console.Write($"{game.Field[i, j] }\t");
                        }
                        Console.WriteLine("\n");
                    }
                    if (game.Field[y, x] == game.Field[princessPositionOx, princessPositionOy])
                    {
                        game.WinGame(ref firstСondition, ref secondСondition, ref numericСondition);
                    }
                    else if (person.Player == trap.Traps[y, x])
                    {
                        trap.Traps[y, x] = trapSymbol;
                        HP -= trap.Damage;
                        if (HP <= 0)
                        {
                            game.LooseGame(ref firstСondition, ref secondСondition, ref numericСondition);
                        }
                    }
                    if (game.Field[y, x] != trapSymbol)
                    {
                        game.Field[y, x] = border;
                    }
                }
                game.RestartGame(ref firstСondition, ref secondСondition, ref numericСondition, ref x, ref y, ref HP);
            }
        }
    }
}