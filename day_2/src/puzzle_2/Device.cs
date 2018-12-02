using System;
using System.Collections.Generic;
using System.Linq;

public class Device
{
    public IEnumerable<ScanResult> Scan(IEnumerable<string> ids)
    {
        return ids.Select((id, selectIndex) =>
        {
            int leastDifferences = id.Length;
            string commonLettersAtLeastDifference = "";
            for (int loopIndex = 0; loopIndex < ids.Count(); loopIndex++)
            {
                if (selectIndex == loopIndex) { continue; }
                string otherId = ids.ElementAt(loopIndex);
                int localDifferences = id.Length;
                string localCommonLetters = "";
                for (int i = 0; i < id.Length; i++)
                {
                    if (id[i] == otherId[i])
                    {
                        localDifferences--;
                        localCommonLetters = localCommonLetters + id[i];
                    }
                }
                if (localDifferences < leastDifferences)
                {
                    leastDifferences = localDifferences;
                    commonLettersAtLeastDifference = localCommonLetters;
                }
            };
            return new ScanResult(id, leastDifferences, commonLettersAtLeastDifference);
        });
    }

    public string FindCommonLettersAtMatch(IEnumerable<ScanResult> matches)
    {
        return matches.Where(result => result.LeastDifferences == 1).First().CommonLettersAtLeastDifference;
    }
}