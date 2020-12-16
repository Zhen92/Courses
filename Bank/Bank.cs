using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class Bank
    {
        Output output = new Output();
        Card card = new Card();

        public void StartBankConversation()
        {
            int mainCondition;
            int firstCondition = 0;
            int secondCondition = 0;
            int endCondition = 0;

            output.GreetUser();
            while (card.IsConnect != true)
            {
                output.ChooseNumberOfAccounts();
                while (!int.TryParse(Console.ReadLine(), out mainCondition))
                {
                    output.ShowErrorMessage();
                }
                card.CreateAccount(mainCondition);

                output.ChooseNumberOfDebitCards();
                while (!int.TryParse(Console.ReadLine(), out mainCondition))
                {
                    output.ShowErrorMessage();
                }
                card.ConnectDebitCard(mainCondition);

                output.ChooseNumberOfCreditCards();
                while (!int.TryParse(Console.ReadLine(), out mainCondition))
                {
                    output.ShowErrorMessage();
                }
                card.ConnectСreditCard(mainCondition);

                if (card.IsConnect == true)
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
                while (!int.TryParse(Console.ReadLine(), out mainCondition))
                {
                    output.ShowErrorMessage();
                }
                Console.Clear();

                switch (mainCondition)
                {
                    case 1:
                        ChooseCard(ref firstCondition);
                        Console.Clear();

                        ChooseNumber(ref secondCondition);
                        Console.Clear();
                        if (mainCondition == 1)
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
                        if (mainCondition == 1)
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

                        if (mainCondition == 1)
                        {
                            card.ToGetBalance(getmoney, secondCondition, firstCondition);
                        }
                        else
                        {
                            card.ToGetBalance(getmoney, secondCondition, firstCondition);
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

                        if (mainCondition == 1)
                        {
                            output.ChooseAccount();
                            while (!int.TryParse(Console.ReadLine(), out transactionAccount))
                            {
                                output.ShowErrorMessage();
                            }
                            if (mainCondition == 1)
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
                                char[] arrScoreNumChar = accountNumber.ToCharArray();
                                arrayOfAccountNumber = new int[arrScoreNumChar.Length];

                                for (int i = 0; i < arrayOfAccountNumber.Length; i++)
                                {
                                    arrayOfAccountNumber[i] = int.Parse(arrScoreNumChar[i].ToString());
                                }

                                if (arrayOfAccountNumber.Length < 20 || arrayOfAccountNumber.Length > 20)
                                {
                                    output.ShowGreatErrorMessage();
                                }
                            }
                            while (arrayOfAccountNumber.Length < 20 || arrayOfAccountNumber.Length > 20);
                            Console.Clear();

                            if (mainCondition == 1)
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
