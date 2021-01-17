using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class Card : Account
    {
        readonly Output output = new Output();

        public bool Connect { get; set; }

        public void ShowBalance(int condition, int cardNumber)
        {
            if (condition == 1)
            {
                if (cardNumber > CreditCards.Length)
                {
                    output.WriteErrorForCard();
                }
                else
                {
                    Console.WriteLine($"Твой баланс: {Accounts[CreditCards[cardNumber - 1]].Balance} условных единиц.");
                }
            }
            else
            {
                if (cardNumber > DebitCards.Length)
                {
                    output.WriteErrorForCard();
                }
                else
                {
                    Console.WriteLine($"Твой баланс: {Accounts[DebitCards[cardNumber - 1]].Balance} условных единиц.");
                }
            }
        }

        public void ConnectDebitCard(int numberOfCard)
        {
            for (int i = 0; i < numberOfCard; i++)
            {
                DebitCards = new int[numberOfCard];
                output.ChooseNumberForDebitCard();
                while (!int.TryParse(Console.ReadLine(), out cardNumber))
                {
                    output.ShowErrorMessage();
                }
                if (cardNumber < 1 || cardNumber > Accounts.Length)
                {
                    Console.WriteLine("У нас нету такого номера (счета)");
                    IsConnect = true;
                }
                else
                {
                    DebitCards[i] = cardNumber - 1;
                    Accounts[cardNumber - 1].Balance = 0;
                }
            }
        }

        public void ConnectСreditCard(int numberOfCard)
        {
            for (int i = 0; i < numberOfCard; i++)
            {
                CreditCards = new int[numberOfCard];
                output.ChooseNumberForCreditCard();
                while (!int.TryParse(Console.ReadLine(), out cardNumber))
                {
                    output.ShowErrorMessage();
                }
                if (cardNumber < 1 || cardNumber > Accounts.Length)
                {
                    Console.WriteLine("У нас нету такого счета");
                    IsConnect = true;
                }
                else
                {
                    CreditCards[i] = cardNumber - 1;
                    Accounts[cardNumber - 1].Balance = 0;
                }
            }
        }
    }
}