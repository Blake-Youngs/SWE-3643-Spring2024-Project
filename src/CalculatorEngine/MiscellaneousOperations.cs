namespace CalculatorEngine;

public partial class CalculatorLogic
{
    public bool Equals(double inputA, double inputB)
    {
        var tolerance = Math.Pow(10, -_precision);
        var absoluteValueOfDiff = Math.Abs(inputA - inputB);
        var isWithinTolerance = absoluteValueOfDiff <= tolerance;
        return isWithinTolerance;
    }
    
    public double Reciprocal(double inputA)
    {
        if (inputA == 0) throw new ArgumentException("Input A cannot be 0");

        return 1 / inputA;
    }
}