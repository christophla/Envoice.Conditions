using System;
using System.ComponentModel;
using Xunit;

namespace Envoice.Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNullOrEmpty method.
    /// </summary>
    public class StringIsNullOrEmptyTests
    {
        [Fact]
        [Description("Calling IsNullOrEmpty on string x with 'x.Length > 0' should fail.")]
        public void IsNullOrEmptyTest1()
        {
            string a = "test";

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNullOrEmpty();
            });
        }

        [Fact]
        [Description("Calling IsNullOrEmpty on string (\"\") should pass.")]
        public void IsNullOrEmptyTest2()
        {
            string a = String.Empty;
            Condition.Requires(a).IsNullOrEmpty();
        }

        [Fact]
        [Description("Calling IsNullOrEmpty on string (null) should pass.")]
        public void IsNullOrEmptyTest3()
        {
            string a = null;
            // A null value will never be found
            Condition.Requires(a).IsNullOrEmpty();
        }

        [Fact]
        [Description("Calling IsNullOrEmpty with conditionDescription parameter should pass.")]
        public void IsNullOrEmptyTest4()
        {
            string a = string.Empty;
            Condition.Requires(a).IsNullOrEmpty(string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNullOrEmpty should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNullOrEmptyTest5()
        {
            string a = "test";
            try
            {
                Condition.Requires(a, "a").IsNullOrEmpty("qwe {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("qwe a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsNullOrEmpty on string x with 'x.Length > 0' should succeed when exceptions are suppressed.")]
        public void IsNullOrEmptyTest6()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().IsNullOrEmpty();
        }
    }
}
