using System;
using System.ComponentModel;
using Envoice.Conditions;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.DoesNotContain method.
    /// </summary>
    public class StringDoesNotContainTests
    {
        [Fact]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain x' should fail.")]
        public void DoesNotContainTest01()
        {
            string a = "test";

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).DoesNotContain(a);
            });
        }

        [Fact]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain \"es\"' should fail.")]
        public void DoesNotContainTest02()
        {
            string a = "test";

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).DoesNotContain("es");
            });
        }

        [Fact]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain null' should pass.")]
        public void DoesNotContainTest03()
        {
            string a = "test";
            // A null value will never be found
            Condition.Requires(a).DoesNotContain(null);
        }

        [Fact]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain \"\"' should fail.")]
        public void DoesNotContainTest04()
        {
            string a = "test";
            // An empty string will always be found

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).DoesNotContain(String.Empty);
            });
        }

        [Fact]
        [Description("Calling DoesNotContain on string x (null) with 'x DoesNotContain \"\"' should pass.")]
        public void DoesNotContainTest05()
        {
            string a = null;
            // A null string only contains other null strings.
            Condition.Requires(a).DoesNotContain(String.Empty);
        }

        [Fact]
        [Description("Calling DoesNotContain on string x (null) with 'x DoesNotContain null' should fail.")]
        public void DoesNotContainTest06()
        {
            string a = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(a).DoesNotContain(null);
            });
        }

        [Fact]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain \"test me\"' should pass.")]
        public void DoesNotContainTest07()
        {
            string a = "test";
            Condition.Requires(a).DoesNotContain("test me");
        }

        [Fact]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain \"test\"' should fail with a correct exception message.")]
        public void DoesNotContainTest08()
        {
            string expectedMessage =
                "a should not contain 'test'." + Environment.NewLine +
                TestHelper.CultureSensitiveArgumentExceptionParameterText + ": a";

            try
            {
                string a = "test";
                Condition.Requires(a, "a").DoesNotContain("test");
            }
            catch (Exception ex)
            {
                expectedMessage.ShouldBe(ex.Message);
            }
        }

        [Fact]
        [Description("Calling DoesNotContain with conditionDescription parameter should pass.")]
        public void DoesNotContainTest09()
        {
            string a = "test";
            Condition.Requires(a).DoesNotContain("test me", string.Empty);
        }

        [Fact]
        [Description("Calling a failing DoesNotContain should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void DoesNotContainTest10()
        {
            string a = "test me";
            try
            {
                Condition.Requires(a, "a").DoesNotContain("test", "qwe {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("qwe a xyz");
            }
        }

        [Fact]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain x' should succeed when exceptions are suppressed.")]
        public void DoesNotContainTest11()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().DoesNotContain(a);
        }
    }
}
