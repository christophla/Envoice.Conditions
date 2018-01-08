// NOTE: This file a copy of ValidatorExtensionTests.Compare.Base.cs with all occurrences of 'xxx' replaced
// with 'Int16'.

using System;
using System.ComponentModel;
using Envoice.Conditions;
using Xunit;

namespace Envoice.Conditions.Tests.CompareTests
{
    public class CompareInt16Tests
    {
        private static readonly Int16 One = 1;
        private static readonly Int16 Two = 2;
        private static readonly Int16 Three = 3;
        private static readonly Int16 Four = 4;
        private static readonly Int16 Five = 5;

        #region IsInt16InRange

        [Fact]
        [Description("Calling IsInRange on Int16 x with 'lower bound > x < upper bound' should fail.")]
        public void IsInt16InRangeTest01()
        {
            Int16 a = One;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsInRange on Int16 x with 'lower bound = x < upper bound' should pass.")]
        public void IsInt16InRangeTest02()
        {
            Int16 a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsInRange on Int16 x with 'lower bound < x < upper bound' should pass.")]
        public void IsInt16InRangeTest03()
        {
            Int16 a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsInRange on Int16 x with 'lower bound < x = upper bound' should pass.")]
        public void IsInt16InRangeTest04()
        {
            Int16 a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsInRange on Int16 x with 'lower bound < x > upper bound' should fail.")]
        public void IsInt16InRangeTest05()
        {
            Int16 a = Five;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsInRange on Int16 x with conditionDescription should pass.")]
        public void IsInt16InRangeTest06()
        {
            Int16 a = Four;
            Condition.Requires(a).IsInRange(Two, Four, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsInRange on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16InRangeTest07()
        {
            Int16 a = Five;
            try
            {
                Condition.Requires(a, "a").IsInRange(Two, Four, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsInRange on Int16 x with 'lower bound > x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt16InRangeTest08()
        {
            Int16 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsInRange(Two, Four);
        }

        #endregion // IsInt16InRange

        #region IsInt16NotInRange

        [Fact]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound > x < upper bound' should pass.")]
        public void IsInt16NotInRangeTest01()
        {
            Int16 a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound = x < upper bound' should fail.")]
        public void IsInt16NotInRangeTest02()
        {
            Int16 a = Two;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound < x < upper bound' should fail.")]
        public void IsInt16NotInRangeTest03()
        {
            Int16 a = Three;
            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound < x = upper bound' should fail.")]
        public void IsInt16NotInRangeTest04()
        {
            Int16 a = Four;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotInRange(Two, Four);
            });
        }

        [Fact]
        [Description("Calling IsNotInRange on Int16 x with 'lower bound < x > upper bound' should pass.")]
        public void IsInt16NotInRangeTest05()
        {
            Int16 a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsNotInRange on Int16 x with conditionDescription should pass.")]
        public void IsInt16NotInRangeTest06()
        {
            Int16 a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotInRange on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16NotInRangeTest07()
        {
            Int16 a = Four;
            try
            {
                Condition.Requires(a, "a").IsNotInRange(Two, Four, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description(
            "Calling IsNotInRange on Int16 x with 'lower bound = x < upper bound' should succeed when exceptions are suppressed."
            )]
        public void IsInt16NotInRangeTest08()
        {
            Int16 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInRange(Two, Four);
        }

        #endregion // IsInt16NotInRange

        #region IsInt16GreaterThan

        [Fact]
        [Description("Calling IsGreaterThan on Int16 x with 'lower bound < x' should fail.")]
        public void IsInt16GreaterThanTest01()
        {
            Int16 a = One;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsGreaterThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsGreaterThan on Int16 x with 'lower bound = x' should fail.")]
        public void IsInt16GreaterThanTest02()
        {
            Int16 a = Two;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsGreaterThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsGreaterThan on Int16 x with 'lower bound < x' should pass.")]
        public void IsInt16GreaterThanTest03()
        {
            Int16 a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsGreaterThan on Int16 x with conditionDescription should pass.")]
        public void IsInt16GreaterThanTest04()
        {
            Int16 a = Three;
            Condition.Requires(a).IsGreaterThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsGreaterThan on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16GreaterThanTest05()
        {
            Int16 a = Three;
            try
            {
                Condition.Requires(a, "a").IsGreaterThan(Three, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsGreaterThan on Int16 x with 'lower bound < x' should succeed when exceptions are suppressed.")]
        public void IsInt16GreaterThanTest06()
        {
            Int16 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterThan(Two);
        }

        #endregion // IsInt16GreaterThan

        #region IsInt16NotGreaterThan

        [Fact]
        [Description("Calling IsNotGreaterThan on Int16 x with 'x < upper bound' should pass.")]
        public void IsInt16NotGreaterThanTest01()
        {
            Int16 a = One;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on Int16 x with 'x = upper bound' should pass.")]
        public void IsInt16NotGreaterThanTest02()
        {
            Int16 a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on Int16 x with 'x > upper bound' should fail.")]
        public void IsInt16NotGreaterThanTest03()
        {
            Int16 a = Three;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotGreaterThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on Int16 x with conditionDescription should pass.")]
        public void IsInt16NotGreaterThanTest04()
        {
            Int16 a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotGreaterThan on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16NotGreaterThanTest05()
        {
            Int16 a = Three;
            try
            {
                Condition.Requires(a, "a").IsNotGreaterThan(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on Int16 x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt16NotGreaterThanTest06()
        {
            Int16 a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotGreaterThan(Two);
        }

        #endregion // IsInt16NotGreaterThan

        #region IsInt16GreaterOrEqual

        [Fact]
        [Description("Calling IsGreaterOrEqual on Int16 x with 'lower bound > x' should fail.")]
        public void IsInt16GreaterOrEqualTest01()
        {
            Int16 a = One;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsGreaterOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Int16 x with 'lower bound = x' should pass.")]
        public void IsInt16GreaterOrEqualTest02()
        {
            Int16 a = Two;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Int16 x with 'lower bound < x' should pass.")]
        public void IsInt16GreaterOrEqualTest03()
        {
            Int16 a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Int16 x with conditionDescription should pass.")]
        public void IsInt16GreaterOrEqualTest04()
        {
            Int16 a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsGreaterOrEqual on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16GreaterOrEqualTest05()
        {
            Int16 a = One;
            try
            {
                Condition.Requires(a, "a").IsGreaterOrEqual(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Int16 x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsInt16GreaterOrEqualTest06()
        {
            Int16 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterOrEqual(Two);
        }

        #endregion // IsInt16GreaterOrEqual

        #region IsInt16NotGreaterOrEqual

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Int16 x with 'x < upper bound' should pass.")]
        public void IsInt16NotGreaterOrEqualTest01()
        {
            Int16 a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Int16 x with 'x = upper bound' should fail.")]
        public void IsInt16NotGreaterOrEqualTest02()
        {
            Int16 a = Two;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotGreaterOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Int16 x with 'x > upper bound' should fail.")]
        public void IsInt16NotGreaterOrEqualTest03()
        {
            Int16 a = Three;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotGreaterOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Int16 x with conditionDescription should pass.")]
        public void IsInt16NotGreaterOrEqualTest04()
        {
            Int16 a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotGreaterOrEqual on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16NotGreaterOrEqualTest05()
        {
            Int16 a = Three;
            try
            {
                Condition.Requires(a, "a").IsNotGreaterOrEqual(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Int16 x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt16NotGreaterOrEqualTest06()
        {
            Int16 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotGreaterOrEqual(Two);
        }

        #endregion // IsInt16NotGreaterOrEqual

        #region IsInt16LessThan

        [Fact]
        [Description("Calling IsLessThan on Int16 x with 'x < upper bound' should pass.")]
        public void IsInt16LessThanTest01()
        {
            Int16 a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [Fact]
        [Description("Calling IsLessThan on Int16 x with 'x = upper bound' should fail.")]
        public void IsInt16LessThanTest02()
        {
            Int16 a = Two;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsLessThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsLessThan on Int16 x with 'x > upper bound' should fail.")]
        public void IsInt16LessThanTest03()
        {
            Int16 a = Three;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsLessThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsLessThan on Int16 x with conditionDescription should pass.")]
        public void IsInt16LessThanTest04()
        {
            Int16 a = Two;
            Condition.Requires(a).IsLessThan(Three, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsLessThan on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16LessThanTest05()
        {
            Int16 a = Three;
            try
            {
                Condition.Requires(a, "a").IsLessThan(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsLessThan on Int16 x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt16LessThanTest06()
        {
            Int16 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessThan(Two);
        }

        #endregion // IsInt16LessThan

        #region IsInt16NotLessThan

        [Fact]
        [Description("Calling IsNotLessThan on Int16 x with 'lower bound > x' should fail.")]
        public void IsInt16NotLessThanTest01()
        {
            Int16 a = One;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotLessThan(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotLessThan on Int16 x with 'lower bound = x' should pass.")]
        public void IsInt16NotLessThanTest02()
        {
            Int16 a = Two;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [Fact]
        [Description("Calling IsNotLessThan on Int16 x with 'lower bound < x' should pass.")]
        public void IsInt16NotLessThanTest03()
        {
            Int16 a = Three;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [Fact]
        [Description("Calling IsNotLessThan on Int16 x with conditionDescription should pass.")]
        public void IsInt16NotLessThanTest04()
        {
            Int16 a = Two;
            Condition.Requires(a).IsNotLessThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotLessThan on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16NotLessThanTest05()
        {
            Int16 a = Two;
            try
            {
                Condition.Requires(a, "a").IsNotLessThan(Three, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsNotLessThan on Int16 x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsInt16NotLessThanTest06()
        {
            Int16 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotLessThan(Two);
        }

        #endregion // IsInt16NotLessThan

        #region IsInt16LessOrEqual

        [Fact]
        [Description("Calling IsLessOrEqual on Int16 x with 'x < upper bound' should pass.")]
        public void IsInt16LessOrEqualTest01()
        {
            Int16 a = One;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsLessOrEqual on Int16 x with 'x = upper bound' should pass.")]
        public void IsInt16LessOrEqualTest02()
        {
            Int16 a = Two;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsLessOrEqual on Int16 x with 'x > upper bound' should fail.")]
        public void IsInt16LessOrEqualTest03()
        {
            Int16 a = Three;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsLessOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsLessOrEqual on Int16 x with conditionDescription should pass.")]
        public void IsInt16LessOrEqualTest04()
        {
            Int16 a = Two;
            Condition.Requires(a).IsLessOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsLessOrEqual on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16LessOrEqualTest05()
        {
            Int16 a = Three;
            try
            {
                Condition.Requires(a, "a").IsLessOrEqual(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsLessOrEqual on Int16 x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsInt16LessOrEqualTest06()
        {
            Int16 a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessOrEqual(Two);
        }

        #endregion // IsInt16LessOrEqual

        #region IsInt16NotLessOrEqual

        [Fact]
        [Description("Calling IsNotLessOrEqual on Int16 x with 'lower bound > x' should fail.")]
        public void IsInt16NotLessOrEqualTest01()
        {
            Int16 a = One;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotLessOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on Int16 x with 'lower bound = x' should fail.")]
        public void IsInt16NotLessOrEqualTest02()
        {
            Int16 a = Two;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Condition.Requires(a).IsNotLessOrEqual(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on Int16 x with 'lower bound < x' should pass.")]
        public void IsInt16NotLessOrEqualTest03()
        {
            Int16 a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on Int16 x with conditionDescription should pass.")]
        public void IsInt16NotLessOrEqualTest04()
        {
            Int16 a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotLessOrEqual on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16NotLessOrEqualTest05()
        {
            Int16 a = Two;
            try
            {
                Condition.Requires(a, "a").IsNotLessOrEqual(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description(
            "Calling IsNotLessOrEqual on Int16 x with 'lower bound > x' should succeed when exceptions are suppressed."
            )]
        public void IsInt16NotLessOrEqualTest06()
        {
            Int16 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotLessOrEqual(Two);
        }

        #endregion // IsNotLessOrEqual

        #region IsInt16EqualTo

        [Fact]
        [Description("Calling IsEqualTo on Int16 x with 'x < other' should fail.")]
        public void IsInt16EqualToTest01()
        {
            Int16 a = One;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsEqualTo(Two);
            });
        }

        [Fact]
        [Description("Calling IsEqualTo on Int16 x with 'x = other' should pass.")]
        public void IsInt16EqualToTest02()
        {
            Int16 a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [Fact]
        [Description("Calling IsEqualTo on Int16 x with 'x > other' should fail.")]
        public void IsInt16EqualToTest03()
        {
            Int16 a = Three;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsEqualTo(Two);
            });
        }

        [Fact]
        [Description("Calling IsEqualTo on Int16 x with conditionDescription should pass.")]
        public void IsInt16EqualToTest04()
        {
            Int16 a = Two;
            Condition.Requires(a).IsEqualTo(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsEqualTo on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16EqualToTest05()
        {
            Int16 a = Three;
            try
            {
                Condition.Requires(a, "a").IsEqualTo(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsEqualTo on Int16 x with 'x < other' should succeed when exceptions are suppressed.")]
        public void IsInt16EqualToTest06()
        {
            Int16 a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsEqualTo(Two);
        }

        #endregion // IsInt16EqualTo

        #region IsInt16NotEqualTo

        [Fact]
        [Description("Calling IsNotEqualTo on Int16 x with 'x < other' should pass.")]
        public void IsInt16NotEqualToTest01()
        {
            Int16 a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [Fact]
        [Description("Calling IsNotEqualTo on Int16 x with 'x = other' should fail.")]
        public void IsInt16NotEqualToTest02()
        {
            Int16 a = Two;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsNotEqualTo(Two);
            });
        }

        [Fact]
        [Description("Calling IsNotEqualTo on Int16 x with 'x > other' should pass.")]
        public void IsInt16NotEqualToTest03()
        {
            Int16 a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [Fact]
        [Description("Calling IsNotEqualTo on Int16 x with conditionDescription should pass.")]
        public void IsInt16NotEqualToTest04()
        {
            Int16 a = Three;
            Condition.Requires(a).IsNotEqualTo(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotEqualTo on Int16 should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsInt16NotEqualToTest05()
        {
            Int16 a = Two;
            try
            {
                Condition.Requires(a, "a").IsNotEqualTo(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsNotEqualTo on Int16 x with 'x = other' should succeed when exceptions are suppressed.")        ]
        public void IsInt16NotEqualToTest06()
        {
            Int16 a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotEqualTo(Two);
        }

        #endregion // IsInt16NotEqualTo
    }
}
