using Solving.Model.Components;

namespace Solving.Model;

public abstract class AbstractBoard
{
    protected Component _sudokuBoard;
    public virtual List<List<Component>> GetBoardData()
    {
        return _sudokuBoard.GetAllData();
    }

}