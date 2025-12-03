Console.WriteLine("Hello, World!");

var input = File.ReadAllLines("testdata.txt");

long joltage = 0;

foreach (var line in input)
{
    var joltagestring = "";

    var numbers = line.Select(c => long.Parse(c.ToString())).ToList();

    var result = new List<long>();
    int start = 0;
    for (int i = 0; i < 12; i++)
    {
        int maxReach = numbers.Count - (11 - i);
        long biggestnr = numbers.GetRange(start, maxReach - start).Max();
        int biggestindex = numbers.IndexOf(biggestnr, start);

        result.Add(biggestnr);
        joltagestring += biggestnr.ToString();
        start = biggestindex + 1;
    }
    var joltagelong = long.Parse(joltagestring);
    joltage += joltagelong;
}

Console.WriteLine($"Number of joltage: {joltage}");