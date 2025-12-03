Console.WriteLine("Hello, World!");

var input = File.ReadAllLines("input.txt");

var index = 50;
var amountofzero = 0;

foreach (var line in input)
{
    var rotations = int.Parse(line[1..]);
    amountofzero += rotations / 100;
    rotations %= 100;
    if (line.StartsWith('L')) rotations *= -1;

    index += rotations;
    if (index < 0)
    {
        if (index != rotations) amountofzero++;
        index += 100;
    }
    else if (index >= 100)
    {
        if (index > 100) amountofzero++;
        index -= 100;
    }

    if (index == 0) amountofzero++;
}

Console.WriteLine($"Number of zeros: {amountofzero}");