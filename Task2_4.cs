using System;
using System.Collections.Generic;
using System.Text;

namespace HW1
{
    class Task2_4
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Created by Killreal \n");
            Console.WriteLine($"This program is a realization of the \"More or Less\" game\n\n");

            Console.WriteLine("Rules:");
            Console.WriteLine("> You enter left and right borders of diapasone from 0 to 1 000 000");
            Console.WriteLine("> Computer guesses the random number in that diapasone");
            Console.WriteLine("> Enter any number from diapasone that you reckon computer might have guessed");
            Console.WriteLine("> Computer will give you hints (Bigger/Smaller) until you will guess the right number or surrender");
            Console.WriteLine("> To exit the game type in \"exit\"\n\n");

            Console.WriteLine("Game starts!");
            Console.WriteLine("======================");

            bool wrongInput = false;
            int leftBorder = 0, rightBorder = 1;

            do
            {
                bool leftInput, rightInput;
                Console.Write("Enter left border of diapasone:  ");
                leftInput = int.TryParse(Console.ReadLine(), out leftBorder);

                if (!leftInput)
                {
                    WrongInput("notNumber");
                    wrongInput = true;
                    continue;
                }

                Console.Write("Enter right border of diapasone: ");
                rightInput = int.TryParse(Console.ReadLine(), out rightBorder);

                if (!rightInput)
                {
                    WrongInput("notNumber");
                    wrongInput = true;
                    continue;
                }

                if (wrongInput = !(leftInput && rightInput && leftBorder < rightBorder && leftBorder >= 0 && rightBorder <= 1000000))
                    WrongInput("border");

            } while (wrongInput);

            Console.WriteLine("-----------------");
            Random rand = new Random();
            int computerNumber = rand.Next(leftBorder, rightBorder + 1), userNumber;
            Console.WriteLine("I have chosen the number! Try to guess what!\n");

            bool surrender = false;
            int fails = -1;
            string answer;

            do
            {
                fails++;
                Console.Write("Guess the number: ");
                answer = Console.ReadLine();
                if (answer.ToLower() == "exit") {
                    surrender = true;
                    break;
                }
               
                if (!(wrongInput = int.TryParse(answer, out userNumber)))
                {
                    WrongInput("notNumber");
                    fails--;
                    continue;
                }
                
                if(userNumber > rightBorder || userNumber < leftBorder)
                {
                    WrongInput("outOfDiapasone", leftBorder, rightBorder);
                    fails--;
                    continue;
                }

                if(userNumber > computerNumber)
                    Console.WriteLine("\nSmaller!\n");
                else if(userNumber < computerNumber)
                    Console.WriteLine("\nBigger!\n");

            } while (userNumber != computerNumber);

            Console.WriteLine("=================");
            double score;
            if (surrender)
            {
                score = 0;
                Console.WriteLine("Game over!");
            }
            else
            {
                int power = 1, variants = rightBorder - leftBorder + 1, leftValue = 0, rightValue = 2;
                do
                {
                    leftValue = rightValue;
                    rightValue *= 2;
                    power++;
                } while (rightValue < variants);

                if (variants - leftValue <= variants - rightValue) power--;

                score = (100 * (power - fails) / power);
                score = Math.Floor(score);
                Console.WriteLine("You won!");
            }

            Console.WriteLine($"Your score is: {score}\n\n");
        }
        public static void WrongInput(string exeption, int leftBorder = 0, int rightBorder = 1)
        {
            Console.WriteLine("\n////////////////////");
            Console.WriteLine("Wrong Input!");
            switch (exeption)
            {
                case "border":
                    Console.WriteLine("Any border can't be less than 0 or more than 1 000 000!\nAlso, left border must be smaller than right.");
                    break;

                case "outOfDiapasone":
                    Console.WriteLine($"Did you really just tried to enter a number out of diapasone that also you have entered? [{leftBorder};{rightBorder}]");
                    Console.WriteLine("I'll just act like I have seen nothing...");
                    break;

                case "notNumber":
                    Console.WriteLine("Try entering an integer number");
                    break;

                default:
                    Console.WriteLine("Unexpected exeption!");
                    break;
            }
            Console.WriteLine("Try again.");
            Console.WriteLine("////////////////////\n");
        }
    }

    
}
