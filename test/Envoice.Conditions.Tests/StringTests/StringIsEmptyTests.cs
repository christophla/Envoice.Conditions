using System;
using System.ComponentModel;
using Envoice.Conditions;
using Xunit;

namespace Envoice.Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsEmpty method.
    /// </summary>
    public class StringIsEmptyTests
    {
        [Fact]
        [Description("Calling IsEmpty on string x with 'x == String.Empty' should pass.")]
        public void IsStringEmptyTest1()
        {
            string s = String.Empty;
            Condition.Requires(s).IsEmpty();
        }

        [Fact]
        [Description("Calling IsEmpty on string x with 'x != String.Empty' should fail.")]
        public void IsStringEmptyTest2()
        {
            string s = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(s).IsEmpty();
            });
        }

        [Fact]
        [Description("Calling IsEmpty on string x with 'x != String.Empty' should fail.")]
        public void IsStringEmptyTest3()
        {
            string s = "test";

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(s).IsEmpty();
            });
        }

        [Fact]
        [Description("Calling IsEmpty with conditionDescription parameter should pass.")]
        public void IsStringEmptyTest4()
        {
            string a = String.Empty;
            Condition.Requires(a).IsEmpty(string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsEmpty should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsStringEmptyTest5()
        {
            string a = "test";
            try
            {
                Condition.Requires(a, "a").IsEmpty("qwe {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("qwe a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsEmpty on string x with 'x != String.Empty' should succeed when exceptions are suppressed.")]
        public void IsStringEmptyTest6()
        {
            string s = null;
            Condition.Requires(s).SuppressExceptionsForTest().IsEmpty();
        }
    }
}
