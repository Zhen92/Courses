using System;

namespace PrincessGame
{
    public class Game
    {
        public string[,] Field { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        private const int buttonForLoseOrWin = 1;
        private const string border = "| |";
        private const string princessSymbol = "P";
        private const int princessPositionOx = 10;
        private const int princessPositionOy = 10;
        private const string trapSymbol = "T";
        private int trapOx = 12;
        private int trapOy = 12;

        Output output = new Output();

        public void LoseCondition(ref bool firstСondition, ref bool secondСondition, ref int numericСondition)
        {
            Console.Clear();
            output.ShowLoseMessage();
            while (!int.TryParse(Console.ReadLine(), out numericСondition))
            {
                output.ShowErrorMessage();
            }
            if (numericСondition == buttonForLoseOrWin)
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

        public void WinCondition(ref bool firstСondition, ref bool secondСondition, ref int numericСondition)
        {
            Console.Clear();
            output.ShowWinMessage();
            while (!int.TryParse(Console.ReadLine(), out numericСondition))
            {
                output.ShowErrorMessage();
            }
            if (numericСondition == buttonForLoseOrWin)
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
            if (numericСondition == buttonForLoseOrWin)
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
                output.GreetPlayer();
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
                        game.WinCondition(ref firstСondition, ref secondСondition, ref numericСondition);
                    }
                    else if (person.Player == trap.Traps[y, x])
                    {
                        trap.Traps[y, x] = trapSymbol;
                        HP -= trap.Damage;
                        if (HP <= 0)
                        {
                            game.LoseCondition(ref firstСondition, ref secondСondition, ref numericСondition);
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