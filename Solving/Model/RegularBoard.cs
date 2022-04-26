using System.Collections;
using Solving.Model.Components;

namespace Solving.Model;

public class RegularBoard : AbstractBoard
{
    private SudokuBoard _sudokuBoard;
    private Solver _solver;

    public RegularBoard(Solver solver)
    {
        var values = CreateValues();
        CreateBoard(values);
        PrintBoard();

        _solver = solver;
        _solver.SudokuBoard = _sudokuBoard;
        var board = _solver.SolveBoard();
        
        PrintBoard(board);
    }
    private void CreateBoard(int[][] mdArray)
    {
        _sudokuBoard = new SudokuBoard();
        var squareLeft = new Square(0);
        var squareMiddle = new Square(1);
        var squareRight = new Square(2);
        int rows = 0;
        int cols = 0;
        int squares = 2;
        
        // create rows and squares
        for (int i = 0; i < mdArray.Length; i++)
        {
            var row = new Row(rows);
            
            for (int j = 0; j < mdArray[i].Length; j++)
            {
                int value = mdArray[i][j];
                var cell = new Cell(value, j, i);
                row.Add(cell);
                cell.Row = row;

                if (j <= 2)
                {
                    squareLeft.Add(cell);
                    cell.Square = squareLeft;
                }
                else if (j is > 2 and <= 5)
                {
                    squareMiddle.Add(cell);
                    cell.Square = squareMiddle;
                }
                else
                {
                    squareRight.Add(cell);
                    cell.Square = squareRight;
                }
            }
            
            if (i is 2 or 5)
            {
                _sudokuBoard.Add(squareLeft);
                _sudokuBoard.Add(squareMiddle);
                _sudokuBoard.Add(squareRight);
                
                squareLeft = new Square(++squares);
                squareMiddle = new Square(++squares);
                squareRight = new Square(++squares);
            }
            _sudokuBoard.Add(row);
        }
        
        _sudokuBoard.Add(squareLeft);
        _sudokuBoard.Add(squareMiddle);
        _sudokuBoard.Add(squareRight);
        
        int horizontalLength = mdArray.Length;
        int verticalLength = mdArray[0].Length;

        // create columns
        for (int j = 0; j < horizontalLength; j++)
        {
            var col = new Column(cols);
            for (int i = 0; i < verticalLength; i++)
            {
                var value = mdArray[i][j];
                var cell = new Cell(value, j, i);
                col.Add(cell);
                cell.Column = col;
            }
            _sudokuBoard.Add(col);
        }
    }

    private int[][] CreateValues()
    {
        // 9 hoog 9 breed
        int[][] boardArray =
        {
            new[] {7, 8, 0, 4, 0, 0, 1, 2, 0},
            new[] {6, 0, 0, 0, 7, 5, 0, 0, 9},
            new[] {0, 0, 0, 6, 0, 1, 0, 7, 8},
            new[] {0, 0, 7, 0, 4, 0, 2, 6, 0},
            new[] {0, 0, 1, 0, 5, 0, 9, 3, 0},
            new[] {9, 0, 4, 0, 6, 0, 0, 0, 5},
            new[] {0, 7, 0, 3, 0, 0, 0, 1, 2},
            new[] {1, 2, 0, 0, 0, 7, 4, 0, 0},
            new[] {0, 4, 9, 2, 0, 6, 0, 0, 7}
        };

        return boardArray;
    }

    private void PrintBoard()
    {
        _sudokuBoard.PrintSelf();
        Console.WriteLine();
        Console.WriteLine();
    }
    
    private void PrintBoard(SudokuBoard sudokuBoard)
    {
        sudokuBoard.PrintSelf();
        Console.WriteLine();
        Console.WriteLine();
    }
}