using System;
using System.ComponentModel;
using Envoice.Conditions;
using Xunit;

namespace Envoice.Conditions.Tests.NumericTests
{
    public partial class NumericDoubleTests
    {
        [Fact]
        [Description("Calling IsNaN on Double x with x is not a number should succeed.")]
        public void IsDoubleNaNTest01()
        {
            Double a = Double.NaN;
            Condition.Requires(a).IsNaN();
        }

        [Fact]
        [Description("Calling IsNaN on Double x with x is a number should fail.")]
        public void IsDoubleNaNTest02()
        {
            Double a = 4;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNaN();
            });
        }

        [Fact]
        [Description("Calling IsNaN on Double x with x not a number and conditionDescription should pass.")]
        public void IsDoubleNaNTest03()
        {
            Double a = Double.NaN;
            Condition.Requires(a).IsNaN(string.Empty);
        }

        [Fact]
        [Description("Calling IsNaN on Double x with x a number and conditionDescription should fail.")]
        public void IsDoubleNaNTest04()
        {
            Double a = 4;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNaN(string.Empty);
            });
        }

        [Fact]
        [Description("Calling IsNaN on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleNaNTest05()
        {
            Double a = 4;
            Condition.Requires(a).SuppressExceptionsForTest().IsNaN();
        }

        [Fact]
        [Description("Calling IsNotNaN on Double x with x is a number should succeed.")]
        public void IsDoubleNonNaNTest01()
        {
            Double a = 4;
            Condition.Requires(a).IsNotNaN();
        }

        [Fact]
        [Description("Calling IsNotNaN on Double x with x is not a number should fail.")]
        public void IsDoubleNonNaNTest02()
        {
            Double a = Double.NaN;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotNaN();
            });
        }

        [Fact]
        [Description("Calling IsNotNaN on Double x with x a number and conditionDescription should pass.")]
        public void IsDoubleNonNaNTest03()
        {
            Double a = 4;
            Condition.Requires(a).IsNotNaN(string.Empty);
        }

        [Fact]
        [Description("Calling IsNotNaN on Double x with x not a number and conditionDescription should fail.")]
        public void IsDoubleNonNaNTest04()
        {
            Double a = Double.NaN;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotNaN(string.Empty);
            });
        }

        [Fact]
        [Description("Calling IsNotNaN on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleNotNaNTest05()
        {
            Double a = Double.NaN;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotNaN();
        }

        [Fact]
        [Description("Calling IsInfinity on Double x with x is negative infinity should succeed.")]
        public void IsDoubleInfinityTest01()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).IsInfinity();
        }

        [Fact]
        [Description("Calling IsInfinity on Double x with x is possitive infinity should succeed.")]
        public void IsDoubleInfinityTest02()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsInfinity();
        }

        [Fact]
        [Description("Calling IsInfinity on Double x with x is a number should fail.")]
        public void IsDoubleInfinityTest03()
        {
            Double a = 4;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsInfinity();
            });
        }

        [Fact]
        [Description("Calling IsInfinity on Double x with x positive infinity and conditionDescription should pass.")]
        public void IsDoubleInfinityTest04()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsInfinity(string.Empty);
        }

        [Fact]
        [Description("Calling IsInfinity on Double x with x a number and conditionDescription should fail.")]
        public void IsDoubleInfinityTest05()
        {
            Double a = 4;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsInfinity(string.Empty);
            });
        }

        [Fact]
        [Description("Calling IsInfinity on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleInfinityTest06()
        {
            Double a = 4;
            Condition.Requires(a).SuppressExceptionsForTest().IsInfinity();
        }

        [Fact]
        [Description("Calling IsNotInfinity on Double x with x is negative infinity should fail.")]
        public void IsDoubleNotInfinityTest01()
        {
            Double a = Double.NegativeInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInfinity();
            });
        }

        [Fact]
        [Description("Calling IsNotInfinity on Double x with x is possitive infinity should fail.")]
        public void IsDoubleNotInfinityTest02()
        {
            Double a = Double.PositiveInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInfinity();
            });
        }

        [Fact]
        [Description("Calling IsNotInfinity on Double x with x is a number should succeed.")]
        public void IsDoubleNotInfinityTest03()
        {
            Double a = 4;
            Condition.Requires(a).IsNotInfinity();
        }

        [Fact]
        [Description("Calling IsNotInfinity on Double x with x a number and conditionDescription should pass.")]
        public void IsDoubleNotInfinityTest04()
        {
            Double a = 4;
            Condition.Requires(a).IsNotInfinity(string.Empty);
        }

        [Fact]
        [Description("Calling IsNotInfinity on Double x with x positive infinity and conditionDescription should fail.")
        ]
        public void IsDoubleNotInfinityTest05()
        {
            Double a = Double.PositiveInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInfinity(string.Empty);
            });
        }

        [Fact]
        [Description("Calling IsNotInfinity on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleNotInfinityTest06()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInfinity();
        }

        [Fact]
        [Description("Calling IsPositiveInfinity on Double x with x is negative infinity should fail.")]
        public void IsDoublePositiveInfinityTest01()
        {
            Double a = Double.NegativeInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsPositiveInfinity();
            });
        }

        [Fact]
        [Description("Calling IsPositiveInfinity on Double x with x is possitive infinity should succeed.")]
        public void IsDoublePositiveInfinityTest02()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsPositiveInfinity();
        }

        [Fact]
        [Description("Calling IsPositiveInfinity on Double x with x is a number should fail.")]
        public void IsDoublePositiveInfinityTest03()
        {
            Double a = 4;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsPositiveInfinity();
            });
        }

        [Fact]
        [Description("Calling IsPositiveInfinity on Double x with x positive infinity and conditionDescription should pass.")]
        public void IsDoublePositiveInfinityTest04()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsPositiveInfinity(string.Empty);
        }

        [Fact]
        [Description("Calling IsPositiveInfinity on Double x with x negative infinity and conditionDescription should fail.")]
        public void IsDoublePositiveInfinityTest05()
        {
            Double a = Double.NegativeInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsPositiveInfinity(string.Empty);
            });
        }

        [Fact]
        [Description("Calling IsPositiveInfinity on Double x should succeed when exceptions are suppressed.")]
        public void IsDoublePositiveInfinityTest06()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).SuppressExceptionsForTest().IsPositiveInfinity();
        }

        [Fact]
        [Description("Calling IsNotPositiveInfinity on Double x with x is negative infinity should succeed.")]
        public void IsDoubleNotPositiveInfinityTest01()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).IsNotPositiveInfinity();
        }

        [Fact]
        [Description("Calling IsNotPositiveInfinity on Double x with x is possitive infinity should fail.")]
        public void IsDoubleNotPositiveInfinityTest02()
        {
            Double a = Double.PositiveInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotPositiveInfinity();
            });
        }

        [Fact]
        [Description("Calling IsNotPositiveInfinity on Double x with x is a number should succeed.")]
        public void IsDoubleNotPositiveInfinityTest03()
        {
            Double a = 4;
            Condition.Requires(a).IsNotPositiveInfinity();
        }

        [Fact]
        [Description("Calling IsNotPositiveInfinity on Double x with x a number and conditionDescription should pass.")]
        public void IsDoubleNotPositiveInfinityTest04()
        {
            Double a = 4;
            Condition.Requires(a).IsNotPositiveInfinity(string.Empty);
        }

        [Fact]
        [Description("Calling IsNotPositiveInfinity on Double x with positive infinity and conditionDescription should fail.")]
        public void IsDoubleNotPositiveInfinityTest05()
        {
            Double a = Double.PositiveInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotPositiveInfinity(string.Empty);
            });
        }

        [Fact]
        [Description("Calling IsNotPositiveInfinity on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleNotPositiveInfinityTest06()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotPositiveInfinity();
        }

        [Fact]
        [Description("Calling IsNegativeInfinity on Double x with x is positive infinity should fail.")]
        public void IsDoubleNegativeInfinityTest01()
        {
            Double a = Double.PositiveInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNegativeInfinity();
            });
        }

        [Fact]
        [Description("Calling IsNegativeInfinity on Double x with x is negative infinity should succeed.")]
        public void IsDoubleNegativeInfinityTest02()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).IsNegativeInfinity();
        }

        [Fact]
        [Description("Calling IsNegativeInfinity on Double x with x is a number should fail.")]
        public void IsDoubleNegativeInfinityTest03()
        {
            Double a = 4;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNegativeInfinity();
            });
        }

        [Fact]
        [Description("Calling IsNegativeInfinity on Double x with x negative infinitiy and conditionDescription should pass.")]
        public void IsDoubleNegativeInfinityTest04()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).IsNegativeInfinity(string.Empty);
        }

        [Fact]
        [Description("Calling IsNegativeInfinity on Double x with x positive infinity and conditionDescription should fail.")]
        public void IsDoubleNegativeInfinityTest05()
        {
            Double a = Double.PositiveInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNegativeInfinity(string.Empty);
            });
        }

        [Fact]
        [Description("Calling IsNegativeInfinity on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleNegativeInfinityTest06()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).SuppressExceptionsForTest().IsNegativeInfinity();
        }

        [Fact]
        [Description("Calling IsNotNegativeInfinity on Double x with x is positive infinity should succeed.")]
        public void IsDoubleNotNegativeInfinityTest01()
        {
            Double a = Double.PositiveInfinity;
            Condition.Requires(a).IsNotNegativeInfinity();
        }

        [Fact]
        [Description("Calling IsNotNegativeInfinity on Double x with x is negative infinity should fail.")]
        public void IsDoubleNotNegativeInfinityTest02()
        {
            Double a = Double.NegativeInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotNegativeInfinity();
            });
        }

        [Fact]
        [Description("Calling IsNotNegativeInfinity on Double x with x is a number should succeed.")]
        public void IsDoubleNotNegativeInfinityTest03()
        {
            Double a = 4;
            Condition.Requires(a).IsNotNegativeInfinity();
        }

        [Fact]
        [Description("Calling IsNotNegativeInfinity on Double x with x a number and conditionDescription should pass.")]
        public void IsDoubleNotNegativeInfinityTest04()
        {
            Double a = 4;
            Condition.Requires(a).IsNotNegativeInfinity(string.Empty);
        }

        [Fact]
        [Description("Calling IsNotNegativeInfinity on Double x with x negative infinity and conditionDescription should fail.")]
        public void IsDoubleNotNegativeInfinityTest05()
        {
            Double a = Double.NegativeInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotNegativeInfinity(string.Empty);
            });
        }

        [Fact]
        [Description("Calling IsNotNegativeInfinity on Double x should succeed when exceptions are suppressed.")]
        public void IsDoubleNotNegativeInfinityTest06()
        {
            Double a = Double.NegativeInfinity;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotNegativeInfinity();
        }
    }
}
