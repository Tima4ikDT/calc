using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // Интерфейс для математических операций
    public interface IOperation
    {
        double Calculate(double num1, double num2);
    }

    // Конкретная реализация операции умножения
    public class Multiplication : IOperation
    {
        public double Calculate(double num1, double num2)
        {
            return num1 * num2;
        }
    }

    // Главный класс программы
    public class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляр операции умножения
            IOperation multiplication = new Multiplication();

            // Вводим числа до тех пор, пока пользователь не введет "стоп"
            double result = 1; // Начальное значение для умножения - 1
            string input;
            do
            {
                Console.WriteLine("Введите число (или 'стоп' для завершения): ");
                input = Console.ReadLine();

                if (double.TryParse(input, out double number))
                {
                    // Умножаем текущее число на результат
                    result = multiplication.Calculate(result, number);
                }
            } while (input.ToLower() != "стоп");

            // Выводим результат
            Console.WriteLine("Результат умножения: " + result);
        }
    }
}
