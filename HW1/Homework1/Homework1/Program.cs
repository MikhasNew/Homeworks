using System;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Ваш заказ собран!");

            //float = 4byte -3.4*10^38 - 3.4*10^38 
            //double = 8byte +-5*10^(-324) - +-1.7*10^308
            //decimal = 16byte 28 number aftr dot

            double cost1 = 1.5; //cost of chocolate
            double cost2 = 12.61; // coffee cost
            double cost3 = 0.75; //  milk cost

            var allCoct = cost1 + cost2 + cost3;

            Console.WriteLine("К оплате: "+ allCoct);

            Console.WriteLine("------------x1 = 999-----------------");

            int x1;
            int x2;
            int x3;

            x1 = 999;
            x2 = x1 + 3;
            x3 = x2 + x1; // or  x3 = x1 + x1 + 3;

            Console.WriteLine("-------------x3 = {0}----------------", x3);

            string s1;
            string s2;
            string s3;

            Console.WriteLine("Введите первое число");
            s1 = Console.ReadLine();

            Console.WriteLine("Введите второе число");
            s2 = Console.ReadLine();

            Console.WriteLine("Введите третье число");
            s3 = Console.ReadLine();

            
            Console.WriteLine("Вами введены следующие данные: первое число - {0}, второе число - {1}, третье число - {2}", s1, s2, s3);

            var dec = (float)(Convert.ToInt32(s1) / Convert.ToInt32(s2));
            var inc = (ulong)(Convert.ToInt32(s1) * Convert.ToInt64(s2) * Convert.ToInt64(s3));

            Console.WriteLine("Результат деления первого на второе число - {0}, результат произведения трех чисел - {1}", dec, inc);

        }
    }
}
