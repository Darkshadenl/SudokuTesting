using Solving.Import;
using Solving.Model;

namespace Solving.Interpreters;

public interface IBoardInterpreter
{
    AbstractBoard Interpret(BoardFile boardFile);
}