using CalculatorEngine;
using Microsoft.AspNetCore.Components;

namespace CalculatorWebServerApp.Components.Pages {
    public partial class Calculator {
        private string _backColor = "#FFECD7";
        private string _fontColor = "#000000";


        private readonly CalculateModel _calculateModel = new();
        private readonly CalculatorLogic _calculatorEngine = new();

        private (bool validNumbers, double operandA) ParseSingle(string operandA) {
            if (operandA.Equals(""))
            {
                _calculateModel.Result = "Missing number(s)";
                DisplayError();
                return (false, double.NaN);
            }

            bool operandAIsValid = double.TryParse(operandA, out double resultA);

            if (!operandAIsValid)
            {
                _calculateModel.Result = "Invalid Input, Numbers Only";
                resultA = double.NaN;
                DisplayError();
            }

            DisplayAnswer();
            return (operandAIsValid, resultA);
        }

        private (bool validNumbers, double operandA, double operandB) ParseDouble(string operandA, string operandB) {
            if (operandA.Equals("") || operandB.Equals(""))
            {
                _calculateModel.Result = "Missing number(s)";
                DisplayError();
                return (false, double.NaN, double.NaN);
            }

            bool operandAIsValid = double.TryParse(operandA, out double resultA);
            bool operandBIsValid = double.TryParse(operandB, out double resultB);

            if (!operandAIsValid)
            {
                DisplayError();
                _calculateModel.Result = "Invalid Input, Numbers Only";
                resultA = double.NaN;
            }

            if (!operandBIsValid)
            {
                DisplayError();
                _calculateModel.Result = "Invalid Input, Numbers Only";
                resultB = double.NaN;
            }

            DisplayAnswer();
            return (operandAIsValid && operandBIsValid, resultA, resultB);
        }

        private void DisplayError() {
            _backColor = "#B70F0A";
            _fontColor = "#FFFFFF";
        }

        private void DisplayAnswer() {
            _backColor = "#FFECD7";
            _fontColor = "#000000";
        }

        private void Add() {
            var (isValidNumber, operandA, operandB) = ParseDouble(_calculateModel.OperandA, _calculateModel.OperandB);

            if (isValidNumber)
            {
                var result = _calculatorEngine.Addition(operandA, operandB);
                _calculateModel.Result = $"{operandA} + {operandB} =";
                _calculateModel.Output = result + "";
                DisplayAnswer();
            }
        }

        private void Subtract() {
            var (isValidNumber, operandA, operandB) = ParseDouble(_calculateModel.OperandA, _calculateModel.OperandB);

            if (isValidNumber)
            {
                var result = _calculatorEngine.Subtraction(operandA, operandB);
                _calculateModel.Result = $"{operandA} - {operandB} =";
                _calculateModel.Output = result + "";
                DisplayAnswer();
            }
        }

        private void Multiply() {
            var (isValidNumber, operandA, operandB) = ParseDouble(_calculateModel.OperandA, _calculateModel.OperandB);

            if (isValidNumber)
            {
                var result = _calculatorEngine.Multiplication(operandA, operandB);
                _calculateModel.Result = $"{operandA} * {operandB} =";
                _calculateModel.Output = result + "";
                DisplayAnswer();
            }
        }

        private void Divide() {
            var (isValidNumber, operandA, operandB) = ParseDouble(_calculateModel.OperandA, _calculateModel.OperandB);

            if (isValidNumber)
            {
                _calculateModel.Result = $"{operandA} / {operandB} =";
                if (operandB != 0)
                {
                    var result = _calculatorEngine.Division(operandA, operandB);
                    _calculateModel.Output = result + "";
                    DisplayAnswer();
                }
                else
                {
                    _calculateModel.Output = "Not a Number";
                    DisplayError();
                }
            }
        }

        private void Equal() {
            var (isValidNumber, operandA, operandB) = ParseDouble(_calculateModel.OperandA, _calculateModel.OperandB);

            if (isValidNumber)
            {
                var result = (1.0 == _calculatorEngine.Equals(operandA, operandB));
                _calculateModel.Result = $"{operandA} == {operandB} ->";
                _calculateModel.Output = result + "";
                DisplayAnswer();
            }
        }

        private void RaisePower() {
            var (isValidNumber, operandA, operandB) = ParseDouble(_calculateModel.OperandA, _calculateModel.OperandB);

            if (isValidNumber)
            {
                var result = _calculatorEngine.RaiseToPower(operandA, operandB);
                _calculateModel.Result = $"{operandA} ^ {operandB} =";
                _calculateModel.Output = result + "";
                DisplayAnswer();
            }
        }

        private void Log() {
            var (isValidNumber, operandA, operandB) = ParseDouble(_calculateModel.OperandA, _calculateModel.OperandB);

            if (isValidNumber)
            {
                if (operandA > 1 && operandB > 0)
                {
                    var result = _calculatorEngine.Logarithm(operandA, operandB);
                    _calculateModel.Result = $"log({operandA}, {operandB}) =";
                    _calculateModel.Output = result + "";
                    DisplayAnswer();
                }
                else
                {
                    _calculateModel.Output = "Invalid Input";
                    DisplayError();
                }
            }
        }

        private void Root() {
            var (isValidNumber, operandA, operandB) = ParseDouble(_calculateModel.OperandA, _calculateModel.OperandB);

            if (isValidNumber)
            {
                if (operandB != 0 && operandA > 0)
                {
                    var result = _calculatorEngine.Root(operandA, operandB);
                    _calculateModel.Result = $"{operandA} root {operandB} =";
                    _calculateModel.Output = result + "";
                    DisplayAnswer();
                }
                else
                {
                    _calculateModel.Output = "Invalid Input";
                    DisplayError();
                }
            }
        }

        private void Factorial() {
            var (isValidNumber, operandA) = ParseSingle(_calculateModel.OperandA);

            if (isValidNumber)
            {
                var result = _calculatorEngine.Factorial(operandA);
                _calculateModel.Result = $"{operandA} ! =";
                _calculateModel.Output = result + "";
                DisplayAnswer();
            }
        }

        private void Sine() {
            var (isValidNumber, operandA) = ParseSingle(_calculateModel.OperandA);

            if (isValidNumber)
            {
                var result = _calculatorEngine.Sine(operandA);
                _calculateModel.Result = $"sin({operandA}) =";
                _calculateModel.Output = result + "";
                DisplayAnswer();
            }
        }

        private void Cosine() {
            var (isValidNumber, operandA) = ParseSingle(_calculateModel.OperandA);

            if (isValidNumber)
            {
                var result = _calculatorEngine.Cosine(operandA);
                _calculateModel.Result = $"cos({operandA}) =";
                _calculateModel.Output = result + "";
                DisplayAnswer();
            }
        }

        private void Tangent() {
            var (isValidNumber, operandA) = ParseSingle(_calculateModel.OperandA);

            if (isValidNumber)
            {
                var result = _calculatorEngine.Tangent(operandA);
                _calculateModel.Result = $"tan({operandA}) =";
                _calculateModel.Output = result + "";
                DisplayAnswer();
            }
        }

        private void Reciprocal() {
            var (isValidNumber, operandA) = ParseSingle(_calculateModel.OperandA);

            if (isValidNumber)
            {
                if (operandA != 0)
                {
                    var result = _calculatorEngine.Reciprocal(operandA);
                    _calculateModel.Result = $"1 / {operandA} =";
                    _calculateModel.Output = result + "";
                    DisplayAnswer();
                }
                else
                {
                    _calculateModel.Output = "Not a Number";
                    DisplayError();
                }
            }
        }

        private void Clear() {
            DisplayAnswer();
            _calculateModel.Result = "Enter a value(s) below and select an operation.";
            _calculateModel.Output = "";
            _calculateModel.OperandA = "0";
            _calculateModel.OperandB = "0";
        }
    }
}