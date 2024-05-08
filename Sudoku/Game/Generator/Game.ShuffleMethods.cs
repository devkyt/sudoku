namespace Sudoku.Game;

class ShuffleMethods {

    protected static int[,] Transpose(int[,] grid) {
        int[,] alteredGird = new int[9, 9];

        for (int i = 0; i < 9; i ++) {
            for (int j = 0; j < 9; j ++) {
                alteredGird[j, i] = grid[i, j];
            }
        }

        return alteredGird;
    }

    protected static int[,] SwapRows(int[,] grid) {
        var (firstRowForSwap, secondRowForSwap) = GetLinesForSwap();
        return SwapTwoRows(grid, firstRowForSwap, secondRowForSwap);
    }

    protected static int[,] SwapColumns(int[,] grid) {
        var (firstColumnForSwap, secondColumnForSwap) = GetLinesForSwap();
        return SwapTwoColumns(grid, firstColumnForSwap, secondColumnForSwap);
    }

    protected static int[,] SwapAreasOfRows(int[,] grid) {
        int[,] alteredGird = Utils.CopyGrid(grid);
        var (firstArea, secondArea) = GetAreasForSwap();

        for (int i = 0; i < 3; i++) {
            alteredGird = SwapTwoRows(alteredGird, firstArea + i, secondArea + i);
        }

        return alteredGird;
    }

    protected static int[,] SwapAreasOfColumns(int[,] grid) {
        int[,] alteredGird = Utils.CopyGrid(grid);
        var (firstArea, secondArea) = GetAreasForSwap();

        for (int i = 0; i < 3; i++) {
            alteredGird = SwapTwoColumns(alteredGird, firstArea + i, secondArea + i);
        }

        return alteredGird;
    }

    protected static (int, int) GetLinesForSwap() {
        int startPoint = 3 * Utils.GetRandomNumber(0, 3);
        int firstPosition = startPoint + Utils.GetRandomNumber(0, 3);
        int secondPosition;

        do 
        {
            secondPosition = startPoint + Utils.GetRandomNumber(0, 3);
        } 
        while (firstPosition == secondPosition);

        return (firstPosition, secondPosition);
    }

    protected static (int, int) GetAreasForSwap() {
        int firstPoint = 3 * Utils.GetRandomNumber(0, 3);
        int secondPoint;

        do 
        {
            secondPoint = 3 * Utils.GetRandomNumber(0, 3);
        } 
        while (firstPoint == secondPoint);

        return (firstPoint, secondPoint);
    }


    protected static int[,] SwapTwoRows(int[,] grid, int firstRow, int secondRow) {
        int[,] alteredGrid = Utils.CopyGrid(grid);

        for (int i = 0; i < 9; i++) {
            alteredGrid[firstRow, i] = grid[secondRow, i];
            alteredGrid[secondRow, i] = grid[firstRow, i];
        }

        return alteredGrid;

    }

    protected static int[,] SwapTwoColumns(int[,] grid, int firstColumns, int secondColumns) {
        int[,] alteredGrid = Utils.CopyGrid(grid);

        for (int i = 0; i < 9; i++) {
            alteredGrid[i, firstColumns] = grid[i, secondColumns];
            alteredGrid[i, secondColumns] = grid[i, firstColumns];
        }

        return alteredGrid;
    }
}
