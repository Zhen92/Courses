﻿using System;

namespace Bank
{
    public class Bank
    {
        readonly Output output = new Output();
        readonly Card card = new Card();
        readonly DataBase accounts = new DataBase();

        private int basicCondition;
        private int firstCondition;
        private int secondCondition;
        private int endCondition;

        public Bank()
        {
            firstCondition = 0;
            secondCondition = 0;
            endCondition = 0;
        }

        public void StartBankConversation()
        {
            output.GreetUser();
            while (accounts.IsConnect != true)
            {
                output.ChooseNumberOfAccounts();
                while (!int.TryParse(Console.ReadLine(), out basicCondition))
                {
                    output.ShowErrorMessage();
                }
                card.CreateAccount(basicCondition);

                output.ChooseNumberOfDebitCards();
                while (!int.TryParse(Console.ReadLine(), out basicCondition))
                {
                    output.ShowErrorMessage();
                }
                card.ConnectDebitCard(basicCondition);

                output.ChooseNumberOfCreditCards();
                while (!int.TryParse(Console.ReadLine(), out basicCondition))
                {
                    output.ShowErrorMessage();
                }
                card.ConnectСreditCard(basicCondition);

                if (card.Connect == true)
                {
                    output.ShowGreatErrorMessage();
                }
                break;
            }

            double transaction;
            int transactionAccount;
            double plus;
            double getmoney;

            while (endCondition != 2)
            {
                Console.Clear();

                output.ManageCards();
                while (!int.TryParse(Console.ReadLine(), out basicCondition))
                {
                    output.ShowErrorMessage();
                }
                Console.Clear();

                switch (basicCondition)
                {
                    case 1:
                        ChooseCard(ref firstCondition);
                        Console.Clear();

                        ChooseNumber(ref secondCondition);
                        Console.Clear();
                        if (basicCondition == 1)
                        {
                            card.ShowBalance(secondCondition, firstCondition);
                        }
                        else
                        {
                            card.ShowBalance(secondCondition, firstCondition);
                        }
                        ChooseOperation(ref endCondition);
                        break;
                    case 2:
                        ChooseCard(ref firstCondition);
                        Console.Clear();

                        ChooseNumber(ref secondCondition);
                        Console.Clear();

                        Console.WriteLine("Сколько денег ты хочешь положить? ");
                        while (!double.TryParse(Console.ReadLine(), out plus))
                        {
                            output.ShowErrorMessage();
                        }
                        Console.Clear();
                        if (basicCondition == 1)
                        {
                            card.AddMoney(plus, secondCondition, firstCondition);
                        }
                        else
                        {
                            card.AddMoney(plus, secondCondition, firstCondition);
                        }
                        ChooseOperation(ref endCondition);
                        break;
                    case 3:
                        ChooseCard(ref firstCondition);
                        Console.Clear();

                        ChooseNumber(ref secondCondition);
                        Console.Clear();

                        Console.WriteLine("Сколько денег ты хочешь снять? ");
                        while (!double.TryParse(Console.ReadLine(), out getmoney))
                        {
                            output.ShowErrorMessage();
                        }
                        Console.Clear();

                        if (basicCondition == 1)
                        {
                            card.GetBalance(getmoney, secondCondition, firstCondition);
                        }
                        else
                        {
                            card.GetBalance(getmoney, secondCondition, firstCondition);
                        }
                        ChooseOperation(ref endCondition);
                        break;
                    case 4:
                        ChooseCard(ref firstCondition);
                        Console.Clear();

                        ChooseNumber(ref secondCondition);
                        Console.Clear();

                        Console.WriteLine("Сколько денег ты хочешь перевести? ");
                        while (!double.TryParse(Console.ReadLine(), out transaction))
                        {
                            output.ShowErrorMessage();
                        }
                        Console.Clear();

                        if (basicCondition == 1)
                        {
                            output.ChooseAccount();
                            while (!int.TryParse(Console.ReadLine(), out transactionAccount))
                            {
                                output.ShowErrorMessage();
                            }
                            if (basicCondition == 1)
                            {
                                card.TransitMoney(transaction, secondCondition, transactionAccount, firstCondition);
                            }
                            else
                            {
                                card.TransitMoney(transaction, secondCondition, transactionAccount, firstCondition);
                            }
                            ChooseOperation(ref endCondition);
                        }
                        else
                        {
                            string name;
                            string surname;
                            string middlename;

                            output.WriteName();
                            name = Console.ReadLine();
                            output.WriteSurname();
                            surname = Console.ReadLine();
                            output.WriteMiddlename();
                            middlename = Console.ReadLine();

                            string accountNumber;
                            int[] arrayOfAccountNumber;

                            output.EnterTransitAccount();
                            do
                            {
                                accountNumber = Console.ReadLine();
                                char[] arrayOfAccountNumberChar = accountNumber.ToCharArray();
                                arrayOfAccountNumber = new int[arrayOfAccountNumberChar.Length];

                                for (int i = 0; i < arrayOfAccountNumber.Length; i++)
                                {
                                    arrayOfAccountNumber[i] = int.Parse(arrayOfAccountNumberChar[i].ToString());
                                }

                                if (arrayOfAccountNumber.Length < 20 || arrayOfAccountNumber.Length > 20)
                                {
                                    output.ShowGreatErrorMessage();
                                }
                            }
                            while (arrayOfAccountNumber.Length < 20 || arrayOfAccountNumber.Length > 20);

                            Console.Clear();

                            if (basicCondition == 1)
                            {
                                card.TransitMoney(transaction, secondCondition, firstCondition);
                            }
                            else
                            {
                                card.TransitMoney(transaction, secondCondition, firstCondition);
                            }
                            ChooseOperation(ref endCondition);
                        }
                        break;
                    default:
                        output.ShowGreatErrorMessage();
                        ChooseOperation(ref endCondition);
                        break;
                }
            }
        }

        public int ChooseOperation(ref int endCondition)
        {
            output.ChooseOperation();
            while (!int.TryParse(Console.ReadLine(), out endCondition))
            {
                output.ShowErrorMessage();
            }
            return endCondition;
        }

        public int ChooseCard(ref int firstCondition)
        {
            output.ChooseCard();
            while (!int.TryParse(Console.ReadLine(), out firstCondition))
            {
                output.ShowErrorMessage();
            }
            return firstCondition;
        }

        public int ChooseNumber(ref int secondCondition)
        {
            output.ChooseNumber();
            while (!int.TryParse(Console.ReadLine(), out secondCondition))
            {
                output.ShowErrorMessage();
            }
            return secondCondition;
        }
    }
}