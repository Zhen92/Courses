using System;
using System.Collections.Generic;
using System.Text;

namespace PrincessGame
{
    public class Output
    {
        public void GreetingPlayer()
        {
            Console.WriteLine("\t\t\tThe Princess game");
            Console.WriteLine("Управление(удобнее играть на намлоке, ты - звездочка '*', добраться тебе нужно до принцессы 'P'):");
            Console.WriteLine("1 - влево, 3 - вправо, 5 - вверх, 2 - вниз. \nПосле каждого хода нужно нажать 'Enter'");
            Console.WriteLine("Нажми клавишу '0' + 'Enter', чтобы начать");
        }
        public void LooseMessage()
        {
            Console.WriteLine("Ты проиграл!\nХочешь попробовать еще раз? \n1)Да \n2)Нет");
        }
        public void WinMessage()
        {
            Console.WriteLine("Ты спас принцессу! ");
            Console.WriteLine("Хочешь попробовать еще раз? \n1)Да \n2)Нет");
        }
        public void ErrorMessage()
        {
            Console.WriteLine("Это не число, введи значение КОРРЕКТНО");
        }
    }
}
