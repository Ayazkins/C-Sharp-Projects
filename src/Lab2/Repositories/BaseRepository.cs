using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class BaseRepository<T>
    where T : DetailBase
{
    private readonly Dictionary<string, T> _dictionary;

    public BaseRepository()
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
}