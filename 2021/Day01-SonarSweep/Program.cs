List<int> numbers = ReadInput();

int partOneSolution = LargerThanPreviousCount(numbers);
Console.WriteLine(partOneSolution);

int partTwoSolution = LargerThanPreviousWindowCount(numbers);
Console.WriteLine(partTwoSolution);

List<int> ReadInput()
{
    List<int> input = new();
    string? line;
    while ((line = Console.ReadLine()) != null)
    {
        input.Add(int.Parse(line));
    }
    return input;
}

int LargerThanPreviousCount(List<int> numbers)
{
    int count = 0;
    for (int i = 1; i < numbers.Count; i++)
    {
        if (numbers[i] > numbers[i - 1])
        {
            count++;
        }
    }
    return count;
}

int LargerThanPreviousWindowCount(List<int> numbers)
{
    int count = 0;
    int prev = numbers[0] + numbers[1] + numbers[2];
    for (int i = 3; i < numbers.Count; i++)
    {
        int curr = prev + numbers[i] - numbers[i - 3];
        if (curr > prev)
        {
            count++;
        }
        prev = curr;
    }
    return count;
}
