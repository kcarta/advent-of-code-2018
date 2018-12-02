public class ScanResult
{
    public bool HasDuplicate { get; private set; }
    public bool HasTriplicate { get; private set; }

    public ScanResult(bool hasDuplicate, bool hasTriplicate)
    {
        HasDuplicate = hasDuplicate;
        HasTriplicate = hasTriplicate;
    }
}