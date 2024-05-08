namespace Sudoku.Game;


class Solver : Validator {

    public bool Solve(int[,] grid) 
    {
        var (row, column) = GetStartPosition(grid);
        if (row < 0) return true;

        for (int value = 1; value <= 9; value++) 
        {
            if (UniqueByAllRules(grid, row, column, value)) 
            {
                grid[row, column] = value;

                if (Solve(grid)) 
                {
                    return true;
                } else 
                {
                    grid[row, column] = 0;
                }

            }
        }

        return false;
    }

    public int CheckBoard(int[,] playGrid, int[,] solvedGrid) 
    {
        var (_, emptyCell) = GetStartPosition(playGrid); 

        if (emptyCell != -1) return 0;

        for (int i = 0; i < 9; i++) 
        {
            for (int j = 0; j < 9; j++) 
            {
                if (playGrid[i, j] != solvedGrid[i, j]) return -1;
            }
        }
        return 1;
    }
        

    public (int, int) GetStartPosition(int[,] grid) 
    {
        for (int i = 0; i < 9; i++) 
        {
            for (int j = 0; j < 9; j++) 
            {
                if (Utils.CellIsEmpty(grid, i, j)) return (i, j);
            }
        }

        return (-1, -1);
    }

    public (int, int, int) GetTip(int[,] solvedGrid, int[,] currentGrid) 
    {   
        if (Utils.CountEmptyCells(currentGrid) == 0) return (-1, -1, -1);

        while (true) {
            int row = Utils.GetRandomNumber(0,9);
            int column = Utils.GetRandomNumber(0,9);
            

            if (Utils.CellIsEmpty(currentGrid, row, column)) 
            {   
                int value = solvedGrid[row, column];
                return (row, column, value);
            }
        }
    }

}
