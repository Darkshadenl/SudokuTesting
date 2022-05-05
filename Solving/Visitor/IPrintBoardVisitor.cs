using Solving.Model;
using Solving.Model.Viewable;

namespace Solving.Visitor;

public interface IPrintBoardVisitor
{
    public void Draw(List<IViewable> board);

}