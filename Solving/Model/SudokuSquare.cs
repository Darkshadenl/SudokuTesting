namespace Solving.Model;

public class SudokuSquare : Component
{
    private List<Cell> _cells;
    
    public override bool isEmpty()
    {
        return _cells.Count == 0;
    }

    public override void add(Component c)
    {
        throw new NotImplementedException();
    }
    
}