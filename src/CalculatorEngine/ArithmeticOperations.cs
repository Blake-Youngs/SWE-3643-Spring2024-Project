namespace CalculatorEngine;

public partial class CalculatorLogic(int precision = 8) : ICalculatorLogic
{
    // Level of precision when comparing two floating point numbers
    private readonly int _precision = precision;
     
    public double Addition(double inputA, double inputB)
    {
        return inputA + inputB;
    }

    public double Subtraction(double inputA, double inputB)
    {
        return inputA - inputB;
    }

    public double Multiplication(double inputA, double inputB)
    {
        return inputA * inputB;
    }

    public double Division(double inputA, double inputB)
    {
        if (inputB == 0) throw new DivideByZeroException();

        return inputA / inputB;
    }

    public double RaiseToPower(double inputA, double inputB)
    {
        return Math.Pow(inputA, inputB);
    }

    public double Logarithm(double inputA, double inputB)
    {
        if (inputA <= 1) throw new ArgumentException("Input A must be greater than 1");
        if (inputB <= 0) throw new Exception("Input B must be greater than 0");

        return Math.Log(inputA, inputB);
    }

    public double Root(double inputA, double inputB)
    {
        if (inputB == 0) throw new ArgumentException("Input B cannot be 0");

        return Math.Pow(inputA, 1 / inputB);
    }

    public double Factorial(double inputA)
    {
        double result = 1;
        for (var i = 0; i < inputA; i++)
        {
            result *= i;
        }

        return result;
    }
}