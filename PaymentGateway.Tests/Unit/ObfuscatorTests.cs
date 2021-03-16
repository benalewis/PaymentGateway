using NUnit.Framework;
using PaymentGateway.Common;

namespace PaymentGateway.Tests.Unit
{
    [TestFixture]
    public class ObfuscatorTests
    {
        [TestCase("Hello", 3, "**llo")]
        [TestCase("Hello", 0, "*****")]
        [TestCase("Hello", 7, "Hello")]
        [TestCase("Hello", 1, "****o")]
        [TestCase(null, 3, null)]

        public void CanObfuscate(string input, int numbers, string output)
        {
            // Act
            var result = input.Obfuscate(numbers);

            // Assert
            Assert.AreEqual(output, result);
        }
    }
}