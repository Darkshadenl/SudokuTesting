using Solving.Factory;
using Solving.Import;
using Solving.Interpreters;
using Solving.Model;

namespace Solving;

public class InterpretBoard
{
    private IBoardInterpreterFactory _boardInterpreterFactory;
    
    public InterpretBoard(IBoardInterpreterFactory factory)
    {
        _boardInterpreterFactory = factory;
    }

    public AbstractBoard InterpretBoardFile(BoardFile boardFile)
    {
        var interpreter = _boardInterpreterFactory.Create(boardFile.Extension);
        return interpreter.Interpret(boardFile);
    }
}