using System.Text;

namespace Sudoku.UI;

class Output {

    public delegate void PrintMethod(String input, ConsoleColor color = ConsoleColor.White);

    public static void DisplayHeader(ConsoleColor color = ConsoleColor.Green) 
    {
        PrintRawLiteral(PrintInCenter, Constants.Title());
        PrintInCenter(Constants.Slogan());
    }

    public static void DisplayOptions(PrintMethod printMethod, string[] options, int currentChoice, ConsoleColor choiceColor = ConsoleColor.Green) 
    {
            for (int i = 0; i < options.Length; i++)
            {    
                ConsoleColor color = i == currentChoice ? choiceColor : ConsoleColor.White;

                printMethod(options[i], color);
            }
    }

    public static void DisplayGrid(int[,] grid) {
        Console.WriteLine("\t" + string.Join("\t", Constants.RowNames()));
        Console.WriteLine(Constants.RowDelimiter + "\n");

        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < grid.GetLength(0); i++) {
            stringBuilder.Append($"R{i+1}\t");
            for (int j = 0; j < grid.GetLength(1); j++) {
                string startDelimiter = j == 0 ? "| " : "";
                string endDelimiter = (j + 1) % 3 == 0 ? "  |\t" : "\t";
                stringBuilder.Append(startDelimiter + $"{grid[i, j]}" + endDelimiter);
                
            }
            Console.Write($"{stringBuilder.ToString()}\n");
            if ((i + 1) % 3 == 0) Console.WriteLine(Constants.RowDelimiter);
            if ((i +1) % 9 != 0) Console.WriteLine(Constants.ColumnDelimiter);

            stringBuilder.Clear();
        }
        Console.WriteLine("\n\n");
    }

    public static void DisplayMessage(string message, ConsoleColor color = ConsoleColor.Green)
    {
        Console.Clear();
        PrintRawLiteral(PrintInCenter, message, color);
        Thread.Sleep(Constants.ShowMessagTime);
    }

    public static void Print(String input, ConsoleColor color = ConsoleColor.White) 
    {
        Console.ForegroundColor = color;
        Console.WriteLine(input);
        Console.ResetColor();
    }

    public static void PrintRawLiteral(PrintMethod printMethod, String input, ConsoleColor color = ConsoleColor.Green) 
    {
        StringReader reader = new StringReader(input);
        string line;
        do
        {
            line = reader.ReadLine();
            if (line != null)
            {
                printMethod(line, color);
            }

        } while (line != null);
    }

    public static void PrintInCenter(String input, ConsoleColor color = ConsoleColor.White) 
    {
        Console.ForegroundColor = color;
        Console.Write(new string(' ', (Console.WindowWidth - input.Length) / 2));
        Console.WriteLine(input);
        Console.ResetColor();
    }
    
}


