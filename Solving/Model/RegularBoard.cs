using System.Collections;

namespace Solving.Model;

public class RegularBoard : AbstractBoard
{
    private List<List<Cell>> board = new();
    private int[] boardSize = {9, 8};

    public RegularBoard()
    {
        Stack<Stack<int>> stack = CreateValues();
        CreateBoard(stack);

        var e = board.ElementAt(0).ElementAt(0).boardBox;
        // var solved = Solve();
        
        PrintBoard();
    }
    
    private bool Solve()
    {
        Cell? find = FindEmpty();
        
        if (find == null)
        {
            return true;
        }

        for (int i = 1; i < 10; i++)
        {
            if (Valid(find, i))
            {
                find.Value = i;

                if (Solve())
                    return true;

                find.Value = 0;
            }
        }
        return false;
    }

    private bool Valid(Cell emptyCell, int number)
    {
        var row = board.ElementAt(emptyCell.Y);

        if (row.Where((cell, i) => cell.Value == number && cell.X != i).Any())
        {
            return false;
        }

        for (int i = 0; i < board.Count; i++)
        {
            var colCell = board.ElementAt(i).ElementAt(emptyCell.X);
            if (colCell.Value == number && emptyCell.Y != i)
            {
                return false;
            }
        }

        var emptyCellBoardBox = emptyCell.boardBox; // x, y of containing box

        foreach (var cells in board)
        {
            foreach (var cell in cells)
            {
                var cellXBoardBox = cell.boardBox[0];
                var cellYBoardBox = cell.boardBox[1];
                
                if (cellXBoardBox == emptyCellBoardBox[0]       // check if horizontally in same box
                    && cellYBoardBox == emptyCellBoardBox[1]    // check if vertically in same box
                    && cell.Value == number                     // 
                    && cell.X != emptyCell.X 
                    && cell.Y != emptyCell.Y)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private Cell? FindEmpty()
    {
        return board.SelectMany(list => list).FirstOrDefault(cell => cell.isEmpty());
    }

    private void CreateBoard(Stack<Stack<int>> stack)
    {
        var stackCount = stack.Count;
        
        for (int i = 0; i < stackCount; i++)
        {
            Stack<int> rowStack = stack.Pop();
            var row = new List<Cell>();
            var cell = new Cell(boardSize);
            List<Cell> cells = cell.CreateCellToYourRight(rowStack, row, stackCount - i);
            board.Add(cells);
        }
    }

    private Stack<Stack<int>> CreateValues()
    {
        // 8 hoog 9 breed
        int[][] boardArray = {
            new[] {7, 8, 0, 4, 0, 0, 1, 2, 0},
            new[] {6, 0, 0, 0, 7, 5, 0, 0, 9},
            new[] {0, 0, 0, 6, 0, 1, 0, 7, 8},
            new[] {0, 0, 7, 0, 4, 0, 2, 6, 0},
            new[] {0, 0, 1, 0, 5, 0, 9, 3, 0},
            new[] {9, 0, 4, 0, 6, 0, 0, 0, 5},
            new[] {0, 7, 0, 3, 0, 0, 0, 1, 2},
            new[] {1, 2, 0, 0, 0, 7, 4, 0, 0},
        };
        
        var stack = new Stack<Stack<int>>();

        for (int i = 0; i < boardArray.Length; i++)
        { 
            var tempStack = new Stack<int>();
            for (int j = 0; j < boardArray[i].Length; j++)
            {
                tempStack.Push(boardArray[i][j]);
            }
            stack.Push(tempStack);
        }

        return stack;
    }

    private void PrintBoard()
    {
        var horC = 0;
        var verC = 0;
        foreach (var cells in board)
        {
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

            horC = 0;

            Console.WriteLine();
        }
    }
}