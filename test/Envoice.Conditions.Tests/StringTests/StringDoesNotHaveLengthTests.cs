using System;
using System.ComponentModel;
using Envoice.Conditions;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.DoesNotHaveLength method.
    /// </summary>
    public class StringDoesNotHaveLengthTests
    {
        [Fact]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length = expected length' should fail.")]
        public void DoesNotHaveLengthTest01()
        {
            string a = "test";

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).DoesNotHaveLength(4);
            });
        }

        [Fact]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length = expected length = 1' should fail.")]
        public void DoesNotHaveLengthTest02()
        {
            string a = "t";

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).DoesNotHaveLength(1);
            });
        }

        [Fact]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length != expected length' should pass.")]
        public void DoesNotHaveLengthTest03()
        {
            string a = "test";
            Condition.Requires(a).DoesNotHaveLength(3);
        }

        [Fact]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length = expected length' should fail.")]
        public void DoesNotHaveLengthTest04()
        {
            string a = String.Empty;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).DoesNotHaveLength(0);
            });
        }

        [Fact]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length != expected length' should pass.")]
        public void DoesNotHaveLengthTest05()
        {
            string a = String.Empty;
            Condition.Requires(a).DoesNotHaveLength(1);
        }

        [Fact]
        [Description("Calling DoesNotHaveLength on string x with 'null = expected length' should fail.")]
        public void DoesNotHaveLengthTest06()
        {
            string a = null;
            // A null string is considered to have the length of 0.

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(a).DoesNotHaveLength(0);
            });
        }

        [Fact]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length != expected length' should pass.")]
        public void DoesNotHaveLengthTest07()
        {
            string a = null;
            // A null string is considered to have the length of 0.
            Condition.Requires(a).DoesNotHaveLength(1);
        }

        [Fact]
        [Description("Calling DoesNotHaveLength with conditionDescription parameter should pass.")]
        public void DoesNotHaveLengthTest08()
        {
            string a = string.Empty;
            Condition.Requires(a).DoesNotHaveLength(1, string.Empty);
        }

        [Fact]
        [Description("Calling a failing DoesNotHaveLength should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void DoesNotHaveLengthTest09()
        {
            string a = null;
            try
            {
                Condition.Requires(a, "a").DoesNotHaveLength(0, "qwe {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("qwe a xyz");
            }
        }

        [Fact]
        [Description("Calling DoesNotHaveLength on string x with 'x.Length = expected length' should succeed when exceptions are suppressed.")]
        public void DoesNotHaveLengthTest10()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().DoesNotHaveLength(4);
        }
    }
}
