using System.IO;

public class InputReader
{
    public string ReadUnits(string filePath)
    {
        return File.ReadAllText(filePath);
    }

}