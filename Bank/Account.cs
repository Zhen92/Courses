using System;

namespace Bank
{
    public class Account : DataBase
    {
        readonly Output output = new Output();

        public double Balance { get; set; }

        private protected int cardNumber;
        
        public void CreateAccount(int accountNumber)
        {
            Accounts = new Account[accountNumber];
            for (int i = 0; i < accountNumber; i++)
            {
                Accounts[i] = new Account();
            }
        }

        public void TransitMoney(double transaction, int cardNumber, int condition, int numberOftransAccount)
        {
            bool isCredit = false;
            for (int i = 0; i < Accounts.Length; i++)
            {
                isCredit = Accounts[i].Balance < 0;
            }
            if (condition == 1)
            {
                if (cardNumber > DebitCards.Length)
                {
                    output.WriteErrorForCard();
                }
                else
                {
                    if (Accounts[DebitCards[cardNumber - 1]].Balance < transaction)
                    {
                        output.HaveNoMoney();
                    }
                    Accounts[DebitCards[cardNumber - 1]].Balance -= transaction;
                    Accounts[numberOftransAccount - 1].Balance += transaction;
                    output.WriteSuccessfulTransaction();
                }
            }
            else if (condition == 2)
            {
                if (cardNumber > CreditCards.Length)
                {
                    output.WriteErrorForCard();
                }
                else
                {
                    if (isCredit)
                    {
                        output.HaveActiveCredit();
                    }
                    else
                    {
                        for (int i = 0; i < DebitCards.Length; i++)
                        {
                            if (IsConnect = numberOftransAccount - 1 == CreditCards[i])
                            {
                                Console.WriteLine("Транзакция между кредитной и дебетовой картами невозможна!");
                                break;
                            }
                            if (IsConnect == false)
                            {
                                Accounts[CreditCards[cardNumber - 1]].Balance -= transaction;
                                Accounts[numberOftransAccount - 1].Balance += transaction;
                                output.WriteSuccessfulTransaction();
                            }
                        }
                    }
                }
            }
        }

        public void TransitMoney(double transaction, int cardID, int condition)
        {
            bool isCredit = false;
            for (int i = 0; i < Accounts.Length; i++)
            {
                isCredit = Accounts[i].Balance < 0;
            }
            if (condition == 1)
            {
                if (cardID > DebitCards.Length)
                {
                    output.WriteErrorForCard();
                }
                else
                {
                    if (Accounts[cardID - 1].Balance < transaction)
                    {
                        output.HaveNoMoney();
                    }
                    else
                    {
                        Accounts[DebitCards[cardID - 1]].Balance -= transaction;
                        output.WriteSuccessfulTransaction();
                    }
                }
            }
            else if (condition == 2)
            {
                if (cardID > CreditCards.Length)
                {
                    output.WriteErrorForCard();
                }
                else
                {
                    if (isCredit)
                    {
                        output.HaveActiveCredit();
                    }
                    else
                    {
                        Accounts[CreditCards[cardID - 1]].Balance -= transaction;
                        output.WriteSuccessfulTransaction();
                    }
                }
            }
        }

        public void AddMoney(double plus, int cardNumber, int condition)
        {
            if (condition == 1)
            {
                if (cardNumber > DebitCards.Length)
                {
                    output.WriteErrorForCard();
                }
                else
                {
                    Accounts[DebitCards[cardNumber - 1]].Balance += plus;
                    output.WriteSuccessfulTransaction();
                }
            }
            else
            {
                if (cardNumber > CreditCards.Length)
                {
                    output.WriteErrorForCard();
                }
                else
                {
                    Accounts[CreditCards[cardNumber - 1]].Balance += plus;
                    output.WriteSuccessfulTransaction();
                }
            }
        }

        public void GetBalance(double getBalance, int cardNumber, int condition)
        {
            bool isCredit = false;
            for (int i = 0; i < Accounts.Length; i++)
            {
                isCredit = Accounts[i].Balance < 0;
                if (isCredit == true)
                {
                    break;
                }
            }
            if (condition == 2)
            {
                if (cardNumber > CreditCards.Length)
                {
                    output.WriteErrorForCard();
                }
                else
                {
                    if (isCredit)
                    {
                        output.HaveActiveCredit();
                    }
                    else
                    {
                        Accounts[CreditCards[cardNumber - 1]].Balance -= getBalance;
                        output.WriteSuccessfulTransaction();
                    }
                }
            }
            else if (condition == 1)
            {
                if (cardNumber > DebitCards.Length)
                {
                    output.WriteErrorForCard();
                }
                else
                {
                    if (Accounts[DebitCards[cardNumber - 1]].Balance < getBalance)
                    {
                        output.HaveNoMoney();
                    }
                    else
                    {
                        Accounts[DebitCards[cardNumber - 1]].Balance -= getBalance;
                        output.WriteSuccessfulTransaction();
                    }
                }
            }
        }
    }
}