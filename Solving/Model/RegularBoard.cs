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
        int squares = 2;
        var columns = new Column[mdArray[0].Length];
        var rows = new Row[mdArray.Length];
        var squaress = new Square[mdArray.Length * mdArray[0].Length];
        
        // create rows, cols and squares
        for (int i = 0; i < mdArray.Length; i++)
        {
            if (rows[i] == null)
            {
                rows[i] = new Row(i);
            }
            
            for (int j = 0; j < mdArray[i].Length; j++)
            {
                if (columns[j] == null)
                {
                    columns[j] = new Column(j);
                }
                
                int value = mdArray[i][j];
                var cell = new Cell(value, j, i);
                
                rows[i].Add(cell);
                columns[j].Add(cell);
                cell.Row = rows[i];
                cell.Column = columns[j];
                
                switch (j)
                {
                    case <= 2:
                        squareLeft.Add(cell);
                        cell.Square = squareLeft;
                        break;
                    case > 2 and <= 5:
                        squareMiddle.Add(cell);
                        cell.Square = squareMiddle;
                        break;
                    default:
                        squareRight.Add(cell);
                        cell.Square = squareRight;
                        break;
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
        }
        foreach (var column in columns)
        {
            _sudokuBoard.Add(column);
        }

        foreach (var row in rows)
        {
            _sudokuBoard.Add(row);
        }
        
        _sudokuBoard.Add(squareLeft);
        _sudokuBoard.Add(squareMiddle);
        _sudokuBoard.Add(squareRight);
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