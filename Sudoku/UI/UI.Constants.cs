namespace Sudoku.UI;


class Constants {

    public const string MenuScreen = "menu";
    public const string BoardScreen = "board";

    public const int ShowMessagTime = 3000;

    public const string ErrorMessage = "Couldn't solve from the current state";

    public const string RowDelimiter = "\t__________________________________________________________________";

    public const string ColumnDelimiter = "\t|\t\t   |\t\t\t   |\t\t\t   |";

    public static string Title() 
    {
        return @"
    ____        __  __             ____   _____           __      __        
   / __ \____ _/ /_/ /_     ____  / __/  / ___/__  ______/ /___  / /____  __
  / /_/ / __ `/ __/ __ \   / __ \/ /_    \__ \/ / / / __  / __ \/ //_/ / / /
 / ____/ /_/ / /_/ / / /  / /_/ / __/   ___/ / /_/ / /_/ / /_/ / ,< / /_/ / 
/_/    \__,_/\__/_/ /_/   \____/_/     /____/\__,_/\__,_/\____/_/|_|\__,_/  
                                                                            
";
    }


    public static string Slogan() {

        return "The videogame based on the boardgame based on the papergame based on the logic!\n\n";

    }

    public static string[] DifficultyLevels() 
    {
        return ["Easy",
                "Medium", 
                "Hard", 
                "Nightmare"];

    }

    public static string[] GameOptions() 
    {
        return ["1. Set value for a cell", 
                "2. Get a tip", 
                "3. Reset previous choice",
                "4. Autosolve from a start board state",
                "5. Reset to start",
                "6. Change difficulty",
                "7. Exit"];

    }

    public static string[] RowNames()
    {
       return ["C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9"];
    }

    public static string WinMessage() 
    {
        return @"
__  __               _       __            __
\ \/ /___  __  __   | |     / /___  ____  / /
 \  / __ \/ / / /   | | /| / / __ \/ __ \/ / 
 / / /_/ / /_/ /    | |/ |/ / /_/ / / / /_/  
/_/\____/\__,_/     |__/|__/\____/_/ /_(_)   
                                             
";
    }

    public static string LoseMessage() 
    {
        return @"
__  __               __                         ______              ___               _     
\ \/ /___  __  __   / /   ____  ________       /_  __/______  __   /   | ____ _____ _(_)___ 
 \  / __ \/ / / /  / /   / __ \/ ___/ _ \       / / / ___/ / / /  / /| |/ __ `/ __ `/ / __ \
 / / /_/ / /_/ /  / /___/ /_/ (__  )  __/      / / / /  / /_/ /  / ___ / /_/ / /_/ / / / / /
/_/\____/\__,_/  /_____/\____/____/\___(_)    /_/ /_/   \__, /  /_/  |_\__, /\__,_/_/_/ /_/ 
                                                       /____/         /____/                
";
    }

}
