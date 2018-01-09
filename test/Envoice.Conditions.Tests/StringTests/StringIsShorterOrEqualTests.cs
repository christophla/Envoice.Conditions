using System;
using System.ComponentModel;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsShorterOrEqual method.
    /// </summary>
    public class StringIsShorterOrEqualTests
    {
        [Fact]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length < upped bound' should pass.")]
        public void IsShorterOrEqual00()
        {
            string a = "test";
            Condition.Requires(a).IsShorterOrEqual(5);
        }

        [Fact]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length = upped bound' should pass.")]
        public void IsShorterOrEqual01()
        {
            string a = "test";
            Condition.Requires(a).IsShorterOrEqual(4);
        }

        [Fact]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length > upped bound' should fail.")]
        public void IsShorterOrEqual02()
        {
            string a = "test";

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsShorterOrEqual(1);
            });
        }

        [Fact]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length < upped bound' should pass.")]
        public void IsShorterOrEqual03()
        {
            string a = String.Empty;
            Condition.Requires(a).IsShorterOrEqual(1);
        }

        [Fact]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length = upped bound' should pass.")]
        public void IsShorterOrEqual04()
        {
            string a = String.Empty;
            Condition.Requires(a).IsShorterOrEqual(0);
        }

        [Fact]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length > upped bound' should fail.")]
        public void IsShorterOrEqual05()
        {
            string a = String.Empty;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsShorterOrEqual(-1);
            });
        }

        [Fact]
        [Description("Calling IsShorterOrEqual on string x with 'null = upped bound' should pass.")]
        public void IsShorterOrEqual06()
        {
            string a = null;
            Condition.Requires(a).IsShorterOrEqual(0);
        }

        [Fact]
        [Description("Calling IsShorterOrEqual on string x with 'null > upped bound' should fail.")]
        public void IsShorterOrEqual07()
        {
            string a = null;
            // A null value is considered to have a length of 0 characters.

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(a).IsShorterOrEqual(-1);
            });
        }

        [Fact]
        [Description("Calling IsShorterOrEqual with conditionDescription parameter should pass.")]
        public void IsShorterOrEqual08()
        {
            string a = string.Empty;
            Condition.Requires(a).IsShorterOrEqual(0, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsShorterOrEqual should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsShorterOrEqual09()
        {
            string a = null;
            try
            {
                Condition.Requires(a, "a").IsShorterOrEqual(-1, "qwe {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("qwe a xyz");
            }
        }

        [Fact]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length > upped bound' should succeed when exceptions are suppressed.")]
        public void IsShorterOrEqual10()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().IsShorterOrEqual(1);
        }
    }
}
