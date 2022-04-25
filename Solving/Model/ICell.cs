namespace Solving.Model;

public interface ICell
{
    List<Cell> CreateCellToYourRight(Stack<int> remainingValues, List<Cell> cells, int verticalLine);
    bool isEmpty();
}