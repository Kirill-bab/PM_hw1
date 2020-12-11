using System;
using System.Collections.Generic;
using System.Text;

namespace HW1
{
    class Task2_1
    {
        public static void Main(string[] args)
        {
            List<int> games = new List<int>(10);
            bool wrongAnswer, exitGame = false;
            string playerFigure, computerFigure;
            int count = 1;

            string[] figures = { "rock", "paper", "scissors" };
            
            Random rand = new Random();

            Console.WriteLine("Created by Killreal \n");
            Console.WriteLine($"This program is an implementation of a simple game \"Rock, Paper, Scissors!\" \n\n");

            Console.WriteLine("RULES:");
            Console.WriteLine("1. You can enter one of the commands below: ");
            Console.WriteLine("> type \"rock\" to throw the rock");
            Console.WriteLine("> type \"paper\" to throw the paper");
            Console.WriteLine("> type \"scissors\" to throw the scissors");
            Console.WriteLine("> type \"exit\" to exit the game\n");
            Console.WriteLine("> There is a hidden figure you can throw. To find it check out the code\n");

            Console.WriteLine("2. Balance: ");
            Console.WriteLine("- rock wins scissors but loses to paper");
            Console.WriteLine("- paper wins rock but loses to scissors");
            Console.WriteLine("- scissors win paper but lose to rock\n\n");

            while (true)
            {
                wrongAnswer = false;
                Console.WriteLine("-----------------");
                Console.WriteLine($"Game {count++}");
                Console.WriteLine("-----------------");

                string result = "";
                Console.Write("You throw:\t\t");
                playerFigure = Console.ReadLine().Trim().ToLower();
                computerFigure = figures[rand.Next(0,3)];
                Console.WriteLine($"Computer throws:\t{computerFigure}");

                if(playerFigure == computerFigure)
                {
                    Console.WriteLine("Draw!");
                    games.Add(0);
                    continue;
                }

                switch (playerFigure)
                {
                    case "rock":
                        if (computerFigure == "scissors")
                        {
                            result = "You win!";
                            games.Add(1);
                        }
                        else
                        {
                            result = "Computer wins!";
                            games.Add(2);
                        }
                        break;

                    case "paper":
                        if (computerFigure == "rock")
                        {
                            result = "You win!";
                            games.Add(1);
                        }
                        else
                        {
                            result = "Computer wins!";
                            games.Add(2);
                        }
                        break;

                    case "scissors":
                        if (computerFigure == "paper")
                        {
                            result = "You win!";
                            games.Add(1);
                        }
                        else
                        {
                            result = "Computer wins!";
                            games.Add(2);
                        }
                        break;

                    case "exit": exitGame = true;
                        break;

                    case "flugegeheimen": UltimateFigure();
                        break;

                    default: 
                        {
                            Alert();
                            wrongAnswer = true;
                            count--;
                            break;
                        }
                }
                if (exitGame) break;
                if (wrongAnswer) continue;

                Console.WriteLine("\n" +result);
            }

            Console.WriteLine("\n\nGame is over!\nHere is your games history:\n");
            Console.WriteLine("  -----------------------");
            Console.WriteLine("  |GAME | YOU | COMPUTER|");
            Console.WriteLine("  -----------------------");
            string score;
            for (int i = 0; i < games.Count; i++)
            {
                if (games[i] == 0) score = " |Draw |  Draw   |";
                else if (games[i] == 1) score = " |  1  |    0    |";
                else if (games[i] == 2) score = " |  0  |    1    |";
                else score = "\t\tERROR!";

                Console.WriteLine($"  | {i+1}  {score}");
            }
            Console.WriteLine("  -----------------------");
        }

        public static void Alert()
        {
            Console.WriteLine("\nGreat answer!...However try typing something from the list below:");
            Console.WriteLine("> type \"rock\" to throw the rock");
            Console.WriteLine("> type \"paper\" to throw the paper");
            Console.WriteLine("> type \"scissors\" to throw the scissors");
            Console.WriteLine("> type \"exit\" to exit the game\n");
        }

        public static void UltimateFigure()
        {
            Console.WriteLine("\nYou use an ultimate weapon!\nIts power is truly unlimited!\nYou completly destroy your computer, turning it into the ashes.\nYou won...But at what cost?");
            System.Environment.Exit(1);
        }
    }

}
