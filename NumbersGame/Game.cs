using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersGame
{
    // Ossy Drakeneld net24
    internal class Game
    {
        private readonly Random rnd = new(); 
        private void NumberGame(int correctAnswer)   // Method to handle the guessing game
        {
            var numberOfTrys = 5; // Number of try user has
            int guess;
            Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök.");

            do
            {
                Console.WriteLine($"du har {numberOfTrys} gissningar kvar");
                guess = Guess();

                if ( guess == 0) // select phrase to use depending on user guess
                {
                    Console.WriteLine("ogiltig gissning -1 gissnig");
                }
                else if (guess < correctAnswer && guess != 0) // if a guess is to low and
                {
                    
                    Console.WriteLine(GetFeedbackPhrase(false));
                }
                else if(guess > correctAnswer)// if a guess is to high
                {
                    Console.WriteLine(GetFeedbackPhrase(true));
                }

                numberOfTrys--; // deduct a guess 


            } while (guess != correctAnswer && numberOfTrys != 0); // Check if user  has guess left or has guess the right gues

            CheckGame(guess, correctAnswer);
        }
        private void CheckGame(int guess, int answer) // Method to check the result of the game 
        {
            if (guess == answer)
            {
                Console.ForegroundColor = ConsoleColor.Green; // Change color of text
                Console.WriteLine("Wohoo! Du klarade det!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök!");
            }
            Console.ResetColor(); // Reset color
        }
        private int Guess() // Method to get the user's guess and validate it
        {
            Console.Write("Skriv din gissning: ");
            string stringGuess = Console.ReadLine();
            return int.TryParse(stringGuess, out int result) ? result : 0; // return a 0 if user dont enter a valid guess
        }
        private string GetFeedbackPhrase(bool toHigh) // Give out a phrase to use depending on numb is high or low
        {
            // array for phrases
            string[] toHighPhrase = { "HAHA för högt", "FEL för högt", "Du gissar för högt" };
            string[] toLowPhrase = { "HHA för låågt", "Helt fel för lågt", "Du gissar för lågt" };

            int whatPhrase = rnd.Next(toHighPhrase.Length);

            if (toHigh) { return toHighPhrase[whatPhrase]; } // Check what phrase to use
            else { return toLowPhrase[whatPhrase]; }

        }
        public void StartGame() // Starting the gamne
        {
            do // Runs games until user enter "nej" 
            {
                int correctAnswer = rnd.Next(1, 20); // give a random number every new game
                NumberGame(correctAnswer);
                Console.WriteLine("Fortsätt spela? skriv nej för avsluta: ");

            } while (Console.ReadLine() != "nej"); 
        }
    }
}
