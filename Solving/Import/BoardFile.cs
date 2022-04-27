namespace Solving.Import;

public class BoardFile
{
    public string Data { get; }
    public string Extension { get; }

    public BoardFile(string data, string extension)
    {
        Data = data;
        Extension = extension;
    }
}