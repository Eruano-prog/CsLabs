using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Abstract;
using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Entities;

public class Expedition
{
    private List<ITrack> track_list;

    PassTrackResult Complete()
    {
        foreach (ITrack track in track_list)
        {
            
        }
    }
}