using Solving.Model;
using Solving.Model.Viewable;
using Solving.Visitor;

namespace Solving.View;

public interface IBoardView
{
    public void DrawBoard(List<IViewable> boardData);
    public void Accept(IPrintBoardVisitor visitor);

}