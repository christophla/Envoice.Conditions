using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Envoice.Conditions;
using Xunit;

namespace Envoice.Conditions.Tests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsLongerOrEqual method.
    /// </summary>
    public class CollectionIsLongerOrEqualTests
    {
        [Fact]
        [Description("Calling IsLongerOrEqual(1) with a collection containing no elements should fail.")]
        public void CollectionIsLongerOrEqualTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(set).IsLongerOrEqual(1);
            });
        }

        [Fact]
        [Description("Calling IsLongerOrEqual(0) with a collection containing no elements should pass.")]
        public void CollectionIsLongerOrEqualTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsLongerOrEqual(0);
        }

        [Fact]
        [Description("Calling IsLongerOrEqual(-1) with a collection containing no elements should pass.")]
        public void CollectionIsLongerOrEqualTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsLongerOrEqual(-1);
        }

        [Fact]
        [Description("Calling IsLongerOrEqual(1) with a collection containing one element should pass.")]
        public void CollectionIsLongerOrEqualTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            Condition.Requires(set).IsLongerOrEqual(1);
        }

        [Fact]
        [Description("Calling IsLongerOrEqual(0) with a collection containing one element should pass.")]
        public void CollectionIsLongerOrEqualTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            Condition.Requires(set).IsLongerOrEqual(0);
        }

        [Fact]
        [Description("Calling IsLongerOrEqual(1) with an ArrayList containing one element should pass.")]
        public void CollectionIsLongerOrEqualTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList { 1 };

            Condition.Requires(list).IsLongerOrEqual(1);
        }

        [Fact]
        [Description("Calling IsLongerOrEqual(2) with an ArrayList containing one element should fail.")]
        public void CollectionIsLongerOrEqualTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList { 1 };

            Condition.Requires(list).IsLongerOrEqual(1);
        }

        [Fact]
        [Description("Calling IsLongerOrEqual(0) on a null reference should pass.")]
        public void CollectionIsLongerOrEqualTest08()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsLongerOrEqual(0);
        }

        [Fact]
        [Description("Calling IsLongerOrEqual(1) on a null reference should fail.")]
        public void CollectionIsLongerOrEqualTest09()
        {
            IEnumerable list = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(list).IsLongerOrEqual(1);
            });
        }

        [Fact]
        [Description("Calling IsLongerOrEqual with the condtionDescription parameter should pass.")]
        public void CollectionIsLongerOrEqualTest10()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsLongerOrEqual(0, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsLongerOrEqual should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionIsLongerOrEqualTest11()
        {
            IEnumerable list = null;
            try
            {
                Condition.Requires(list, "list").IsLongerOrEqual(1, "abc {0} def");
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc list def"));
            }
        }

        [Fact]
        [Description("Calling IsLongerOrEqual(1) with a collection containing no elements should succeed when exceptions are suppressed.")]
        public void CollectionIsLongerOrEqualTest12()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).SuppressExceptionsForTest().IsLongerOrEqual(1);
        }
    }
}
