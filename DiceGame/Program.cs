using DiceGame;
using System;


class program
{
    static void Main(string[] args)
    {
        // Objects

        Test TestMode = new Test();

        Game game = new Game();


        // Methods 

        game.InitialRoll();

        game.ContinuousRoll();

        // For Using the Testing mode, Uncomment the line below
        // TestMode.Testing();

    }

}