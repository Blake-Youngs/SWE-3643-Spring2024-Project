using NUnit.Framework.Constraints;
using System;

// ReSharper disable ConvertToConstant.Local

namespace CalculatorEngineUnitTests {
    public partial class CalculatorEngineUnitTests {
        private CalculatorEngine.CalculatorLogic _calculatorEngine;
        private double tolerance = 0.00000001;

        [SetUp]
        public void Setup() {
            _calculatorEngine = new CalculatorEngine.CalculatorLogic();
        }

        [TearDown]
        public void TearDown() {
            _calculatorEngine = null;
        }

        [Test]
        public void Addition_AddTwoNumbers_ReturnsCorrectSum() {
            // preq-UNIT-TEST-2
            var inputA = 5.5;
            var inputB = -3.15;
            var expectedResult = 2.35;

            var actualResult = _calculatorEngine.Addition(inputA, inputB);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Subtraction_SubtractTwoNumbers_ReturnCorrectDifference() {
            // preq-UNIT-TEST-3
            var inputA = 27.93;
            var inputB = 4;
            var expectedResult = 23.93;

            var actualResult = _calculatorEngine.Subtraction(inputA, inputB);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Multiplication_MultiplyTwoNumbers_ReturnCorrectProduct() {
            // preq-UNIT-TEST-4
            var inputA = 5;
            var inputB = 7.1;
            var expectedResult = 35.5;

            var actualResult = _calculatorEngine.Multiplication(inputA, inputB);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Division_DivideTwoNumbers_ReturnCorrectQuotient() {
            // preq-UNIT-TEST-5
            var inputA = 3.0;
            var inputB = 9.0;
            var expectedResult = 0.33333333;

            var actualResult = _calculatorEngine.Division(inputA, inputB);

            Assert.That(actualResult, Is.EqualTo(expectedResult).Within(tolerance));
        }

        [Test]
        public void Division_DivideByZero_ThrowsDivideByZeroException() {
            // preq-UNIT-TEST-6
            var inputA = 11.2;
            var inputB = 0;

            Assert.Throws<DivideByZeroException>(() => { _calculatorEngine.Division(inputA, inputB); });
        }
    }
}