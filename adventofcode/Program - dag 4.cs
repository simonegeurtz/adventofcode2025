Console.WriteLine("Hello, World!");

var input = File.ReadAllLines("input.txt");

int amountofpaper = 0;
for (var line = 0; line < input.Length; line++)
{
    int amounttoAdd = 0;

    for (var i = 0; i < input[line].Length; i++)
    {
        var amountsurrounding = 0;

        if (input[line][i] != '@')
        {
            continue;
        }

        //rij 1
        else if (line == 0)
        {
            //de meest linkste
            if (i == 0)
            {
                bool[] allsurrounding = [Onder(input, line, i), Rechtsonder(input, line, i), Rechts(input, line, i)];
                foreach (var a in allsurrounding)
                { 
                    if (a == true)
                    {
                        amountsurrounding++;
                    }
                }
               
            }
            //de meest rechtse
            else if (i == input[line].Length - 1)
            {
                bool[] allsurrounding = [Onder(input, line, i), Linksonder(input, line, i), Links(input, line, i)];
                foreach (var a in allsurrounding)
                {
                    if (a == true)
                    {
                        amountsurrounding++;
                    }
                }
            }
            //alle middelste
            else
            {
                bool[] allsurrounding = [Onder(input, line, i), Rechtsonder(input, line, i), Rechts(input, line, i), Links(input, line, i), Linksonder(input, line, i)];
                foreach (var a in allsurrounding)
                {
                    if (a == true)
                    {
                        amountsurrounding++;
                    }
                }
            }

        }


        //rij onderaan
        else if (line == input.Length - 1)
        {
            //de meest linkse
            if (i == 0)
            {
                bool[] allsurrounding = [Boven(input, line, i), Rechtsboven(input, line, i), Rechts(input, line, i)];
                foreach (var a in allsurrounding)
                {
                    if (a == true)
                    {
                        amountsurrounding++;
                    }
                }
            }

            //de meest rechtste
            else if (i == input[line].Length - 1)
            {
                bool[] allsurrounding = [Boven(input, line, i), Linksboven(input, line, i), Links(input, line, i)];
                foreach (var a in allsurrounding)
                {
                    if (a == true)
                    {
                        amountsurrounding++;
                    }
                }
            }

            //alle middelste
            else
            {
                bool[] allsurrounding = [Linksboven(input, line, i), Boven(input, line, i), Rechtsboven(input, line, i), Links(input, line, i), Rechts(input, line, i)];
                foreach (var a in allsurrounding)
                {
                    if (a == true)
                    {
                        amountsurrounding++;
                    }
                }
            }
        }


        //alle middelste rijen 
        else
        {
            //de meest linkse
            if (i == 0)
            {
                bool[] allsurrounding = [Onder(input, line, i), Boven(input, line, i), Rechtsboven(input, line, i), Rechtsonder(input, line, i), Rechts(input, line, i)];
                foreach (var a in allsurrounding)
                {
                    if (a == true)
                    {
                        amountsurrounding++;
                    }
                }
            }

            //de meest rechtse

            else if (i == input[line].Length - 1)
            {

                bool[] allsurrounding = [Onder(input, line, i), Boven(input, line, i), Linksboven(input, line, i), Linksonder(input, line, i), Links(input, line, i)];
                foreach (var a in allsurrounding)
                {
                    if (a == true)
                    {
                        amountsurrounding++;
                    }
                }
            }

            //alle middelste
            else
            {
                bool[] allsurrounding = [Onder(input, line, i), Linksboven(input, line, i), Rechtsboven(input, line, i), Links(input, line, i), Rechts(input, line, i), Linksonder(input, line, i), Rechtsonder(input, line, i), Boven(input, line, i)];
                foreach (var a in allsurrounding)
                {
                    if (a == true)
                    {
                        amountsurrounding++;
                    }
                }
            }
        }


        //if amountsurrounding < 4 dan amount of paper 1 meer
        if (amountsurrounding < 4)
        {
            amountofpaper++;
            amounttoAdd++;
            var chars = input[line].ToCharArray();
            chars[i] = '#';
            input[line] = new string(chars);
        }
    }
    if(amounttoAdd > 0)
    {
        line = -1;
    }

}

Console.WriteLine($"Number of paper: {amountofpaper}");

static bool Rechts(string[] input, int line, int index)
{
    return input[line][index+1].ToString() == "@";
}
static bool Links(string[] input, int line, int index)
{
    return input[line][index - 1].ToString() == "@";
}

static bool Linksboven(string[] input, int line, int index)
{
    return input[line -1][index - 1].ToString() == "@";
}
static bool Rechtsboven(string[] input, int line, int index)
{
    return input[line -1][index + 1].ToString() == "@";
}
static bool Rechtsonder(string[] input, int line, int index)
{
    return input[line +1][index + 1].ToString() == "@";
}
static bool Linksonder(string[] input, int line, int index)
{
    return input[line +1][index - 1].ToString() == "@";
}
static bool Onder(string[] input, int line, int index)
{
      var test=  input[line +1][index].ToString();
    return (test == "@");

}
static bool Boven(string[] input, int line, int index)
{
    return input[line -1][index].ToString() == "@";
}



