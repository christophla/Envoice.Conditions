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
    /// Tests the ValidatorExtensions.IsShorterThan method.
    /// </summary>
    public class CollectionIsShorterThanTests
    {
        [Fact]
        [Description("Calling IsShorterThan(1) with a collection containing no elements should pass.")]
        public void CollectionIsShorterThanTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsShorterThan(1);
        }

        [Fact]
        [Description("Calling IsShorterThan(0) with a collection containing no elements should fail.")]
        public void CollectionIsShorterThanTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(set).IsShorterThan(0);
            });
        }

        [Fact]
        [Description("Calling IsShorterThan(-1) with a collection containing no elements should fail.")]
        public void CollectionIsShorterThanTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(set).IsShorterThan(-1);
            });
        }

        [Fact]
        [Description("Calling IsShorterThan(2) with a collection containing one element should pass.")]
        public void CollectionIsShorterThanTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            Condition.Requires(set).IsShorterThan(2);
        }

        [Fact]
        [Description("Calling IsShorterThan(1) with a collection containing one element should fail.")]
        public void CollectionIsShorterThanTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(set).IsShorterThan(1);
            });
        }

        [Fact]
        [Description("Calling IsShorterThan(1) with an ArrayList containing one element should fail.")]
        public void CollectionIsShorterThanTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList { 1 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(list).IsShorterThan(1);
            });
        }

        [Fact]
        [Description("Calling IsShorterThan(1) with an ArrayList containing no elements should pass.")]
        public void CollectionIsShorterThanTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            Condition.Requires(list).IsShorterThan(1);
        }

        [Fact]
        [Description("Calling IsShorterThan(1) on a null reference should pass.")]
        public void CollectionIsShorterThanTest08()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsShorterThan(1);
        }

        [Fact]
        [Description("Calling IsShorterThan(0) on a null reference should fail.")]
        public void CollectionIsShorterThanTest09()
        {
            IEnumerable list = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(list).IsShorterThan(0);
            });
        }

        [Fact]
        [Description("Calling IsShorterThan with the condtionDescription parameter should pass.")]
        public void CollectionIsShorterThanTest10()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsShorterThan(1, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsShorterThan should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionIsShorterThanTest11()
        {
            IEnumerable list = null;
            try
            {
                Condition.Requires(list, "list").IsShorterThan(0, "abc {0} def");
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("abc list def");
            }
        }

        [Fact]
        [Description("Calling IsShorterThan(0) with a collection containing no elements should succeed when exceptions are suppressed.")]
        public void CollectionIsShorterThanTest12()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).SuppressExceptionsForTest().IsShorterThan(0);
        }
    }
}
