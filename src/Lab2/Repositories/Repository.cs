using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class Repository<T> : IRepository<T>
    where T : DetailBase
{
    private readonly Dictionary<string, T> _dictionary;

    public Repository()
    {
        _dictionary = new Dictionary<string, T>();
    }

    public void Add(T detail)
    {
        if (detail == null)
        {
            throw new ArgumentNullException(nameof(detail));
        }

        if (detail.Name == null)
        {
            throw new ArgumentNullException(nameof(detail));
        }

        _dictionary.Add(detail.Name, detail);
    }

    public T GetDetail(string name)
    {
        return _dictionary[name];
    }

    public void Delete(string name)
    {
        _dictionary.Remove(name);
    }

    public void Update(string name, T detail)
    {
        if (_dictionary.ContainsKey(name))
        {
            _dictionary[name] = detail;
            return;
        }

        throw new ArgumentException("No such element", nameof(name));
    }
}