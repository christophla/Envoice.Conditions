﻿// NOTE: This file a copy of ValidatorExtensionTests.Compare.Base.cs with all occurrences of 'xxx' replaced
// with 'Decimal'.

using System;
using System.ComponentModel;
using Envoice.Conditions;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests.CompareTests
{
    public class CompareDecimalTests
    {
        private static readonly Decimal One = 1;
        private static readonly Decimal Two = 2;
        private static readonly Decimal Three = 3;
        private static readonly Decimal Four = 4;
        private static readonly Decimal Five = 5;

        #region IsDecimalInRange

        [Fact]
        [Description("Calling IsInRange on Decimal x with 'lower bound > x < upper bound' should fail.")]
        public void IsDecimalInRangeTest01()
        {
            Decimal a = One;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsInRange on Decimal x with 'lower bound = x < upper bound' should pass.")]
        public void IsDecimalInRangeTest02()
        {
            Decimal a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsInRange on Decimal x with 'lower bound < x < upper bound' should pass.")]
        public void IsDecimalInRangeTest03()
        {
            Decimal a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsInRange on Decimal x with 'lower bound < x = upper bound' should pass.")]
        public void IsDecimalInRangeTest04()
        {
            Decimal a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsInRange on Decimal x with 'lower bound < x > upper bound' should fail.")]
        public void IsDecimalInRangeTest05()
        {
            Decimal a = Five;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsInRange on Decimal x with conditionDescription should pass.")]
        public void IsDecimalInRangeTest06()
        {
            Decimal a = Four;
            Condition.Requires(a).IsInRange(Two, Four, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsInRange on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalInRangeTest07()
        {
            Decimal a = Five;
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
        [Description("Calling IsInRange on Decimal x with 'lower bound > x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsDecimalInRangeTest08()
        {
            Decimal a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsInRange(Two, Four);
        }

        #endregion // IsDecimalInRange

        #region IsDecimalNotInRange

        [Fact]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound > x < upper bound' should pass.")]
        public void IsDecimalNotInRangeTest01()
        {
            Decimal a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound = x < upper bound' should fail.")]
        public void IsDecimalNotInRangeTest02()
        {
            Decimal a = Two;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound < x < upper bound' should fail.")]
        public void IsDecimalNotInRangeTest03()
        {
            Decimal a = Three;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound < x = upper bound' should fail.")]
        public void IsDecimalNotInRangeTest04()
        {
            Decimal a = Four;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound < x > upper bound' should pass.")]
        public void IsDecimalNotInRangeTest05()
        {
            Decimal a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsNotInRange on Decimal x with conditionDescription should pass.")]
        public void IsDecimalNotInRangeTest06()
        {
            Decimal a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotInRange on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalNotInRangeTest07()
        {
            Decimal a = Four;
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
        [Description("Calling IsNotInRange on Decimal x with 'lower bound = x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsDecimalNotInRangeTest08()
        {
            Decimal a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInRange(Two, Four);
        }

        #endregion // IsDecimalNotInRange

        #region IsDecimalGreaterThan

        [Fact]
        [Description("Calling IsGreaterThan on Decimal x with 'lower bound < x' should fail.")]
        public void IsDecimalGreaterThanTest01()
        {
            Decimal a = One;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsGreaterThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsGreaterThan on Decimal x with 'lower bound = x' should fail.")]
        public void IsDecimalGreaterThanTest02()
        {
            Decimal a = Two;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsGreaterThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsGreaterThan on Decimal x with 'lower bound < x' should pass.")]
        public void IsDecimalGreaterThanTest03()
        {
            Decimal a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsGreaterThan on Decimal x with conditionDescription should pass.")]
        public void IsDecimalGreaterThanTest04()
        {
            Decimal a = Three;
            Condition.Requires(a).IsGreaterThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsGreaterThan on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalGreaterThanTest05()
        {
            Decimal a = Three;
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
        [Description("Calling IsGreaterThan on Decimal x with 'lower bound < x' should succeed when exceptions are suppressed.")]
        public void IsDecimalGreaterThanTest06()
        {
            Decimal a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterThan(Two);
        }

        #endregion // IsDecimalGreaterThan

        #region IsDecimalNotGreaterThan

        [Fact]
        [Description("Calling IsNotGreaterThan on Decimal x with 'x < upper bound' should pass.")]
        public void IsDecimalNotGreaterThanTest01()
        {
            Decimal a = One;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on Decimal x with 'x = upper bound' should pass.")]
        public void IsDecimalNotGreaterThanTest02()
        {
            Decimal a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on Decimal x with 'x > upper bound' should fail.")]
        public void IsDecimalNotGreaterThanTest03()
        {
            Decimal a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on Decimal x with conditionDescription should pass.")]
        public void IsDecimalNotGreaterThanTest04()
        {
            Decimal a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotGreaterThan on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalNotGreaterThanTest05()
        {
            Decimal a = Three;
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
        [Description("Calling IsNotGreaterThan on Decimal x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsDecimalNotGreaterThanTest06()
        {
            Decimal a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotGreaterThan(Two);
        }

        #endregion // IsDecimalNotGreaterThan

        #region IsDecimalGreaterOrEqual

        [Fact]
        [Description("Calling IsGreaterOrEqual on Decimal x with 'lower bound > x' should fail.")]
        public void IsDecimalGreaterOrEqualTest01()
        {
            Decimal a = One;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsGreaterOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Decimal x with 'lower bound = x' should pass.")]
        public void IsDecimalGreaterOrEqualTest02()
        {
            Decimal a = Two;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Decimal x with 'lower bound < x' should pass.")]
        public void IsDecimalGreaterOrEqualTest03()
        {
            Decimal a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Decimal x with conditionDescription should pass.")]
        public void IsDecimalGreaterOrEqualTest04()
        {
            Decimal a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsGreaterOrEqual on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalGreaterOrEqualTest05()
        {
            Decimal a = One;
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
        [Description("Calling IsGreaterOrEqual on Decimal x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsDecimalGreaterOrEqualTest06()
        {
            Decimal a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterOrEqual(Two);
        }

        #endregion // IsDecimalGreaterOrEqual

        #region IsDecimalNotGreaterOrEqual

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Decimal x with 'x < upper bound' should pass.")]
        public void IsDecimalNotGreaterOrEqualTest01()
        {
            Decimal a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Decimal x with 'x = upper bound' should fail.")]
        public void IsDecimalNotGreaterOrEqualTest02()
        {
            Decimal a = Two;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotGreaterOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Decimal x with 'x > upper bound' should fail.")]
        public void IsDecimalNotGreaterOrEqualTest03()
        {
            Decimal a = Three;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotGreaterOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Decimal x with conditionDescription should pass.")]
        public void IsDecimalNotGreaterOrEqualTest04()
        {
            Decimal a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotGreaterOrEqual on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalNotGreaterOrEqualTest05()
        {
            Decimal a = Three;
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
        [Description("Calling IsNotGreaterOrEqual on Decimal x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsDecimalNotGreaterOrEqualTest06()
        {
            Decimal a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotGreaterOrEqual(Two);
        }

        #endregion // IsDecimalNotGreaterOrEqual

        #region IsDecimalLessThan

        [Fact]
        [Description("Calling IsLessThan on Decimal x with 'x < upper bound' should pass.")]
        public void IsDecimalLessThanTest01()
        {
            Decimal a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [Fact]
        [Description("Calling IsLessThan on Decimal x with 'x = upper bound' should fail.")]
        public void IsDecimalLessThanTest02()
        {
            Decimal a = Two;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsLessThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsLessThan on Decimal x with 'x > upper bound' should fail.")]
        public void IsDecimalLessThanTest03()
        {
            Decimal a = Three;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsLessThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsLessThan on Decimal x with conditionDescription should pass.")]
        public void IsDecimalLessThanTest04()
        {
            Decimal a = Two;
            Condition.Requires(a).IsLessThan(Three, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsLessThan on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalLessThanTest05()
        {
            Decimal a = Three;
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
        [Description("Calling IsLessThan on Decimal x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsDecimalLessThanTest06()
        {
            Decimal a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessThan(Two);
        }

        #endregion // IsDecimalLessThan

        #region IsDecimalNotLessThan

        [Fact]
        [Description("Calling IsNotLessThan on Decimal x with 'lower bound > x' should fail.")]
        public void IsDecimalNotLessThanTest01()
        {
            Decimal a = One;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotLessThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotLessThan on Decimal x with 'lower bound = x' should pass.")]
        public void IsDecimalNotLessThanTest02()
        {
            Decimal a = Two;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [Fact]
        [Description("Calling IsNotLessThan on Decimal x with 'lower bound < x' should pass.")]
        public void IsDecimalNotLessThanTest03()
        {
            Decimal a = Three;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [Fact]
        [Description("Calling IsNotLessThan on Decimal x with conditionDescription should pass.")]
        public void IsDecimalNotLessThanTest04()
        {
            Decimal a = Two;
            Condition.Requires(a).IsNotLessThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotLessThan on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalNotLessThanTest05()
        {
            Decimal a = Two;
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
        [Description("Calling IsNotLessThan on Decimal x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsDecimalNotLessThanTest06()
        {
            Decimal a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotLessThan(Two);
        }

        #endregion // IsDecimalNotLessThan

        #region IsDecimalLessOrEqual

        [Fact]
        [Description("Calling IsLessOrEqual on Decimal x with 'x < upper bound' should pass.")]
        public void IsDecimalLessOrEqualTest01()
        {
            Decimal a = One;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsLessOrEqual on Decimal x with 'x = upper bound' should pass.")]
        public void IsDecimalLessOrEqualTest02()
        {
            Decimal a = Two;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsLessOrEqual on Decimal x with 'x > upper bound' should fail.")]
        public void IsDecimalLessOrEqualTest03()
        {
            Decimal a = Three;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsLessOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsLessOrEqual on Decimal x with conditionDescription should pass.")]
        public void IsDecimalLessOrEqualTest04()
        {
            Decimal a = Two;
            Condition.Requires(a).IsLessOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsLessOrEqual on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalLessOrEqualTest05()
        {
            Decimal a = Three;
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
        [Description("Calling IsLessOrEqual on Decimal x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsDecimalLessOrEqualTest06()
        {
            Decimal a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessOrEqual(Two);
        }

        #endregion // IsDecimalLessOrEqual

        #region IsDecimalNotLessOrEqual

        [Fact]
        [Description("Calling IsNotLessOrEqual on Decimal x with 'lower bound > x' should fail.")]
        public void IsDecimalNotLessOrEqualTest01()
        {
            Decimal a = One;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotLessOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on Decimal x with 'lower bound = x' should fail.")]
        public void IsDecimalNotLessOrEqualTest02()
        {
            Decimal a = Two;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotLessOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on Decimal x with 'lower bound < x' should pass.")]
        public void IsDecimalNotLessOrEqualTest03()
        {
            Decimal a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on Decimal x with conditionDescription should pass.")]
        public void IsDecimalNotLessOrEqualTest04()
        {
            Decimal a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotLessOrEqual on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalNotLessOrEqualTest05()
        {
            Decimal a = Two;
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
            "Calling IsNotLessOrEqual on Decimal x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsDecimalNotLessOrEqualTest06()
        {
            Decimal a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotLessOrEqual(Two);
        }

        #endregion // IsNotLessOrEqual

        #region IsDecimalEqualTo

        [Fact]
        [Description("Calling IsEqualTo on Decimal x with 'x < other' should fail.")]
        public void IsDecimalEqualToTest01()
        {
            Decimal a = One;
            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsEqualTo(Two);
            });
        }

        [Fact]
        [Description("Calling IsEqualTo on Decimal x with 'x = other' should pass.")]
        public void IsDecimalEqualToTest02()
        {
            Decimal a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [Fact]
        [Description("Calling IsEqualTo on Decimal x with 'x > other' should fail.")]
        public void IsDecimalEqualToTest03()
        {
            Decimal a = Three;
            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsEqualTo(Two);
            });
        }

        [Fact]
        [Description("Calling IsEqualTo on Decimal x with conditionDescription should pass.")]
        public void IsDecimalEqualToTest04()
        {
            Decimal a = Two;
            Condition.Requires(a).IsEqualTo(Two, string.Empty);
        }

        [Fact]
        [Description(
            "Calling a failing IsEqualTo on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument."
            )]
        public void IsDecimalEqualToTest05()
        {
            Decimal a = Three;
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
        [Description("Calling IsEqualTo on Decimal x with 'x < other' should succeed when exceptions are suppressed.")]
        public void IsDecimalEqualToTest06()
        {
            Decimal a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsEqualTo(Two);
        }

        #endregion // IsDecimalEqualTo

        #region IsDecimalNotEqualTo

        [Fact]
        [Description("Calling IsNotEqualTo on Decimal x with 'x < other' should pass.")]
        public void IsDecimalNotEqualToTest01()
        {
            Decimal a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [Fact]
        [Description("Calling IsNotEqualTo on Decimal x with 'x = other' should fail.")]
        public void IsDecimalNotEqualToTest02()
        {
            Decimal a = Two;
            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotEqualTo(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotEqualTo on Decimal x with 'x > other' should pass.")]
        public void IsDecimalNotEqualToTest03()
        {
            Decimal a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [Fact]
        [Description("Calling IsNotEqualTo on Decimal x with conditionDescription should pass.")]
        public void IsDecimalNotEqualToTest04()
        {
            Decimal a = Three;
            Condition.Requires(a).IsNotEqualTo(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotEqualTo on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalNotEqualToTest05()
        {
            Decimal a = Two;
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
        [Description("Calling IsNotEqualTo on Decimal x with 'x = other' should succeed when exceptions are suppressed.")]
        public void IsDecimalNotEqualToTest06()
        {
            Decimal a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotEqualTo(Two);
        }

        #endregion // IsDecimalNotEqualTo
    }
}
