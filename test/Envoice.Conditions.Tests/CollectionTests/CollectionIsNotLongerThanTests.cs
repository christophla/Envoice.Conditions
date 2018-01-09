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
    /// Tests the ValidatorExtensions.IsNotLongerThan method.
    /// </summary>
    public class CollectionIsNotLongerThanTests
    {
        [Fact]
        [Description("Calling IsNotLongerThan(1) with a collection containing no elements should pass.")]
        public void CollectionIsNotLongerThanTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsNotLongerThan(1);
        }

        [Fact]
        [Description("Calling IsNotLongerThan(0) with a collection containing no elements should pass.")]
        public void CollectionIsNotLongerThanTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsNotLongerThan(0);
        }

        [Fact]
        [Description("Calling IsNotLongerThan(-1) with a collection containing no elements should fail.")]
        public void CollectionIsNotLongerThanTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(set).IsNotLongerThan(-1);
            });
        }

        [Fact]
        [Description("Calling IsNotLongerThan(1) with a collection containing two element should fail.")]
        public void CollectionIsNotLongerThanTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1, 2 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(set).IsNotLongerThan(1);
            });
        }

        [Fact]
        [Description("Calling IsNotLongerThan(2) with a collection containing two elements should pass.")]
        public void CollectionIsNotLongerThanTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1, 2 };

            Condition.Requires(set).IsNotLongerThan(2);
        }

        [Fact]
        [Description("Calling IsNotLongerThan(1) with an ArrayList containing one element should pass.")]
        public void CollectionIsNotLongerThanTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList { 1 };

            Condition.Requires(list).IsNotLongerThan(1);
        }

        [Fact]
        [Description("Calling IsNotLongerThan(0) with an ArrayList containing one element should fail.")]
        public void CollectionIsNotLongerThanTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList { 1 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(list).IsNotLongerThan(0);
            });
        }

        [Fact]
        [Description("Calling IsNotLongerThan(0) on a null reference should pass.")]
        public void CollectionIsNotLongerThanTest08()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotLongerThan(0);
        }

        [Fact]
        [Description("Calling IsNotLongerThan(-1) on a null reference should fail.")]
        public void CollectionIsNotLongerThanTest09()
        {
            IEnumerable list = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(list).IsNotLongerThan(-1);
            });
        }

        [Fact]
        [Description("Calling IsNotLongerThan with the condtionDescription parameter should pass.")]
        public void CollectionIsNotLongerThanTest10()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotLongerThan(1, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotLongerThan should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionIsNotLongerThanTest11()
        {
            IEnumerable list = null;
            try
            {
                Condition.Requires(list, "list").IsNotLongerThan(-1, "abc {0} def");
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("abc list def");
            }
        }

        [Fact]
        [Description("Calling IsNotLongerThan(-1) with a collection containing no elements should succeed when exceptions are suppressed.")]
        public void CollectionIsNotLongerThanTest12()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).SuppressExceptionsForTest().IsNotLongerThan(-1);
        }
    }
}
