using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Device
{
    public List<Unit> Parse(string input)
    {
        // TRIM!!! Aghhh
        return input.Trim().Select(character => new Unit(character)).ToList();
    }

    public List<Unit> Process(List<Unit> units)
    {
        // Going waaaay imperative because my clever attempts all seem off...
        int index = 0;
        while (index < units.Count)
        {
            if (units.ElementAtOrDefault(index)?.ReactsWith(units.ElementAtOrDefault(index + 1)) ?? false)
            {
                units.RemoveRange(index, 2);
                index--;
            }
            else if (units.ElementAtOrDefault(index)?.ReactsWith(units.ElementAtOrDefault(index - 1)) ?? false)
            {
                units.RemoveRange(index - 1, 2);
                index--;
            }
            else
            {
                index += 1;
            }
        }
        return units;
    }
}