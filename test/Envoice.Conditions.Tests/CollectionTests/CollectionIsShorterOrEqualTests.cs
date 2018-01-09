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
    /// Tests the ValidatorExtensions.IsShorterOrEqual method.
    /// </summary>
    public class CollectionIsShorterOrEqualTests
    {
        [Fact]
        [Description("Calling IsShorterOrEqual(1) with a collection containing no elements should pass.")]
        public void CollectionIsShorterOrEqualTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsShorterOrEqual(1);
        }

        [Fact]
        [Description("Calling IsShorterOrEqual(0) with a collection containing no elements should pass.")]
        public void CollectionIsShorterOrEqualTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsShorterOrEqual(0);
        }

        [Fact]
        [Description("Calling IsShorterOrEqual(-1) with a collection containing no elements should fail.")]
        public void CollectionIsShorterOrEqualTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(set).IsShorterOrEqual(-1);
            });
        }

        [Fact]
        [Description("Calling IsShorterOrEqual(1) with a collection containing one element should pass.")]
        public void CollectionIsShorterOrEqualTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            Condition.Requires(set).IsShorterOrEqual(1);
        }

        [Fact]
        [Description("Calling IsShorterOrEqual(0) with a collection containing one element should fail.")]
        public void CollectionIsShorterOrEqualTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(set).IsShorterOrEqual(0);
            });
        }

        [Fact]
        [Description("Calling IsShorterOrEqual(-1) with an ArrayList containing no elements should fail.")]
        public void CollectionIsShorterOrEqualTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(list).IsShorterOrEqual(-1);
            });
        }

        [Fact]
        [Description("Calling IsShorterOrEqual(0) with an ArrayList containing no elements should pass.")]
        public void CollectionIsShorterOrEqualTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList();

            Condition.Requires(list).IsShorterOrEqual(0);
        }

        [Fact]
        [Description("Calling IsShorterOrEqual(0) on a null reference should pass.")]
        public void CollectionIsShorterOrEqualTest08()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsShorterOrEqual(0);
        }

        [Fact]
        [Description("Calling IsShorterOrEqual(-1) on a null reference should fail.")]
        public void CollectionIsShorterOrEqualTest09()
        {
            IEnumerable list = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(list).IsShorterOrEqual(-1);
            });
        }

        [Fact]
        [Description("Calling IsShorterOrEqual with the condtionDescription parameter should pass.")]
        public void CollectionIsShorterOrEqualTest10()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsShorterOrEqual(0, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsShorterOrEqual should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionIsShorterOrEqualTest11()
        {
            IEnumerable list = null;
            try
            {
                Condition.Requires(list, "list").IsShorterOrEqual(-1, "abc {0} def");
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("abc list def");
            }
        }

        [Fact]
        [Description("Calling IsShorterOrEqual(-1) with a collection containing no elements should succeed when exceptions are suppressed.")]
        public void CollectionIsShorterOrEqualTest12()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).SuppressExceptionsForTest().IsShorterOrEqual(-1);
        }
    }
}
