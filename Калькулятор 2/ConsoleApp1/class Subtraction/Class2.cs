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

    // Конкретная реализация операции вычитания
    public class Subtraction : IOperation
    {
        public double Calculate(double num1, double num2)
        {
            return num1 - num2;
        }
    }

    // Главный класс программы
    public class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляр операции вычитания
            IOperation subtraction = new Subtraction();

            // Вводим числа до тех пор, пока пользователь не введет "стоп"
            double result = 0;
            string input;
            do
            {
                Console.WriteLine("Введите число (или 'стоп' для завершения): ");
                input = Console.ReadLine();

                if (double.TryParse(input, out double number))
                {
                    // Вычитаем текущее число из результата
                    result = subtraction.Calculate(result, number);
                }
            } while (input.ToLower() != "стоп");

            // Выводим результат
            Console.WriteLine("Результат вычитания: " + result);
        }
    }
}
