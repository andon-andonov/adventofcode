List<string> input = ReadInput();
Console.WriteLine(CalcPowerConsumption(input));
Console.WriteLine(CalcLifeSupportRating(input));

List<string> ReadInput()
{
    List<string> input = new();
    string? line;
    while ((line = Console.ReadLine()) != null)
    {
        input.Add(line);
    }
    return input;
}

int CalcPowerConsumption(List<string> input)
{
    int[] rates = new int[input[0].Length];
    for (int i = 0; i < input.Count(); i++)
    {
        for (int j = 0; j < input[i].Length; j++)
        {
            if (input[i][j] == '1')
            {
                rates[rates.Length - j - 1] += 1;
            }
            else
            {
                rates[rates.Length - j - 1] -= 1;
            }
        }
    }

    int gamaRate = 0;
    int epsRate = 0;

    for (int i = 0; i < rates.Length; i++)
    {
        if (rates[i] > 0)
        {
            gamaRate |= 1 << i;
        }
        else
        {
            epsRate |= 1 << i;
        }
    }

    int powerConsumption = gamaRate * epsRate;

    return powerConsumption;
}

long CalcLifeSupportRating(List<string> input)
{
    int oxigenGeneratorRating = CalcOxigenGeneratorRating(input);
    int co2ScubberRating = CalcCO2ScubberRating(input);
    Console.WriteLine(oxigenGeneratorRating);
    Console.WriteLine(co2ScubberRating);
    return oxigenGeneratorRating * co2ScubberRating;
}

int CalcOxigenGeneratorRating(List<string> input)
{
    HashSet<int> discarded = new();
    for (int i = 0; i < input[0].Length; i++)
    {
        char mostCommon = CalcMostCommonBit(input, discarded, i);
        for (int j = 0; j < input.Count(); j++)
        {
            if (discarded.Contains(j))
            {
                continue;
            }
            if (discarded.Count() == input.Count() - 1)
            {
                return Convert.ToInt32(input[j], 2);
            }
            if (input[j][i] != mostCommon)
            {
                discarded.Add(j);
            }
        }
        
    }

    for (int k = 0; k < input.Count(); k++)
    {
        if (!discarded.Contains(k))
        {
            return Convert.ToInt32(input[k], 2);
        }
       
    }

    return -1;
}

int CalcCO2ScubberRating(List<string> input)
{
    HashSet<int> discarded = new();
    for (int i = 0; i < input[0].Length; i++)
    {
        char mostCommon = CalcMostCommonBit(input, discarded, i);
        for (int j = 0; j < input.Count(); j++)
        {
            if (discarded.Contains(j))
            {
                continue;
            }
            if (discarded.Count() == input.Count() - 1)
            {
                return Convert.ToInt32(input[j], 2);
            }
            if (input[j][i] == mostCommon)
            {
                discarded.Add(j);
            }
        }
    }
    for (int k = 0; k < input.Count(); k++)
    {
        if (!discarded.Contains(k))
        {
            return Convert.ToInt32(input[k], 2);
        }
       
    }
    return -1;
}

char CalcMostCommonBit(List<string> input, HashSet<int> discarded, int index)
{
    int rate = 0;
    for (int i = 0; i < input.Count(); i++)
    {
        if (discarded.Contains(i))
        {
            continue;
        }
        if (input[i][index] == '1')
        {
            rate += 1;
        }
        else
        {
            rate -= 1;
        }
    }
    if (rate >=0)
    {
        return '1';
    }
    return '0';
}