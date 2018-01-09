using System;
using System.ComponentModel;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.HasLength method.
    /// </summary>
    public class StringHasLengthTests
    {
        [Fact]
        [Description("Calling HasLength on string x with 'x.Length = expected length' should pass.")]
        public void HasLengthTest01()
        {
            string a = "test";
            Condition.Requires(a).HasLength(4);
        }

        [Fact]
        [Description("Calling HasLength on string x with 'x.Length != expected length' should fail.")]
        public void HasLengthTest02()
        {
            string a = "test";

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).HasLength(3);
            });
        }

        [Fact]
        [Description("Calling HasLength on string x with 'x.Length = expected length' should pass.")]
        public void HasLengthTest03()
        {
            string a = String.Empty;
            Condition.Requires(a).HasLength(0);
        }

        [Fact]
        [Description("Calling HasLength on string x with 'x.Length != expected length' should fail.")]
        public void HasLengthTest04()
        {
            string a = String.Empty;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).HasLength(1);
            });
        }

        [Fact]
        [Description("Calling HasLength on string x with 'null = expected length' should pass.")]
        public void HasLengthTest05()
        {
            string a = null;
            // A null value will never be found
            Condition.Requires(a).HasLength(0);
        }

        [Fact]
        [Description("Calling HasLength on string x with 'null != expected length' should fail.")]
        public void HasLengthTest06()
        {
            string a = null;
            // A null value will never be found

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(a).HasLength(1);
            });
        }

        [Fact]
        [Description("Calling HasLength with conditionDescription parameter should pass.")]
        public void HasLengthTest07()
        {
            string a = string.Empty;
            Condition.Requires(a).HasLength(0, string.Empty);
        }

        [Fact]
        [Description("Calling a failing HasLength should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void HasLengthTest08()
        {
            string a = null;
            try
            {
                Condition.Requires(a, "a").HasLength(1, "qwe {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("qwe a xyz");
            }
        }

        [Fact]
        [Description("Calling HasLength on string x with 'x.Length != expected length' should succeed when exceptions are suppressed.")]
        public void HasLengthTest09()
        {
            string a = String.Empty;
            Condition.Requires(a).SuppressExceptionsForTest().HasLength(1);
        }
    }
}
