class Program
{
    static void Main()
    {
        ICalculator calculator = new Calculator();
        Menu menu = new Menu();
        bool running = true;

        while (running)
        {
            Operation operation = menu.GetUserChoice();

            if (operation == Operation.Exit)
            {
                running = false;
                continue;
            }

            if (operation == 0)
            {
                Console.WriteLine("Invalid choice.");
                continue;
            }

            int a = ReadNumber("Enter first number: ");
            int b = ReadNumber("Enter second number: ");

            try
            {
                Console.WriteLine(operation switch
                {
                    Operation.Add => calculator.Add(a, b),
                    Operation.Subtract => calculator.Subtract(a, b),
                    Operation.Multiply => calculator.Multiply(a, b),
                    Operation.Divide => calculator.Divide(a, b),
                    _ => "Unknown operation"
                });
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero.");
            }
        }
    }

    static int ReadNumber(string message)
    {
        Console.WriteLine(message);
        string? input = Console.ReadLine();
        int number;

        while (!int.TryParse(input, out number))
        {
            Console.WriteLine("Invalid number. Try again:");
            input = Console.ReadLine();
        }

        return number;
    }
}
