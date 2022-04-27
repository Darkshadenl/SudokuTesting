using Solving.Model.Components;

namespace Solving.Model;

public abstract class AbstractBoard
{
    public abstract AbstractBoard CreateBoard(int[][] mdArray);
    public virtual void GetBoardData()
    {
        
    }

}