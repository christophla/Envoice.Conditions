using System;
using System.ComponentModel;
using Envoice.Conditions;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests.NullTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNotNull method.
    /// </summary>
    public class NullIsNotNullTests
    {
        [Fact]
        [Description("Calling IsNotNull on null should fail.")]
        public void IsNotNullTest1()
        {
            object o = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(o).IsNotNull();
            });
        }

        [Fact]
        [Description("Calling IsNotNull on a reference should pass.")]
        public void IsNotNullTest2()
        {
            object o = new object();
            Condition.Requires(o).IsNotNull();
        }

        [Fact]
        [Description("Calling IsNotNull on a null Nullable<T> should fail.")]
        public void IsNotNullTest3()
        {
            int? i = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(i).IsNotNull();
            });
        }

        [Fact]
        [Description("Calling IsNotNull on a set Nullable<T> should pass.")]
        public void IsNotNullTest4()
        {
            int? i = 3;
            Condition.Requires(i).IsNotNull();
        }

        [Fact]
        [Description("Calling IsNotNull with conditionDescription parameter should pass.")]
        public void IsNotNullTest5()
        {
            object o = new object();
            Condition.Requires(o).IsNotNull(string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotNull should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNotNullTest6()
        {
            object o = null;
            try
            {
                Condition.Requires(o, "o").IsNotNull("qwe {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("qwe o xyz");
            }
        }

        [Fact]
        [Description("Calling IsNotNull on Nullable<T> with conditionDescription parameter should pass.")]
        public void IsNotNullTest7()
        {
            int? i = 4;
            Condition.Requires(i).IsNotNull(string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotNull on Nullable<T> should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNotNullTest8()
        {
            int? i = null;
            try
            {
                Condition.Requires(i, "i").IsNotNull("qwe {0} xyz");

                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("qwe i xyz");
            }
        }

        [Fact]
        [Description("Calling IsNotNull on null should succeed when exceptions are suppressed.")]
        public void IsNotNullTest9()
        {
            object o = null;
            Condition.Requires(o).SuppressExceptionsForTest().IsNotNull();
        }
    }
}
