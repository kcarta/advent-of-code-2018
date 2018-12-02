using System;
using System.Collections.Generic;
using System.Linq;

public class Device
{
    public IEnumerable<ScanResult> Scan(IEnumerable<string> ids)
    {
        return ids.Select(id =>
        {
            bool hasDuplicates = CheckForCount(id, 2);
            bool hasTriplicates = CheckForCount(id, 3);
            return new ScanResult(hasDuplicates, hasTriplicates);
        });
    }

    private bool CheckForCount(string id, int count)
    {
        return id.GroupBy(letter => letter)
                 .Any(letterGrouping => letterGrouping.Count() == count);
    }

    public int CalculateChecksum(IEnumerable<ScanResult> scanResults)
    {
        int duplicateCount = scanResults.Where(result => result.HasDuplicate).Count();
        int triplicateCount = scanResults.Where(result => result.HasTriplicate).Count();
        return duplicateCount * triplicateCount;
    }
}