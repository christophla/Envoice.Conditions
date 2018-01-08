using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using Envoice.Conditions;
using Xunit;

namespace Envoice.Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.DoesNotStartWith method.
    /// </summary>
    public class StringDoesNotStartWithTests
    {
        [Fact]
        [Description("Calling DoesNotStartWith on string x with 'x DoesNotStartWith x' should fail.")]
        public void DoesNotStartWithTest01()
        {
            string a = "test";

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).DoesNotStartWith(a);
            });
        }

        [Fact]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith \"tes\"' should fail.")]
        public void DoesNotStartWithTest02()
        {
            string a = "test";

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).DoesNotStartWith("tes");
            });
        }

        [Fact]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith null' should pass.")]
        public void DoesNotStartWithTest03()
        {
            string a = "test";
            // A null value will never be found
            Condition.Requires(a).DoesNotStartWith(null);
        }

        [Fact]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith \"\"' should fail.")]
        public void DoesNotStartWithTest04()
        {
            string a = "test";
            // An empty string will always be found

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).DoesNotStartWith(String.Empty);
            });
        }

        [Fact]
        [Description("Calling DoesNotStartWith on string x (null) with 'x DoesNotStartWith \"\"' should pass.")]
        public void DoesNotStartWithTest05()
        {
            string a = null;
            // A null string only contains other null strings.
            Condition.Requires(a).DoesNotStartWith(String.Empty);
        }

        [Fact]
        [Description("Calling DoesNotStartWith on string x (null) with 'x DoesNotStartWith null' should fail.")]
        public void DoesNotStartWithTest06()
        {
            string a = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(a).DoesNotStartWith(null);
            });
        }

        [Fact]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith \"test me\"' should pass.")]
        public void DoesNotStartWithTest07()
        {
            string a = "test";
            Condition.Requires(a).DoesNotStartWith("test me");
        }

        [Fact]
        [Description("Calling DoesNotStartWith on string x (\"test\") with 'x DoesNotStartWith \"test\"' should fail with a correct exception message.")]
        public void DoesNotStartWithTest08()
        {
            string expectedMessage =
                "a should not start with 'test'." + Environment.NewLine +
                TestHelper.CultureSensitiveArgumentExceptionParameterText + ": a";

            try
            {
                string a = "test";
                Condition.Requires(a, "a").DoesNotStartWith("test");
            }
            catch (Exception ex)
            {
                Assert.Equal(expectedMessage, ex.Message);
            }
        }

        [Fact]
        [Description("Calling DoesNotStartWith with conditionDescription parameter should pass.")]
        public void DoesNotStartWithTest09()
        {
            string a = "test";
            Condition.Requires(a).DoesNotStartWith("test me", string.Empty);
        }

        [Fact]
        [Description("Calling a failing DoesNotStartWith should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void DoesNotStartWithTest10()
        {
            string a = "test";
            try
            {
                Condition.Requires(a, "a").DoesNotStartWith("test", "qwe {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("qwe a xyz"));
            }
        }

        [Fact]
        [Description("Calling DoesNotStartWith should be language dependent.")]
        public void DoesNotStartWithTest11()
        {
            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;

            string a = "hi ya'all";

            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");

                // We check this using the Turkish-I problem.
                // see: http://msdn.microsoft.com/en-us/library/ms973919.aspx#stringsinnet20_topic5
                string turkishUpperCase = "HI";

                Condition.Requires(a).DoesNotStartWith(turkishUpperCase, StringComparison.CurrentCultureIgnoreCase);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = originalCulture;
            }
        }

        [Fact]
        [Description("Calling DoesNotStartWith on string x with 'x DoesNotStartWith x' should succeed when exceptions are suppressed.")]
        public void DoesNotStartWithTest12()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().DoesNotStartWith(a);
        }
    }
}
