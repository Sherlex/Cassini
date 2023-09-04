using Microsoft.VisualStudio.TestTools.UnitTesting;
using lr3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr3.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void IsDataOkTest()
        {
            // Arrange
            var data = new Form1();
            bool expected = true;

            // Act
            bool actual = data.IsDataOk(1, 3, 0.1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IncorrectStep()
        {
            // Arrange
            var data = new Form1();
            bool expected = false;

            // Act
            bool actual = data.IsDataOk(1, 3, 50.1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IncorrectLimits()
        {
            // Arrange
            var data = new Form1();
            bool expected = false;

            // Act
            bool actual = data.IsDataOk(50, 3, 0.1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ZeroStep()
        {
            // Arrange
            var data = new Form1();
            bool expected = false;

            // Act
            bool actual = data.IsDataOk(1, 3, 0);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass()]
    public class FunctionsTest
    {
        [TestMethod()]
        public void PositiveFunctionsAEqualX()
        {
            // Arrange
            var expected = (0);

            // Act
            var actual = Functions.PositiveFunction(10, 10, 0);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PositiveFunctionsAAbsEqualXAbs()
        {
            // Arrange
            var expected = (0);

            // Act
            var actual = Functions.PositiveFunction(-10, 10, 0);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PositiveFunctionTestAllZero()
        {
            // Arrange
            var expected = (0);

            // Act
            var actual = Functions.PositiveFunction(0, 0, 0);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PositiveFunctionTest()
        {
            // Arrange
            var expected = 8.631;

            // Act
            var actual = Math.Round(Functions.PositiveFunction(5, 10, 1), 3);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NegativeFunctionTestAEqualX()
        {
            // Arrange
            var expected = (0);

            // Act
            var actual = Functions.NegativeFunction(10, 10, 0);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NegFunctionTestAAbsEqualXAbs()
        {
            /// Arrange
            var expected = (0);

            // Act
            var actual = Functions.NegativeFunction(-10, 10, 0);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NegFunctionTestAllZero()
        {
            // Arrange
            var expected = (0);

            // Act
            var actual = Functions.NegativeFunction(0, 0, 0);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NegativeFunctionTest()
        {
            // Arrange
            var expected = -8.631;

            // Act
            var actual = Math.Round(Functions.NegativeFunction(5, 10, 1), 3);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}