using System;

public class Record
{
    public DateTime Timestamp { get; private set; }
    public String Text { get; private set; }

    public Record(DateTime timestamp, string text)
    {
        Timestamp = timestamp;
        Text = text;
    }
}