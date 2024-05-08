namespace Sudoku.UI;

class Input {

    public static (ConsoleKey, int) GetUserChoice(int currentChoice) 
    {
        ConsoleKey key = Console.ReadKey(true).Key;

        switch(key) 
        {
            case ConsoleKey.UpArrow:
                currentChoice--;
                break;
            case ConsoleKey.DownArrow:
                currentChoice++;
                break;
            case ConsoleKey.Escape:
                return (key, -100);
        }

        return (key, currentChoice);

    }

    public static (bool, int) GetNumericInput(string lineType) 
    {
            int number = 0;
            Console.WriteLine($"Enter a {lineType}: ");
            bool result = Int32.TryParse(Console.ReadLine(), out number);
            
            if (!result || number > 9 || number < 1) 
            {
                Output.Print("\nYou should use number from 1 to 9", ConsoleColor.Red);
                Thread.Sleep(Constants.ShowMessagTime);
                return (false, 0);
            }

            return (result, number);
    }
    
}
