using System;
using System.Collections.Generic;
using System.Text;

namespace HW1
{
    class Task1_4
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Created by Killreal \n");
            Console.WriteLine("This program shows all simple numbers on the entered segment\n\n");

            int left, right;
            bool is_Simple;

            Console.Write("Enter left border of segment:\t");
            left = int.Parse(Console.ReadLine());

            Console.Write("Enter right border of segment:\t");
            right = int.Parse(Console.ReadLine());

            Console.WriteLine("\n==================\n");

            Console.WriteLine($"Simple numbers on segment [{left};{right}] : ");

            for (int i = left; i <= right; i++)
            {
                is_Simple = true;
                if (i <= 1) continue;
                
                for (int j = 2; j <= Math.Round(Math.Sqrt(i)); j++)
                {
                    if (i % j == 0)
                    {
                        is_Simple = false;
                        break;
                    }
                }
                if (is_Simple) Console.Write($"{i} ");
            }
        }
    }
}
