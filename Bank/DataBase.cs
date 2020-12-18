using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class DataBase
    {
        public Account[] Accounts { get; set; }
        public bool IsConnect { get; set; }
        public int[] DebitCards { get; set; }
        public int[] CreditCards { get; set; }

    }
}