using System;
using System.Collections.Generic;

public class Guard
{
    public List<int> SleepMinutes { get; } = new List<int>();
    public string Id { get; }

    public Guard(string id)
    {
        Id = id;
    }

}