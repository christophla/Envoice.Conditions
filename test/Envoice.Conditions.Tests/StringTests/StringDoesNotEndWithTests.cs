using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using Envoice.Conditions;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.DoesNotEndWith method.
    /// </summary>
    public class StringDoesNotEndWithTests
    {
        [Fact]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith x' should fail.")]
        public void DoesNotEndWithTest01()
        {
            string a = "test";

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).DoesNotEndWith(a);
            });
        }

        [Fact]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith \"est\"' should fail.")]
        public void DoesNotEndWithTest02()
        {
            string a = "test";

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).DoesNotEndWith("est");
            });
        }

        [Fact]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith null' should pass.")]
        public void DoesNotEndWithTest03()
        {
            string a = "test";
            // A null value will never be found
            Condition.Requires(a).DoesNotEndWith(null);
        }

        [Fact]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith \"\"' should fail.")]
        public void DoesNotEndWithTest04()
        {
            string a = "test";
            // An empty string will always be found

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).DoesNotEndWith(String.Empty);
            });
        }

        [Fact]
        [Description("Calling DoesNotEndWith on string x (null) with 'x DoesNotEndWith \"\"' should pass.")]
        public void DoesNotEndWithTest05()
        {
            string a = null;
            // A null string only contains other null strings.
            Condition.Requires(a).DoesNotEndWith(String.Empty);
        }

        [Fact]
        [Description("Calling DoesNotEndWith on string x (null) with 'x DoesNotEndWith null' should fail.")]
        public void DoesNotEndWithTest06()
        {
            string a = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(a).DoesNotEndWith(null);
            });
        }

        [Fact]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith \"me test\"' should pass.")]
        public void DoesNotEndWithTest07()
        {
            string a = "test";
            Condition.Requires(a).DoesNotEndWith("me test");
        }

        [Fact]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith \"test\"' should fail with a correct exception message.")]
        public void DoesNotEndWithTest08()
        {
            string expectedMessage =
                "a should not end with 'test'." + Environment.NewLine +
                TestHelper.CultureSensitiveArgumentExceptionParameterText + ": a";

            try
            {
                string a = "test";
                Condition.Requires(a, "a").DoesNotEndWith("test");
            }
            catch (Exception ex)
            {
                expectedMessage.ShouldBe(ex.Message);
            }
        }

        [Fact]
        [Description("Calling DoesNotEndWith with conditionDescription parameter should pass.")]
        public void DoesNotEndWithTest09()
        {
            string a = "test";
            Condition.Requires(a).DoesNotEndWith("test me", string.Empty);
        }

        [Fact]
        [Description("Calling a failing DoesNotEndWith should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void DoesNotEndWithTest10()
        {
            string a = "test me";
            try
            {
                Condition.Requires(a, "a").DoesNotEndWith("me", "qwe {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("qwe a xyz");
            }
        }

        [Fact]
        [Description("Calling DoesNotEndWith should be language dependent.")]
        public void DoesNotEndWithTest11()
        {
            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;

            string a = "hello and hi";

            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");

                // We check this using the Turkish-I problem.
                // see: http://msdn.microsoft.com/en-us/library/ms973919.aspx#stringsinnet20_topic5
                string turkishUpperCase = "HI";

                Condition.Requires(a).DoesNotEndWith(turkishUpperCase, StringComparison.CurrentCultureIgnoreCase);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = originalCulture;
            }
        }

        [Fact]
        [Description("Calling DoesNotEndWith on string x (\"test\") with 'x DoesNotEndWith x' should succeed when exceptions are suppressed.")]
        public void DoesNotEndWithTest12()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().DoesNotEndWith(a);
        }
    }
}
