using Solving.Model;
using Solving.Model.Components;

namespace Solving.View;

public interface IBoardView
{
    public IPrintBoardVisitor PrintBoardVisitor { get; set; }
    public void DrawBoard(AbstractBoard board);
    public void Clear();
}

public class GameView 
{
    public IPrintBoardVisitor PrintBoardVisitor { get; set; }

    public void Draw()
    {
        
    }

    public void Clear()
    {
        // Clear screen
    }
}

public interface IPrintBoardVisitor
{
    public void Draw(RegularBoard board);
}

public class PrintBoardVisitor : IPrintBoardVisitor
{
    public void Draw(AbstractBoard board)
    {
        var data = board.GetBoardData();

        var verC = 0;
        var horizontalLine = "-------------------------------";

        Console.WriteLine(horizontalLine);
        
        // for (var index = 0; index < _components.Count; index++)
        // {
        //     Component component = _components[index];
        //     if (component is not Row) continue;
        //
        //     component.PrintSelf();
        //     Console.WriteLine();
        //     if (verC == 2)
        //     {
        //         Console.WriteLine(horizontalLine);
        //         verC = 0;
        //     }
        //     else
        //     {
        //         verC++;
        //     }
        // }
        
        foreach (var row in data)
        {
            foreach (var component in row)
            {
                
            }
        }
    }
}