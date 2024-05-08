using System.Reflection;

namespace Sudoku.Game;

class Generator : ShuffleMethods {


    public (int[,], int[,]) GetGameGrids(int emptyCells, int shuffles = 10) {
        int[,] originalGrid = CreateUniqueGrid(shuffles);
        int[,] playGrid = AddEmptyCells(originalGrid, emptyCells);
        return (originalGrid, playGrid);
    }

    public int[,] CreateUniqueGrid(int shuffles) {
        int[,] playGrid = CreateBaseGrid();
        playGrid = Shuffle(playGrid, shuffles);
        return playGrid;
    }

    public int[,] AddEmptyCells(int[,] grid, int emptyCells) {
        int[,] alteredGrid = Utils.CopyGrid(grid);
        int i = 0;

        while (i < emptyCells) {
            int row = Utils.GetRandomNumber(0,9);
            int column = Utils.GetRandomNumber(0,9);

            if (Utils.CellIsEmpty(alteredGrid, row, column)) continue;

            alteredGrid[row, column] = 0;
            i++;
        }

        return alteredGrid;
    }

    public int[,] CreateBaseGrid() {
        int[,] baseGrid = new int[9,9];

        for (int i = 0; i < 9; i ++) {
            for (int j = 0; j < 9; j ++) {
                baseGrid[i, j] = (i*3 + i/3 + j) % 9 + 1;
            }
        }

        return baseGrid;
    }

    public int[,] Shuffle(int[,] grid, int shuffles) {
        int[,] alteredGrid = Utils.CopyGrid(grid);
        string[] shuffleMethods = ["Transpose", "SwapRows", "SwapColumns", "SwapAreasOfRows", "SwapAreasOfColumns"];

        for (int i = 0; i < shuffles; i++) {
            int index = Utils.GetRandomNumber(0,5);
            alteredGrid = InvokeShuffleMethod(shuffleMethods[index], alteredGrid);

        }
        
        return alteredGrid;
    }

    public int[,] InvokeShuffleMethod(string methodName, int[,] grid) {
        Type type = typeof(ShuffleMethods);
        MethodInfo method = type.GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic)!;
        return (int[,])method.Invoke(null, [grid])!;
    }

};
