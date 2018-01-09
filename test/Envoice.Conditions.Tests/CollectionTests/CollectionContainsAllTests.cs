using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Envoice.Conditions;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests.CollectionTests
{
    /// <summary>
    ///     /// Tests the ValidatorExtensions.ContainsAll method.
    /// </summary>
    public class CollectionContainsAllTests
    {
        // Calling ContainsAll on an array should compile
        internal static void CollectionContainsAllShouldCompileTest01()
        {
            int[] c = { 1 };
            IEnumerable<int> all = c;
            Condition.Requires(c).ContainsAll(all);
        }

        // Calling ContainsAll on a Collection should compile
        internal static void CollectionContainsAllShouldCompileTest02()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).ContainsAll(c);
        }

        // Calling ContainsAll on an IEnumerable should compile
        internal static void CollectionContainsAllShouldCompileTest03()
        {
            IEnumerable<int> c = new Collection<int> { 1 };
            Condition.Requires(c).ContainsAll(c);
        }

        [Fact]
        [Description("Calling ContainsAll on a null collection with a null reference as 'all' collection should pass.")]
        public void CollectionContainsAllTest01()
        {
            Collection<int> c = null;
            int[] all = null;
            Condition.Requires(c).ContainsAll(all);
        }

        [Fact]
        [Description("Calling ContainsAll on an empty collection with a null reference as 'all' collection should pass.")]
        public void CollectionContainsAllTest02()
        {
            Collection<int> c = new Collection<int>();
            int[] all = null;
            Condition.Requires(c).ContainsAll(all);
        }

        [Fact]
        [Description("Calling ContainsAll on a filled collection with a null reference as 'all' collection should pass.")]
        public void CollectionContainsAllTest03()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] all = null;
            Condition.Requires(c).ContainsAll(all);
        }

        [Fact]
        [Description("Calling ContainsAll on a null collection with an empty collection as 'all' collection should pass.")]
        public void CollectionContainsAllTest04()
        {
            Collection<int> c = null;
            int[] all = new int[0];
            Condition.Requires(c).ContainsAll(all);
        }

        [Fact]
        [Description("Calling ContainsAll on an empty collection with an empty collection as 'all' collection should pass.")]
        public void CollectionContainsAllTest05()
        {
            Collection<int> c = new Collection<int>();
            int[] all = new int[0];
            Condition.Requires(c).ContainsAll(all);
        }

        [Fact]
        [Description("Calling ContainsAll on a filled collection with an empty collection as 'all' collection should pass.")]
        public void CollectionContainsAllTest06()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] all = new int[0];
            Condition.Requires(c).ContainsAll(all);
        }

        [Fact]
        [Description("Calling ContainsAll with a 'all' collection containing all elements of the tested collection should pass.")]
        public void CollectionContainsAllTest07()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] all = { 1, 2, 3, 4 };
            Condition.Requires(c).ContainsAll(all);
        }

        [Fact]
        [Description("Calling ContainsAll with a 'all' collection containing one element of the tested collection should fail.")]
        public void CollectionContainsAllTest08()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] all = { 4, 5, 6, 7 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).ContainsAll(all);
            });
        }

        [Fact]
        [Description("Calling ContainsAll with a 'all' collection containing no element of the tested collection should fail.")]
        public void CollectionContainsAllTest09()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] all = { 5, 6, 7, 8 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).ContainsAll(all);
            });
        }

        [Fact]
        [Description("Calling ContainsAll with an non-generic 'all' collection containing all elements of the tested typed collection should pass.")]
        public void CollectionContainsAllTest10()
        {
            int[] c = { 1, 2, 3, 4 };
            ArrayList all = new ArrayList(new[] { 1, 2, 3, 4 });
            Condition.Requires(c).ContainsAll(all);
        }

        [Fact]
        [Description("Calling ContainsAll with an non-generic 'all' collection containing all elements of the tested non-generic collection should pass.")]
        public void CollectionContainsAllTest11()
        {
            ArrayList c = new ArrayList(new[] { 1, 2, 3, 4 });
            ArrayList all = new ArrayList(new[] { 1, 2, 3, 4 });
            Condition.Requires(c).ContainsAll(all);
        }

        [Fact]
        [Description("Calling ContainsAll with an non-generic 'all' collection containing all elements of different types of the tested non-generic collection should pass.")]
        public void CollectionContainsAllTest12()
        {
            ArrayList c = new ArrayList { 1, DayOfWeek.Friday, 10.8D };
            ArrayList all = new ArrayList { DayOfWeek.Friday, 1 };
            Condition.Requires(c).ContainsAll(all);
        }

        [Fact]
        [Description("Calling ContainsAll with an non-generic 'all' collection containing not all elements of the tested typed collection should fail.")]
        public void CollectionContainsAllTest13()
        {
            int[] c = { 1, 2, 3, 4 };
            ArrayList all = new ArrayList(new[] { 4, 5, 6, 7 });

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).ContainsAll(all);
            });
        }

        [Fact]
        [Description("Calling ContainsAll with an non-generic 'all' collection containing all elements of the tested non-generic collection should fail.")]
        public void CollectionContainsAllTest14()
        {
            ArrayList c = new ArrayList(new[] { 1, 2, 3, 4 });
            ArrayList all = new ArrayList(new[] { 4, 5, 6, 7 });

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).ContainsAll(all);
            });
        }

        [Fact]
        [Description("Calling ContainsAll with an non-generic 'all' collection containing not all elements of different types of the tested non-generic collection should fail.")]
        public void CollectionContainsAllTest15()
        {
            ArrayList c = new ArrayList { 1, DayOfWeek.Friday, 10.8D };
            ArrayList all = new ArrayList { DayOfWeek.Friday, 1, new object() };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).ContainsAll(all);
            });
        }

        [Fact]
        [Description("Calling ContainsAll on an empty collection with an non empty 'all' collection should fail.")]
        public void CollectionContainsAllTest16()
        {
            Collection<int> c = new Collection<int>();
            int[] all = { 4, 5, 6, 7 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).ContainsAll(all);
            });
        }

        [Fact]
        [Description("Calling ContainsAll with an empty non-generic 'all' collection should pass.")]
        public void CollectionContainsAllTest17()
        {
            ArrayList c = new ArrayList(new[] { 1, 2, 3, 4 });
            ArrayList all = new ArrayList();
            Condition.Requires(c).ContainsAll(all);
        }

        [Fact]
        [Description("Calling ContainsAll with an non-generic 'all' on an empty collection should fail.")]
        public void CollectionContainsAllTest18()
        {
            ArrayList c = new ArrayList();
            ArrayList all = new ArrayList(new[] { 1, 2, 3, 4 });

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).ContainsAll(all);
            });
        }

        [Fact]
        [Description("Calling ContainsAll on a generic collection with the condtionDescription parameter should pass.")]
        public void CollectionContainsAllTest19()
        {
            IEnumerable<int> c = Enumerable.Range(1, 2);
            Condition.Requires(c).ContainsAll(c, string.Empty);
        }

        [Fact]
        [Description("Calling a failing ContainsAll with a generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionContainsAllTest20()
        {
            IEnumerable<int> c = Enumerable.Range(1, 2);
            try
            {
                Condition.Requires(c, "c").ContainsAll(Enumerable.Range(3, 2), "{0} must contain all");
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("c must contain all");
            }
        }

        [Fact]
        [Description("Calling ContainsAll on a non-generic collection with the condtionDescription parameter should pass.")]
        public void CollectionContainsAllTest21()
        {
            ArrayList c = new ArrayList { 1, 2 };
            Condition.Requires(c).ContainsAll(c, string.Empty);
        }

        [Fact]
        [Description("Calling a failing ContainsAll with a non-generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionContainsAllTest22()
        {
            ArrayList c = new ArrayList { 1, 2 };
            try
            {
                Condition.Requires(c, "c").ContainsAll(new ArrayList { 3, 4 }, "{0} must contain all");
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("c must contain all");
            }
        }

        [Fact]
        [Description("Calling ContainsAll on non-empty collection that doesn't contain a null value with a 'all' collection that does contain the value null should fail.")]
        public void CollectionContainsAllTest023()
        {
            int?[] c = new int?[] { 1 };
            int?[] all = new int?[] { null };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).ContainsAll(all);
            });
        }

        [Fact]
        [Description("Calling ContainsAll on non-empty non-generic collection that doesn't contain a null value with a 'all' collection that does contain the value null should fail.")]
        public void CollectionContainsAllTest024()
        {
            ArrayList c = new ArrayList { 1 };
            ArrayList all = new ArrayList { null };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).ContainsAll(all);
            });
        }

        [Fact]
        [Description("Calling the generic ContainsAll with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionContainsAllTest25()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 2, 3, 4 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the values 1 and 2.
            set.Count.ShouldBe(2);
            // Because of the use of OddEqualityComparer, set.Contains(3) should return true.
            set.ShouldContain(3, "OddEqualityComparer is implemented incorrectly.");

            int[] elements = { 3 };

            // ContainsAll should fail, because the value is not in the initial list,
            // otherwise this behavior would be inconsistent with the non-generic overload of ContainsAll.
            try
            {
                // Call the generic ContainsAll<C, E>(Validator<C>, IEnumerable<E>) overload.
                Condition.Requires(set).ContainsAll(elements);
                Assert.True(false, "ContainsAll did not throw the excepted ArgumentException.");
            }
            catch
            {
                // We expect an exception to be thrown.
            }
        }

        [Fact]
        [Description("Calling the non-generic ContainsAll with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionContainsAllTest26()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 2, 3, 4 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the values 1 and 2.
            set.Count.ShouldBe(2);
            // Because of the use of OddEqualityComparer, set.Contains(3) should return true.
            set.ShouldContain(3, "OddEqualityComparer is implemented incorrectly.");

            ArrayList elements = new ArrayList { 3 };

            // ContainsAll should fail, because the value is not in the initial list.
            try
            {
                // Call the non-generic ContainsAll<T>(Validator<T>, IEnumerable) overload.
                Condition.Requires(set).ContainsAll(elements);
                Assert.True(false, "ContainsAll did not throw the excepted ArgumentException.");
            }
            catch
            {
                // We expect an exception to be thrown.
            }
        }

        [Fact]
        [Description("Calling ContainsAll with a 'all' collection containing no element of the tested collection should succeed when exceptions are suppressed.")]
        public void CollectionContainsAllTest27()
        {
            int[] c = { 1 };
            int[] all = { 2 };
            Condition.Requires(c).SuppressExceptionsForTest().ContainsAll(all);
        }
    }
}
