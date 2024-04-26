namespace CalculatorEngine;

// CalculatorLogic covers all calculation logic related requirements.
public class CalculatorLogic(int precision = 8) : ICalculatorLogic {
    // Level of precision when comparing two floating point numbers.
    private readonly int _precision = precision;

    public double Addition(double inputA, double inputB) {
        // Preq-ENGINE-3
        return inputA + inputB;
    }

    public double Subtraction(double inputA, double inputB) {
        // Preq-ENGINE-4
        return inputA - inputB;
    }

    public double Multiplication(double inputA, double inputB) {
        // Preq-ENGINE-5
        return inputA * inputB;
    }

    public double Division(double inputA, double inputB) {
        // Preq-ENGINE-7
        if (inputB == 0)
            throw new DivideByZeroException(); // Can't divide by 0.

        return inputA / inputB;
    }

    public double Equals(double inputA, double inputB) {
        // Preq-ENGINE-8
        // Compares both floating point numbers to a level of precision.
        var tolerance = Math.Pow(10, -_precision);
        var absoluteValueOfDiff = Math.Abs(inputA - inputB);
        var isWithinTolerance = absoluteValueOfDiff <= tolerance;
        return isWithinTolerance ? 1 : 0;
    }

    public double RaiseToPower(double inputA, double inputB) {
        // Preq-ENGINE-9
        return Math.Pow(inputA, inputB);
    }

    public double Logarithm(double inputA, double inputB) {
        // Preq-ENGINE-10
        if (inputA <= 1)
            throw new ArgumentException(inputA + " must be greater than 1.");
        if (inputB <= 0)
            throw new ArgumentException(inputB + " must be greater than 0.");

        return Math.Log(inputA, inputB);
    }

    public double Root(double inputA, double inputB) {
        // Preq-ENGINE-11
        if (inputA <= 0)
            throw new ArgumentException(inputA + " must be > 0.");
        if (inputB == 0)
            throw new AggregateException(inputB + " cannot be 0.");

        return Math.Pow(inputA, 1 / inputB);
    }

    public double Factorial(double inputA) {
        // Preq-ENGINE-12
        double result = 1;
        for (var i = 1; i <= inputA; i++) result *= i;

        return result;
    }

    public double Sine(double inputA) {
        return Math.Sin(inputA);
    }

    public double Cosine(double inputA) {
        return Math.Cos(inputA);
    }

    public double Tangent(double inputA) {
        return Math.Tan(inputA);
    }

    public double Reciprocal(double inputA) {
        // Preq-ENGINE-16
        if (inputA == 0)
            throw new DivideByZeroException(inputA + " is cannot be used.");

        return 1 / inputA;
    }
}