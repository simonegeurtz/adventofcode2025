Console.WriteLine("Hello, World!");

var input = File.ReadAllText("testdata.txt")
    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

long invalidids = 0;

foreach (var line in input)
{
    var parts = line.Split('-', StringSplitOptions.TrimEntries);
    if (parts.Length == 2)
    {
        for (long i = long.Parse(parts[0]); i <= long.Parse(parts[1]); i++)
        {
            var stringI = i.ToString();
            for (int partsCount = 2; partsCount <= stringI.Length; partsCount++)
            {
                if (stringI.Length % partsCount == 0)
                {
                    int partLength = stringI.Length / partsCount;
                    var part = stringI.Substring(0, partLength);
                    bool allEqual = true;
                    for (int p = 1; p < partsCount; p++)
                    {
                        var nextPart = stringI.Substring(p * partLength, partLength);
                        if (nextPart != part)
                        {
                            allEqual = false;
                            break;
                        }
                    }
                    if (allEqual)
                    {
                        invalidids += i;
                        break;
                    }
                }
            }
        }
    }
    else
    {
        Console.WriteLine($"Invalid range: {line}");
    }
}

Console.WriteLine($"Number of invalidids: {invalidids}");