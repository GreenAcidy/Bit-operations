using NUnit.Framework;
using System;

namespace NumbersExtensionNUTests
{
    [TestFixture]
    class NUTests
    {
        [TestCase(2728, 655, 3, 8, ExpectedResult = 2680)]
        [TestCase(554216104, 15, 0, 31, ExpectedResult = 15)]
        [TestCase(-55465467, 345346, 0, 31, ExpectedResult = 345346)]
        [TestCase(554216104, 4460559, 11, 18, ExpectedResult = 554203816)]
        [TestCase(-1, 0, 31, 31, ExpectedResult = 2147483647)]
        [TestCase(-2147483648, 2147483647, 0, 30, ExpectedResult = -1)]
        [TestCase(-2223, 5440, 18, 23, ExpectedResult = -16517295)]
        [TestCase(2147481425, 5440, 18, 23, ExpectedResult = 2130966353)]
        public int InsertNumberIntoAnotherTests(int sourceNumber, int insertNumber, int i, int j)
            => NumbersExtension.InsertNumberIntoAnother(sourceNumber, insertNumber, i, j);

        [Test]
        public void InsertNumberIntoAnother_ArgumentException() =>
            Assert.Throws<ArgumentException>(() => NumbersExtension.InsertNumberIntoAnother(8, 15, 8, 3),
                message: "i must be less then j");

        [Test]
        public void InsertNumberIntoAnother_ArgumentOutOfRangeException_Less() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => NumbersExtension.InsertNumberIntoAnother(8, 15, -1, 3),
                message: "index must be positive");

        [Test]
        public void InsertNumberIntoAnother_ArgumentOutOfRangeException_More() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => NumbersExtension.InsertNumberIntoAnother(8, 15, 32, 32),
                message: "index must be less then 32");

        [Test]
        public void InsertNumberIntoAnother_ArgumentOutOfRangeException_MoreAndLess() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => NumbersExtension.InsertNumberIntoAnother(8, 15, 0, 32),
                message: "index must be less then 32");


        [TestCase(1001, ExpectedResult = true)]
        [TestCase(10101, ExpectedResult = true)]
        [TestCase(10201, ExpectedResult = true)]
        [TestCase(109901, ExpectedResult = true)]
        [TestCase(123451001, ExpectedResult = false)]

        public bool IsPalindromeTests(int incomingPalindrome)
            => NumbersExtension.IsPalindrome(incomingPalindrome);

        [Test]
        public void NegativeNumberAbsPalindrome_ArgumentOutOfRangeException_Negative() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => NumbersExtension.IsPalindrome(-1001),
        message: "number must be positive");

        [Test]
        public void NegativeNumberAbsFalsePalindrome_ArgumentOutOfRangeException_Negative() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => NumbersExtension.IsPalindrome(-10123401),
        message: "number must be positive");

        [Test]
        [Order(2)]
        [Timeout(500)]
        public void PossiblyVerySlowCode_WithTimeLessThan1000Milliseconds()
        {
            for (int source = 0; source < 1_000_000; source++)
            {
                BitOperations.NumbersExtension.IsPalindrome(source);
            }
        }

        [Test]
        [Order(1)]
        [Timeout(2_000)]
        public void PossiblyVerySlowCode_WithTimeLessThan25000Milliseconds()
        {
            for (int source = 0; source < 10_000_000; source++)
            {
                BitOperations.NumbersExtension.IsPalindrome(source);
            }
        }
    }
}
