public class ScanResult
{
    public string SourceId { get; private set; }
    public int LeastDifferences { get; private set; }
    public string CommonLettersAtLeastDifference { get; private set; }

    public ScanResult(string sourceId, int leastDifferences, string commonLettersAtLeastDifference)
    {
        SourceId = sourceId;
        LeastDifferences = leastDifferences;
        CommonLettersAtLeastDifference = commonLettersAtLeastDifference;
    }

    public override bool Equals(object obj)
    {
        return obj is ScanResult result
            && result.SourceId == this.SourceId
            && result.LeastDifferences == this.LeastDifferences
            && result.CommonLettersAtLeastDifference == this.CommonLettersAtLeastDifference;
    }

    public override int GetHashCode()
    {
        return (SourceId + LeastDifferences + CommonLettersAtLeastDifference).GetHashCode(); // Going for laziest version of this possible
    }
}