namespace Solving.Model.Components;

public class Row : Component
{
    public Row(int rowNumber)
    {
        _id = rowNumber;
    }

    public override void PrintSelf()
    {
        var horC = 0;
        
        Console.Write("|");
        for (var index = 0; index < _components.Count; index++)
        {
            horC += 1;
            var component = _components[index];
            
            if (!component.IsComposite())
            {
                component.PrintSelf();
            }
            
            if (horC == 3)
            {
                Console.Write("|");
                horC = 0;
            }
        }
    }
    
}