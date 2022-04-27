namespace Solving.Model.Components;

public class Square : Component
{
    public int CoordinateX { get; }
    public int CoordinateY { get; }

    public Square(int coordinateX, int coordinateY)
    {
        CoordinateX = coordinateX;
        CoordinateY = coordinateY;
    }
    public override void PrintSelf()
    {
        foreach (var component in _components)
        {
            component.PrintSelf();
        }
    }

}