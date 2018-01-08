using System;
using System.ComponentModel;
using Xunit;

namespace Envoice.Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNotEmpty method.
    /// </summary>
    public class StringIsNotEmptyTests
    {
        [Fact]
        [Description("Calling IsNotEmpty on string x with 'x == String.Empty' should fail.")]
        public void IsStringNotEmptyTest1()
        {
            string s = String.Empty;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(s).IsNotEmpty();
            });
        }

        [Fact]
        [Description("Calling IsNotEmpty on string x with 'x != String.Empty' should pass.")]
        public void IsStringNotEmptyTest2()
        {
            string s = null;
            Condition.Requires(s).IsNotEmpty();
        }

        [Fact]
        [Description("Calling IsNotEmpty on string x with 'x != String.Empty' should pass.")]
        public void IsStringNotEmptyTest3()
        {
            string s = "test";
            Condition.Requires(s).IsNotEmpty();
        }

        [Fact]
        [Description("Calling IsNotEmpty with conditionDescription parameter should pass.")]
        public void IsStringNotEmptyTest4()
        {
            string a = "test";
            Condition.Requires(a).IsNotEmpty(string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotEmpty should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsStringNotEmptyTest5()
        {
            string a = string.Empty;
            try
            {
                Condition.Requires(a, "a").IsNotEmpty("qwe {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("qwe a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsNotEmpty on string x with 'x == String.Empty' should succeed when exceptions are suppressed.")]
        public void IsStringNotEmptyTest6()
        {
            string s = String.Empty;
            Condition.Requires(s).SuppressExceptionsForTest().IsNotEmpty();
        }
    }
}
