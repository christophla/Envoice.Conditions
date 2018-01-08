using System;
using System.ComponentModel;
using Xunit;

namespace Envoice.Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNotNullOrEmpty method.
    /// </summary>
    public class StringIsNotNullOrEmptyTests
    {
        [Fact]
        [Description("Calling IsNullOrEmpty on string x with 'x.Length > 0' should pass.")]
        public void IsNotNullOrEmptyTest1()
        {
            string a = "test";
            Condition.Requires(a).IsNotNullOrEmpty();
        }

        [Fact]
        [Description("Calling IsNullOrEmpty on string (\"\") should fail.")]
        public void IsNotNullOrEmptyTest2()
        {
            string a = String.Empty;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotNullOrEmpty();
            });
        }

        [Fact]
        [Description("Calling IsNullOrEmpty on string (null) should fail.")]
        public void IsNotNullOrEmptyTest3()
        {
            string a = null;
            // A null value will never be found

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(a).IsNotNullOrEmpty();
            });
        }

        [Fact]
        [Description("Calling IsNotNullOrEmpty with conditionDescription parameter should pass.")]
        public void IsNotNullOrEmptyTest4()
        {
            string a = "test";
            Condition.Requires(a).IsNotNullOrEmpty(string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotNullOrEmpty should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNotNullOrEmptyTest5()
        {
            string a = string.Empty;
            try
            {
                Condition.Requires(a, "a").IsNotNullOrEmpty("qwe {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("qwe a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsNullOrEmpty on string (\"\") should succeed when exceptions are suppressed.")]
        public void IsNotNullOrEmptyTest6()
        {
            string a = String.Empty;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotNullOrEmpty();
        }
    }
}
