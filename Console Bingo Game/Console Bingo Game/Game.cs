using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Bingo_Game
{
    class Game
    {
        //Properties
        int[] NumbersCalled
        { get; set; }

        int MaxBalls
        { get; set; }

        int Count
        { get; set; }

        public bool IsGameOver
        { get; private set; }

        string[] BingoCalls
        { get; set; }

        //Constructor
        public Game()
        {
            NumbersCalled = new int[90];
            MaxBalls = 90;
            Count = 0;
            IsGameOver = false;
        }

        //Methods
        public void CallBall()
        {
            if (Count >= 90)
            {
                Console.WriteLine("All balls have been called. Somebody must have won...");
                return;
            }
            int ball = RandomNumber();
            NumbersCalled[Count] = ball;
            Count++;
            Console.WriteLine($"\n- {BingoCalls[ball - 1]}, Number {ball} \n");

            
            Array.Sort(NumbersCalled, 0, Count);
            Console.Write("Numbers already called: ");
            for(int i = 0; i < Count; i++)
            {
                Console.Write(NumbersCalled[i] + ", ");
            }
            Console.Write("\n");
        }

        public void DisplayInstructions()
        {
            Console.WriteLine("| - - - - - - - - - - - - - - - - |");
            Console.WriteLine("|          Instructions           |");
            Console.WriteLine("| - - - - - - - - - - - - - - - - |");
            Console.WriteLine("| Enter C to Call the next Ball   |");
            Console.WriteLine("| Enter Check to check for a Line |");
            Console.WriteLine("| Enter Bingo to check for Bingo  |");
            Console.WriteLine("| Enter Quit to exit application  |");
            Console.WriteLine("| Enter i to Display Instructions |");
            Console.WriteLine("| - - - - - - - - - - - - - - - - |");
        }

        public int RandomNumber()
        {
            Random random = new Random();
            int ball = random.Next(1, MaxBalls + 1);
            while(NumbersCalled.Contains(ball))
                ball = random.Next(1, MaxBalls + 1);
            return ball;
        }

        public void CheckNumbers(int[] playerNums)
        {
            int intNum = 0;
            int count = 0;

            for (int i = 0; i < playerNums.Length; i++)
            {
                //does not account for userinput not being a num
                Console.Write($"Enter number {i + 1}: ");
                string num = Console.ReadLine();
                if (!int.TryParse(num, out intNum))
                {
                    Console.WriteLine($"Sorry, {num} is not a number. Please enter a number to be checked");
                    i--;
                }
                    
                //intNum = Convert.ToInt32(num);
                else if (playerNums.Contains(intNum))
                {
                    Console.WriteLine($"Sorry, you have already entered {num}. Please enter the next number to be checked");
                    i--;
                }
                else
                    playerNums[i] = intNum;
            }

            //check the player's number has been called
            foreach (int number in playerNums)
            {
                if (NumbersCalled.Contains(number))
                    count++;
                else
                    Console.WriteLine($"\n{number} was not called");
            }
            if (count == playerNums.Length && playerNums.Length == 9)
            {
                Console.WriteLine("\n* Congrats! You got a line *\nLet's continue playing till we reach Bingo");
            }

            else if (count == playerNums.Length && playerNums.Length == 27)
            {
                GameOver();
            }
            else
            { 
            Console.WriteLine("\n| Not all of those numbers were called. Sorry |");
            Console.WriteLine("| Let's continue playing |");
            }

            Array.Clear(playerNums, 0, playerNums.Length);
        }

        public void GameOver()
        {
            IsGameOver = true;
            Console.WriteLine("\n*--------------*");
            Console.WriteLine("*    BINGO!    *");
            Console.WriteLine("*--------------*");

            Console.WriteLine("Game Over. Thanks for Playing!");
        }

        public void SetBingoCalls()
        {
            int index = 0;
            BingoCalls = new string[MaxBalls];

            BingoCalls[index] = "Kelly’s eye";
            index++;
            BingoCalls[index] = "Little duck";
            index++;
            BingoCalls[index] = "Cup of tea";
            index++;
            BingoCalls[index] = "On the floor";
            index++;
            BingoCalls[index] = "Man alive";
            index++;
            BingoCalls[index] = "In a Fix";
            index++;
            BingoCalls[index] = "David Beckham";
            index++;
            BingoCalls[index] = "One fat lady";
            index++;
            BingoCalls[index] = "Doctor’s orders";
            index++;

            //the 10th number. Array index = 9
            BingoCalls[index] = "Big fat hen";
            index++;
            BingoCalls[index] = "Legs";
            index++;
            BingoCalls[index] = "One dozen";
            index++;
            BingoCalls[index] = "Unlucky for some";
            index++;
            BingoCalls[index] = "Valentine’s day";
            index++;
            BingoCalls[index] = "Rugby team";
            index++;
            BingoCalls[index] = "Sweet sixteen";
            index++;
            BingoCalls[index] = "Dancing queen";
            index++;
            BingoCalls[index] = "Coming of Age";
            index++;
            BingoCalls[index] = "Goodbye teens";
            index++;

            //the 20th number. Array index = 19
            BingoCalls[index] = "One score";
            index++;
            BingoCalls[index] = "Key of the door";
            index++;
            BingoCalls[index] = "Two little ducks (Quack Quack)";
            index++;
            BingoCalls[index] = "A duck and a flea";
            index++;
            BingoCalls[index] = "Two dozen";
            index++;
            BingoCalls[index] = "Duck and dive";
            index++;
            BingoCalls[index] = "Bed and breakfast";
            index++;
            BingoCalls[index] = "Gateway to Heaven";
            index++;
            BingoCalls[index] = "Duck and its mate";
            index++;
            BingoCalls[index] = "Rise and shine";
            index++;

            //the 30th number. Array index = 29
            BingoCalls[index] = "Dirty Gertie";
            index++;
            BingoCalls[index] = "Get up and run";
            index++;
            BingoCalls[index] = "Buckle my Shoe";
            index++;
            BingoCalls[index] = "Two little fleas";
            index++;
            BingoCalls[index] = "Ask for more";
            index++;
            BingoCalls[index] = "Jump and jive";
            index++;
            BingoCalls[index] = "Three dozen";
            index++;
            BingoCalls[index] = "A flea in heaven";
            index++;
            BingoCalls[index] = "Christmas cake";
            index++;
            BingoCalls[index] = "All the steps";
            index++;

            //The 40th number. Array index = 39
            BingoCalls[index] = "Life begins at";
            index++;
            BingoCalls[index] = "Life’s begun";
            index++;
            BingoCalls[index] = "Whinny the Poo";
            index++;
            BingoCalls[index] = "Down on your knees";
            index++;
            BingoCalls[index] = "All the fours";
            index++;
            BingoCalls[index] = "Halfway there";
            index++;
            BingoCalls[index] = "Up to tricks";
            index++;
            BingoCalls[index] = "Four and seven";
            index++;
            BingoCalls[index] = "Four dozen";
            index++;
            BingoCalls[index] = "PC";
            index++;

            //The 50th number. Array index = 49
            BingoCalls[index] = "Bulls eye";
            index++;
            BingoCalls[index] = "I love my mum";
            index++;
            BingoCalls[index] = "Weeks in a year";
            index++;
            BingoCalls[index] = "Stuck in the tree";
            index++;
            BingoCalls[index] = "Clean the floor";
            index++;
            BingoCalls[index] = "All the fives";
            index++;
            BingoCalls[index] = "Was she worth it?";
            index++;
            BingoCalls[index] = "Heinz varieties";
            index++;
            BingoCalls[index] = "Make them wait";
            index++;
            BingoCalls[index] = "Five and nine";
            index++;

            //The 60th number. Array index = 59
            BingoCalls[index] = "Three Score";
            index++;
            BingoCalls[index] = "Bakers bun";
            index++;
            BingoCalls[index] = "Turn on the screw";
            index++;
            BingoCalls[index] = "Tickle me";
            index++;
            BingoCalls[index] = "The Beatles number";
            index++;
            BingoCalls[index] = "Old age pension (You wish)";
            index++;
            BingoCalls[index] = "Clickety click";
            index++;
            BingoCalls[index] = "Made in heaven";
            index++;
            BingoCalls[index] = "Saving grace";
            index++;
            BingoCalls[index] = "Either way up";
            index++;

            //The 70th number. Array index = 69
            BingoCalls[index] = "Three Score and Ten";
            index++;
            BingoCalls[index] = "Bang on the Drum";
            index++;
            BingoCalls[index] = "Par for the course";
            index++;
            BingoCalls[index] = "Crutch with a flea";
            index++;
            BingoCalls[index] = "Candy store";
            index++;
            BingoCalls[index] = "Granddaddy of Bingo";
            index++;
            BingoCalls[index] = "Trombones";
            index++;
            BingoCalls[index] = "All the sevens";
            index++;
            BingoCalls[index] = "Heaven’s Gate";
            index++;
            BingoCalls[index] = "Lucky Nine";
            index++;

            //The 80th number. Array index = 79
            BingoCalls[index] = "Gandhi’s breakfast";
            index++;
            BingoCalls[index] = "Stop and run";
            index++;
            BingoCalls[index] = "Fat lady with a duck";
            index++;
            BingoCalls[index] = "Time for tea";
            index++;
            BingoCalls[index] = "Seven dozen";
            index++;
            BingoCalls[index] = "Staying alive";
            index++;
            BingoCalls[index] = "Between the sticks";
            index++;
            BingoCalls[index] = "Fat lady with a crutch";
            index++;
            BingoCalls[index] = "Two fat ladies";
            index++;
            BingoCalls[index] = "Nearly there";
            index++;

            //The 80th number. Array index = 89
            BingoCalls[index] = "Top of the House";
            index++;
        }
    }
}
