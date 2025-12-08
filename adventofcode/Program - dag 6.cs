Console.WriteLine("Hello, World!");

var input = File.ReadAllLines("input.txt");
long answer = 0;
var previousEmptyLineIndex = 0;
var amountofrows = input[0].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;

var sumnumbers = new string[input.Length -1];

//loop hier zo vaak doorheen als dat er getallen staan in de eerste rij.
for(var a = 0; a < amountofrows; a++)
{
    var emptyindex = 0;

    //welke lengte moet ik hier door
    for (var i = 0; i < input.Length -1; i++)
    {
        //kijk hoelang het eerste getal is
        foreach (var lines in input)
        {
            //gooi achter elke line een lege '' 
            var goodline = lines.Substring(previousEmptyLineIndex);
             goodline = goodline + ' ';
            var nr = false;
            foreach (var letter in goodline)
            {
                if(letter != ' ')
                {
                    nr = true;
                }
                else if (nr == false)
                {
                    //replace space with 0
                    var goodlineChars = goodline.ToCharArray();
                    goodlineChars[goodline.IndexOf(letter)] = '0';
                    goodline = new string(goodlineChars);
                }
                else
                {

                }
            }
            int emptyLineIndex = goodline.IndexOf(" ");
            if (emptyLineIndex > emptyindex)
            {
                emptyindex = emptyLineIndex;
                emptyLineIndex = 0;
            }
        }
        //pak van index 0 tm emptylineindex-1 de string van elke line inclusief de lege waarden 
        var line = input[i];
        var numberstring = line.Substring(previousEmptyLineIndex, emptyindex).Replace(" ", "0");
        sumnumbers[i] = numberstring;
    }
    previousEmptyLineIndex += (emptyindex + 1);

    var correctSumNumbers = new long[sumnumbers.Max().ToString().Length];


    //pak de goede waarden uit de sumnumbers
    //sumnumbers heeft nu incl 0's
    var length = sumnumbers[0].Length;

    for (var l = 0; l<length; l++)
    {
        var nrtoAdd = "";
        //haal uit elke string van sumnumbers het l-de karakter
        for (var k = 0; k < sumnumbers.Length; k++)
        {
            nrtoAdd += sumnumbers[k][l];
        }
        var correctnrtoAdd = nrtoAdd.Trim('0');
       
        try
        {
        correctSumNumbers[l] = long.Parse(correctnrtoAdd);

        }
        catch
        {
            continue;
        }
    }


    //reken per kolom de som uit
    long sum = 0;
    for (int k = 0; k < correctSumNumbers.Length; k++)
    { 
        var test = input[input.Length - 1].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var operator2 = test[a].ToString();
      
        if (sum == 0)
        {
            sum = correctSumNumbers[k];
        }
        else if (operator2 == "+")
        {
            sum = sum + correctSumNumbers[k];
        }
        else if (operator2 == "*")
        {
            sum = sum * correctSumNumbers[k];
        }
    }
    answer += sum;
}

Console.WriteLine($"Total amount: {answer}");