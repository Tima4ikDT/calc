using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    // Интерфейс для операций с числами
    public interface ICalculator
    {
        double Calculate(IEnumerable<double> numbers);
    }

    // Реализация операции квадратного корня
    public class SquareRootCalculator : ICalculator
    {
        public double Calculate(IEnumerable<double> numbers)
        {
            foreach (double num in numbers)
            {
                if (num < 0)
                {
                    throw new ArithmeticException("Квадратный корень из отрицательного числа не определен");
                }
            }

            return Math.Sqrt(numbers.Aggregate((a, b) => a * b));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание экземпляра калькулятора
            ICalculator calculator = new SquareRootCalculator();

            // Использование калькулятора для вычисления
            double result = calculator.Calculate(new List<double> { 2, 3, 4 });

            Console.WriteLine(result);
        }
    }
}
