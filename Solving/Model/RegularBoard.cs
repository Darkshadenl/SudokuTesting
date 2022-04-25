using System.Collections;

namespace Solving.Model;

public class RegularBoard : AbstractBoard
{
    private List<List<Cell>> board = new();
    private int[] boardSize = {9, 8};

    public RegularBoard()
    {
        var queue = CreateValues();
        CreateBoard(queue);
        Solve();
        PrintBoard();
    }

    private bool Solve()
    {
        Cell? cellNoNumber = FindEmpty();

        if (cellNoNumber == null)
        {
            return true;
        }

        for (int targetNumber = 1; targetNumber < 10; targetNumber++) // 1 to 9
        {
            if (Valid(cellNoNumber, targetNumber))
            {
                cellNoNumber.Value = targetNumber;

                if (Solve())
                    return true;

                cellNoNumber.Value = 0;
            }
        }

        return false;
    }

    private bool Valid(Cell emptyCell, int number)
    {
        var row = board.ElementAt(emptyCell.Y);
        
        foreach (var cell in row)
        {
            if (cell.Value == number && !cell.Equals(emptyCell))
            {
                return false;
            }
        }

        for (int i = 0; i < board.Count; i++)
        {
            var cell = board.ElementAt(i).ElementAt(emptyCell.X);
            if (cell.Value == number && !cell.Equals(emptyCell))
            {
                return false;
            }
        }

        var emptyCellBoardBox = emptyCell.boardBox; // x, y of containing box
        List<Cell> cellsOfMatchingBox = new();

        foreach (List<Cell> cells in board)
        {
            foreach (Cell cell in cells)
            {
                if (cell.boardBox[0] == emptyCellBoardBox[0] && cell.boardBox[1] == emptyCellBoardBox[1])
                {
                    cellsOfMatchingBox.Add(cell);
                }
            }
        }

        foreach (var cell in cellsOfMatchingBox)
        {
            if (cell.Value == number && !cell.Equals(emptyCell))
            {
                return false;
            }
        }
        
        return true;
    }

    private Cell? FindEmpty()
    {
        foreach (List<Cell> cells in board)
        {
            foreach (Cell cell in cells)
            {
                if (cell.Value == 0)
                {
                    return cell;
                }
            }
        }

        return null;
    }

    private void CreateBoard(Queue<Queue<int>> queue)
    {
        var queueCount = queue.Count;
        var verticalLine = 0;

        for (int i = 0; i < queueCount; i++)
        {
            Queue<int> rowQueue = queue.Dequeue();
            var row = new List<Cell>();
            var cell = new Cell(boardSize);
            List<Cell> cells = cell.CreateCellToYourRight(rowQueue, row, verticalLine, 0);
            board.Add(cells);
            verticalLine += 1;
        }
    }

    private Queue<Queue<int>> CreateValues()
    {
        // 8 hoog 9 breed
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

        // var stack = new Stack<Stack<int>>();
        var queue = new Queue<Queue<int>>();

        for (int i = 0; i < boardArray.Length; i++)
        {
            var tempQueue = new Queue<int>();
            for (int j = 0; j < boardArray[i].Length; j++)
            {
                tempQueue.Enqueue(boardArray[i][j]);
                // tempStack.Push(boardArray[i][j]);
            }

            queue.Enqueue(tempQueue);
        }

        return queue;
    }

    private void PrintBoard()
    {
        var horC = 0;
        var verC = 0;
        var horizontalLine = "-------------------------";

        Console.WriteLine(horizontalLine);
        foreach (var cells in board)
        {
            verC += 1;
            Console.Write("| ");
            for (int i = 0; i < cells.Count; i++)
            {
                Console.Write(cells.ElementAt(i).Value);
                Console.Write(" ");
                horC += 1;
                if (horC == 3)
                {
                    Console.Write("| ");
                    horC = 0;
                }
            }

            if (verC == 3)
            {
                Console.WriteLine();
                Console.Write(horizontalLine);
                verC = 0;
            }

            horC = 0;
            Console.WriteLine();
        }
    }
}