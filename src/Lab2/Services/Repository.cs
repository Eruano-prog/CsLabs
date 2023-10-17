using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class Repository
{
    private readonly Dictionary<string, List<BasePart>> _database;

    public Repository()
    {
        _database = new Dictionary<string, List<BasePart>>();
    }

    public void AddPart(BasePart part)
    {
        if (part is null) return;
        List<BasePart> array = _database[part.GetPart().ToString()];

        if (array.Any(current => current.Name == part.Name))
        {
            return;
        }

        array.Add(part);
    }

    public BasePart GetPart(Parts part, string name)
    {
        List<BasePart> array = _database[part.ToString()];

        foreach (BasePart? current in array.Where(current => current.Name == name))
        {
            return current;
        }

        throw new InvalidOperationException();
    }
}