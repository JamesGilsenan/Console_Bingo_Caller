using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Bingo_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lineNums = new int[9];
            int[] bingoNums = new int[27];

            Game bingo = new Game();
            bingo.SetBingoCalls();
            bingo.DisplayInstructions();

            while (bingo.IsGameOver == false)
            {
                Console.Write("Enter action: ");
                string userInput = Console.ReadLine();
                userInput = userInput.ToLower();

                if (userInput == "c" || userInput == "call")
                    bingo.CallBall();
                else if (userInput == "check")
                    bingo.CheckNumbers(lineNums);
                else if (userInput == "bingo")
                    bingo.CheckNumbers(bingoNums);
                else if (userInput == "i" || userInput == "instructions")
                    bingo.DisplayInstructions();
                else if (userInput == "q" || userInput == "quit")
                {
                    Console.WriteLine("Game Over. \nPress any key to Exit application");
                    break;
                }
                    
                else
                    Console.WriteLine($"{userInput} is not a valid input. Enter i if you require instructions");
            }

            Console.Read();
        }
    }
}
