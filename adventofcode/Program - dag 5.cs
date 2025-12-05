Console.WriteLine("Hello, World!");

var input = File.ReadAllLines("input.txt").Select(x => x.Trim()).ToArray();

// Split the input into two parts: before and after the empty line
int emptyLineIndex = Array.IndexOf(input, "");
string[] freshIngredients = [.. input.Take(emptyLineIndex)];
string[] availableIngredients = [.. input.Skip(emptyLineIndex + 1)];
var freshIngredientsIds = new List<(long, long)>();
long amountOfAvailableIngredients = 0;
var distinctRanges = new List<(long, long)>();

var amountOfFreshIngredients = 0;

foreach (var ingredientrange in freshIngredients)
{
    var parts = ingredientrange.Split('-', StringSplitOptions.TrimEntries);
    var low = long.Parse(parts[0]);
    var high = long.Parse(parts[1]);
    freshIngredientsIds.Add((low, high));
}


//distinct ranges maken
foreach(var range in freshIngredientsIds.OrderBy(r => r.Item1))
{
    if (distinctRanges.Count == 0)
    {
        distinctRanges.Add(range);
    }
    else
    {
        var lastRange = distinctRanges.Last();
        if (range.Item1 <= lastRange.Item2 + 1)
        {
            var highestend = Math.Max(lastRange.Item2, range.Item2);
            distinctRanges[distinctRanges.Count - 1] = (lastRange.Item1, highestend);
        }
        else
        {
            distinctRanges.Add(range);
        }
    }
}

//dit moet in de distinct ranges komen
foreach (var range in distinctRanges)
{
    var amount = range.Item2 - range.Item1 + 1;
    amountOfAvailableIngredients += amount;
}

foreach (var available in availableIngredients)
{
    long availableLong = long.Parse(available);
    if (freshIngredientsIds.Any(range => range.Item1 <= availableLong && availableLong <= range.Item2))
    {
        amountOfFreshIngredients++;
    }
}

Console.WriteLine($"Number of fresh ingredients: {amountOfFreshIngredients}");
Console.WriteLine($"Total amount of available ingredients: {amountOfAvailableIngredients}");