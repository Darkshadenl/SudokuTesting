namespace Solving.Config.JSONModel;

public class BoardInterpreterRoot
{
    public Boardinterpreter[] boardinterpreter { get; set; }
}

public class Boardinterpreter
{
    public string match { get; set; }
    public string library { get; set; }
    public string _namespace { get; set; }
}
