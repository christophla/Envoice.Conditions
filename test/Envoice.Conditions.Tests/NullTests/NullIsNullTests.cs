using System;
using System.ComponentModel;
using Envoice.Conditions;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests.NullTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNull method.
    /// </summary>
    public class NullIsNullTests
    {
        [Fact]
        [Description("Calling IsNull on null should pass.")]
        public void IsNullTest01()
        {
            object o = null;
            Condition.Requires(o).IsNull();
        }

        [Fact]
        [Description("Calling IsNull on a reference should fail.")]
        public void IsNullTest02()
        {
            object o = new object();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(o).IsNull();
            });
        }

        [Fact]
        [Description("Calling IsNull on a null Nullable<T> should pass.")]
        public void IsNullTest03()
        {
            int? i = null;
            Condition.Requires(i).IsNull();
        }

        [Fact]
        [Description("Calling IsNull on a set Nullable<T> should fail.")]
        public void IsNullTest04()
        {
            int? i = 3;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(i).IsNull();
            });
        }

        [Fact]
        [Description("Calling IsNull on an object containing an enum should fail with ArgumentException.")]
        public void IsNullTest05()
        {
            object i = DayOfWeek.Sunday;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(i).IsNull();
            });
        }

        [Fact]
        [Description("Calling IsNull with conditionDescription parameter should pass.")]
        public void IsNullTest06()
        {
            object o = null;
            Condition.Requires(o).IsNull(string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNull should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNullTest07()
        {
            object o = new object();
            try
            {
                Condition.Requires(o, "o").IsNull("qwe {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("qwe o xyz");
            }
        }

        [Fact]
        [Description("Calling IsNull on Nullable<T> with conditionDescription parameter should pass.")]
        public void IsNullTest08()
        {
            int? i = null;
            Condition.Requires(i).IsNull(string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNull on Nullable<T> should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNullTest09()
        {
            int? i = 4;
            try
            {
                Condition.Requires(i, "i").IsNull("qwe {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("qwe i xyz");
            }
        }

        [Fact]
        [Description("Calling IsNull on a reference should succeed when exceptions are suppressed.")]
        public void IsNullTest10()
        {
            object o = new object();
            Condition.Requires(o).SuppressExceptionsForTest().IsNull();
        }
    }
}
