// NOTE: This file a copy of ValidatorExtensionTests.Compare.Base.cs with all occurrences of 'xxx' replaced
// with 'Int64'.

using System;
using System.ComponentModel;
using Envoice.Conditions;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests.CompareTests
{
    public class CompareInt64Tests
    {
        private static readonly Int64 One = 1;
        private static readonly Int64 Two = 2;
        private static readonly Int64 Three = 3;
        private static readonly Int64 Four = 4;
        private static readonly Int64 Five = 5;

        #region IsInt64InRange

        [Fact]
        [Description("Calling IsInRange on Int64 x with 'lower bound > x < upper bound' should fail.")]
        public void IsInt64InRangeTest01()
        {
            Int64 a = One;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsInRange on Int64 x with 'lower bound = x < upper bound' should pass.")]
        public void IsInt64InRangeTest02()
        {
            Int64 a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsInRange on Int64 x with 'lower bound < x < upper bound' should pass.")]
        public void IsInt64InRangeTest03()
        {
            Int64 a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsInRange on Int64 x with 'lower bound < x = upper bound' should pass.")]
        public void IsInt64InRangeTest04()
        {
            Int64 a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsInRange on Int64 x with 'lower bound < x > upper bound' should fail.")]
        public void IsInt64InRangeTest05()
        {
            Int64 a = Five;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsInRange on Int64 x with conditionDescription should pass.")]
        public void IsInt64InRangeTest06()
        {
            Int64 a = Four;
            Condition.Requires(a).IsInRange(Two, Four, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsInRange on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64InRangeTest07()
        {
            Int64 a = Five;
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
        [Description("Calling IsInRange on Int64 x with 'lower bound > x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt64InRangeTest08()
        {
            Int64 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsInRange(Two, Four);
        }

        #endregion // IsInt64InRange

        #region IsInt64NotInRange

        [Fact]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound > x < upper bound' should pass.")]
        public void IsInt64NotInRangeTest01()
        {
            Int64 a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound = x < upper bound' should fail.")]
        public void IsInt64NotInRangeTest02()
        {
            Int64 a = Two;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound < x < upper bound' should fail.")]
        public void IsInt64NotInRangeTest03()
        {
            Int64 a = Three;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound < x = upper bound' should fail.")]
        public void IsInt64NotInRangeTest04()
        {
            Int64 a = Four;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsNotInRange on Int64 x with 'lower bound < x > upper bound' should pass.")]
        public void IsInt64NotInRangeTest05()
        {
            Int64 a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsNotInRange on Int64 x with conditionDescription should pass.")]
        public void IsInt64NotInRangeTest06()
        {
            Int64 a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotInRange on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64NotInRangeTest07()
        {
            Int64 a = Four;
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
        [Description("Calling IsNotInRange on Int64 x with 'lower bound = x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt64NotInRangeTest08()
        {
            Int64 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInRange(Two, Four);
        }

        #endregion // IsInt64NotInRange

        #region IsInt64GreaterThan

        [Fact]
        [Description("Calling IsGreaterThan on Int64 x with 'lower bound < x' should fail.")]
        public void IsInt64GreaterThanTest01()
        {
            Int64 a = One;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsGreaterThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsGreaterThan on Int64 x with 'lower bound = x' should fail.")]
        public void IsInt64GreaterThanTest02()
        {
            Int64 a = Two;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsGreaterThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsGreaterThan on Int64 x with 'lower bound < x' should pass.")]
        public void IsInt64GreaterThanTest03()
        {
            Int64 a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsGreaterThan on Int64 x with conditionDescription should pass.")]
        public void IsInt64GreaterThanTest04()
        {
            Int64 a = Three;
            Condition.Requires(a).IsGreaterThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsGreaterThan on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64GreaterThanTest05()
        {
            Int64 a = Three;
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
        [Description("Calling IsGreaterThan on Int64 x with 'lower bound < x' should succeed when exceptions are suppressed.")]
        public void IsInt64GreaterThanTest06()
        {
            Int64 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterThan(Two);
        }

        #endregion // IsInt64GreaterThan

        #region IsInt64NotGreaterThan

        [Fact]
        [Description("Calling IsNotGreaterThan on Int64 x with 'x < upper bound' should pass.")]
        public void IsInt64NotGreaterThanTest01()
        {
            Int64 a = One;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on Int64 x with 'x = upper bound' should pass.")]
        public void IsInt64NotGreaterThanTest02()
        {
            Int64 a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on Int64 x with 'x > upper bound' should fail.")]
        public void IsInt64NotGreaterThanTest03()
        {
            Int64 a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on Int64 x with conditionDescription should pass.")]
        public void IsInt64NotGreaterThanTest04()
        {
            Int64 a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotGreaterThan on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64NotGreaterThanTest05()
        {
            Int64 a = Three;
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
        [Description("Calling IsNotGreaterThan on Int64 x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt64NotGreaterThanTest06()
        {
            Int64 a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotGreaterThan(Two);
        }

        #endregion // IsInt64NotGreaterThan

        #region IsInt64GreaterOrEqual

        [Fact]
        [Description("Calling IsGreaterOrEqual on Int64 x with 'lower bound > x' should fail.")]
        public void IsInt64GreaterOrEqualTest01()
        {
            Int64 a = One;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsGreaterOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Int64 x with 'lower bound = x' should pass.")]
        public void IsInt64GreaterOrEqualTest02()
        {
            Int64 a = Two;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Int64 x with 'lower bound < x' should pass.")]
        public void IsInt64GreaterOrEqualTest03()
        {
            Int64 a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Int64 x with conditionDescription should pass.")]
        public void IsInt64GreaterOrEqualTest04()
        {
            Int64 a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsGreaterOrEqual on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64GreaterOrEqualTest05()
        {
            Int64 a = One;
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
        [Description("Calling IsGreaterOrEqual on Int64 x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsInt64GreaterOrEqualTest06()
        {
            Int64 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterOrEqual(Two);
        }

        #endregion // IsInt64GreaterOrEqual

        #region IsInt64NotGreaterOrEqual

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Int64 x with 'x < upper bound' should pass.")]
        public void IsInt64NotGreaterOrEqualTest01()
        {
            Int64 a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Int64 x with 'x = upper bound' should fail.")]
        public void IsInt64NotGreaterOrEqualTest02()
        {
            Int64 a = Two;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotGreaterOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Int64 x with 'x > upper bound' should fail.")]
        public void IsInt64NotGreaterOrEqualTest03()
        {
            Int64 a = Three;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotGreaterOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Int64 x with conditionDescription should pass.")]
        public void IsInt64NotGreaterOrEqualTest04()
        {
            Int64 a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotGreaterOrEqual on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64NotGreaterOrEqualTest05()
        {
            Int64 a = Three;
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
        [Description("Calling IsNotGreaterOrEqual on Int64 x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt64NotGreaterOrEqualTest06()
        {
            Int64 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotGreaterOrEqual(Two);
        }

        #endregion // IsInt64NotGreaterOrEqual

        #region IsInt64LessThan

        [Fact]
        [Description("Calling IsLessThan on Int64 x with 'x < upper bound' should pass.")]
        public void IsInt64LessThanTest01()
        {
            Int64 a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [Fact]
        [Description("Calling IsLessThan on Int64 x with 'x = upper bound' should fail.")]
        public void IsInt64LessThanTest02()
        {
            Int64 a = Two;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsLessThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsLessThan on Int64 x with 'x > upper bound' should fail.")]
        public void IsInt64LessThanTest03()
        {
            Int64 a = Three;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsLessThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsLessThan on Int64 x with conditionDescription should pass.")]
        public void IsInt64LessThanTest04()
        {
            Int64 a = Two;
            Condition.Requires(a).IsLessThan(Three, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsLessThan on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64LessThanTest05()
        {
            Int64 a = Three;
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
        [Description("Calling IsLessThan on Int64 x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt64LessThanTest06()
        {
            Int64 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessThan(Two);
        }

        #endregion // IsInt64LessThan

        #region IsInt64NotLessThan

        [Fact]
        [Description("Calling IsNotLessThan on Int64 x with 'lower bound > x' should fail.")]
        public void IsInt64NotLessThanTest01()
        {
            Int64 a = One;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotLessThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotLessThan on Int64 x with 'lower bound = x' should pass.")]
        public void IsInt64NotLessThanTest02()
        {
            Int64 a = Two;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [Fact]
        [Description("Calling IsNotLessThan on Int64 x with 'lower bound < x' should pass.")]
        public void IsInt64NotLessThanTest03()
        {
            Int64 a = Three;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [Fact]
        [Description("Calling IsNotLessThan on Int64 x with conditionDescription should pass.")]
        public void IsInt64NotLessThanTest04()
        {
            Int64 a = Two;
            Condition.Requires(a).IsNotLessThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotLessThan on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64NotLessThanTest05()
        {
            Int64 a = Two;
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
        [Description("Calling IsNotLessThan on Int64 x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsInt64NotLessThanTest06()
        {
            Int64 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotLessThan(Two);
        }

        #endregion // IsInt64NotLessThan

        #region IsInt64LessOrEqual

        [Fact]
        [Description("Calling IsLessOrEqual on Int64 x with 'x < upper bound' should pass.")]
        public void IsInt64LessOrEqualTest01()
        {
            Int64 a = One;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsLessOrEqual on Int64 x with 'x = upper bound' should pass.")]
        public void IsInt64LessOrEqualTest02()
        {
            Int64 a = Two;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsLessOrEqual on Int64 x with 'x > upper bound' should fail.")]
        public void IsInt64LessOrEqualTest03()
        {
            Int64 a = Three;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsLessOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsLessOrEqual on Int64 x with conditionDescription should pass.")]
        public void IsInt64LessOrEqualTest04()
        {
            Int64 a = Two;
            Condition.Requires(a).IsLessOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsLessOrEqual on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64LessOrEqualTest05()
        {
            Int64 a = Three;
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
        [Description("Calling IsLessOrEqual on Int64 x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt64LessOrEqualTest06()
        {
            Int64 a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessOrEqual(Two);
        }

        #endregion // IsInt64LessOrEqual

        #region IsInt64NotLessOrEqual

        [Fact]
        [Description("Calling IsNotLessOrEqual on Int64 x with 'lower bound > x' should fail.")]
        public void IsInt64NotLessOrEqualTest01()
        {
            Int64 a = One;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotLessOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on Int64 x with 'lower bound = x' should fail.")]
        public void IsInt64NotLessOrEqualTest02()
        {
            Int64 a = Two;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotLessOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on Int64 x with 'lower bound < x' should pass.")]
        public void IsInt64NotLessOrEqualTest03()
        {
            Int64 a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on Int64 x with conditionDescription should pass.")]
        public void IsInt64NotLessOrEqualTest04()
        {
            Int64 a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotLessOrEqual on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64NotLessOrEqualTest05()
        {
            Int64 a = Two;
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
            "Calling IsNotLessOrEqual on Int64 x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsInt64NotLessOrEqualTest06()
        {
            Int64 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotLessOrEqual(Two);
        }

        #endregion // IsNotLessOrEqual

        #region IsInt64EqualTo

        [Fact]
        [Description("Calling IsEqualTo on Int64 x with 'x < other' should fail.")]
        public void IsInt64EqualToTest01()
        {
            Int64 a = One;
            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsEqualTo(Two);
            });
        }

        [Fact]
        [Description("Calling IsEqualTo on Int64 x with 'x = other' should pass.")]
        public void IsInt64EqualToTest02()
        {
            Int64 a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [Fact]
        [Description("Calling IsEqualTo on Int64 x with 'x > other' should fail.")]
        public void IsInt64EqualToTest03()
        {
            Int64 a = Three;
            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsEqualTo(Two);
            });
        }

        [Fact]
        [Description("Calling IsEqualTo on Int64 x with conditionDescription should pass.")]
        public void IsInt64EqualToTest04()
        {
            Int64 a = Two;
            Condition.Requires(a).IsEqualTo(Two, string.Empty);
        }

        [Fact]
        [Description(
            "Calling a failing IsEqualTo on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument."
            )]
        public void IsInt64EqualToTest05()
        {
            Int64 a = Three;
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
        [Description("Calling IsEqualTo on Int64 x with 'x < other' should succeed when exceptions are suppressed.")]
        public void IsInt64EqualToTest06()
        {
            Int64 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsEqualTo(Two);
        }

        #endregion // IsInt64EqualTo

        #region IsInt64NotEqualTo

        [Fact]
        [Description("Calling IsNotEqualTo on Int64 x with 'x < other' should pass.")]
        public void IsInt64NotEqualToTest01()
        {
            Int64 a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [Fact]
        [Description("Calling IsNotEqualTo on Int64 x with 'x = other' should fail.")]
        public void IsInt64NotEqualToTest02()
        {
            Int64 a = Two;
            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotEqualTo(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotEqualTo on Int64 x with 'x > other' should pass.")]
        public void IsInt64NotEqualToTest03()
        {
            Int64 a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [Fact]
        [Description("Calling IsNotEqualTo on Int64 x with conditionDescription should pass.")]
        public void IsInt64NotEqualToTest04()
        {
            Int64 a = Three;
            Condition.Requires(a).IsNotEqualTo(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotEqualTo on Int64 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt64NotEqualToTest05()
        {
            Int64 a = Two;
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
        [Description("Calling IsNotEqualTo on Int64 x with 'x = other' should succeed when exceptions are suppressed.")]
        public void IsInt64NotEqualToTest06()
        {
            Int64 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotEqualTo(Two);
        }

        #endregion // IsInt64NotEqualTo
    }
}
