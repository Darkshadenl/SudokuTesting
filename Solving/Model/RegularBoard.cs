using System.Collections;
using Solving.Model.Components;

namespace Solving.Model;

public class RegularBoard : AbstractBoard
{
    private SudokuBoard _sudokuBoard;

    public RegularBoard(Solver solver)
    {
        _solver = solver;
        _sudokuBoard = new SudokuBoard();

        var values = CreateValues();
        CreateBoard(values);
        PrintBoard();
        _solver.SudokuBoard = _sudokuBoard;
        var board = _solver.SolveBoard();
        if (board != null)
        {
            PrintBoard(board);
        }
        else
        {
            Console.WriteLine("No solution found");
        }
    }
    private void CreateBoard(int[][] mdArray)
    {
        var columns = new Column[mdArray[0].Length];
        var rows = new Row[mdArray.Length];
        var squares = new Square[mdArray.Length / 3][];
        squares[0] = new Square[mdArray.Length / 3];
        squares[1] = new Square[mdArray.Length / 3];
        squares[2] = new Square[mdArray.Length / 3];
       
        
        // create rows, cols and squares
        for (int i = 0; i < mdArray.Length; i++)
        {
            if (rows[i] == null)
            {
                rows[i] = new Row(i);
            }
            
            for (int j = 0; j < mdArray[i].Length; j++)
            {
                var c = j;
                var r = i;
                Square activeSquare;
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

                activeSquare = squares[i % 3][j % 3];
                if (activeSquare == null)
                {
                    activeSquare = new Square(i % 3, j % 3);
                    squares[i % 3][j % 3] = activeSquare;
                }
                activeSquare.Add(cell);
                cell.Square = activeSquare;
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

        foreach (var square in squares)
        {
            foreach (var square1 in square)
            {
                _sudokuBoard.Add(square1);
            }
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