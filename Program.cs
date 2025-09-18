using System;
namespace ConsoleApp1
{
    internal class Program
    {
        static int wallet = 1000; //Skapa en plånbok
        static void Main(string[] args)
        {
        while (true)
        {
        Console.Clear();
        int[] winningNumbers = GeneratorWinner(); // Generera vinnar numret
        int[] userNumbers = UserInput(); // Användares lotter
        CheckWinner(userNumbers, winningNumbers);
        Console.WriteLine("Skriv exit om du vill avsluta programmet, annars tryck enter för att spela igen"); // Skapa exit program
        string input = Console.ReadLine(); // Skapa exit program
        if (input == "exit")
            {
                break;
            }
        
        }    
        
        }
        /* --------------------------------- */

        static void CheckWinner(int[] userNumbers, int[] winningNumbers) // Kolla om användaren har vunnit
        {   
            bool isWinner = false; // Markera om användaren har vunnit
            foreach (int number1 in userNumbers) 
            {
                foreach (int number2 in winningNumbers) // Kolla om användarens nummer är en av vinnar numret
                {
                    if (number1 == number2)
                    {
                        wallet += 500;
                        Console.WriteLine("Du har vunnit med " + number1 + " Du har vunnit 500 kr, Du har " + wallet + " kr nu"); 
                        isWinner = true;
                    }
                }
            }
            if (!isWinner)
            {
                Console.WriteLine("Tyvärr, så vann du inte denna gång"); // Om användaren inte har vunnit
            }


        }

        /* --------------------------------- */

        static int[] GeneratorWinner()
        {
            int[] winningNumbers = new int[3];
            Random random = new Random();
            for (int i = 0; i < winningNumbers.Length; i++)
            {
                winningNumbers[i] = random.Next(1, 51); // Generera 3 slumpmässiga nummer mellan 1-50
            }
            return winningNumbers;
        }
        /* --------------------------------- */
        
        
        /* --------------------------------- */
        static int[] UserInput()
        {
            int[] userNumbers = new int[5];
            int i = 0;
            Console.WriteLine("Köp ditt lottnummer mellan 1-50, eller done för att avsluta"); // Be användaren köpa ett lott nummer
            while (i < 5)
            {
                int number;
                string userinput = Console.ReadLine();
                bool success = int.TryParse(userinput, out number); // Kolla om användaren skrev in ett nummer
                if (success && number > 0  && number < 51) // Kolla om numret är mellan 1-50
                {
                    userNumbers[i] = number;
                    wallet -= 50;
                    Console.WriteLine("You bought ticket: " + number + "Du har " + wallet + " kr kvar"); // Skriv ut användarens plånbok
                    i++;
                }
                else if (userinput == "done")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ogiltigt inmatning"); // Skriv den texten om användaren skrev fel nummer
                }
            }
            return userNumbers;
                    
        }
        /* --------------------------------- */

    }
}        
