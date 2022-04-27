using Solving.Factory;
using Solving.Import;
using Solving.Model;

namespace Solving;

public class InterpretBoard
{
    private IBoardInterpreterFactory _boardInterpreterFactory;
    
    public InterpretBoard()
    {
        _boardInterpreterFactory = new BoardInterpreterFactory();
    }

    public AbstractBoard InterpretBoardFile(BoardFile boardFile)
    {
        var interpreter = _boardInterpreterFactory.GetInterpreter(boardFile);
        return interpreter.Interpret(boardFile);
    }
}