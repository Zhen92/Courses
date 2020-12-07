using System;
using System.Collections.Generic;
using System.Text;

namespace PrincessGame
{
    public class Person
    {
        public string Player { get; set; } = " *";
        public int HP { get; set; } = 10;

        Output output = new Output();

        private int direction;

        public void ToMovePlayer(ref int x, ref int y)
        {
            while (!int.TryParse(Console.ReadLine(), out direction))
            {
                output.ShowErrorMessage();
            }
            switch (direction)
            {
                case 1:
                    if (x == 1)
                    {
                        break;
                    }
                    else
                    {
                        x -= 1;
                    }
                    break;
                case 2:
                    if (y == 10)
                    {
                        break;
                    }
                    else
                    {
                        y += 1;
                    }
                    break;
                case 3:
                    if (x == 10)
                    {
                        break;
                    }
                    else
                    {
                        x += 1;
                    }
                    break;
                case 5:
                    if (y == 1)
                    {
                        break;
                    }
                    else
                    {
                        y -= 1;
                    }
                    break;
                case 0:
                    break;
            }
        }
    }
}
