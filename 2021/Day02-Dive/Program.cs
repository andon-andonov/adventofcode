List<Command> commands = ReadInput();
Position pos = CalcPosition(commands);
Console.WriteLine($"Part 1: {pos.Horizontal}:{pos.Depth} => {pos.Horizontal * pos.Depth}");
Position posAim = CalcPositionAim(commands);
Console.WriteLine($"Part 2: {posAim.Horizontal}:{posAim.Depth} => {posAim.Horizontal * posAim.Depth}");

List<Command> ReadInput()
{
    List<Command> input = new();
    string? line;
    while ((line = Console.ReadLine()) != null)
    {
        input.Add(new Command(line));
    }
    return input;
}

Position CalcPosition(List<Command> commands)
{
    Position position = new Position();
    foreach (Command command in commands)
    {
        if (command.Direction == "forward")
        {
            position.Horizontal += command.Units;
        }
        if (command.Direction == "down")
        {
            position.Depth += command.Units;
        }
        if (command.Direction == "up")
        {
            position.Depth -= command.Units;
        }
    }
    return position;
}

Position CalcPositionAim(List<Command> commands)
{
    Position position = new Position();
    int aim = 0;
    foreach (Command command in commands)
    {
        if (command.Direction == "forward")
        {
            position.Horizontal += command.Units;
            position.Depth += (aim * command.Units);
        }
        if (command.Direction == "down")
        {
            aim += command.Units;
        }
        if (command.Direction == "up")
        {
            aim -= command.Units;
        }
    }
    return position;
}

class Command
{
    public string Direction { get; set; }
    public int Units { get; set; }

    public Command(string s)
    {
        string[] tokens = s.Split(' ');
        Direction = tokens[0];
        Units = int.Parse(tokens[1]);
    }
}

class Position
{
    public int Horizontal { get; set; }

    public int Depth { get; set; }
}
