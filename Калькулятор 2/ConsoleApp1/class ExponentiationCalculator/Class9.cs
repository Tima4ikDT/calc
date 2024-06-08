using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // Интерфейс для операций с числами
    public interface ICalculator
    {
        double Calculate(double num1, double num2);
    }

    // Реализация операции возведения в степень
    public class ExponentiationCalculator : ICalculator
    {
        public double Calculate(double num1, double num2)
        {
            return Math.Pow(num1, num2);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание экземпляра калькулятора
            ICalculator calculator = new ExponentiationCalculator();

            // Ввод чисел до тех пор, пока пользователь не введет "стоп"
            Console.WriteLine("Введите два числа (введите 'стоп' для завершения):");
            string input;
            do
            {
                input = Console.ReadLine();

                if (input.ToLower() == "стоп")
                {
                    break;
                }

                // Разделение строки ввода на два числа
                string[] parts = input.Split(' ');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Неверный формат ввода. Введите два числа, разделенных пробелом.");
                    continue;
                }

                // Преобразование введенных строк в числа
                if (double.TryParse(parts[0], out double num1) && double.TryParse(parts[1], out double num2))
                {
                    // Вычисление и вывод результата
                    double result = calculator.Calculate(num1, num2);
                    Console.WriteLine($"{num1} в степени {num2} = {result}");
                }
                else
                {
                    Console.WriteLine("Неверный формат ввода. Введите числа.");
                }
            } while (true);
        }
    }
}
