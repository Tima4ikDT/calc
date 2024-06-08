using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringCalculator
{
    // Интерфейс для выполнения математических операций
    public interface IOperation
    {
        double Calculate(double num1, double num2);
    }

    // Конкретная реализация операций
    public class Addition : IOperation
    {
        public double Calculate(double num1, double num2)
        {
            return num1 + num2;
        }
    }

    public class Subtraction : IOperation
    {
        public double Calculate(double num1, double num2)
        {
            return num1 - num2;
        }
    }

    public class Multiplication : IOperation
    {
        public double Calculate(double num1, double num2)
        {
            return num1 * num2;
        }
    }

    public class Division : IOperation
    {
        public double Calculate(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Деление на ноль недопустимо.");
            }
            return num1 / num2;
        }
    }

    // Интерфейс для тригонометрических операций
    public interface ITrigOperation
    {
        double Calculate(double angleDegrees);
    }

    // Конкретные реализации тригонометрических операций
    public class Sine : ITrigOperation
    {
        public double Calculate(double angleDegrees)
        {
            return Math.Sin(angleDegrees * Math.PI / 180);
        }
    }

    public class Cosine : ITrigOperation
    {
        public double Calculate(double angleDegrees)
        {
            return Math.Cos(angleDegrees * Math.PI / 180);
        }
    }

    public class Tangent : ITrigOperation
    {
        public double Calculate(double angleDegrees)
        {
            return Math.Tan(angleDegrees * Math.PI / 180);
        }
    }

    public class Cotangent : ITrigOperation
    {
        public double Calculate(double angleDegrees)
        {
            return 1 / Math.Tan(angleDegrees * Math.PI / 180);
        }
    }

    // Класс для возведения в степень
    public static class Exponentiation
    {
        public static double Calculate(double num, double exponent)
        {
            return Math.Pow(num, exponent);
        }
    }

    // Класс для получения квадратного корня
    public static class SquareRoot
    {
        public static double Calculate(double num)
        {
            if (num < 0)
            {
                throw new ArgumentException("Квадратный корень из отрицательного числа невозможен.");
            }
            return Math.Sqrt(num);
        }
    }

    // Основной класс программы
    public class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                DisplayMenu();

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            PerformOperation(new Addition());
                            break;
                        case "2":
                            PerformOperation(new Subtraction());
                            break;
                        case "3":
                            PerformOperation(new Multiplication());
                            break;
                        case "4":
                            PerformOperation(new Division());
                            break;
                        case "5":
                            PerformTrigonometricOperation(new Sine(), "5");
                            break;
                        case "6":
                            PerformTrigonometricOperation(new Cosine(), "6");
                            break;
                        case "7":
                            PerformTrigonometricOperation(new Tangent(), "7");
                            break;
                        case "8":
                            PerformTrigonometricOperation(new Cotangent(), "8");
                            break;
                        case "9":
                            PerformExponentiation();
                            break;
                        case "10":
                            PerformSquareRoot();
                            break;
                        case "11":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Неверная операция. Попробуйте снова.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }

        // Отображение меню доступных операций
        static void DisplayMenu()
        {
            Console.WriteLine("Выберите операцию:");
            Console.WriteLine("1. Сложение (+)");
            Console.WriteLine("2. Вычитание (-)");
            Console.WriteLine("3. Умножение (*)");
            Console.WriteLine("4. Деление (/)");
            Console.WriteLine("5. Синус (sin)");
            Console.WriteLine("6. Косинус (cos)");
            Console.WriteLine("7. Тангенс (tan)");
            Console.WriteLine("8. Котангенс (cot)");
            Console.WriteLine("9. Возведение в степень (^)");
            Console.WriteLine("10. Квадратный корень (√)");
            Console.WriteLine("11. Выход");
        }

        // Выполнить двоичную операцию
        static void PerformOperation(IOperation operation)
        {
            List<double> numbers = new List<double>();
            double result = 0;
            bool continueInput = true;

            Console.WriteLine("Введите числа (введите 'стоп', чтобы завершить ввод):");

            while (continueInput)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "стоп")
                {
                    continueInput = false;
                }
                else if (double.TryParse(input, out double number))
                {
                    numbers.Add(number);
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Введите число или 'стоп'.");
                }
            }

            if (numbers.Count > 0)
            {
                result = numbers[0];
                for (int i = 1; i < numbers.Count; i++)
                {
                    result = operation.Calculate(result, numbers[i]);
                }
                Console.WriteLine($"Результат: {result}");
            }
            else
            {
                Console.WriteLine("Введено недостаточно чисел для выполнения операции.");
            }
        }

        // Выполнить тригонометрическую операцию
        static void PerformTrigonometricOperation(ITrigOperation operation, string choice)
        {
            double angleDegrees = GetNumber("Введите угол в градусах:");
            string operationName = choice switch
            {
                "5" => "Синус",
                "6" => "Косинус",
                "7" => "Тангенс",
                "8" => "Котангенс",
                _ => "Неизвестная операция"
            };
            Console.WriteLine($"Результат {operationName} угла {angleDegrees} градусов: {operation.Calculate(angleDegrees)}");
        }

        // Получить ввод номера от пользователя
        static double GetNumber(string prompt)
        {
            Console.WriteLine(prompt);
            return Convert.ToDouble(Console.ReadLine());
        }

        // Perform exponentiation
        static void PerformExponentiation()
        {
            double num = GetNumber("Введите число:");
            double exponent = GetNumber("Введите степень:");
            Console.WriteLine($"Результат: {Exponentiation.Calculate(num, exponent)}");
        }

        // Perform square root
        static void PerformSquareRoot()
        {
            double num = GetNumber("Введите число:");
            try
            {
                Console.WriteLine($"Результат: {SquareRoot.Calculate(num)}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}