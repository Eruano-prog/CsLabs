using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class Repository<T>
    where T : BasePart
{
    private List<T> _database;

    public Repository()
    {
        _database = new List<T>();
    }

    public void AddPart(T part)
    {
        if (part is null) return;

        if (_database.Any(current => current.Name == part.Name))
        {
            return;
        }

        _database.Add(part);
    }

    public T GetPart(string name)
    {
        foreach (T? current in _database.Where(current => current.Name == name))
        {
            return current;
        }

        throw new InvalidOperationException();
    }

    public void Init(Collection<T> array)
    {
        if (array is null) return;

        foreach (T part in array)
        {
            _database.Add(part);
        }
    }
}