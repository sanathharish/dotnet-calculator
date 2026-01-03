class Menu
{
    public Operation GetUserChoice()
    {
        Console.WriteLine();
        Console.WriteLine("Choose operation:");
        Console.WriteLine("1. Add");
        Console.WriteLine("2. Subtract");
        Console.WriteLine("3. Multiply");
        Console.WriteLine("4. Divide");
        Console.WriteLine("5. Exit");

        Console.Write("Choice: ");
        string? input = Console.ReadLine();

        if (Enum.TryParse(input, out Operation operation))
        {
            return operation;
        }

        return 0;
    }
}
