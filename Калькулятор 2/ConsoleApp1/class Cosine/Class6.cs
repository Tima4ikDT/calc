﻿using System;
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

    // Конкретная реализация функции косинуса
    public class Cosine : IFunction
    {
        public double Calculate(double angleDegrees)
        {
            double angleRadians = angleDegrees * Math.PI / 180;
            return Math.Cos(angleRadians);
        }
    }

    // Главный класс программы
    public class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляр функции косинуса
            IFunction cosine = new Cosine();

            // Вводим числа до тех пор, пока пользователь не введет "стоп"
            Console.WriteLine("Введите числа (введите 'стоп' для завершения):");
            string input;
            do
            {
                input = Console.ReadLine();

                if (double.TryParse(input, out double number))
                {
                    // Вычисляем косинус и выводим результат
                    Console.WriteLine($"Косинус {number} градусов: {cosine.Calculate(number)}");
                }
            } while (input.ToLower() != "стоп");
        }
    }
}
