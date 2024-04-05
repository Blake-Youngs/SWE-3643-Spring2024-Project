using NUnit.Framework.Constraints;
using System;

namespace CalculatorEngineUnitTests {
    public partial class CalculatorEngineUnitTests {
        // Miscellaneous Functions

        // Returns the equivalence of to doubles to a precision of 8
        [TestCase(0.33333333, 0.33333333, 1)] // 1 is True | 0 is false
        [TestCase(0.333333339, 0.333333330, 1)]
        [TestCase(0.3, 0.2, 0)]
        public void Equals_CompareTwoNumbers_ReturnsTrue(double inputA, double inputB, double expectedResult) {
            // preq-UNIT-TEST-7
            var actualResult = _calculatorEngine.Equals(inputA, inputB);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void RaiseToPower_WithValidInput_ReturnsCorrectResult() {
            // preq-UNIT-TEST-8
            var inputA = 2;
            var inputB = 3;
            var expectedResult = 8;

            var actualResult = _calculatorEngine.RaiseToPower(inputA, inputB);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Logarithm_WithValidInput_ReturnsCorrectResult() {
            // preq-UNIT-TEST-9
            var inputA = 8;
            var inputB = 2;
            var expectedResult = 3;

            var actualResult = _calculatorEngine.Logarithm(inputA, inputB);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Logarithm_BaseLessThanOne_ThrowsArgumentException() {
            // preq-UNIT-TEST-10
            var inputA = 1;
            var inputB = 12;

            Assert.Throws<ArgumentException>(() => { _calculatorEngine.Logarithm(inputA, inputB); });
        }

        [Test]
        public void Logarithm_WithZeroArgument_ThrowsArgumentException() {
            // preq-UNIT-TEST-11
            var inputA = 8;
            var inputB = 0;

            Assert.Throws<ArgumentException>(() => { _calculatorEngine.Logarithm(inputA, inputB); });
        }

        [Test]
        public void Root_WithValidInput_ReturnsCorrectRoot() {
            // preq-UNIT-TEST-12
            var inputA = 8;
            var inputB = 3;
            var expectedResult = 2;

            var actualResult = _calculatorEngine.Root(inputA, inputB);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Root_WithZeroExponent_ThrowsArgumentException() {
            // preq-UNIT-TEST-13
            var inputA = 8;
            var inputB = 0;

            Assert.Throws<DivideByZeroException>(() => { _calculatorEngine.Root(inputA, inputB); });
        }

        [Test]
        public void Factorial_WithNumber_ReturnsCorrectResult() {
            // preq-UNIT-TEST-14
            var inputA = 5;
            var expectedResult = 120;

            var actualResult = _calculatorEngine.Factorial(inputA);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Factorial_WithZero_ReturnsOne() {
            // preq-UNIT-TEST-15
            var inputA = 0;
            var expectedResult = 1;

            var actualResult = _calculatorEngine.Factorial(inputA);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Reciprocal_WithValidNumber_ReturnCorrectResult() {
            // preq-UNIT-TEST-19
            var inputA = 10;
            var expectedResult = 0.1;

            var actualResult = _calculatorEngine.Reciprocal(inputA);

            Assert.That(actualResult, Is.EqualTo(expectedResult).Within(tolerance));
        }

        [Test]
        public void Reciprocal_WithZero_ThrowsDivideByZeroException() {
            // preq-UNIT-TEST-20
            var inputA = 0;

            Assert.Throws<DivideByZeroException>(() => { _calculatorEngine.Reciprocal(inputA); });
        }
    }
}