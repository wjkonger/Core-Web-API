namespace Model;

public interface IService<T> 
{
    T RetrieveById(int id);

    int Create(T entity);

    bool Modify(T entity);

    bool Remove(T entity);
}
