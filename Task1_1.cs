using System;
using System.Collections.Generic;
using System.Text;

namespace HW1
{
    class Task1_1
    {
        public static void Main(string[] args)
        {
            double a, b = 2001, c = 3, d = 20, result;
            Console.WriteLine("Created by Killreal \n \n");
            Console.WriteLine("This program calculates value of the folowing expression:\n");
            Console.WriteLine("y = (exp(a) + 4 * lg(c)) / sqrt(b) + |arctg(d)| + 5 / sin(a)\n\n");
            Console.WriteLine("Where:");
            Console.WriteLine($"b = {b} \nc = {c} \nd = {d}\n");
            Console.Write("Please, enter parameter a: ");

            a = Double.Parse(Console.ReadLine());

            result = (Math.Exp(a) + 4 * Math.Log10(c)) / Math.Sqrt(b) + Math.Abs(Math.Atan(d)) + 5 / Math.Sin(a);
            Console.WriteLine($"Your result is: {result}");
        }
    }
}
