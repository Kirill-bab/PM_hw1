using System;
using System.Collections.Generic;
using System.Text;

namespace HW1
{
    class Task1_3
    {
        public static void RowSum()
        {
            double epsilon = 1.0 / 2001;
            double sum = 0, element;
            int i = 1;

            Console.WriteLine("Created by Killreal \n");
            Console.WriteLine("This program calculates sum of the following row:");
            Console.WriteLine($"Sum = 1 / (i * (i + 1)),   with epsilon = {epsilon}  precision\n\n");

            do
            {
                element = (1.0 / (i * (i + 1)));
                sum += element;
                i++;
            } while (element >= epsilon);

            Console.WriteLine($"Row sum = {sum}");
        }
    }
}
