namespace Sudoku.UI;

class Utils {
      public static bool CellIsEmpty(int[,] grid, int row, int column) {
        return grid[row, column] == 0;
    }
    
}
