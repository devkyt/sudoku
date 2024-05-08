namespace Sudoku.Game;


class Board : Solver {

    public int[,] solvedGrid = new int[9,9];
    public int[,] playGrid = new int[9,9];
    public int[,] backupGrid = new int[9,9];

    public int emptyCells;

    Generator _generator;
    Solver _solver;

    public Board(int tips) {
        _generator = new Generator();
        _solver = new Solver();
        emptyCells = 81 - tips;
    }

    public void Generate() {
        (solvedGrid, playGrid) = _generator.GetGameGrids(emptyCells, Difficulty.SHUFFLES);
        MakeBackup();
    }

    public bool SolveCurrent() {
       return _solver.Solve(playGrid);
    }

    public void SolveOrignial() {
      playGrid = Utils.CopyGrid(solvedGrid);
    }

    public void GetTip() {
        var (row, column, value) = _solver.GetTip(solvedGrid, playGrid);
        if (row != -1) Update(row, column, value); 
    }

    public void Update(int row, int column, int value) {
        playGrid[row, column] = value;
    }

    private void MakeBackup() {
        backupGrid = Utils.CopyGrid(playGrid);
    }

    public void Reset() {
        playGrid = Utils.CopyGrid(backupGrid);
    }

    public int Check() {
        return _solver.CheckBoard(playGrid, solvedGrid);
    }

}
