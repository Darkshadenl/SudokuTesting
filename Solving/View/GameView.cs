using Solving.Model.Viewable;
using Solving.Visitor;

namespace Solving.View;

public class GameView : IBoardView
{
    private IPrintBoardVisitor _printBoardVisitor;
    public GameView(IPrintBoardVisitor printBoardVisitor)
    {
        _printBoardVisitor = printBoardVisitor;
    }

    public void Accept(IPrintBoardVisitor visitor)
    {
        _printBoardVisitor = visitor;
    }

    public void DrawBoard(List<IViewable> boardData)
    {
        Console.WriteLine("Press ESC to stop");
        Draw(boardData);
        
        do {
            while (!Console.KeyAvailable) {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        Draw(boardData);
                        break;
                    case ConsoleKey.DownArrow:
                        Draw(boardData);
                        break;
                    case ConsoleKey.RightArrow:
                        Draw(boardData);
                        break;
                    case ConsoleKey.LeftArrow:
                        Draw(boardData);
                        break;
                }
            }
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }

    private void Draw(List<IViewable> boardData)
    {
        Console.Clear();
        _printBoardVisitor.Draw(boardData);
    }
}