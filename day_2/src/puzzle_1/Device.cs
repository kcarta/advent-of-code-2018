using System.Collections.Generic;
using System.Linq;

public class Device
{
    public IEnumerable<ScanResult> Scan(IEnumerable<string> ids)
    {
        return ids.Select(id => new ScanResult());
    }

}