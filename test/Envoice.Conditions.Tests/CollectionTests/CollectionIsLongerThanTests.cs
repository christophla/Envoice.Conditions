using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Envoice.Conditions;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsLongerThan method.
    /// </summary>
    public class CollectionIsLongerThanTests
    {
        [Fact]
        [Description("Calling IsLongerThan(1) with a collection containing no elements should fail.")]
        public void CollectionIsLongerThanTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(set).IsLongerThan(1);
            });
        }

        [Fact]
        [Description("Calling IsLongerThan(0) with a collection containing no elements should fail.")]
        public void CollectionIsLongerThanTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(set).IsLongerThan(0);
            });
        }

        [Fact]
        [Description("Calling IsLongerThan(-1) with a collection containing no elements should pass.")]
        public void CollectionIsLongerThanTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsLongerThan(-1);
        }

        [Fact]
        [Description("Calling IsLongerThan(1) with a collection containing two element should pass.")]
        public void CollectionIsLongerThanTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1, 2 };

            Condition.Requires(set).IsLongerThan(1);
        }

        [Fact]
        [Description("Calling IsLongerThan(2) with a collection containing two elements should fail.")]
        public void CollectionIsLongerThanTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1, 2 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(set).IsLongerThan(2);
            });
        }

        [Fact]
        [Description("Calling IsLongerThan(1) with an ArrayList containing one element should fail.")]
        public void CollectionIsLongerThanTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList { 1 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(list).IsLongerThan(1);
            });
        }

        [Fact]
        [Description("Calling IsLongerThan(0) with an ArrayList containing one element should pass.")]
        public void CollectionIsLongerThanTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList { 1 };

            Condition.Requires(list).IsLongerThan(0);
        }

        [Fact]
        [Description("Calling IsLongerThan(-1) on a null reference should pass.")]
        public void CollectionIsLongerThanTest08()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsLongerThan(-1);
        }

        [Fact]
        [Description("Calling IsLongerThan(0) on a null reference should fail.")]
        public void CollectionIsLongerThanTest09()
        {
            IEnumerable list = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(list).IsLongerThan(0);
            });
        }

        [Fact]
        [Description("Calling IsLongerThan with the condtionDescription parameter should pass.")]
        public void CollectionIsLongerThanTest10()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsLongerThan(-1, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsLongerThan should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionIsLongerThanTest11()
        {
            IEnumerable list = null;
            try
            {
                Condition.Requires(list, "list").IsLongerThan(1, "abc {0} def");
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("abc list def");
            }
        }

        [Fact]
        [Description("Calling IsLongerThan(1) with a collection containing no elements should succeed when exceptions are suppressed.")]
        public void CollectionIsLongerThanTest12()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).SuppressExceptionsForTest().IsLongerThan(1);
        }
    }
}
