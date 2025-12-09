Console.WriteLine("Hello, World!");

var splits = 0;
var input = File.ReadAllLines("input.txt");

int startindex = input[0].IndexOf("S");
int[] oldindexes = [startindex];
int[] indexesToCount = [];

//kijk elke line of er een punt of een ^ zit op de plek van de index. 
//is er een punt op elke plek van de indexen. Dan doen we niks en gaan we de volgende regel checken.
//is het een dakje. Dan willen we splitsen.
//amount of splits gaat dan omhoog, en op de volgende regel moeten we verder met 2 nieuwe indexes.


for (int i = 1; i < input.Length; i++)
{
    var line = input[i];
    int[] newindexes = [];
    int[] splitableindexes = [];
    foreach (var index in oldindexes)
    {
        if (line[index] == '^')
        {
            splits++;
            newindexes = [.. newindexes, index - 1];
            newindexes = [.. newindexes, index + 1];
            splitableindexes = [.. splitableindexes, index -1, index+1];
        }
        else
        {
            newindexes = [.. newindexes, index];
        }
    }
    if(newindexes.Length == 0)
    {
        newindexes = oldindexes;
    }
    oldindexes = newindexes.Distinct().ToArray();
    indexesToCount = [.. indexesToCount, splitableindexes.Distinct().ToArray().Length];
    
}


Console.WriteLine($"Total splits: {splits}");
