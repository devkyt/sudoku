using System.Text;

namespace Sudoku.Game;

class Utils {
    
    public static int GetRandomNumber(int min, int max) {
        Random random = new Random();
        return random.Next(min, max);
    }

    public static (int, int, int, int) GetBoxBorders(int currentRow, int currentColumn) {
        var (minRow, maxRow) = GetRange(currentRow); 
        var (minCloumn, maxColumn) = GetRange(currentColumn);
        return (minRow, maxRow, minCloumn, maxColumn);
    }

    public static (int, int) GetRange(int index) {
        int minValue = index / 3 * 3;
        int maxValue = (int)(Math.Ceiling((double)(index + 1) / 3) * 3);
        return (minValue, maxValue);
    }

    public static int CountEmptyCells(int[,] grid) {
        int counter = 0;

        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                if (grid[i, j] == 0) counter++;
            }
        }

        return counter;
    }

    public static bool CellIsEmpty(int[,] grid, int row, int column) {
        return grid[row, column] == 0;
    }

    public static int[,] CopyGrid(int[,] grid) {
        return (int[,])grid.Clone();
    }

}
