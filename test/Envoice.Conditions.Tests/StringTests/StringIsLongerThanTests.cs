using System;
using System.ComponentModel;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsLongerThan method.
    /// </summary>
    public class StringIsLongerThanTests
    {
        [Fact]
        [Description("Calling IsLongerThan on string x with 'lower bound < x.Length' should pass.")]
        public void IsLongerThan01()
        {
            string a = "test";
            Condition.Requires(a).IsLongerThan(3);
        }

        [Fact]
        [Description("Calling IsLongerThan on string x with 'lower bound = x.Length' should fail.")]
        public void IsLongerThan2()
        {
            string a = "test";

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsLongerThan(4);
            });
        }

        [Fact]
        [Description("Calling IsLongerThan on string x with '-1 < x.Length' should pass.")]
        public void IsLongerThan003()
        {
            string a = String.Empty;
            Condition.Requires(a).IsLongerThan(-1);
        }

        [Fact]
        [Description("Calling IsLongerThan on string x with 'lower bound = x.Length' should fail.")]
        public void IsLongerThan04()
        {
            string a = String.Empty;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsLongerThan(0);
            });
        }

        [Fact]
        [Description("Calling IsLongerThan on string x with '-1 < null' should pass.")]
        public void IsLongerThan05()
        {
            string a = null;
            Condition.Requires(a).IsLongerThan(-1);
        }

        [Fact]
        [Description("Calling IsLongerThan on string x with 'lower bound = null' should fail.")]
        public void IsLongerThan06()
        {
            string a = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(a).IsLongerThan(0);
            });
        }

        [Fact]
        [Description("Calling IsLongerThan with conditionDescription parameter should pass.")]
        public void IsLongerThan07()
        {
            string a = string.Empty;
            Condition.Requires(a).IsLongerThan(-1, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsLongerThan should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsLongerThan08()
        {
            string a = null;
            try
            {
                Condition.Requires(a, "a").IsLongerThan(0, "qwe {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("qwe a xyz");
            }
        }

        [Fact]
        [Description("Calling IsLongerThan on string x with 'lower bound = 1' should fail.")]
        public void IsLongerThan09()
        {
            // Testing a string with length of one and minLength = 1 to achieve 100% code coverage.
            string a = "1";

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsLongerThan(1);
            });
        }

        [Fact]
        [Description("Calling IsLongerThan on string x with 'lower bound = x.Length' should succeed when exceptions are suppressed.")]
        public void IsLongerThan10()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().IsLongerThan(4);
        }
    }
}
