using System;
using System.ComponentModel;
using Envoice.Conditions;
using Xunit;

namespace Envoice.Conditions.Tests.NumericTests
{
    public partial class NumericSingleTests
    {
        [Fact]
        [Description("Calling IsNaN on Single x with x is not a number should succeed.")]
        public void IsSingleNaNTest01()
        {
            Single a = Single.NaN;
            Condition.Requires(a).IsNaN();
        }

        [Fact]
        [Description("Calling IsNaN on Single x with x is a number should fail.")]
        public void IsSingleNaNTest02()
        {
            Single a = 4;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNaN();
            });
        }

        [Fact]
        [Description("Calling IsNaN on Single x with x not a number and conditionDescription should pass.")]
        public void IsSingleNaNTest03()
        {
            Single a = Single.NaN;
            Condition.Requires(a).IsNaN(string.Empty);
        }

        [Fact]
        [Description("Calling IsNaN on Single x with x a number and conditionDescription should fail.")]
        public void IsSingleNaNTest04()
        {
            Single a = 4;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNaN(string.Empty);
            });
        }

        [Fact]
        [Description("Calling IsNotNaN on Single x with x is a number should succeed.")]
        public void IsSingleNonNaNTest01()
        {
            Single a = 4;
            Condition.Requires(a).IsNotNaN();
        }

        [Fact]
        [Description("Calling IsNotNaN on Single x with x is not a number should fail.")]
        public void IsSingleNonNaNTest02()
        {
            Single a = Single.NaN;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotNaN();
            });
        }

        [Fact]
        [Description("Calling IsNotNaN on Single x with x a number and conditionDescription should pass.")]
        public void IsSingleNonNaNTest03()
        {
            Single a = 4;
            Condition.Requires(a).IsNotNaN(string.Empty);
        }

        [Fact]
        [Description("Calling IsNotNaN on Single x with x not a number and conditionDescription should fail.")]
        public void IsSingleNonNaNTest04()
        {
            Single a = Single.NaN;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotNaN(string.Empty);
            });
        }

        [Fact]
        [Description("Calling IsInfinity on Single x with x is negative infinity should succeed.")]
        public void IsSingleInfinityTest01()
        {
            Single a = Single.NegativeInfinity;
            Condition.Requires(a).IsInfinity();
        }

        [Fact]
        [Description("Calling IsInfinity on Single x with x is possitive infinity should succeed.")]
        public void IsSingleInfinityTest02()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsInfinity();
        }

        [Fact]
        [Description("Calling IsInfinity on Single x with x is a number should fail.")]
        public void IsSingleInfinityTest03()
        {
            Single a = 4;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsInfinity();
            });
        }

        [Fact]
        [Description("Calling IsInfinity on Single x with x positive infinity and conditionDescription should pass.")]
        public void IsSingleInfinityTest04()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsInfinity(string.Empty);
        }

        [Fact]
        [Description("Calling IsInfinity on Single x with x a number and conditionDescription should fail.")]
        public void IsSingleInfinityTest05()
        {
            Single a = 4;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsInfinity(string.Empty);
            });
        }

        [Fact]
        [Description("Calling IsNotInfinity on Single x with x is negative infinity should fail.")]
        public void IsSingleNotInfinityTest01()
        {
            Single a = Single.NegativeInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInfinity();
            });
        }

        [Fact]
        [Description("Calling IsNotInfinity on Single x with x is possitive infinity should fail.")]
        public void IsSingleNotInfinityTest02()
        {
            Single a = Single.PositiveInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInfinity();
            });
        }

        [Fact]
        [Description("Calling IsNotInfinity on Single x with x is a number should succeed.")]
        public void IsSingleNotInfinityTest03()
        {
            Single a = 4;
            Condition.Requires(a).IsNotInfinity();
        }

        [Fact]
        [Description("Calling IsNotInfinity on Single x with x a number and conditionDescription should pass.")]
        public void IsSingleNotInfinityTest04()
        {
            Single a = 4;
            Condition.Requires(a).IsNotInfinity(string.Empty);
        }

        [Fact]
        [Description("Calling IsNotInfinity on Single x with x positive infinity and conditionDescription should fail.")
        ]
        public void IsSingleNotInfinityTest05()
        {
            Single a = Single.PositiveInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInfinity(string.Empty);
            });
        }

        [Fact]
        [Description("Calling IsPositiveInfinity on Single x with x is negative infinity should fail.")]
        public void IsSinglePositiveInfinityTest01()
        {
            Single a = Single.NegativeInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsPositiveInfinity();
            });
        }

        [Fact]
        [Description("Calling IsPositiveInfinity on Single x with x is possitive infinity should succeed.")]
        public void IsSinglePositiveInfinityTest02()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsPositiveInfinity();
        }

        [Fact]
        [Description("Calling IsPositiveInfinity on Single x with x is a number should fail.")]
        public void IsSinglePositiveInfinityTest03()
        {
            Single a = 4;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsPositiveInfinity();
            });
        }

        [Fact]
        [Description("Calling IsPositiveInfinity on Single x with x positive infinity and conditionDescription should pass.")]
        public void IsSinglePositiveInfinityTest04()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsPositiveInfinity(string.Empty);
        }

        [Fact]
        [Description("Calling IsPositiveInfinity on Single x with x negative infinity and conditionDescription should fail.")]
        public void IsSinglePositiveInfinityTest05()
        {
            Single a = Single.NegativeInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsPositiveInfinity(string.Empty);
            });
        }

        [Fact]
        [Description("Calling IsNotPositiveInfinity on Single x with x is negative infinity should succeed.")]
        public void IsSingleNotPositiveInfinityTest01()
        {
            Single a = Single.NegativeInfinity;
            Condition.Requires(a).IsNotPositiveInfinity();
        }

        [Fact]
        [Description("Calling IsNotPositiveInfinity on Single x with x is possitive infinity should fail.")]
        public void IsSingleNotPositiveInfinityTest02()
        {
            Single a = Single.PositiveInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotPositiveInfinity();
            });
        }

        [Fact]
        [Description("Calling IsNotPositiveInfinity on Single x with x is a number should succeed.")]
        public void IsSingleNotPositiveInfinityTest03()
        {
            Single a = 4;
            Condition.Requires(a).IsNotPositiveInfinity();
        }

        [Fact]
        [Description("Calling IsNotPositiveInfinity on Single x with x a number and conditionDescription should pass.")]
        public void IsSingleNotPositiveInfinityTest04()
        {
            Single a = 4;
            Condition.Requires(a).IsNotPositiveInfinity(string.Empty);
        }

        [Fact]
        [Description("Calling IsNotPositiveInfinity on Single x with positive infinity and conditionDescription should fail.")]
        public void IsSingleNotPositiveInfinityTest05()
        {
            Single a = Single.PositiveInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotPositiveInfinity(string.Empty);
            });
        }

        [Fact]
        [Description("Calling IsNegativeInfinity on Single x with x is positive infinity should fail.")]
        public void IsSingleNegativeInfinityTest01()
        {
            Single a = Single.PositiveInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNegativeInfinity();
            });
        }

        [Fact]
        [Description("Calling IsNegativeInfinity on Single x with x is negative infinity should succeed.")]
        public void IsSingleNegativeInfinityTest02()
        {
            Single a = Single.NegativeInfinity;
            Condition.Requires(a).IsNegativeInfinity();
        }

        [Fact]
        [Description("Calling IsNegativeInfinity on Single x with x is a number should fail.")]
        public void IsSingleNegativeInfinityTest03()
        {
            Single a = 4;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNegativeInfinity();
            });
        }

        [Fact]
        [Description("Calling IsNegativeInfinity on Single x with x negative infinitiy and conditionDescription should pass.")]
        public void IsSingleNegativeInfinityTest04()
        {
            Single a = Single.NegativeInfinity;
            Condition.Requires(a).IsNegativeInfinity(string.Empty);
        }

        [Fact]
        [Description("Calling IsNegativeInfinity on Single x with x positive infinity and conditionDescription should fail.")]
        public void IsSingleNegativeInfinityTest05()
        {
            Single a = Single.PositiveInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNegativeInfinity(string.Empty);
            });
        }

        [Fact]
        [Description("Calling IsNotNegativeInfinity on Single x with x is positive infinity should succeed.")]
        public void IsSingleNotNegativeInfinityTest01()
        {
            Single a = Single.PositiveInfinity;
            Condition.Requires(a).IsNotNegativeInfinity();
        }

        [Fact]
        [Description("Calling IsNotNegativeInfinity on Single x with x is negative infinity should fail.")]
        public void IsSingleNotNegativeInfinityTest02()
        {
            Single a = Single.NegativeInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotNegativeInfinity();
            });
        }

        [Fact]
        [Description("Calling IsNotNegativeInfinity on Single x with x is a number should succeed.")]
        public void IsSingleNotNegativeInfinityTest03()
        {
            Single a = 4;
            Condition.Requires(a).IsNotNegativeInfinity();
        }

        [Fact]
        [Description("Calling IsNotNegativeInfinity on Single x with x a number and conditionDescription should pass.")]
        public void IsSingleNotNegativeInfinityTest04()
        {
            Single a = 4;
            Condition.Requires(a).IsNotNegativeInfinity(string.Empty);
        }

        [Fact]
        [Description("Calling IsNotNegativeInfinity on Single x with x negative infinity and conditionDescription should fail.")]
        public void IsSingleNotNegativeInfinityTest05()
        {
            Single a = Single.NegativeInfinity;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotNegativeInfinity(string.Empty);
            });
        }
    }
}
