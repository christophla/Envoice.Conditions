using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Envoice.Conditions;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.DoesNotContain method.
    /// </summary>
    public class CollectionDoesNotContainTests
    {
        // Calling DoesNotContain on an array should compile.
        internal static void CollectionDoesNotContainShouldCompileTest01()
        {
            int[] c = new int[0];
            Condition.Requires(c).DoesNotContain(1);
        }

        // Calling DoesNotContain on a Collection should compile.
        internal static void CollectionDoesNotContainShouldCompileTest02()
        {
            Collection<int> c = new Collection<int>();
            Condition.Requires(c).DoesNotContain(1);
        }

        // Calling DoesNotContain on an IEnumerable should compile.
        internal static void CollectionDoesNotContainShouldCompileTest03()
        {
            IEnumerable<int> c = new Collection<int>();
            Condition.Requires(c).DoesNotContain(1);
        }

        [Fact]
        [Description("Calling DoesNotContain on null reference should pass.")]
        public void CollectionDoesNotContainTest01()
        {
            Collection<int> c = null;
            Condition.Requires(c).DoesNotContain(1);
        }

        [Fact]
        [Description("Calling DoesNotContain on an empty collection should pass.")]
        public void CollectionDoesNotContainTest02()
        {
            Collection<int> c = new Collection<int>();
            Condition.Requires(c).DoesNotContain(1);
        }

        [Fact]
        [Description("Calling DoesNotContain on an Collection that contains the tested value should fail.")]
        public void CollectionDoesNotContainTest03()
        {
            Collection<int> c = new Collection<int> { 1 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).DoesNotContain(1);
            });
        }

        [Fact]
        [Description("Calling DoesNotContain on an ArrayList that does not contain the tested value should pass.")]
        public void CollectionDoesNotContainTest04()
        {
            ArrayList c = new ArrayList { 1, 2, 3, 4 };
            Condition.Requires(c).DoesNotContain((object)5);
        }

        [Fact]
        [Description("Calling DoesNotContain on an ArrayList that contains the tested value should fail.")]
        public void CollectionDoesNotContainTest05()
        {
            ArrayList c = new ArrayList { 1, 2, 3, 4 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).DoesNotContain((object)4);
            });
        }

        [Fact]
        [Description("Calling the generic DoesNotContain with an optional condition description parameter should pass.")
        ]
        public void CollectionDoesNotContainTest06()
        {
            Collection<int> c = new Collection<int>();
            Condition.Requires(c).DoesNotContain(1, string.Empty);
        }

        [Fact]
        [Description("Calling a failing generic DoesNotContain should throw an exception with an exception message containing the supplied parameterized condition description.")]
        public void CollectionDoesNotContainTest07()
        {
            Collection<int> c = new Collection<int> { 1 };
            try
            {
                Condition.Requires(c, "c").DoesNotContain(1, "{0} contains the value 1 while it shouldn't");
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("c contains the value 1 while it shouldn't");
            }
        }

        [Fact]
        [Description("Calling the non-generic DoesNotContain with an optional condition description parameter should pass.")]
        public void CollectionDoesNotContainTest08()
        {
            ArrayList c = new ArrayList { 1, 2, 3, 4 };
            Condition.Requires(c).DoesNotContain((object)5, string.Empty);
        }

        [Fact]
        [Description("Calling a failing non-generic DoesNotContain should throw an exception with an exception message containing the supplied parameterized condition description.")]
        public void CollectionDoesNotContainTest09()
        {
            ArrayList c = new ArrayList { 1, 2, 3, 4 };
            try
            {
                Condition.Requires(c, "c").DoesNotContain((object)1, "{0} contains the value 1 while it shouldn't");
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("c contains the value 1 while it shouldn't");
            }
        }

        [Fact]
        [Description("Calling the generic DoesNotContain with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionDoesNotContainTest10()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 3 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the value 1.
            set.Count.ShouldBe(1);
            // Because of the use of OddEqualityComparer, the set contains both 1 and 3.
            set.ShouldContain(1, "OddEqualityComparer is implemented incorrectly.");
            set.ShouldContain(3, "OddEqualityComparer is implemented incorrectly.");

            // DoesNotContain should succeed, because 3 should not be in the list while iterating over it.
            // Call the generic DoesNotContain<T>(Validator<T>, T) overload.
            Condition.Requires(set).DoesNotContain(3);
        }

        [Fact]
        [Description("Calling the non-generic DoesNotContain with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionDoesNotContainTest11()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 3 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the value 1.
            set.Count.ShouldBe(1);
            // Because of the use of OddEqualityComparer, the set contains both 1 and 3.
            set.ShouldContain(1, "OddEqualityComparer is implemented incorrectly.");
            set.ShouldContain(3, "OddEqualityComparer is implemented incorrectly.");

            // DoesNotContain should succeed, because 3 should not be in the list while iterating over it.
            // Call the non-generic DoesNotContain<T>(Validator<T>, object) overload.
            Condition.Requires(set).DoesNotContain((object)3);
        }

        [Fact]
        [Description("Calling DoesNotContain on an Collection that contains the tested value should succeed when exceptions are suppressed.")]
        public void CollectionDoesNotContainTest12()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).SuppressExceptionsForTest().DoesNotContain(1);
        }
    }
}
