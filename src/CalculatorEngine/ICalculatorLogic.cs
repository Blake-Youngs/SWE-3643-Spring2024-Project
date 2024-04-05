namespace CalculatorEngine;

public interface ICalculatorLogic
{
    public double Add(double inputA, double inputB); // A + B
    public double Subtraction(double inputA, double inputB); // A - B
    public double Multiplication(double inputA, double inputB); // A * B
    public double Division(double inputA, double inputB); // A / B
    public double Equals(double inputA, double inputB); // A == B
    public double RaiseToPower(double inputA, double inputB); // A ^ B
    public double Logarithm(double inputA, double inputB); // A log B
    public double Root(double inputA, double inputB); // A root B
    
    // Single input operations
    public double Factorial(double inputA); // A !
    public double Sine(double inputA); // sin A
    public double Cosine(double inputA); // cos A
    public double Tangent(double inputA); // tan A
    public double Reciprocal(double inputA); // 1 / A
}