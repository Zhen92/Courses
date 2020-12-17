using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class Output
    {
        public void GreetUser()
        {
            const string GreetUser = "~~~~~~~~~~~~~~~~~~Банк~~~~~~~~~~~~~~~~~~";
            Console.WriteLine("\t\t\t" + GreetUser);
        }

        public void ShowErrorMessage()
        {
            Console.WriteLine("Введи значение КОРРЕКТНО: ");
        }

        public void ShowGreatErrorMessage()
        {
            Console.WriteLine("Произошла ошибка. ");
        }

        public void ManageCards()
        {
            Console.WriteLine("Меню \n 1) Посмотреть остаток  \n 2) Добавить деньги на счет. \n 3) Снять деньги со счета. \n 4) Перевести деньги.");
        }

        public void ChooseCard()
        {
            Console.WriteLine("Выбери карту: \n 1) Дебитовая \n 2) Кредитная");
        }

        public void ChooseOperation()
        {
            Console.WriteLine("Хотите продолжить? \n1) Да. \n2) Нет.");
        }
        public void ChooseNumber()
        {
            Console.WriteLine("Выбери номер карты");
        }

        public void ChooseNumberOfAccounts()
        {
            Console.WriteLine("Выбери количество счетов, которое Ты хотел бы создать: ");
        }

        public void ChooseNumberOfDebitCards()
        {
            Console.WriteLine("Выбери количество дебитовых карт: ");
        }

        public void ChooseNumberOfCreditCards()
        {
            Console.WriteLine("Выбери количество кредитных карт: ");
        }

        public void ChooseNumberForDebitCard()
        {
            Console.WriteLine("Выбери номер для дебитовой карты: ");
        }

        public void ChooseNumberForCreditCard()
        {
            Console.WriteLine("Выбери номер для кредитной карты: ");
        }

        public void WriteErrorForCard()
        {
            Console.WriteLine("Неправильный номер карты.");
        }

        public void WriteName()
        {
            Console.WriteLine("Напиши Имя: ");
        }

        public void WriteSurname()
        {
            Console.WriteLine("Напиши Фамилию: ");
        }

        public void WriteMiddlename()
        {
            Console.WriteLine("Напиши Отчество: ");
        }
        public void EnterTransitAccount()
        {
            Console.WriteLine("Введи счет получателя (максимум 20 символов): ");
        }

        public void WriteSuccessfulTransaction()
        {
            Console.WriteLine("Транзакция проведена успешно!");
        }

        public void HaveNoMoney()
        {
            Console.WriteLine("У тебя недостаточно денег для этой транзакции ");
        }

        public void HaveActiveCredit()
        {
            Console.WriteLine("У тебя есть неоплаченный кредит.");
        }

        public void ChooseAccount()
        {
            Console.WriteLine("Выбери счет: ");
        }
    }
}