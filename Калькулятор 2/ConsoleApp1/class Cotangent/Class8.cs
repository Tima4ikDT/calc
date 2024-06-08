using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // Интерфейс для математических функций
    public interface IFunction
    {
        double Calculate(double input);
    }

    // Конкретная реализация функции котангенса
    public class Cotangent : IFunction
    {
        public double Calculate(double angleDegrees)
        {
            double angleRadians = angleDegrees * Math.PI / 180;
            if (Math.Tan(angleRadians) == 0)
            {
                return double.PositiveInfinity; // Котангенс 90 градусов равен бесконечности
            }
            return 1 / Math.Tan(angleRadians);
        }
    }

    // Главный класс программы
    public class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляр функции котангенса
            IFunction cotangent = new Cotangent();

            // Вводим числа до тех пор, пока пользователь не введет "стоп"
            Console.WriteLine("Введите числа (введите 'стоп' для завершения):");
            string input;
            do
            {
                input = Console.ReadLine();

                if (double.TryParse(input, out double number))
                {
                    // Вычисляем котангенс и выводим результат
                    Console.WriteLine($"Котангенс {number} градусов: {cotangent.Calculate(number)}");
                }
            } while (input.ToLower() != "стоп");
        }
    }
}
