using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабороторная_работа
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double orderCost = ReadPositiveDouble("Введите стоимость заказа (руб): ");
            double distance = ReadPositiveDouble("Введите расстояние доставки (км): ");
            int hour = ReadHour("Введите время заказа (час, 0-23): ");

            double deliveryCost = CalculateDeliveryCost(orderCost, distance, hour);
            double totalAmount = orderCost + deliveryCost;

            Console.WriteLine($"Стоимость доставки: {deliveryCost} руб");
            Console.WriteLine($"Итого к оплате: {totalAmount} руб");
        }

        static double ReadPositiveDouble(string message)
        {
            double value;
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (double.TryParse(input, out value) && value >= 0)
                {
                    return value;
                }
                Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
            }
        }

        static int ReadHour(string message)
        {
            int hour;
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (int.TryParse(input, out hour) && hour >= 0 && hour <= 23)
                {
                    return hour;
                }
                Console.WriteLine("Некорректный ввод. Введите число от 0 до 23.");
            }
        }

        static double CalculateDeliveryCost(double orderCost, double distance, int hour)
        {
            const double basePrice = 150;
            const double additionalKmPrice = 50;
            const double peakMultiplier = 1.3;

            double totalPrice = 0;

            if (orderCost >= 2000)
            {
                totalPrice = 0; 
            }
            else
            {
                totalPrice = basePrice;
                if (distance > 3)
                {
                    totalPrice += (distance - 3) * additionalKmPrice;
                }
            }

            if (IsPeakHour(hour))
            {
                totalPrice *= peakMultiplier;
            }

            return Math.Round(totalPrice);
        }

        static bool IsPeakHour(int hour)
        {
            return (hour >= 12 && hour < 14) || (hour >= 18 && hour < 20);
        }
    }
}
