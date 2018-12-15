using System;

namespace CalcDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc calc = new Calc(new Calc.LogToConsole(Show_Message));
            calc.Sum();
            calc.Sub();
            calc.Multiplication();
            calc.Dividing();
        }

        private static void Show_Message(string message)
        {
            Console.WriteLine(message);
        }

    }
}