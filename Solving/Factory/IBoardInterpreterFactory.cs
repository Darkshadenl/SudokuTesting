using Solving.Import;
using Solving.Interpreters;

namespace Solving.Factory;

public interface IBoardInterpreterFactory
{
    public IBoardInterpreter Create(string interpreter);
}