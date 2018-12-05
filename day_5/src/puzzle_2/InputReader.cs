using System.IO;

public class InputReader
{
    public string[] ReadIds(string filePath)
    {
        return File.ReadAllLines(filePath);
    }

}