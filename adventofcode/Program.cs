Console.WriteLine("Hello, World!");

var input = File.ReadAllLines("testdata.txt");

int amountofpaper = 0;
for (var line = 0; line < input.Length -1; line++)
{
    for(var i  = 0; i < input[line].Length -1; i++)
    {
        if (input[line][i].ToString() != "@")
        {
            break ;
        }
        int amountsurrounding = 0;

        var lineBoven = line - 1;
        var lineOnder = line + 1;
        var indexLinks = i - 1;
        var indexRechts = i + 1;

        
        if (line != 0)
        {
            //boven
            if (input[lineBoven][i].ToString() == "@")
            {
                amountsurrounding++;
            }
           

            if (i != 0)
            {
                //linksboven
                if (input[lineBoven][indexLinks].ToString() == "@")
                {
                    amountsurrounding++;
                }
            }

            if (i < input[line].Length -1) {
                //rechtsboven
                if (input[lineBoven][indexRechts].ToString() == "@")
                {
                    amountsurrounding++;
                }
            }
        }
        
        if (line != input.Length -1 ) {

            if(i != input[line].Length - 1)
            {
                //rechtsonder
                if (input[lineOnder][indexRechts].ToString() == "@")
                {
                    amountsurrounding++;
                }
            }

            if (i != 0)
            {
                //linksonder
                if (input[lineOnder][indexLinks].ToString() == "@")
                {
                    amountsurrounding++;
                }
            }
                   
            //onder
            if (input[lineOnder][i].ToString() == "@")
            {
                amountsurrounding++;
            }
        }

        if (i != 0) {
            //linksnaast
            if (input[line][indexLinks].ToString() == "@")
            {
                amountsurrounding++;
            }
        }

        if (i != input[line].Length -1 )
        {
            //rechtsnaast
            if (input[line][indexRechts].ToString() == "@")
            {
                amountsurrounding++;
            }
        }

        //if amountsurrounding < 4 dan amount of paper 1 meer, en als het ook een @ is
        if (amountsurrounding < 4 )
        {
            amountofpaper++;
        }
    }
   
}

Console.WriteLine($"Number of paper: {amountofpaper}");