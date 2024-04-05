using NUnit.Framework.Constraints;
using System;

namespace CalculatorEngineUnitTests {
    public partial class CalculatorEngineUnitTests {
        // Trigonometric Functions

        [Test]
        public void Sine_WithValidDegree_ReturnsCorrectResult() {
            // preq-UNIT-TEST-16
            var inputA = 1;
            var expectedResult = 0.841470984;

            var actualResult = _calculatorEngine.Sine(inputA);

            Assert.That(actualResult, Is.EqualTo(expectedResult).Within(tolerance));
        }

        [Test]
        public void Cosine_WithValidDegree_ReturnCorrectResult() {
            // preq-UNIT-TEST-17
            var inputA = 1;
            var expectedResult = 0.54030230;

            var actualResult = _calculatorEngine.Cosine(inputA);

            Assert.That(actualResult, Is.EqualTo(expectedResult).Within(tolerance));
        }

        [Test]
        public void Tangent_WithValidDegree_ReturnCorrectResult() {
            // preq-UNIT-TEST-18
            var inputA = 1;
            var expectedResult = 1.55740772;

            var actualResult = _calculatorEngine.Tangent(inputA);

            Assert.That(actualResult, Is.EqualTo(expectedResult).Within(tolerance));
        }
    }
}