using System;
using System.Collections.Generic;
using System.Text;

namespace PrincessGame
{
    public class Trap
    {
        public string[,] Traps { get; set; }
        public int Damage { get; set; }

        readonly Person person = new Person();
        static readonly Random random = new Random();

        private const int trapFieldOx = 11;
        private const int trapFieldOy = 11;

        public void MiningTheField()
        {
            Traps = new string[trapFieldOx, trapFieldOy];

            int numberOfTraps = 10;
            int minDamageOfTrap = 1;
            int maxDamageOfTrap = 10;
            int minTrapNumberRows = 1;
            int maxTrapNumberRows = 10;
            int minTrapNumberСolumn = 1;
            int maxTrapNumberСolumn = 10;

            Damage = random.Next(minDamageOfTrap, maxDamageOfTrap);

            for (int i = 0; i < numberOfTraps; i++)
            {
                int TrapOx = random.Next(minTrapNumberRows, maxTrapNumberRows);
                int TrapOy = random.Next(minTrapNumberСolumn, maxTrapNumberСolumn);

                if (Traps[TrapOx, TrapOy] == null)
                {
                    if (TrapOx != maxTrapNumberRows && TrapOy != maxTrapNumberСolumn)
                    {
                        if (TrapOx != minTrapNumberRows && TrapOy != minTrapNumberСolumn)
                        {
                            Traps[TrapOx, TrapOy] = $"{person.Player}";
                        }
                    }
                }
                else
                {
                    numberOfTraps++;
                }
            }
        }
    }
}