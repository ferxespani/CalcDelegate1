using System;

namespace CalcDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc calc = new Calc();
            calc.DoOperation(calc.Sum);
            Console.WriteLine();
            calc.DoOperation(calc.Sub);
            Console.WriteLine();
            calc.DoOperation(calc.Multiplication);
            Console.WriteLine();
            calc.DoOperation(calc.Dividing);
            Console.WriteLine();
        }
    }
}