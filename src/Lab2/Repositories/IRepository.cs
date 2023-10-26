namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public interface IRepository<T>
    where T : DetailBase
{
    void Add(T detail);
    T GetDetail(string name);
    void Delete(string name);
    void Update(string name, T detail);
}