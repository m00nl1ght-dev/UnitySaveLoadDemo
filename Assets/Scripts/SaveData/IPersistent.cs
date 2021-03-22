public interface IPersistent<T>
{
    public T Save();
    
    public void Load(T data);
}
