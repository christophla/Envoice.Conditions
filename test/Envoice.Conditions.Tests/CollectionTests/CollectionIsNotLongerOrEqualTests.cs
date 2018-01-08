using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Envoice.Conditions;
using Xunit;

namespace Envoice.Conditions.Tests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNotLongerOrEqual method.
    /// </summary>
    public class CollectionIsNotLongerOrEqualTests
    {
        [Fact]
        [Description("Calling IsNotLongerOrEqual(1) with a collection containing no elements should pass.")]
        public void CollectionIsNotLongerOrEqualTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsNotLongerOrEqual(1);
        }

        [Fact]
        [Description("Calling IsNotLongerOrEqual(0) with a collection containing no elements should fail.")]
        public void CollectionIsNotLongerOrEqualTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(set).IsNotLongerOrEqual(0);
            });
        }

        [Fact]
        [Description("Calling IsNotLongerOrEqual(-1) with a collection containing no elements should fail.")]
        public void CollectionIsNotLongerOrEqualTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(set).IsNotLongerOrEqual(-1);
            });
        }

        [Fact]
        [Description("Calling IsNotLongerOrEqual(1) with a collection containing one element should fail.")]
        public void CollectionIsNotLongerOrEqualTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(set).IsNotLongerOrEqual(1);
            });
        }

        [Fact]
        [Description("Calling IsNotLongerOrEqual(0) with a collection containing one element should fail.")]
        public void CollectionIsNotLongerOrEqualTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(set).IsNotLongerOrEqual(0);
            });
        }

        [Fact]
        [Description("Calling IsNotLongerOrEqual(1) with an ArrayList containing one element should fail.")]
        public void CollectionIsNotLongerOrEqualTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList { 1 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(list).IsNotLongerOrEqual(1);
            });
        }

        [Fact]
        [Description("Calling IsNotLongerOrEqual(2) with an ArrayList containing one element should pass.")]
        public void CollectionIsNotLongerOrEqualTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList { 1 };

            Condition.Requires(list).IsNotLongerOrEqual(2);
        }

        [Fact]
        [Description("Calling IsNotLongerOrEqual(1) on a null reference should pass.")]
        public void CollectionIsNotLongerOrEqualTest08()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotLongerOrEqual(1);
        }

        [Fact]
        [Description("Calling IsNotLongerOrEqual(0) on a null reference should fail.")]
        public void CollectionIsNotLongerOrEqualTest09()
        {
            IEnumerable list = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(list).IsNotLongerOrEqual(0);
            });
        }

        [Fact]
        [Description("Calling IsNotLongerOrEqual with the condtionDescription parameter should pass.")]
        public void CollectionIsNotLongerOrEqualTest10()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotLongerOrEqual(1, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotLongerOrEqual should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionIsNotLongerOrEqualTest11()
        {
            IEnumerable list = null;
            try
            {
                Condition.Requires(list, "list").IsNotLongerOrEqual(0, "abc {0} def");
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc list def"));
            }
        }

        [Fact]
        [Description("Calling IsNotLongerOrEqual(0) with a collection containing no elements should succeed when exceptions are suppressed.")]
        public void CollectionIsNotLongerOrEqualTest12()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).SuppressExceptionsForTest().IsNotLongerOrEqual(0);
        }
    }
}
