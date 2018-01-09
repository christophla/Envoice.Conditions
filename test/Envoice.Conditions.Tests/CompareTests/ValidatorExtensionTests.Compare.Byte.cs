// NOTE: This file a copy of ValidatorExtensionTests.Compare.Base.cs with all occurrences of 'xxx' replaced
// with 'Byte'.

using System;
using System.ComponentModel;
using Envoice.Conditions;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests.CompareTests
{
    public class CompareByteTests
    {
        private static readonly Byte One = 1;
        private static readonly Byte Two = 2;
        private static readonly Byte Three = 3;
        private static readonly Byte Four = 4;
        private static readonly Byte Five = 5;

        #region IsByteInRange

        [Fact]
        [Description("Calling IsInRange on Byte x with 'lower bound > x < upper bound' should fail.")]
        public void IsByteInRangeTest01()
        {
            Byte a = One;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsInRange on Byte x with 'lower bound = x < upper bound' should pass.")]
        public void IsByteInRangeTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsInRange on Byte x with 'lower bound < x < upper bound' should pass.")]
        public void IsByteInRangeTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsInRange on Byte x with 'lower bound < x = upper bound' should pass.")]
        public void IsByteInRangeTest04()
        {
            Byte a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsInRange on Byte x with 'lower bound < x > upper bound' should fail.")]
        public void IsByteInRangeTest05()
        {
            Byte a = Five;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsInRange on Byte x with conditionDescription should pass.")]
        public void IsByteInRangeTest06()
        {
            Byte a = Four;
            Condition.Requires(a).IsInRange(Two, Four, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsInRange on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteInRangeTest07()
        {
            Byte a = Five;
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
        [Description("Calling IsInRange on Byte x with 'lower bound > x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsByteInRangeTest08()
        {
            Byte a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsInRange(Two, Four);
        }

        #endregion // IsByteInRange

        #region IsByteNotInRange

        [Fact]
        [Description("Calling IsNotInRange on Byte x with 'lower bound > x < upper bound' should pass.")]
        public void IsByteNotInRangeTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsNotInRange on Byte x with 'lower bound = x < upper bound' should fail.")]
        public void IsByteNotInRangeTest02()
        {
            Byte a = Two;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsNotInRange on Byte x with 'lower bound < x < upper bound' should fail.")]
        public void IsByteNotInRangeTest03()
        {
            Byte a = Three;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsNotInRange on Byte x with 'lower bound < x = upper bound' should fail.")]
        public void IsByteNotInRangeTest04()
        {
            Byte a = Four;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsNotInRange on Byte x with 'lower bound < x > upper bound' should pass.")]
        public void IsByteNotInRangeTest05()
        {
            Byte a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsNotInRange on Byte x with conditionDescription should pass.")]
        public void IsByteNotInRangeTest06()
        {
            Byte a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotInRange on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotInRangeTest07()
        {
            Byte a = Four;
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
        [Description("Calling IsNotInRange on Byte x with 'lower bound = x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsByteNotInRangeTest08()
        {
            Byte a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInRange(Two, Four);
        }

        #endregion // IsByteNotInRange

        #region IsByteGreaterThan

        [Fact]
        [Description("Calling IsGreaterThan on Byte x with 'lower bound < x' should fail.")]
        public void IsByteGreaterThanTest01()
        {
            Byte a = One;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsGreaterThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsGreaterThan on Byte x with 'lower bound = x' should fail.")]
        public void IsByteGreaterThanTest02()
        {
            Byte a = Two;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsGreaterThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsGreaterThan on Byte x with 'lower bound < x' should pass.")]
        public void IsByteGreaterThanTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsGreaterThan on Byte x with conditionDescription should pass.")]
        public void IsByteGreaterThanTest04()
        {
            Byte a = Three;
            Condition.Requires(a).IsGreaterThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsGreaterThan on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteGreaterThanTest05()
        {
            Byte a = Three;
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
        [Description("Calling IsGreaterThan on Byte x with 'lower bound < x' should succeed when exceptions are suppressed.")]
        public void IsByteGreaterThanTest06()
        {
            Byte a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterThan(Two);
        }

        #endregion // IsByteGreaterThan

        #region IsByteNotGreaterThan

        [Fact]
        [Description("Calling IsNotGreaterThan on Byte x with 'x < upper bound' should pass.")]
        public void IsByteNotGreaterThanTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on Byte x with 'x = upper bound' should pass.")]
        public void IsByteNotGreaterThanTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on Byte x with 'x > upper bound' should fail.")]
        public void IsByteNotGreaterThanTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on Byte x with conditionDescription should pass.")]
        public void IsByteNotGreaterThanTest04()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotGreaterThan on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotGreaterThanTest05()
        {
            Byte a = Three;
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
        [Description("Calling IsNotGreaterThan on Byte x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsByteNotGreaterThanTest06()
        {
            Byte a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotGreaterThan(Two);
        }

        #endregion // IsByteNotGreaterThan

        #region IsByteGreaterOrEqual

        [Fact]
        [Description("Calling IsGreaterOrEqual on Byte x with 'lower bound > x' should fail.")]
        public void IsByteGreaterOrEqualTest01()
        {
            Byte a = One;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsGreaterOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Byte x with 'lower bound = x' should pass.")]
        public void IsByteGreaterOrEqualTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Byte x with 'lower bound < x' should pass.")]
        public void IsByteGreaterOrEqualTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Byte x with conditionDescription should pass.")]
        public void IsByteGreaterOrEqualTest04()
        {
            Byte a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsGreaterOrEqual on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteGreaterOrEqualTest05()
        {
            Byte a = One;
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
        [Description("Calling IsGreaterOrEqual on Byte x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsByteGreaterOrEqualTest06()
        {
            Byte a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterOrEqual(Two);
        }

        #endregion // IsByteGreaterOrEqual

        #region IsByteNotGreaterOrEqual

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Byte x with 'x < upper bound' should pass.")]
        public void IsByteNotGreaterOrEqualTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Byte x with 'x = upper bound' should fail.")]
        public void IsByteNotGreaterOrEqualTest02()
        {
            Byte a = Two;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotGreaterOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Byte x with 'x > upper bound' should fail.")]
        public void IsByteNotGreaterOrEqualTest03()
        {
            Byte a = Three;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotGreaterOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Byte x with conditionDescription should pass.")]
        public void IsByteNotGreaterOrEqualTest04()
        {
            Byte a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotGreaterOrEqual on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotGreaterOrEqualTest05()
        {
            Byte a = Three;
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
        [Description("Calling IsNotGreaterOrEqual on Byte x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsByteNotGreaterOrEqualTest06()
        {
            Byte a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotGreaterOrEqual(Two);
        }

        #endregion // IsByteNotGreaterOrEqual

        #region IsByteLessThan

        [Fact]
        [Description("Calling IsLessThan on Byte x with 'x < upper bound' should pass.")]
        public void IsByteLessThanTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [Fact]
        [Description("Calling IsLessThan on Byte x with 'x = upper bound' should fail.")]
        public void IsByteLessThanTest02()
        {
            Byte a = Two;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsLessThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsLessThan on Byte x with 'x > upper bound' should fail.")]
        public void IsByteLessThanTest03()
        {
            Byte a = Three;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsLessThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsLessThan on Byte x with conditionDescription should pass.")]
        public void IsByteLessThanTest04()
        {
            Byte a = Two;
            Condition.Requires(a).IsLessThan(Three, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsLessThan on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteLessThanTest05()
        {
            Byte a = Three;
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
        [Description("Calling IsLessThan on Byte x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsByteLessThanTest06()
        {
            Byte a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessThan(Two);
        }

        #endregion // IsByteLessThan

        #region IsByteNotLessThan

        [Fact]
        [Description("Calling IsNotLessThan on Byte x with 'lower bound > x' should fail.")]
        public void IsByteNotLessThanTest01()
        {
            Byte a = One;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotLessThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotLessThan on Byte x with 'lower bound = x' should pass.")]
        public void IsByteNotLessThanTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [Fact]
        [Description("Calling IsNotLessThan on Byte x with 'lower bound < x' should pass.")]
        public void IsByteNotLessThanTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [Fact]
        [Description("Calling IsNotLessThan on Byte x with conditionDescription should pass.")]
        public void IsByteNotLessThanTest04()
        {
            Byte a = Two;
            Condition.Requires(a).IsNotLessThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotLessThan on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotLessThanTest05()
        {
            Byte a = Two;
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
        [Description("Calling IsNotLessThan on Byte x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsByteNotLessThanTest06()
        {
            Byte a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotLessThan(Two);
        }

        #endregion // IsByteNotLessThan

        #region IsByteLessOrEqual

        [Fact]
        [Description("Calling IsLessOrEqual on Byte x with 'x < upper bound' should pass.")]
        public void IsByteLessOrEqualTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsLessOrEqual on Byte x with 'x = upper bound' should pass.")]
        public void IsByteLessOrEqualTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsLessOrEqual on Byte x with 'x > upper bound' should fail.")]
        public void IsByteLessOrEqualTest03()
        {
            Byte a = Three;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsLessOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsLessOrEqual on Byte x with conditionDescription should pass.")]
        public void IsByteLessOrEqualTest04()
        {
            Byte a = Two;
            Condition.Requires(a).IsLessOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsLessOrEqual on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteLessOrEqualTest05()
        {
            Byte a = Three;
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
        [Description("Calling IsLessOrEqual on Byte x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsByteLessOrEqualTest06()
        {
            Byte a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessOrEqual(Two);
        }

        #endregion // IsByteLessOrEqual

        #region IsByteNotLessOrEqual

        [Fact]
        [Description("Calling IsNotLessOrEqual on Byte x with 'lower bound > x' should fail.")]
        public void IsByteNotLessOrEqualTest01()
        {
            Byte a = One;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotLessOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on Byte x with 'lower bound = x' should fail.")]
        public void IsByteNotLessOrEqualTest02()
        {
            Byte a = Two;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotLessOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on Byte x with 'lower bound < x' should pass.")]
        public void IsByteNotLessOrEqualTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on Byte x with conditionDescription should pass.")]
        public void IsByteNotLessOrEqualTest04()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotLessOrEqual on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotLessOrEqualTest05()
        {
            Byte a = Two;
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
            "Calling IsNotLessOrEqual on Byte x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsByteNotLessOrEqualTest06()
        {
            Byte a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotLessOrEqual(Two);
        }

        #endregion // IsNotLessOrEqual

        #region IsByteEqualTo

        [Fact]
        [Description("Calling IsEqualTo on Byte x with 'x < other' should fail.")]
        public void IsByteEqualToTest01()
        {
            Byte a = One;
            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsEqualTo(Two);
            });
        }

        [Fact]
        [Description("Calling IsEqualTo on Byte x with 'x = other' should pass.")]
        public void IsByteEqualToTest02()
        {
            Byte a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [Fact]
        [Description("Calling IsEqualTo on Byte x with 'x > other' should fail.")]
        public void IsByteEqualToTest03()
        {
            Byte a = Three;
            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsEqualTo(Two);
            });
        }

        [Fact]
        [Description("Calling IsEqualTo on Byte x with conditionDescription should pass.")]
        public void IsByteEqualToTest04()
        {
            Byte a = Two;
            Condition.Requires(a).IsEqualTo(Two, string.Empty);
        }

        [Fact]
        [Description(
            "Calling a failing IsEqualTo on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument."
            )]
        public void IsByteEqualToTest05()
        {
            Byte a = Three;
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
        [Description("Calling IsEqualTo on Byte x with 'x < other' should succeed when exceptions are suppressed.")]
        public void IsByteEqualToTest06()
        {
            Byte a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsEqualTo(Two);
        }

        #endregion // IsByteEqualTo

        #region IsByteNotEqualTo

        [Fact]
        [Description("Calling IsNotEqualTo on Byte x with 'x < other' should pass.")]
        public void IsByteNotEqualToTest01()
        {
            Byte a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [Fact]
        [Description("Calling IsNotEqualTo on Byte x with 'x = other' should fail.")]
        public void IsByteNotEqualToTest02()
        {
            Byte a = Two;
            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotEqualTo(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotEqualTo on Byte x with 'x > other' should pass.")]
        public void IsByteNotEqualToTest03()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [Fact]
        [Description("Calling IsNotEqualTo on Byte x with conditionDescription should pass.")]
        public void IsByteNotEqualToTest04()
        {
            Byte a = Three;
            Condition.Requires(a).IsNotEqualTo(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotEqualTo on Byte should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsByteNotEqualToTest05()
        {
            Byte a = Two;
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
        [Description("Calling IsNotEqualTo on Byte x with 'x = other' should succeed when exceptions are suppressed.")]
        public void IsByteNotEqualToTest06()
        {
            Byte a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotEqualTo(Two);
        }

        #endregion // IsByteNotEqualTo
    }
}
