using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.StartsWith method.
    /// </summary>
    public class StringStartsWithTests
    {
        [Fact]
        [Description("Calling StartsWith on string x with 'x StartsWith x' should pass.")]
        public void StartsWithTest01()
        {
            string a = "test";
            Condition.Requires(a).StartsWith(a);
        }

        [Fact]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith \"tes\"' should pass.")]
        public void StartsWithTest02()
        {
            string a = "test";
            Condition.Requires(a).StartsWith("tes");
        }

        [Fact]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith null' should fail.")]
        public void StartsWithTest03()
        {
            string a = "test";
            // A null value will never be found

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).StartsWith(null);
            });
        }

        [Fact]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith \"\"' should pass.")]
        public void StartsWithTest04()
        {
            string a = "test";
            // An empty string will always be found
            Condition.Requires(a).StartsWith(String.Empty);
        }

        [Fact]
        [Description("Calling StartsWith on string x (null) with 'x StartsWith \"\"' should fail.")]
        public void StartsWithTest05()
        {
            string a = null;
            // A null string only contains other null strings.

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(a).StartsWith(String.Empty);
            });
        }

        [Fact]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith null' should pass.")]
        public void StartsWithTest06()
        {
            string a = null;
            Condition.Requires(a).StartsWith(null);
        }

        [Fact]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith \"test me\"' should fail.")]
        public void StartsWithTest07()
        {
            string a = "test";

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).StartsWith("test me");
            });
        }

        [Fact]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith \"test me\"' should fail with a correct exception message.")]
        public void StartsWithTest08()
        {
            string expectedMessage =
                "a should start with 'test me'." + Environment.NewLine +
                TestHelper.CultureSensitiveArgumentExceptionParameterText + ": a";

            try
            {
                string a = "test";
                Condition.Requires(a, "a").StartsWith("test me");
            }
            catch (Exception ex)
            {
                expectedMessage.ShouldBe(ex.Message);
            }
        }

        [Fact]
        [Description("Calling StartsWith with conditionDescription parameter should pass.")]
        public void StartsWithTest09()
        {
            string a = null;
            Condition.Requires(a).StartsWith(null, string.Empty);
        }

        [Fact]
        [Description("Calling a failing StartsWith should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void StartsWithTest10()
        {
            string a = null;
            try
            {
                // A null string is considered to have a length of 0.
                Condition.Requires(a, "a").StartsWith("test", "qwe {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("qwe a xyz");
            }
        }

        [Fact]
        [Description("Calling StartsWith should be language dependent.")]
        public void StartsWithTest11()
        {
            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;

            string a = "hi ya'all";

            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");

                // We check this using the Turkish-I problem.
                // see: http://msdn.microsoft.com/en-us/library/ms973919.aspx#stringsinnet20_topic5
                string turkishUpperCase = "Hİ";

                Condition.Requires(a).StartsWith(turkishUpperCase, StringComparison.CurrentCultureIgnoreCase);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = originalCulture;
            }
        }

        [Fact]
        [Description("Calling StartsWith on string x (\"test\") with 'x StartsWith null' should succeed when exceptions are suppressed.")]
        public void StartsWithTest12()
        {
            string a = "test";
            // A null value will never be found
            Condition.Requires(a).SuppressExceptionsForTest().StartsWith(null);
        }
    }
}
