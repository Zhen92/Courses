using System;

namespace PrincessGame
{
    public class GamePlay
    {
        private string[,] field;
        private int rows;
        private int columns;

        Output output = new Output();
        public void IsFiasco(ref bool firstСondition, ref bool secondСondition, ref int numericСondition) //same as fail =)
        {
            Console.Clear();
            output.LooseMessage();
            while (!int.TryParse(Console.ReadLine(), out numericСondition))
            {
                output.ErrorMessage();
            }
            if (numericСondition == 1)
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
        public void IsWin(ref bool firstСondition, ref bool secondСondition, ref int numericСondition)
        {
            Console.Clear();
            output.WinMessage();
            while (!int.TryParse(Console.ReadLine(), out numericСondition))
            {
                output.ErrorMessage();
            }
            if (numericСondition == 1)
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
            field = new string[12, 12];
            rows = field.GetUpperBound(0) + 1;
            columns = field.Length / rows;
            for (int i = 1; i < rows - 1; i++)
            {
                for (int j = 1; j < columns - 1; j++)
                {
                    field[i, j] = "| |";
                }
            }
        }
        public void RestartGame(ref bool firstСondition, ref bool secondСondition, ref int numericСondition, ref int x, ref int y, ref int HP)
        {
            x = 1;
            y = 1;
            HP = 10;
            if (numericСondition == 1)
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
        public void CreateLogic()
        {
            GamePlay gamePlay = new GamePlay();
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
                //secondСondition = true;
                //firstСondition = true;
                output.GreetingPlayer();
                gamePlay.CreateField();
                trap.MiningTheField();

                while (secondСondition)
                {
                    person.ToMovePlayer(ref x, ref y);
                    gamePlay.field[y, x] = person.Player;

                    Console.Clear();

                    if (person.Player == trap.Traps[y, x])
                    {
                        gamePlay.field[y, x] = "T";
                    }
                    gamePlay.field[10, 10] = "P";
                    Console.WriteLine("Твой HP: " + HP);

                    for (int i = 0; i < gamePlay.rows; i++)
                    {
                        for (int j = 0; j < gamePlay.columns; j++)
                        {
                            Console.Write($"{gamePlay.field[i, j] }\t");
                        }
                        Console.WriteLine("\n");
                    }
                    if (gamePlay.field[y, x] == gamePlay.field[10, 10])
                    {
                        gamePlay.IsWin(ref firstСondition, ref secondСondition, ref numericСondition);
                    }
                    else if (person.Player == trap.Traps[y, x])
                    {
                        trap.Traps[y, x] = "T";
                        HP -= trap.Damage;
                        if (HP <= 0)
                        {
                            gamePlay.IsFiasco(ref firstСondition, ref secondСondition, ref numericСondition);
                        }
                    }
                    if (gamePlay.field[y, x] != "T")
                    {
                        gamePlay.field[y, x] = "| |";
                    }
                }
                gamePlay.RestartGame(ref firstСondition, ref secondСondition, ref numericСondition, ref x, ref y, ref HP);
            }
        }
    }
}