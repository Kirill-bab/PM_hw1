using System;
using System.Collections.Generic;
using System.Text;

namespace HW1
{
    class Task2_3
    {
        public static int Run(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                double[] array = new double[args.Length];
                for (int i = 0; i < args.Length; i++)
                {
                    if (Double.TryParse(args[i], out array[i]) == false) return -1;
                }
                ArrayStatistics(array);
                return 0;
            }

            Console.WriteLine("Created by Killreal \n");
            Console.WriteLine($"This program gives statistics of the entered array :\n>Minimal and Maximal elements\n>Sum of all elements\n" +
                $">Average value of array\n>Standart deviation  \n\n");

            bool input = true;
            int length;
            do
            {
                Console.Write("Enter the length of array: ");
                input = int.TryParse(Console.ReadLine(), out length);
            } while (input == false || length <= 0);

            double[] arr = new double[length];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Enter {i+1} element: ");
                input = Double.TryParse(Console.ReadLine(), out arr[i]);
                if(input == false)
                    i--;                
            }
            ArrayStatistics(arr);

            return 0;
        }

        public static void ArrayStatistics(double[] arr)
        {
            double min, max, avg, dev, sum = 0, devSum = 0;
            bool isSorted = false;
            double temp;
            while (isSorted == false)
            {
                isSorted = true;
                for (int i = arr.Length - 1; i > 0; i--)
                {
                    if(arr[i] < arr[i - 1])
                    {
                        temp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = temp;
                        isSorted = false;
                    }
                }
            }

            min = arr[0];
            max = arr[arr.Length - 1];

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            avg = sum / arr.Length;

            for (int i = 0; i < arr.Length; i++)
            {
                devSum += (arr[i] - avg) * (arr[i] - avg);
            }

            dev = Math.Sqrt(devSum / arr.Length);

            Console.WriteLine("====================");
            Console.WriteLine("Array statistics:");
            Console.WriteLine($"> Min element:\t\t{min}");
            Console.WriteLine($"> Max element:\t\t{max}");
            Console.WriteLine($"> Sum of elements:\t{sum}");
            Console.WriteLine($"> Average value:\t{avg}");
            Console.WriteLine($"> Standart deviation:\t{dev}");
            Console.WriteLine("--------------------");
            Console.WriteLine("Sorted array:");
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n");
        }

    }
}
