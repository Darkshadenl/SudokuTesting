using Solving;
using Solving.Import;
using Solving.View;

// AbstractBoard board = new RegularBoard(new Solver());

string pathRegular = @"C:\Users\qmb\Documents\Repos\SudokuTesting\Solving\Resources\Sudoku-files\puzzle.9x9";       // Works
string pathSamurai = @"C:\Users\qmb\Documents\Repos\SudokuTesting\Solving\Resources\Sudoku-files\puzzle.samurai";   // TODO samurai
string pathJigsaw = @"C:\Users\qmb\Documents\Repos\SudokuTesting\Solving\Resources\Sudoku-files\puzzle3.jigsaw";    // TODO jigsaw
string reg2 = @"C:\Users\qmb\Documents\Repos\SudokuTesting\Solving\Resources\Sudoku-files\puzzle2.9x9";             

Import import = new Import();
var boardFile = import.ImportFromPath(pathRegular);
InterpretBoard interpret = new InterpretBoard();
var abstractBoard = interpret.InterpretBoardFile(boardFile);


GameView view = new GameView();
view.Board = abstractBoard;


