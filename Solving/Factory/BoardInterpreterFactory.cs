using Solving.Import;
using Solving.Interpreters;

namespace Solving.Factory;

public class BoardInterpreterFactory : IBoardInterpreterFactory
{
    public IBoardInterpreter GetInterpreter(BoardFile boardFile)
    {
        switch (boardFile.Extension)
        {
            // case ".4x4":
            //     return new TextBoardInterpreter();
            // case ".6x6":
            //     return new CsvBoardInterpreter();
            case ".9x9":
                return new RegularInterpreter();
            case ".jigsaw":
                return new JigsawInterpreter();
            // case ".samurai":
            //     return new CsvBoardInterpreter();
            default:
                throw new ArgumentException("Invalid file extension");
        }
    }
}