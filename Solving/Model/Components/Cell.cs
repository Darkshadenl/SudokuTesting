namespace Solving.Model.Components;

public class Cell : Component
{
    public int Value { get; set; }
    public int X { get; private set; }
    public int Y { get; private set; }
    public Row Row { get; set; }
    public Square Square { get; set; }
    public Column Column { get; set; }

    public Cell(int value, int x, int y)
    {
        Value = value;
        X = x;
        Y = y;
    }

    public override void Add(Component c)
    {
        throw new NotImplementedException();
    }
    
    public override bool IsComposite()
    {
        return false;
    }

    public override bool IsEmpty()
    {
        return Value == 0;
    }

    public override void PrintSelf()
    {
        Console.Write($" {Value} ");
    }
    
    public override void PrintSelfId()
    {
        Console.WriteLine("Cell component has no id(ea)");
    }

    public bool IsCellValueDuplicateInRow(int number)
    {
        return Row.DoesHaveDuplicate(this, number);
    }

    public bool IsCellValueDuplicateInColumn(int number)
    {
        return Column.DoesHaveDuplicate(this, number);
    }

    public bool IsCellValueDuplicateInSquare(int number)
    {
        return Square.DoesHaveDuplicate(this, number);
    }
}