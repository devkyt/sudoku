namespace Sudoku.Game;


class Validator {

    public static bool UniqueByAllRules(int[,] grid, int row, int column, int value) {
           return UniqueInRow(grid, row, value) && UniqueInColumn(grid, column, value) && UniqueInBox(grid, row, column, value);
    }

    public static bool UniqueInRow(int[,] grid, int row, int value) {
        for (int i = 0; i < 9; i++) {
            if (grid[row, i] == value) return false;
        }

        return true;
    }

    public static bool UniqueInColumn(int[,] grid, int column, int value) {
        for (int i = 0; i < 9; i++) {
            if (grid[i, column] == value) return false;
        }

        return true;
    }

    public static bool UniqueInBox(int[,] grid, int row, int column, int value) {
        var (minRow, maxRow, minCloumn, maxColumn) = Utils.GetBoxBorders(row, column);

        for (int i = minRow; i < maxRow; i ++) {
            for (int j = minCloumn; j < maxColumn; j ++) {
                if (grid[i, j] == value) return false;
            } 
        }

        return true;
    }

}
