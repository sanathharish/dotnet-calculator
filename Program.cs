using System;

class Program
{
    static void Main()
    {
        ICalculator calc = new Calculator();
        Menu menu = new Menu();

        bool running = true;

        while (running)
        {
            Operation operation = menu.GetUserChoice();

            if (operation == 0)
            {
                Console.WriteLine("Invalid choice.");
                continue;
            }

            if (operation == Operation.Exit)
            {
                running = false;
                continue;
            }

            try
            {
                calc.ReadInputs();

                Console.WriteLine(operation switch
                {
                    Operation.Add => calc.Add(),
                    Operation.Subtract => calc.Subtract(),
                    Operation.Multiply => calc.Multiply(),
                    Operation.Divide => calc.Divide(),
                    _ => "Unknown operation"
                });
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero.");
            }
        }
    }

}

interface ICalculator
{
    void ReadInputs();
    int Add();
    int Subtract();
    int Multiply();
    int Divide();
}

enum Operation
{
    Add = 1,
    Subtract = 2,
    Multiply = 3,
    Divide = 4,
    Exit = 5
}

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

        return 0; // invalid
    }
}


class Calculator : ICalculator
{
    private int _a;
    private int _b;

    public void ReadInputs()
    {
        _a = ReadNumber("Enter first number: ");
        _b = ReadNumber("Enter second number: ");
    }

    public int Add() => _a + _b;
    public int Subtract() => _a - _b;
    public int Multiply() => _a * _b;

    public int Divide()
    {
        if (_b == 0)
            throw new InvalidOperationException("Cannot divide by zero");

        return _a / _b;
    }

    private int ReadNumber(string message)
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
