using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DiceGame
{
    /* 
     The Class 'Dice' introduces the 'Random' algorithm and the 'Roll' Method.
     The program will select an integer number between 1-6 and locate it under the 'DiceResult' variable.
     This result is then returned, allowing for its use elsewhere.
    */
    class Dice
    {
        static Random rand = new();


        //Function
        public int Roll()
        {
            int DiceResult = rand.Next(1, 7);

            return DiceResult;
        }


    }

    /* 
        The Class 'Game' introduces the 'Initial Roll', 'Continuous Roll' and 'AvailableAmount' methods .
        The InitialRoll method takes the Dice object 'Die' and rolls it three times. This is stored in the list 'DiceResults'
        The ContinuousRoll method allows users to input additional dice to roll on top of the dice they have already used initially.
        AvailableAmount checks the user input for any Null returns that could harm the ContinuousRoll Method.
    */
    class Game
    {
        // objects

        Dice Die = new Dice();

        protected List <int> DiceResults = new List<int>();


        // Retrieves the 'DiceResults' list to be used in the 'Test' Class
        public List<int> _DiceResults
        {
            get
            {
                return DiceResults;
            }

        }

        // A Method that Rolls a set of three dice, adds the result to a list object and then calculates the total using the built-in .Sum method
        internal void InitialRoll()
        {

            int Counter = 0;

            for (int x = 0; x < 3; x++) 
            {
                DiceResults.Add(Die.Roll());
            }

            Console.WriteLine("--");

            foreach (int i in DiceResults)
            {
                Counter++;
                Console.WriteLine("Dice " + Counter + " has rolled a " + i);
            }

            int DiceSum = DiceResults.Sum();

            Console.WriteLine("--\nThe sum of all the dice combined is: " + DiceSum);
        }

        // A Method that allows for users to roll more dice and add the result on to the already rolled dice
        
        internal void ContinuousRoll()
        {

            int UserRoll = 1; 

            while (UserRoll != 0)
            {

                int Counter = 0;

                UserRoll = AvailableAmount();


                if (UserRoll > 0)
                {
                    for (int x = 0; x < UserRoll; x++)
                    {
                        DiceResults.Add(Die.Roll());
                    }

                    Console.WriteLine("--");

                    foreach (int i in DiceResults)
                    {
                        Counter++;
                        Console.WriteLine("Dice " + Counter + " has rolled a " + i);
                    }

                    int DiceSum = DiceResults.Sum();

                    Console.WriteLine("--\nThe sum of all the dice combined is: " + DiceSum);

                }


                else
                {
                    Console.WriteLine("\nThank you for using the DiceGame program. Press the enter key to leave.");
                    Console.Read();
                    
                    System.Environment.Exit(0);
                }
            }


        }

        // A Method that allows users to input the amount of dice they would like to roll for Game.ContinuousRoll
        public int AvailableAmount()
        {

            int AvailableRoll;

            Console.WriteLine("\nInput the amount of additional dice you wish to roll. If you don't want to roll anymore, type 0.\n");

            var ContinueRolling = Console.ReadLine();

            bool IsInt = false;


            while (IsInt == false)
            {
                bool IsInteger = int.TryParse(ContinueRolling, out AvailableRoll);

                if (IsInteger == true)
                {
                    IsInt = true;

                    return AvailableRoll;
                }

                else
                {
                    Console.WriteLine("There appears to be an error with your input, please try again.\n\n");

                    AvailableAmount();
                }
            }

            return 0;


        }

    }

    /* 
       The Class 'Test' introduces the 'Testing' method.
       This creates multiple instances of the InitialRoll Method from the Game class and uses Debug.Assert to check the logic of both the dice rolls and the resulting sum 
   */

    class Test
    {
        // Objects
        Game GameTest = new Game();

        public void Testing()
        {

            List<int> DiceResults = GameTest._DiceResults;

            for (int loop = 0; loop < 100; loop++)
            {
                DiceResults.Clear();

                GameTest.InitialRoll();

                foreach (int Dice in DiceResults)
                {
                    Debug.Assert(Dice > 0 && Dice <= 6);

                }

                int DiceSum = DiceResults.Sum();

                Debug.Assert(DiceSum > 3 && DiceSum <= 18);

            }

                
        }

    }       
            
   
}
