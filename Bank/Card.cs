using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class Card 
    {
        Output output = new Output();
        Account[] accounts;

        private int cardNumber;
        private bool isConnect;
        private int[] creditCards;
        private int[] debitCards;

        public bool IsConnect { get; set; }

        public void CreateAccount(int numberOfAccount)
        {
            accounts = new Account[numberOfAccount];
            for (int i = 0; i < numberOfAccount; i++)
            {
                accounts[i] = new Account();
            }
        }

        public void AddMoney(double plus, int cardNumber, int condition)
        {
            if (condition == 1)
            {
                if (cardNumber > debitCards.Length)
                {
                    output.WriteErrorForCard();
                }
                else
                {
                    accounts[debitCards[cardNumber - 1]].Balance += plus;
                    output.WriteSuccessfulTransaction();
                }
            }
            else
            {
                if (cardNumber > creditCards.Length)
                {
                    output.WriteErrorForCard();
                }
                else
                {
                    accounts[creditCards[cardNumber - 1]].Balance += plus;
                    output.WriteSuccessfulTransaction();
                }
            }
        }

        public void ShowBalance(int condition, int cardNumber)
        {
            if (condition == 1)
            {
                if (cardNumber > creditCards.Length)
                {
                    output.WriteErrorForCard();
                }
                else
                {
                    Console.WriteLine($"Твой баланс: {accounts[creditCards[cardNumber - 1]].Balance} условных единиц.");
                }
            }
            else
            {
                if (cardNumber > debitCards.Length)
                {
                    output.WriteErrorForCard();
                }
                else
                {
                    Console.WriteLine($"Твой баланс: {accounts[debitCards[cardNumber - 1]].Balance} условных единиц.");
                }
            }
        }

        public void ToGetBalance(double getBalance, int cardNumber, int condition)
        {
            bool isCredit = false;
            for (int i = 0; i < accounts.Length; i++)
            {
                isCredit = accounts[i].Balance < 0;
                if (isCredit == true)
                {
                    break;
                }
            }
            if (condition == 2)
            {
                if (cardNumber > creditCards.Length)
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
                        accounts[creditCards[cardNumber - 1]].Balance -= getBalance;
                        output.WriteSuccessfulTransaction();
                    }
                }
            }
            else if (condition == 1)
            {
                if (cardNumber > debitCards.Length)
                {
                    output.WriteErrorForCard();
                }
                else
                {
                    if (accounts[debitCards[cardNumber - 1]].Balance < getBalance)
                    {
                        output.HaveNoMoney();
                    }
                    else
                    {
                        accounts[debitCards[cardNumber - 1]].Balance -= getBalance;
                        output.WriteSuccessfulTransaction();
                    }
                }
            }
        }

        public void ConnectDebitCard(int numberOfCard)
        {
            for (int i = 0; i < numberOfCard; i++)
            {
                debitCards = new int[numberOfCard];
                output.ChooseNumberForDebitCard();
                while (!int.TryParse(Console.ReadLine(), out cardNumber))
                {
                    output.ShowErrorMessage();
                }
                if (cardNumber < 1 || cardNumber > accounts.Length)
                {
                    Console.WriteLine("У нас нету такого номера (счета)");
                    isConnect = true;
                }
                else
                {
                    debitCards[i] = cardNumber - 1;
                    accounts[cardNumber - 1].Balance = 0;
                }
            }
        }

        public void ConnectСreditCard(int numberOfCard)
        {
            for (int i = 0; i < numberOfCard; i++)
            {
                creditCards = new int[numberOfCard];
                output.ChooseNumberForCreditCard();
                while (!int.TryParse(Console.ReadLine(), out cardNumber))
                {
                    output.ShowErrorMessage();
                }
                if (cardNumber < 1 || cardNumber > accounts.Length)
                {
                    Console.WriteLine("У нас нету такого счета");
                    isConnect = true;
                }
                else
                {
                    creditCards[i] = cardNumber - 1;
                    accounts[cardNumber - 1].Balance = 0;
                }
            }
        }             

        public void TransitMoney(double transaction, int cardNumber, int condition, int numberOftransAccount) 
        {
            bool isCredit = false;
            for (int i = 0; i < accounts.Length; i++)
            {
                isCredit = accounts[i].Balance < 0;
            }
            if (condition == 1)
            {
                if (cardNumber > debitCards.Length)
                {
                    output.WriteErrorForCard();
                }
                else
                {
                    if (accounts[debitCards[cardNumber - 1]].Balance < transaction)
                    {
                        output.HaveNoMoney();
                    }
                    accounts[debitCards[cardNumber - 1]].Balance -= transaction;
                    accounts[numberOftransAccount - 1].Balance += transaction;
                    output.WriteSuccessfulTransaction();
                }
            }
            else if (condition == 2)
            {
                if (cardNumber > creditCards.Length)
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
                        for (int i = 0; i < debitCards.Length; i++)
                        {
                            if (isConnect = numberOftransAccount - 1 == creditCards[i])
                            {
                                Console.WriteLine("Транзакция между кредитной и дебетовой картами невозможна!");
                                break;
                            }
                            if (isConnect == false)
                            {
                                accounts[creditCards[cardNumber - 1]].Balance -= transaction;
                                accounts[numberOftransAccount - 1].Balance += transaction;
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
            for (int i = 0; i < accounts.Length; i++)
            {
                isCredit = accounts[i].Balance < 0;
            }
            if (condition == 1)
            {
                if (cardID > debitCards.Length)
                {
                    output.WriteErrorForCard();
                }
                else
                {
                    if (accounts[cardID - 1].Balance < transaction)
                    {
                        output.HaveNoMoney();
                    }
                    else
                    {
                        accounts[debitCards[cardID - 1]].Balance -= transaction;
                        output.WriteSuccessfulTransaction();
                    }
                }
            }
            else if (condition == 2)
            {
                if (cardID > creditCards.Length)
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
                        accounts[creditCards[cardID - 1]].Balance -= transaction;
                        output.WriteSuccessfulTransaction();
                    }
                }
            }
        }
    }
}