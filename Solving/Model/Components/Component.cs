namespace Solving.Model.Components;

public abstract class Component
{
    protected List<Component> _components = new ();
    protected int _id = -1;
    
    public virtual bool IsEmpty()
    {
        return _components.Count == 0;
    }

    public virtual void Add(Component c)
    {
        _components.Add(c);
    }
    
    public virtual bool IsComposite()
    {
        return true;
    }

    public virtual void PrintSelf()
    {
        throw new NotImplementedException();
    }
    
    public virtual void PrintSelfId()
    {
        Console.WriteLine(_id);
    }
    
    public virtual bool DoesHaveDuplicate(Cell cell, int number)
    {
        foreach (Component component in _components)
        {
            if (component is not Cell c) continue;
            if (c.Equals(cell)) continue;
            if (c.Value == number) return true;
        }

        return false;
    }

}