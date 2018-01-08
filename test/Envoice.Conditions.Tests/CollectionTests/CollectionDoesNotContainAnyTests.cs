using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Envoice.Conditions;
using Xunit;

namespace Envoice.Conditions.Tests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.DoesNotContainAny method.
    /// </summary>
    public class CollectionDoesNotContainAnyTests
    {
        // Calling DoesNotContainAny on an array should compile.
        internal static void CollectionDoesNotContainAnyShouldCompileTest01()
        {
            int[] c = { 1 };
            IEnumerable<int> any = new[] { 2 };
            Condition.Requires(c).DoesNotContainAny(any);
        }

        // Calling DoesNotContainAny on a Collection should compile.
        internal static void CollectionDoesNotContainAnyShouldCompileTest02()
        {
            Collection<int> c = new Collection<int> { 1 };
            Collection<int> any = new Collection<int> { 2 };
            Condition.Requires(c).DoesNotContainAny(any);
        }

        // Calling DoesNotContainAny on an IEnumerable should compile.
        internal static void CollectionDoesNotContainAnyShouldCompileTest03()
        {
            IEnumerable<int> c = new Collection<int> { 1 };
            int[] any = { 2 };
            Condition.Requires(c).DoesNotContainAny(any);
        }

        [Fact]
        [Description("Calling DoesNotContainAny on a null collection with a null reference as 'any' collection should pass.")]
        public void CollectionDoesNotContainAnyTest01()
        {
            Collection<int> c = null;
            int[] elements = null;
            Condition.Requires(c).DoesNotContainAny(elements);
        }

        [Fact]
        [Description("Calling DoesNotContainAny on an empty collection with a null reference as 'any' collection should pass.")]
        public void CollectionDoesNotContainAnyTest02()
        {
            Collection<int> c = new Collection<int>();
            int[] elements = null;
            Condition.Requires(c).DoesNotContainAny(elements);
        }

        [Fact]
        [Description("Calling DoesNotContainAny on a filled collection with a null reference as 'any' collection should pass.")]
        public void CollectionDoesNotContainAnyTest03()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] elements = null;
            Condition.Requires(c).DoesNotContainAny(elements);
        }

        [Fact]
        [Description("Calling DoesNotContainAny on a null collection with an empty collection as 'any' collection should pass.")]
        public void CollectionDoesNotContainAnyTest04()
        {
            Collection<int> c = null;
            int[] elements = new int[0];
            Condition.Requires(c).DoesNotContainAny(elements);
        }

        [Fact]
        [Description("Calling DoesNotContainAny on an empty collection with an empty collection as 'any' collection should pass.")]
        public void CollectionDoesNotContainAnyTest05()
        {
            Collection<int> c = new Collection<int>();
            int[] elements = new int[0];
            Condition.Requires(c).DoesNotContainAny(elements);
        }

        [Fact]
        [Description("Calling DoesNotContainAny on a filled collection with an empty collection as 'any' collection should pass.")]
        public void CollectionDoesNotContainAnyTest06()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] elements = new int[0];
            Condition.Requires(c).DoesNotContainAny(elements);
        }

        [Fact]
        [Description("Calling DoesNotContainAny with a 'any' collection containing all elements of the tested collection should fail.")]
        public void CollectionDoesNotContainAnyTest07()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] any = { 1, 2, 3, 4 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).DoesNotContainAny(any);
            });
        }

        [Fact]
        [Description("Calling DoesNotContainAny with a 'any' collection containing one element of the tested collection should fail.")]
        public void CollectionDoesNotContainAnyTest08()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] any = { 4, 5, 6, 7 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).DoesNotContainAny(any);
            });
        }

        [Fact]
        [Description("Calling DoesNotContainAny with a 'any' collection containing no element of the tested collection should pass.")]
        public void CollectionDoesNotContainAnyTest09()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] any = { 5, 6, 7, 8 };
            Condition.Requires(c).DoesNotContainAny(any);
        }

        [Fact]
        [Description("Calling DoesNotContainAny with an non-generic 'any' collection containing one element of the tested typed collection should fail.")]
        public void CollectionDoesNotContainAnyTest10()
        {
            int[] c = { 1, 2, 3, 4 };
            ArrayList any = new ArrayList(new[] { 4, 5, 6, 8 });

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).DoesNotContainAny(any);
            });
        }

        [Fact]
        [Description("Calling DoesNotContainAny with an non-generic 'any' collection containing one element of the tested non-generic collection should fail.")]
        public void CollectionDoesNotContainAnyTest11()
        {
            ArrayList c = new ArrayList(new object[] { 1, 2, 3, null });
            ArrayList any = new ArrayList(new object[] { null, 5, 6, 8 });

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).DoesNotContainAny(any);
            });
        }

        [Fact]
        [Description("Calling DoesNotContainAny with an non-generic 'any' collection containing one element of different types of the tested non-generic collection should fail.")]
        public void CollectionDoesNotContainAnyTest12()
        {
            ArrayList c = new ArrayList { 1, DayOfWeek.Friday, 10.8D };

            ArrayList any = new ArrayList { DayOfWeek.Friday, 2 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).DoesNotContainAny(any);
            });
        }

        [Fact]
        [Description("Calling DoesNotContainAny with an non-generic 'any' collection containing no elements of the tested typed collection should pass.")]
        public void CollectionDoesNotContainAnyTest13()
        {
            int[] c = { 1, 2, 3, 4 };
            ArrayList any = new ArrayList(new[] { 5, 6, 7, 8 });
            Condition.Requires(c).DoesNotContainAny(any);
        }

        [Fact]
        [Description("Calling DoesNotContainAny with an non-generic 'any' collection containing no elements of the tested non-generic collection should pass.")]
        public void CollectionDoesNotContainAnyTest14()
        {
            ArrayList c = new ArrayList(new[] { 1, 2, 3, 4 });
            ArrayList any = new ArrayList(new[] { 5, 6, 7, 8 });
            Condition.Requires(c).DoesNotContainAny(any);
        }

        [Fact]
        [Description("Calling DoesNotContainAny with an non-generic 'any' collection containing no elements of different types of the tested non-generic collection should pass.")]
        public void CollectionDoesNotContainAnyTest15()
        {
            ArrayList c = new ArrayList { 1, DayOfWeek.Friday, 10.8D };

            ArrayList any = new ArrayList { DayOfWeek.Saturday, 2, new object() };

            Condition.Requires(c).DoesNotContainAny(any);
        }

        [Fact]
        [Description("Calling DoesNotContainAny on a generic collection with the condtionDescription parameter should pass.")]
        public void CollectionDoesNotContainAnyTest16()
        {
            IEnumerable<int> c = Enumerable.Range(1, 2);
            Condition.Requires(c).DoesNotContainAny(Enumerable.Range(3, 2), string.Empty);
        }

        [Fact]
        [Description("Calling a failing DoesNotContainAny with a generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionDoesNotContainAnyTest17()
        {
            IEnumerable<int> c = Enumerable.Range(1, 2);
            try
            {
                Condition.Requires(c, "c").DoesNotContainAny(c, "{0} should contain some");
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("c should contain some"));
            }
        }

        [Fact]
        [Description("Calling DoesNotContainAny on a non-generic collection with the condtionDescription parameter should pass.")]
        public void CollectionDoesNotContainAnyTest18()
        {
            ArrayList c = new ArrayList { 1, 2 };
            Condition.Requires(c).DoesNotContainAny(new ArrayList { 3, 4 }, string.Empty);
        }

        [Fact]
        [Description("Calling a failing DoesNotContainAny with a non-generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionDoesNotContainAnyTest19()
        {
            ArrayList c = new ArrayList { 1, 2 };
            try
            {
                Condition.Requires(c, "c").DoesNotContainAny(c, "{0} should contain some");
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("c should contain some"));
            }
        }

        [Fact]
        [Description("Calling the generic DoesNotContainAny with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionDoesNotContainAnyTest20()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 3 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the value 1.
            Assert.True(set.Count == 1);
            // Because of the use of OddEqualityComparer, set.Contains(3) should return true.
            Assert.True(set.Contains(3), "OddEqualityComparer is implemented incorrectly.");
            Assert.True(set.Contains(5), "OddEqualityComparer is implemented incorrectly.");

            int[] elements = { 3, 5 };

            // Call the generic DoesNotContainAny<C, E>(Validator<C>, IEnumerable<E>) overload.
            // DoesNotContainAny should fail, because the value is not in the initial list,
            // otherwise this behavior would be inconsistent with the non-generic overload of DoesNotContainAny.
            Condition.Requires(set).DoesNotContainAny(elements);
        }

        [Fact]
        [Description("Calling the non-generic DoesNotContainAny with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionDoesNotContainAnyTest21()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 3 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the value 1.
            Assert.True(set.Count == 1);
            // Because of the use of OddEqualityComparer, set.Contains(3) should return true.
            Assert.True(set.Contains(3), "OddEqualityComparer is implemented incorrectly.");
            Assert.True(set.Contains(5), "OddEqualityComparer is implemented incorrectly.");

            ArrayList elements = new ArrayList { 3, 5 };

            // Call the non-generic DoesNotContainAny<T>(Validator<T>, IEnumerable) overload.
            // DoesNotContainAny should fail, because the value is not in the initial list.
            Condition.Requires(set).DoesNotContainAny(elements);
        }

        [Fact]
        [Description("Calling DoesNotContainAny with a 'any' collection containing all elements of the tested collection should succeed when exceptions are suppressed.")]
        public void CollectionDoesNotContainAnyTest22()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] any = { 1, 2, 3, 4 };
            Condition.Requires(c).SuppressExceptionsForTest().DoesNotContainAny(any);
        }
    }
}
