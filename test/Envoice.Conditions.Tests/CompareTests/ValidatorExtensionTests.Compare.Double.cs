// NOTE: This file a copy of ValidatorExtensionTests.Compare.Base.cs with all occurrences of 'xxx' replaced
// with 'Double'.

using System;
using System.ComponentModel;
using Envoice.Conditions;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests.CompareTests
{
    public class CompareDoubleTests
    {
        private static readonly Double One = 1;
        private static readonly Double Two = 2;
        private static readonly Double Three = 3;
        private static readonly Double Four = 4;
        private static readonly Double Five = 5;

        #region IsDoubleInRange

        [Fact]
        [Description("Calling IsInRange on Double x with 'lower bound > x < upper bound' should fail.")]
        public void IsDoubleInRangeTest01()
        {
            Double a = One;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsInRange on Double x with 'lower bound = x < upper bound' should pass.")]
        public void IsDoubleInRangeTest02()
        {
            Double a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsInRange on Double x with 'lower bound < x < upper bound' should pass.")]
        public void IsDoubleInRangeTest03()
        {
            Double a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsInRange on Double x with 'lower bound < x = upper bound' should pass.")]
        public void IsDoubleInRangeTest04()
        {
            Double a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsInRange on Double x with 'lower bound < x > upper bound' should fail.")]
        public void IsDoubleInRangeTest05()
        {
            Double a = Five;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsInRange on Double x with conditionDescription should pass.")]
        public void IsDoubleInRangeTest06()
        {
            Double a = Four;
            Condition.Requires(a).IsInRange(Two, Four, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsInRange on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleInRangeTest07()
        {
            Double a = Five;
            try
            {
                Condition.Requires(a, "a").IsInRange(Two, Four, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("abc a xyz");
            }
        }

        [Fact]
        [Description("Calling IsInRange on Double x with 'lower bound > x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsDoubleInRangeTest08()
        {
            Double a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsInRange(Two, Four);
        }

        #endregion // IsDoubleInRange

        #region IsDoubleNotInRange

        [Fact]
        [Description("Calling IsNotInRange on Double x with 'lower bound > x < upper bound' should pass.")]
        public void IsDoubleNotInRangeTest01()
        {
            Double a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsNotInRange on Double x with 'lower bound = x < upper bound' should fail.")]
        public void IsDoubleNotInRangeTest02()
        {
            Double a = Two;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsNotInRange on Double x with 'lower bound < x < upper bound' should fail.")]
        public void IsDoubleNotInRangeTest03()
        {
            Double a = Three;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsNotInRange on Double x with 'lower bound < x = upper bound' should fail.")]
        public void IsDoubleNotInRangeTest04()
        {
            Double a = Four;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsNotInRange on Double x with 'lower bound < x > upper bound' should pass.")]
        public void IsDoubleNotInRangeTest05()
        {
            Double a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsNotInRange on Double x with conditionDescription should pass.")]
        public void IsDoubleNotInRangeTest06()
        {
            Double a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotInRange on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleNotInRangeTest07()
        {
            Double a = Four;
            try
            {
                Condition.Requires(a, "a").IsNotInRange(Two, Four, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("abc a xyz");
            }
        }

        [Fact]
        [Description("Calling IsNotInRange on Double x with 'lower bound = x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsDoubleNotInRangeTest08()
        {
            Double a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInRange(Two, Four);
        }

        #endregion // IsDoubleNotInRange

        #region IsDoubleGreaterThan

        [Fact]
        [Description("Calling IsGreaterThan on Double x with 'lower bound < x' should fail.")]
        public void IsDoubleGreaterThanTest01()
        {
            Double a = One;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsGreaterThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsGreaterThan on Double x with 'lower bound = x' should fail.")]
        public void IsDoubleGreaterThanTest02()
        {
            Double a = Two;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsGreaterThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsGreaterThan on Double x with 'lower bound < x' should pass.")]
        public void IsDoubleGreaterThanTest03()
        {
            Double a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsGreaterThan on Double x with conditionDescription should pass.")]
        public void IsDoubleGreaterThanTest04()
        {
            Double a = Three;
            Condition.Requires(a).IsGreaterThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsGreaterThan on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleGreaterThanTest05()
        {
            Double a = Three;
            try
            {
                Condition.Requires(a, "a").IsGreaterThan(Three, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("abc a xyz");
            }
        }

        [Fact]
        [Description("Calling IsGreaterThan on Double x with 'lower bound < x' should succeed when exceptions are suppressed.")]
        public void IsDoubleGreaterThanTest06()
        {
            Double a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterThan(Two);
        }

        #endregion // IsDoubleGreaterThan

        #region IsDoubleNotGreaterThan

        [Fact]
        [Description("Calling IsNotGreaterThan on Double x with 'x < upper bound' should pass.")]
        public void IsDoubleNotGreaterThanTest01()
        {
            Double a = One;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on Double x with 'x = upper bound' should pass.")]
        public void IsDoubleNotGreaterThanTest02()
        {
            Double a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on Double x with 'x > upper bound' should fail.")]
        public void IsDoubleNotGreaterThanTest03()
        {
            Double a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on Double x with conditionDescription should pass.")]
        public void IsDoubleNotGreaterThanTest04()
        {
            Double a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotGreaterThan on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleNotGreaterThanTest05()
        {
            Double a = Three;
            try
            {
                Condition.Requires(a, "a").IsNotGreaterThan(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("abc a xyz");
            }
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on Double x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsDoubleNotGreaterThanTest06()
        {
            Double a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotGreaterThan(Two);
        }

        #endregion // IsDoubleNotGreaterThan

        #region IsDoubleGreaterOrEqual

        [Fact]
        [Description("Calling IsGreaterOrEqual on Double x with 'lower bound > x' should fail.")]
        public void IsDoubleGreaterOrEqualTest01()
        {
            Double a = One;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsGreaterOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Double x with 'lower bound = x' should pass.")]
        public void IsDoubleGreaterOrEqualTest02()
        {
            Double a = Two;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Double x with 'lower bound < x' should pass.")]
        public void IsDoubleGreaterOrEqualTest03()
        {
            Double a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Double x with conditionDescription should pass.")]
        public void IsDoubleGreaterOrEqualTest04()
        {
            Double a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsGreaterOrEqual on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleGreaterOrEqualTest05()
        {
            Double a = One;
            try
            {
                Condition.Requires(a, "a").IsGreaterOrEqual(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("abc a xyz");
            }
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Double x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsDoubleGreaterOrEqualTest06()
        {
            Double a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterOrEqual(Two);
        }

        #endregion // IsDoubleGreaterOrEqual

        #region IsDoubleNotGreaterOrEqual

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Double x with 'x < upper bound' should pass.")]
        public void IsDoubleNotGreaterOrEqualTest01()
        {
            Double a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Double x with 'x = upper bound' should fail.")]
        public void IsDoubleNotGreaterOrEqualTest02()
        {
            Double a = Two;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotGreaterOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Double x with 'x > upper bound' should fail.")]
        public void IsDoubleNotGreaterOrEqualTest03()
        {
            Double a = Three;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotGreaterOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Double x with conditionDescription should pass.")]
        public void IsDoubleNotGreaterOrEqualTest04()
        {
            Double a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotGreaterOrEqual on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleNotGreaterOrEqualTest05()
        {
            Double a = Three;
            try
            {
                Condition.Requires(a, "a").IsNotGreaterOrEqual(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("abc a xyz");
            }
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Double x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsDoubleNotGreaterOrEqualTest06()
        {
            Double a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotGreaterOrEqual(Two);
        }

        #endregion // IsDoubleNotGreaterOrEqual

        #region IsDoubleLessThan

        [Fact]
        [Description("Calling IsLessThan on Double x with 'x < upper bound' should pass.")]
        public void IsDoubleLessThanTest01()
        {
            Double a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [Fact]
        [Description("Calling IsLessThan on Double x with 'x = upper bound' should fail.")]
        public void IsDoubleLessThanTest02()
        {
            Double a = Two;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsLessThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsLessThan on Double x with 'x > upper bound' should fail.")]
        public void IsDoubleLessThanTest03()
        {
            Double a = Three;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsLessThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsLessThan on Double x with conditionDescription should pass.")]
        public void IsDoubleLessThanTest04()
        {
            Double a = Two;
            Condition.Requires(a).IsLessThan(Three, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsLessThan on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleLessThanTest05()
        {
            Double a = Three;
            try
            {
                Condition.Requires(a, "a").IsLessThan(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("abc a xyz");
            }
        }

        [Fact]
        [Description("Calling IsLessThan on Double x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsDoubleLessThanTest06()
        {
            Double a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessThan(Two);
        }

        #endregion // IsDoubleLessThan

        #region IsDoubleNotLessThan

        [Fact]
        [Description("Calling IsNotLessThan on Double x with 'lower bound > x' should fail.")]
        public void IsDoubleNotLessThanTest01()
        {
            Double a = One;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotLessThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotLessThan on Double x with 'lower bound = x' should pass.")]
        public void IsDoubleNotLessThanTest02()
        {
            Double a = Two;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [Fact]
        [Description("Calling IsNotLessThan on Double x with 'lower bound < x' should pass.")]
        public void IsDoubleNotLessThanTest03()
        {
            Double a = Three;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [Fact]
        [Description("Calling IsNotLessThan on Double x with conditionDescription should pass.")]
        public void IsDoubleNotLessThanTest04()
        {
            Double a = Two;
            Condition.Requires(a).IsNotLessThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotLessThan on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleNotLessThanTest05()
        {
            Double a = Two;
            try
            {
                Condition.Requires(a, "a").IsNotLessThan(Three, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("abc a xyz");
            }
        }

        [Fact]
        [Description("Calling IsNotLessThan on Double x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsDoubleNotLessThanTest06()
        {
            Double a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotLessThan(Two);
        }

        #endregion // IsDoubleNotLessThan

        #region IsDoubleLessOrEqual

        [Fact]
        [Description("Calling IsLessOrEqual on Double x with 'x < upper bound' should pass.")]
        public void IsDoubleLessOrEqualTest01()
        {
            Double a = One;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsLessOrEqual on Double x with 'x = upper bound' should pass.")]
        public void IsDoubleLessOrEqualTest02()
        {
            Double a = Two;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsLessOrEqual on Double x with 'x > upper bound' should fail.")]
        public void IsDoubleLessOrEqualTest03()
        {
            Double a = Three;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsLessOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsLessOrEqual on Double x with conditionDescription should pass.")]
        public void IsDoubleLessOrEqualTest04()
        {
            Double a = Two;
            Condition.Requires(a).IsLessOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsLessOrEqual on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleLessOrEqualTest05()
        {
            Double a = Three;
            try
            {
                Condition.Requires(a, "a").IsLessOrEqual(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("abc a xyz");
            }
        }

        [Fact]
        [Description("Calling IsLessOrEqual on Double x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsDoubleLessOrEqualTest06()
        {
            Double a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessOrEqual(Two);
        }

        #endregion // IsDoubleLessOrEqual

        #region IsDoubleNotLessOrEqual

        [Fact]
        [Description("Calling IsNotLessOrEqual on Double x with 'lower bound > x' should fail.")]
        public void IsDoubleNotLessOrEqualTest01()
        {
            Double a = One;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotLessOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on Double x with 'lower bound = x' should fail.")]
        public void IsDoubleNotLessOrEqualTest02()
        {
            Double a = Two;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotLessOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on Double x with 'lower bound < x' should pass.")]
        public void IsDoubleNotLessOrEqualTest03()
        {
            Double a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on Double x with conditionDescription should pass.")]
        public void IsDoubleNotLessOrEqualTest04()
        {
            Double a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotLessOrEqual on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleNotLessOrEqualTest05()
        {
            Double a = Two;
            try
            {
                Condition.Requires(a, "a").IsNotLessOrEqual(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("abc a xyz");
            }
        }

        [Fact]
        [Description(
            "Calling IsNotLessOrEqual on Double x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsDoubleNotLessOrEqualTest06()
        {
            Double a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotLessOrEqual(Two);
        }

        #endregion // IsNotLessOrEqual

        #region IsDoubleEqualTo

        [Fact]
        [Description("Calling IsEqualTo on Double x with 'x < other' should fail.")]
        public void IsDoubleEqualToTest01()
        {
            Double a = One;
            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsEqualTo(Two);
            });
        }

        [Fact]
        [Description("Calling IsEqualTo on Double x with 'x = other' should pass.")]
        public void IsDoubleEqualToTest02()
        {
            Double a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [Fact]
        [Description("Calling IsEqualTo on Double x with 'x > other' should fail.")]
        public void IsDoubleEqualToTest03()
        {
            Double a = Three;
            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsEqualTo(Two);
            });
        }

        [Fact]
        [Description("Calling IsEqualTo on Double x with conditionDescription should pass.")]
        public void IsDoubleEqualToTest04()
        {
            Double a = Two;
            Condition.Requires(a).IsEqualTo(Two, string.Empty);
        }

        [Fact]
        [Description(
            "Calling a failing IsEqualTo on Double should throw an Exception with an exception message that contains the given parameterized condition description argument."
            )]
        public void IsDoubleEqualToTest05()
        {
            Double a = Three;
            try
            {
                Condition.Requires(a, "a").IsEqualTo(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("abc a xyz");
            }
        }

        [Fact]
        [Description("Calling IsEqualTo on Double x with 'x < other' should succeed when exceptions are suppressed.")]
        public void IsDoubleEqualToTest06()
        {
            Double a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsEqualTo(Two);
        }

        #endregion // IsDoubleEqualTo

        #region IsDoubleNotEqualTo

        [Fact]
        [Description("Calling IsNotEqualTo on Double x with 'x < other' should pass.")]
        public void IsDoubleNotEqualToTest01()
        {
            Double a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [Fact]
        [Description("Calling IsNotEqualTo on Double x with 'x = other' should fail.")]
        public void IsDoubleNotEqualToTest02()
        {
            Double a = Two;
            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotEqualTo(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotEqualTo on Double x with 'x > other' should pass.")]
        public void IsDoubleNotEqualToTest03()
        {
            Double a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [Fact]
        [Description("Calling IsNotEqualTo on Double x with conditionDescription should pass.")]
        public void IsDoubleNotEqualToTest04()
        {
            Double a = Three;
            Condition.Requires(a).IsNotEqualTo(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotEqualTo on Double should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDoubleNotEqualToTest05()
        {
            Double a = Two;
            try
            {
                Condition.Requires(a, "a").IsNotEqualTo(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("abc a xyz");
            }
        }

        [Fact]
        [Description("Calling IsNotEqualTo on Double x with 'x = other' should succeed when exceptions are suppressed.")]
        public void IsDoubleNotEqualToTest06()
        {
            Double a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotEqualTo(Two);
        }

        #endregion // IsDoubleNotEqualTo
    }
}
