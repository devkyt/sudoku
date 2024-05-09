using System.Diagnostics.Tracing;
using Sudoku.UI;
using Sudoku.Game;


class Program {
    static void Main(string[] args) {
        
        bool play = true;
        int tmpRow = -1;
        int tmpColumn = -1;

        while (play)
        {   
            bool autoSolver = false;

            int difficultyLevel = UI.ShowMainMenu(); 

            if (difficultyLevel == -100) break;

            Board board = new Board(Difficulty.TIPS[difficultyLevel]);
            board.Generate();

            bool session = true;

            while (session) {
                int result = board.Check();

                switch(result) 
                {
                    case 1:
                        if (!autoSolver) 
                        {
                            UI.ShowWinMessage();
                            session = false;
                            continue;
                        };
                        break;
                    case -1:
                        if (!autoSolver) 
                        {
                            UI.ShowLoseMessage();
                            session = false;
                            continue;
                        };
                        break;
                }

                int option = UI.ShowGameBoard(board.playGrid);

                if (option == -100) break;

                switch(option)
                {
                    case 0:
                        var (row, column, value) = UI.GetCellsValueFromUser(board.playGrid);
                        (tmpRow, tmpColumn) = (row, column);
                        board.Update(row, column, value);
                        break;
                    case 1:
                        board.GetTip();
                        break;
                    case 2:
                        if (tmpRow >=0 && tmpColumn >= 0) board.Update(tmpRow, tmpColumn, 0);
                        break;
                        // bool possible = board.SolveCurrent();
                        // if (!possible) 
                        // {
                        //     UI.ShowErrorMessage();
                        //     break;
                        // }
                        // autoSolver = true;
                        // break;
                    case 3:
                        board.SolveOrignial();
                        autoSolver = true;
                        break;
                    case 4:
                        board.Reset();
                        autoSolver = false;
                        break;
                    case 5:
                        session = false;
                        break;
                    case 6:
                        session = false;
                        play = false;
                        break;
                        
                }
            }
        }
    }
}
