using System.Text;

namespace Sudoku.UI;

class UI {

    public static int ShowUI(string[] options, string screenType =  Constants.MenuScreen, bool alignCenter = true, int[,]? grid = null) 
    {
        int currentChoice = 0;

        ConsoleKey key;

        Console.CursorVisible = false;

        Output.PrintMethod printMethod = alignCenter ? Output.PrintInCenter : Output.Print;

        do 
        {   
            if (currentChoice > options.Length - 1) currentChoice = 0;
            if (currentChoice < 0) currentChoice = options.Length - 1;
            
            Console.Clear();

            switch(screenType)
            {
                case Constants.MenuScreen:
                    Output.DisplayHeader();
                    break;
                case Constants.BoardScreen:
                    if(grid != null) Output.DisplayGrid(grid);
                    break;
            }

            Output.DisplayOptions(printMethod, options, currentChoice);

            (key, currentChoice) = Input.GetUserChoice(currentChoice);

            if (currentChoice == -100) return currentChoice;

        } while (key != ConsoleKey.Enter);

        Console.CursorVisible = true;

        Console.Clear(); 

        return currentChoice;
    }

    public static int ShowMainMenu()
    {
        return ShowUI(Constants.DifficultyLevels(), screenType: Constants.MenuScreen, alignCenter: true);
    }
    public static int ShowGameBoard(int[,] grid) 
    {
        return ShowUI(Constants.GameOptions(), screenType: Constants.BoardScreen, alignCenter: false, grid: grid);
    }

    public static void ShowErrorMessage() 
    {   
        Output.DisplayMessage(Constants.ErrorMessage, ConsoleColor.Red);
    }

    public static void ShowWinMessage() {
        Output.DisplayMessage(Constants.WinMessage(), ConsoleColor.Green);
    }

    public static void ShowLoseMessage() {
        Output.DisplayMessage(Constants.LoseMessage(), ConsoleColor.Red);
    }

    public static (int, int, int) GetCellsValueFromUser(int[,] grid) 
    {
        int row = 0;
        int column = 0;
        int value = 0;
        bool result;

        do 
        {       
            Output.DisplayGrid(grid);

            (result, row) = Input.GetNumericInput("row");

            if (!result) continue;
            
            (result, column) = Input.GetNumericInput("column");

            if (!result) continue;

            if (!Utils.CellIsEmpty(grid, row - 1, column - 1)) 
            {
                Output.Print("\nThe cell is already taken", ConsoleColor.Red);
                Thread.Sleep(Constants.ShowMessagTime);
                continue;
            }

            (result, value) = Input.GetNumericInput("value");

            if (!result) continue;

        } while (row == 0 || column == 0 || value == 0);

        return (row - 1, column - 1, value);
    }

}
