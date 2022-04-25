namespace Solving.Model;

public abstract class Component
{
    public virtual bool isEmpty()
    {
        throw new NotImplementedException();
    }

    public virtual void add(Component c)
    {
        throw new NotImplementedException();
    }
    
    public virtual bool IsComposite()
    {
        return true;
    }
    
}