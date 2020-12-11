using System;
using System.Collections.Generic;
using System.Text;

namespace HW1
{
    class Task1_2
    {
       public static void Main(string[] args)
        {
            double p1, p2, x, margin;
            double pp1, pp2, px;

            string name1, name2;
            Console.WriteLine("Created by Killreal \n");
            Console.WriteLine("This program converts odds, entered by user to percents and calculates the bookmaker's margin\n\n");

            Console.Write("Enter the name of the first participant:\t");
            name1 = Console.ReadLine();

            Console.Write("Enter the name of the second participant:\t");
            name2 = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Enter the odds for the victory of the first participant:\t");
            p1 = double.Parse(Console.ReadLine());
            pp1 = Math.Round((1 / p1) * 100,1);

            Console.Write("Enter the odds for the victory of the second participant:\t");
            p2 = double.Parse(Console.ReadLine());
            pp2 = Math.Round((1 / p2) * 100,1);

            Console.Write("Enter the odds for the draw:\t");
            x = double.Parse(Console.ReadLine());
            px = Math.Round((1 / x) * 100,1);
          
            Console.WriteLine("=======================");
            Console.WriteLine($"{name1} wins: {pp1}%" );
            Console.WriteLine($"{name2} wins: {pp2}%");
            Console.WriteLine($"Draw: {px}%\n");

            margin = Math.Round((1 - (1 / (1 / p1 + 1 / p2 + 1 / x)))*100,1);
            Console.WriteLine($"Bookmaker's margin is: {margin}%");
        }
    }
}
