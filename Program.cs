/* 
Welcome message with ------
Promt user to give name
Promt user to choose language from list for greeting (here comes in Dictionary and Parse)
Show chosen option
Inser waiting thingy "Making personalised greeting..."
Print: 
- Good morning/afternoon/evening {name}. Accordingly to language
- This message was created date, time. 
 */
using System.Collections;
using System.Data;

namespace Basic_Oppgave_2;

class Program
{
    static void Main(string[] args)
    {
        // Greeting part and getting user name
        Console.WriteLine("");
        Console.WriteLine("Welcome to the personalized greeting program!");
        Console.WriteLine("---------------------------------------------");

        Console.WriteLine("Please enter your name:");
        string? name = Console.ReadLine();

        // Language dictionary
        Dictionary<int, string> languages = new()
        {
            { 1, "English" },
            { 2, "Norsk" },
            { 3, "Español" },
        };

        //Let user to choose language til correct/usable number
        int number;
        while (true)
        {
            Console.WriteLine("Choose a number for the language you want to be greeted in:");
            foreach (var language in languages)
            {
                Console.WriteLine($"{language.Key}. {language.Value}");
            }

            string? input = Console.ReadLine();

            // Check if number valid
            if (int.TryParse(input, out number) && languages.ContainsKey(number))
            {
                break; // Valid input, exit the loop
            }
            else
            {
                Console.WriteLine("Invalid number, please try again.");
            }
        }
        // Print chosen language
        Console.WriteLine($"You have chosen \"{languages[number]}\" for your greeting.");

        // Display waiting message
        for (int i = 0; i <= 3; i++) // Show 0 to 3 dots
        {
            Console.Write("\rMaking personalised greeting" + new string('.', i)); // Overwrite the same line
            Thread.Sleep(700);
        }

        Console.WriteLine(); // Move to the next line after the animation

        // Print a greeting message in the chosen language accordingly to time of the day
        string greeting;
        int currentHour = DateTime.Now.Hour;

        Console.ForegroundColor = ConsoleColor.Green; //changing Foreground Color of Text in Console
        switch (number)
        {
            case 1: //English
                if (currentHour < 12)
                    greeting = "Good morning";
                else if (currentHour < 18)
                    greeting = "Good afternoon";
                else
                    greeting = "Good evening";
                Console.WriteLine($"{greeting}, {name}!");
                break;

            case 2: //Norwegian
                if (currentHour < 12)
                    greeting = "God morgen";
                else if (currentHour < 18)
                    greeting = "God ettermiddag";
                else
                    greeting = "God kveld";
                Console.WriteLine($"{greeting}, {name}!");
                break;

            case 3: //Spanish
                if (currentHour < 12)
                    greeting = "Buenos días";
                else if (currentHour < 18)
                    greeting = "Buenas tardes";
                else
                    greeting = "Buenas noches";
                Console.WriteLine($"{greeting}, {name}!");
                break;
        }

        // Current time
        DateTime date = DateTime.Now;
        Console.WriteLine();
        Console.WriteLine($"This message was created on:");
        Console.WriteLine($"\tToday is: {date:D}");
        Console.WriteLine($"\tCurrent time: {date:T}\n");

        Console.ForegroundColor = ConsoleColor.White; //changing back

    }
}
