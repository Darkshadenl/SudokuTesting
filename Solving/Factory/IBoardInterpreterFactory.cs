using Solving.Import;
using Solving.Interpreters;

namespace Solving.Factory;

public interface IBoardInterpreterFactory
{
    IBoardInterpreter GetInterpreter(BoardFile boardFile);
}