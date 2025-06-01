namespace Model;

public interface IRepository<T>
{
    T GetById(int id);

    int Add(T entity);

    bool Update(T entity);

    bool Delete(T entity);
}
