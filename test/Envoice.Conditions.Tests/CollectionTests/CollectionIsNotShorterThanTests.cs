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
    /// Tests the ValidatorExtensions.IsNotShorterThan method.
    /// </summary>
    public class CollectionIsNotShorterThanTests
    {
        [Fact]
        [Description("Calling IsNotShorterThan(1) with a collection containing no elements should fail.")]
        public void CollectionIsNotShorterThanTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(set).IsNotShorterThan(1);
            });
        }

        [Fact]
        [Description("Calling IsNotShorterThan(0) with a collection containing no elements should pass.")]
        public void CollectionIsNotShorterThanTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsNotShorterThan(0);
        }

        [Fact]
        [Description("Calling IsNotShorterThan(-1) with a collection containing no elements should pass.")]
        public void CollectionIsNotShorterThanTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsNotShorterThan(-1);
        }

        [Fact]
        [Description("Calling IsNotShorterThan(2) with a collection containing one element should fail.")]
        public void CollectionIsNotShorterThanTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(set).IsNotShorterThan(2);
            });
        }

        [Fact]
        [Description("Calling IsNotShorterThan(1) with a collection containing one element should pass.")]
        public void CollectionIsNotShorterThanTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            Condition.Requires(set).IsNotShorterThan(1);
        }

        [Fact]
        [Description("Calling IsNotShorterThan(1) with an ArrayList containing one element should pass.")]
        public void CollectionIsNotShorterThanTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList { 1 };

            Condition.Requires(list).IsNotShorterThan(1);
        }

        [Fact]
        [Description("Calling IsNotShorterThan(1) with an ArrayList containing no elements should fail.")]
        public void CollectionIsNotShorterThanTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(list).IsNotShorterThan(1);
            });
        }

        [Fact]
        [Description("Calling IsNotShorterThan(0) on a null reference should pass.")]
        public void CollectionIsNotShorterThanTest08()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotShorterThan(0);
        }

        [Fact]
        [Description("Calling IsNotShorterThan(1) on a null reference should fail.")]
        public void CollectionIsNotShorterThanTest09()
        {
            IEnumerable list = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(list).IsNotShorterThan(1);
            });
        }

        [Fact]
        [Description("Calling IsNotShorterThan with the condtionDescription parameter should pass.")]
        public void CollectionIsNotShorterThanTest10()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsNotShorterThan(-1, string.Empty);
        }

        [Fact]
        [Description(
            "Calling a failing IsNotShorterThan should throw an Exception with an exception message that contains the given parameterized condition description argument."
            )]
        public void CollectionIsNotShorterThanTest11()
        {
            IEnumerable list = null;
            try
            {
                Condition.Requires(list, "list").IsNotShorterThan(1, "abc {0} def");
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("abc list def");
            }
        }

        [Fact]
        [Description(
            "Calling IsNotShorterThan(1) with a collection containing no elements should succeed when exceptions are suppressed."
            )]
        public void CollectionIsNotShorterThanTest12()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).SuppressExceptionsForTest().IsNotShorterThan(1);
        }
    }
}
