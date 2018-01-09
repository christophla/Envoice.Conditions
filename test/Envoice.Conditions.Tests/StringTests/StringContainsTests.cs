using System;
using System.ComponentModel;
using Envoice.Conditions;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.Contains method.
    /// </summary>
    public class StringContainsTests
    {
        [Fact]
        [Description("Calling Contains on string x with 'x Contains x' should pass.")]
        public void ContainsTest01()
        {
            string a = "test";
            Condition.Requires(a).Contains(a);
        }

        [Fact]
        [Description("Calling Contains on string x (\"test\") with 'x Contains \"es\"' should pass.")]
        public void ContainsTest02()
        {
            string a = "test";
            Condition.Requires(a).Contains("es");
        }

        [Fact]
        [Description("Calling Contains on string x (\"test\") with 'x Contains null' should fail.")]
        public void ContainsTest03()
        {
            string a = "test";
            // A null value will never be found

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).Contains(null);
            });
        }

        [Fact]
        [Description("Calling Contains on string x (\"test\") with 'x Contains \"\"' should pass.")]
        public void ContainsTest04()
        {
            string a = "test";
            // An empty string will always be found
            Condition.Requires(a).Contains(String.Empty);
        }

        [Fact]
        [Description("Calling Contains on string x (null) with 'x Contains \"\"' should fail.")]
        public void ContainsTest05()
        {
            string a = null;
            // A null string only contains other null strings.

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(a).Contains(String.Empty);
            });
        }

        [Fact]
        [Description("Calling Contains on string x (null) with 'x Contains null' should pass.")]
        public void ContainsTest06()
        {
            string a = null;
            Condition.Requires(a).Contains(null);
        }

        [Fact]
        [Description("Calling Contains on string x (\"test\") with 'x Contains \"test me\"' should fail.")]
        public void ContainsTest07()
        {
            string a = "test";

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).Contains("test me");
            });
        }

        [Fact]
        [Description("Calling Contains on string x (\"test\") with 'x Contains \"test me\"' should fail with a correct exception message.")]
        public void ContainsTest08()
        {
            string expectedMessage =
                "a should contain 'test me'." + Environment.NewLine +
                TestHelper.CultureSensitiveArgumentExceptionParameterText + ": a";

            try
            {
                string a = "test";
                Condition.Requires(a, "a").Contains("test me");
            }
            catch (Exception ex)
            {
                expectedMessage.ShouldBe(ex.Message);
            }
        }

        [Fact]
        [Description("Calling Contains with conditionDescription parameter should pass.")]
        public void ContainsTest09()
        {
            string a = null;
            Condition.Requires(a).Contains(null, string.Empty);
        }

        [Fact]
        [Description("Calling a failing Contains should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void ContainsTest10()
        {
            string a = "test";
            try
            {
                Condition.Requires(a, "a").Contains("test me", "qwe {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("qwe a xyz");
            }
        }

        [Fact]
        [Description("Calling Contains on string x (\"test\") with 'x Contains null' should succeed when exceptions are suppressed.")]
        public void ContainsTest11()
        {
            string a = "test";
            // A null value will never be found
            Condition.Requires(a).SuppressExceptionsForTest().Contains(null);
        }
    }
}
