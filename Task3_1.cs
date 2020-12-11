using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HW1
{
    class Task3_1
    {

        public static int Calculate(string[] args)
        {
            bool cmdMode = false;
            if (args != null && args.Length > 0) cmdMode = true;

            if (!cmdMode)
            {
                Console.WriteLine("Created by Killreal \n");
                Console.WriteLine("This is simple calculator\n\n");

                Console.WriteLine("Rules:");
                Console.WriteLine($"> You can enter symbols from list below: 1234567890+-/pow^*%x&|!");
                Console.WriteLine($"> You can enter only unary or binary operation");
                Console.WriteLine($"> You can not divide by zero or power negative number");
                Console.WriteLine($"> To exit the program type /'exit/'");
                Console.WriteLine("> To ask for help type /'help/'");
            }
            while (true)
            {
                double first = 0, second = 0;
                bool firstNegative = false, secondNegative = false, exit = false, help = false, wrongInput = false;
                int index = 0;

                string rightValues = "1234567890+-/pow^*%x&|!";
                string operation = "";
                string input = "";

                do
                {
                    wrongInput = false;
                    index = 0;
                    first = second = 0;
                    firstNegative = secondNegative = exit = help = false;
                    operation = "";
                    try
                    {
                        if (!cmdMode)
                        {
                            Console.WriteLine("Enter expression:");
                            input = Console.ReadLine().Trim().Replace(" ", "");
                        }
                        else input = String.Join("",args);
                        string str1 = "", str2 = "";

                        if (input.ToLower() == "exit")
                        {
                            exit = true;
                            break;
                        }
                        if (input.ToLower() == "help")
                        {
                            help = true;
                            break;
                        }

                        for (int i = 0; i < input.Length; i++)
                        {
                            if (!rightValues.Contains(input[i])) throw new ArgumentOutOfRangeException(nameof(input));
                        }
                        

                        if (!double.TryParse(input[0].ToString(), out double tmp))
                        {
                            switch (input[0])
                            {
                                case '!':
                                    operation = "!a";
                                    int i = 1;

                                    if (input.Length < 2) throw new ArgumentOutOfRangeException(nameof(input));

                                    for (;i < input.Length && Double.TryParse(input[i].ToString(), out tmp); i++)
                                    {
                                        str1 += input[i].ToString();
                                    }

                                    if (i != input.Length || !Double.TryParse(input[1].ToString(), out tmp)) throw new ArgumentOutOfRangeException(nameof(input));

                                    first = int.Parse(str1);
                                    break;

                                case '-':
                                    if (!Double.TryParse(input[1].ToString(), out tmp)) throw new ArgumentOutOfRangeException(nameof(input));
                                    firstNegative = true;
                                    index++;
                                    break;

                                default:
                                    throw new ArgumentOutOfRangeException(nameof(input));
                                    break;
                            }
                        }
                        if (operation == "!a") break;

                        for (;index < input.Length && Double.TryParse(input[index].ToString(), out tmp) ; index++)
                        {
                            str1 += input[index].ToString();
                        }
                        first = Double.Parse(str1);

                        if (index == input.Length)
                        {
                            if (firstNegative)
                                operation = "-a";
                            else
                                operation = "a";
                            break;
                        }

                        switch (input[index])
                        {
                            case '!':
                                if (index != input.Length - 1) throw new ArgumentOutOfRangeException(nameof(input));
                                operation = "a!";
                                break;

                            case 'p':
                                if (input.Substring(index, 3) != "pow") throw new ArgumentOutOfRangeException(nameof(input));
                                operation = "pow";
                                index += 2;
                                break;
                            default:
                                operation = input[index].ToString();
                                break;
                        }

                        if (operation == "a!") break;

                        if (index == input.Length - 1) throw new ArgumentOutOfRangeException(nameof(input));

                        index++;

                        if (input[index] == '-')
                        {
                            secondNegative = true;
                            index++;
                        }

                        for (; index < input.Length && Double.TryParse(input[index].ToString(), out tmp) ; index++)
                        {
                            str2 += input[index].ToString();
                        }

                        if (index != input.Length) throw new ArgumentOutOfRangeException(nameof(input));

                        second = Double.Parse(str2);


                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        if (cmdMode) return -1;
                        wrongInput = true;
                        Alert();
                    }
                } while (wrongInput);

                int firstMultilier = firstNegative ? -1 : 1;
                int secondMultilier = secondNegative ? -1 : 1;
                double result = 0;

                if (exit) break;
                if (help)
                {
                    Help();
                    continue;
                }

                try
                {
                    checked
                    {
                        first *= firstMultilier;
                        second *= secondMultilier;

                        switch (operation)
                        {
                            case "!a": result = ~(int)first;
                                break;
                            case "a!": result = first!;
                                break;
                            case "pow": if (first < 0) throw new OverflowException();
                                    result = Math.Pow(first, second);
                                break;
                            case "+": result = first + second;
                                break;
                            case "-":
                                result = first - second;
                                break;
                            case "*":
                                result = first * second;
                                break;
                            case "/":
                                if (second == 0) throw new OverflowException();
                                result = first / second;
                                break;
                            case "x":
                                result = first * second;
                                break;
                            case "^":
                                result = (int)first ^ (int)second;
                                break;
                            case "&":
                                result = (int)first & (int)second;
                                break;
                            case "%":
                                result = first % second;
                                break;
                            case "|":
                                result = (int)first | (int)second;
                                break;
                            default: throw new OverflowException();
                        }
                    }
                }
                catch (OverflowException)
                {
                    if (cmdMode) return -1;
                    Alert();
                    wrongInput = true;
                }
                if(!wrongInput)
                Console.WriteLine($"{input} = {result}");
                if (cmdMode) return 0;
            }
            return 0;
        }
        public static void Alert()
        {
            Console.WriteLine("Exeption!");
        }

        public static void Help()
        {
            Console.WriteLine("Rules:");
            Console.WriteLine($"> You can enter symbols from list below: 1234567890+-/pow^*%x&|!");
            Console.WriteLine($"> You can enter only unary or binary operation");
            Console.WriteLine($"> You can not divide by zero or power negative number");
            Console.WriteLine($"> To exit the program type /'exit/'");
            Console.WriteLine("> To ask for help type /'help/'");
        }

    }
}

