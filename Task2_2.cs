using System;
using System.Collections.Generic;
using System.Text;

namespace HW1
{
    class Task2_2
    {
        public static int Main(string[] args)
        {
            double area = 0;

            if (args != null && args.Length > 0)
            {
               
                switch (args[0].Trim().ToLower())
                {
                    case "rectangle": 
                        if(args.Length != 3 || !Double.TryParse(args[1], out double a) || !Double.TryParse(args[2], out double b) || a <= 0 || b <= 0) 
                            return -1;
                        else
                            Console.WriteLine(a * b);
                        break;

                    case "circle":
                        if (args.Length != 2 || !Double.TryParse(args[1], out double radius) || radius <= 0)
                            return -1;
                        else
                            Console.WriteLine(radius * radius * Math.PI);
                        break;

                    case "triangle":
                        if (args.Length != 4 || !Double.TryParse(args[1], out double A) || !Double.TryParse(args[2], out double B) || 
                            !Double.TryParse(args[3], out double C) || A <= 0 || B <= 0 || C <= 0 || A + B <= C || A + C <= B || B + C <= A)
                            return -1;
                        else
                        {
                            double p = (A + B + C) / 2;
                            Console.WriteLine(Math.Sqrt(p * (p - A) * (p - B) * (p - C)));
                        }
                        break;
                    default: return -1;
                }
                return 0;
            }
            Console.WriteLine("Created by Killreal \n");
            Console.WriteLine($"This program counts area of the entered shape with entered parameters \n\n");

            Console.WriteLine("You can calculate area of the folowing figures:");
            Console.WriteLine("> Rectangle");
            Console.WriteLine("> Circle");
            Console.WriteLine("> Triangle");
            Console.WriteLine("> Type \"exit\" to stop the program\n");

            string figure;
            bool wrongFigure;

            while(true)
            {
                Console.WriteLine("====================");
                wrongFigure = false;
                Console.WriteLine("Enter figure:");
                figure = Console.ReadLine().Trim().ToLower();

                switch (figure)
                {
                    case "rectangle": area = Rectangle();
                        break;
                    case "circle":
                        area = Circle();
                        break;
                    case "triangle":
                        area = Triangle();
                        break;
                    case "exit":
                        return 0;
                    default: wrongFigure = true;
                        WrongInput("figure");
                        break;
                }
                if (wrongFigure) continue;

                Console.Write($"Calculated Area: {area}\n");
            } 

            
           
        }

        public static double Rectangle()
        {
            double a, b;
            bool inputA,inputB;
            while (true)
            {
                Console.WriteLine("-------------------");
                Console.Write("Enter side A: ");
                inputA = Double.TryParse(Console.ReadLine(),out a);
                Console.Write("Enter side B: ");
                inputB = Double.TryParse(Console.ReadLine(), out b);

                if (inputA == false || inputB ==false)
                {
                    WrongInput("not number");
                    continue;
                }else if(a <= 0 || b <= 0)
                {
                    WrongInput("negative value");
                    continue;
                }

                return a * b;
            }           
        }

        public static double Circle()
        {
            double radius;
            bool inputR;
            while (true)
            {
                Console.WriteLine("-------------------");
                Console.Write("Enter radius R: ");
                inputR = Double.TryParse(Console.ReadLine(), out radius);                

                if (inputR == false)
                {
                    WrongInput("not number");
                    continue;
                }
                else if (radius <= 0)
                {
                    WrongInput("negative value");
                    continue;
                }

                return radius * radius * Math.PI;
            }
        }

        public static double Triangle()
        {
            double a, b, c;
            bool inputA, inputB, inputC;
            while (true)
            {
                Console.WriteLine("-------------------");
                Console.Write("Enter side A: ");
                inputA = Double.TryParse(Console.ReadLine(), out a);
                Console.Write("Enter side B: ");
                inputB = Double.TryParse(Console.ReadLine(), out b);
                Console.Write("Enter side C: ");
                inputC = Double.TryParse(Console.ReadLine(), out c);

                if (inputA == false || inputB == false || inputC == false)
                {
                    WrongInput("not number");
                    continue;
                }
                else if (a <= 0 || b <= 0 || c <= 0)
                {
                    WrongInput("negative value");
                    continue;
                }else if (!(a + b > c && a + c > b && b + c > a))
                {
                    WrongInput("triangle");
                    continue;
                }

                double p = (a + b + c) / 2;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }

        }

        public static void WrongInput(string exeption)
        {
            Console.WriteLine();
            switch (exeption)
            {
                case "figure":
                    Console.WriteLine("Sorry, I can't calculate an area of this figure :(\nTry to enter one of these:");
                    Console.WriteLine("> Rectangle");
                    Console.WriteLine("> Circle");
                    Console.WriteLine("> Triangle");
                    Console.WriteLine("> Type \"exit\" to stop the program\n");
                    break;
                case "not number": 
                    Console.WriteLine("You entered wrong parameter!(not a number or too big number probably)\nTry again.\n");
                    break;
                case "negative value":
                    Console.WriteLine("I can't count an area with a negative parameter!\nEnter a positive one.");
                    break;
                case "triangle":
                    Console.WriteLine("Triangle with entered parameters does not exist!\nTry again.");
                    break;
                default:
                    Console.WriteLine("Unexpected exeption!");
                    break;
            }
            
        }
    }
}
