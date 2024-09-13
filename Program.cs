using System;

namespace NumbersGame
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök.");

            RandomNumberGenerator randomNumber = new(); // create instance
            int secretNumber = randomNumber.GetRandomNumber(); // get the random number

			int guessChances = 5;

			while (guessChances > 0)
			{
				try
				{
					int userGuess = Int32.Parse(Console.ReadLine()); // parse to int

					// check user input vs random generated number
					if (userGuess > secretNumber) 
					{
						Console.WriteLine("Tyvärr du gissade för högt!");
					}
					else if (userGuess < secretNumber)
					{
						Console.WriteLine("Tyvärr du gissade för lågt!");
					}
					else
					{
						Console.WriteLine("Woho! Du gjorde det!");
						break;
					}
					guessChances--;

				}
				catch (FormatException) // if user enters invalid input
				{
					Console.WriteLine("Du måste ange ett nummer.");
				}
			}
            if (guessChances == 0)
            {
                Console.WriteLine($"Du har inga fler försök. Korrekt nummer var {secretNumber}.");
            }
        }
    }

    public class RandomNumberGenerator
	{
        private Random random;
        private int randNumber;

		public RandomNumberGenerator() 
        {
			random = new Random();
			randNumber = random.Next(1, 21);
		}

		public int GetRandomNumber()
		{
			return randNumber;
		}
	}
}