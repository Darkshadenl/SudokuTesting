namespace Solving.Model.Components;

public class SudokuBoard : Component
{
    public override void PrintSelf()
    {
        var verC = 0;
        var horizontalLine = "-------------------------------";
        
        Console.WriteLine(horizontalLine);
        for (var index = 0; index < _components.Count; index++)
        {
            Component component = _components[index];
            if (component is not Row) continue;
            
            component.PrintSelf();
            Console.WriteLine();
            if (verC == 2)
            {
                Console.WriteLine(horizontalLine);
                verC = 0;
            }
            else
            {
                verC++;
            }

        }
    }
    
    public Cell? FindEmptyCell()
    {
        foreach (var component in _components)
        {
            if (component is not Cell cell) continue;
            if (cell.Value == 0) return cell;
        }
        return null;
    }

    public void PrintSquaresIds()
    {
        foreach (var component in _components)
        {
            if (component is not Square square) continue;
            square.PrintSelfId();
        }
    }
}