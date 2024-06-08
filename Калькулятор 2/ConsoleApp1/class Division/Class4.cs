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

    // Конкретная реализация операции деления
    public class Division : IOperation
    {
        public double Calculate(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Невозможно разделить на ноль");
            }
            return num1 / num2;
        }
    }

    // Главный класс программы
    public class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляр операции деления
            IOperation division = new Division();

            // Вводим числа до тех пор, пока пользователь не введет "стоп"
            Console.WriteLine("Введите числа (введите 'стоп' для завершения):");
            string input;
            double result = 0;
            bool firstNumber = true; // Флаг для первого вводимого числа
            do
            {
                input = Console.ReadLine();

                if (double.TryParse(input, out double number))
                {
                    if (firstNumber)
                    {
                        result = number; // Сохраняем первое число
                        firstNumber = false;
                    }
                    else
                    {
                        try
                        {
                            result = division.Calculate(result, number);
                        }
                        catch (DivideByZeroException ex)
                        {
                            Console.WriteLine(ex.Message);
                            // Можно добавить обработку, например, запросить другое число вместо деления на ноль
                        }
                    }
                }
            } while (input.ToLower() != "стоп");

            // Выводим результат
            Console.WriteLine("Результат деления: " + result);
        }
    }
}
