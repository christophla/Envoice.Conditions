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
    /// Tests the ValidatorExtensions.ContainsAny method.
    /// </summary>
    public class CollectionContainsAnyTests
    {
        // Calling ContainsAny on an array should compile.
        internal static void CollectionContainsAnyShouldCompileTest01()
        {
            int[] c = { 1 };
            IEnumerable<int> any = c;
            Condition.Requires(c).ContainsAny(any);
        }

        // Calling ContainsAny on a Collection should compile.
        internal static void CollectionContainsAnyShouldCompileTest02()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).ContainsAny(c);
        }

        // Calling ContainsAny on an IEnumerable should compile.
        internal static void CollectionContainsAnyShouldCompileTest03()
        {
            IEnumerable<int> c = new Collection<int> { 1 };
            Condition.Requires(c).ContainsAny(c);
        }

        [Fact]
        [Description("Calling ContainsAny on a null collection with a null reference as 'any' collection should fail.")]
        public void CollectionContainsAnyTest01()
        {
            Collection<int> c = null;
            int[] elements = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(c).ContainsAny(elements);
            });
        }

        [Fact]
        [Description("Calling ContainsAny on an empty collection with a null reference as 'any' collection should fail.")]
        public void CollectionContainsAnyTest02()
        {
            Collection<int> c = new Collection<int>();
            int[] elements = null;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).ContainsAny(elements);
            });
        }

        [Fact]
        [Description("Calling ContainsAny on a filled collection with a null reference as 'any' collection should fail.")]
        public void CollectionContainsAnyTest03()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] elements = null;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).ContainsAny(elements);
            });
        }

        [Fact]
        [Description("Calling ContainsAny on a null collection with an empty 'any' collection should fail.")]
        public void CollectionContainsAnyTest04()
        {
            Collection<int> c = null;
            int[] elements = new int[0];

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(c).ContainsAny(elements);
            });
        }

        [Fact]
        [Description("Calling ContainsAny on an empty collection with an empty collection as 'any' collection should fail.")]
        public void CollectionContainsAnyTest05()
        {
            Collection<int> c = new Collection<int>();
            int[] elements = new int[0];

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).ContainsAny(elements);
            });
        }

        [Fact]
        [Description("Calling ContainsAny on a filled collection with an empty collection as 'any' collection should fail.")]
        public void CollectionContainsAnyTest06()
        {
            Collection<int> c = new Collection<int> { 1, 2, 3 };
            int[] elements = new int[0];

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).ContainsAny(elements);
            });
        }

        [Fact]
        [Description("Calling ContainsAny with a 'any' collection containing all elements of the tested collection should pass.")]
        public void CollectionContainsAnyTest07()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] any = { 1, 2, 3, 4 };
            Condition.Requires(c).ContainsAny(any);
        }

        [Fact]
        [Description("Calling ContainsAny with a 'any' collection containing one element of the tested collection should pass.")]
        public void CollectionContainsAnyTest08()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] any = { 4, 5, 6, 7 };
            Condition.Requires(c).ContainsAny(any);
        }

        [Fact]
        [Description("Calling ContainsAny with a 'any' collection containing no element of the tested collection should fail.")]
        public void CollectionContainsAnyTest09()
        {
            int[] c = { 1, 2, 3, 4 };
            int[] any = { 5, 6, 7, 8 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).ContainsAny(any);
            });
        }

        [Fact]
        [Description("Calling ContainsAny with an non-generic 'any' collection containing one element of the tested typed collection should pass.")]
        public void CollectionContainsAnyTest10()
        {
            int[] c = { 1, 2, 3, 4 };
            ArrayList any = new ArrayList(new[] { 4, 5, 6, 8 });
            Condition.Requires(c).ContainsAny(any);
        }

        [Fact]
        [Description("Calling ContainsAny with an non-generic 'any' collection containing one element of the tested non-generic collection should pass.")]
        public void CollectionContainsAnyTest11()
        {
            ArrayList c = new ArrayList(new object[] { 1, 2, 3, null });
            ArrayList any = new ArrayList(new object[] { null, 5, 6, 8 });
            Condition.Requires(c).ContainsAny(any);
        }

        [Fact]
        [Description("Calling ContainsAny with an non-generic 'any' collection containing one element of different types of the tested non-generic collection should pass.")]
        public void CollectionContainsAnyTest12()
        {
            ArrayList c = new ArrayList { 1, DayOfWeek.Friday, 10.8D };

            ArrayList any = new ArrayList { DayOfWeek.Friday, 2 };

            Condition.Requires(c).ContainsAny(any);
        }

        [Fact]
        [Description("Calling ContainsAny with an non-generic 'any' collection containing no elements of the tested typed collection should fail.")]
        public void CollectionContainsAnyTest13()
        {
            int[] c = { 1, 2, 3, 4 };
            ArrayList any = new ArrayList(new[] { 5, 6, 7, 8 });

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).ContainsAny(any);
            });
        }

        [Fact]
        [Description("Calling ContainsAny with an non-generic 'any' collection containing no elements of the tested non-generic collection should fail.")]
        public void CollectionContainsAnyTest14()
        {
            ArrayList c = new ArrayList(new[] { 1, 2, 3, 4 });
            ArrayList any = new ArrayList(new[] { 5, 6, 7, 8 });

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).ContainsAny(any);
            });
        }

        [Fact]
        [Description("Calling ContainsAny with an non-generic 'any' collection containing no elements of different types of the tested non-generic collection should fail.")]
        public void CollectionContainsAnyTest15()
        {
            ArrayList c = new ArrayList { 1, DayOfWeek.Friday, 10.8D };

            ArrayList any = new ArrayList { DayOfWeek.Saturday, 2, new object() };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).ContainsAny(any);
            });
        }

        [Fact]
        [Description("Calling ContainsAny with an empty non-generic collection should fail.")]
        public void CollectionContainsAnyTest16()
        {
            ArrayList c = new ArrayList();
            ArrayList any = new ArrayList(new object[] { null, 5, 6, 8 });

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).ContainsAny(any);
            });
        }

        [Fact]
        [Description("Calling ContainsAny with an empty 'any' collection should fail.")]
        public void CollectionContainsAnyTest17()
        {
            ArrayList c = new ArrayList(new object[] { 1, 2, 3, null });
            ArrayList any = new ArrayList();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).ContainsAny(any);
            });
        }

        [Fact]
        [Description("Calling ContainsAny with an two collections that implement IEnumerable<T> but not IColletion<T> should pass.")]
        public void CollectionContainsAnyTest18()
        {
            IEnumerable<int> c = Enumerable.Range(1, 2);
            Condition.Requires(c).ContainsAny(c);
        }

        [Fact]
        [Description("Calling ContainsAny on a generic collection with the condtionDescription parameter should pass.")]
        public void CollectionContainsAnyTest19()
        {
            IEnumerable<int> c = Enumerable.Range(1, 2);
            Condition.Requires(c).ContainsAny(c, string.Empty);
        }

        [Fact]
        [Description("Calling a failing ContainsAny with a generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionContainsAnyTest20()
        {
            IEnumerable<int> c = Enumerable.Range(1, 2);
            try
            {
                Condition.Requires(c, "c").ContainsAny(Enumerable.Range(3, 2), "{0} should contain some");
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("c should contain some");
            }
        }

        [Fact]
        [Description("Calling ContainsAny on a non-generic collection with the condtionDescription parameter should pass.")]
        public void CollectionContainsAnyTest21()
        {
            ArrayList c = new ArrayList { 1, 2 };
            Condition.Requires(c).ContainsAny(c, string.Empty);
        }

        [Fact]
        [Description("Calling a failing ContainsAny with a non-generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionContainsAnyTest22()
        {
            ArrayList c = new ArrayList { 1, 2 };
            try
            {
                Condition.Requires(c, "c").ContainsAny(new ArrayList { 3, 4 }, "{0} should contain some");
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("c should contain some");
            }
        }

        [Fact]
        [Description("Calling ContainsAny on a null collection with an non-empty 'any' collection should fail.")]
        public void CollectionContainsAnyTest23()
        {
            Collection<int> c = null;
            int[] elements = new int[] { 1 };

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(c).ContainsAny(elements);
            });
        }

        [Fact]
        [Description("Calling ContainsAny on a collection containing a null value with an 'any' collection also containing a null value should succeed.")]
        public void CollectionContainsAnyTest24()
        {
            var collection = new int?[] { null };
            var elements = new int?[] { null };
            Condition.Requires(collection).ContainsAny(elements);
        }

        [Fact]
        [Description("Calling the generic ContainsAny with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionContainsAnyTest25()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 2, 3, 4 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the values 1 and 2.
            set.Count.ShouldBe(2);
            // Because of the use of OddEqualityComparer, set.Contains(3) should return true.
            set.ShouldContain(3, "OddEqualityComparer is implemented incorrectly.");

            int[] elements = { 3 };

            // Because the value is not in the initial list, ContainsAny should fail.
            // Otherwise this behavior would be inconsistent with the non-generic overload of ContainsAny.
            try
            {
                // Call the generic ContainsAny<C, E>(Validator<C>, IEnumerable<E>) overload.
                Condition.Requires(set).ContainsAny(elements);
                Assert.True(false, "ContainsAny did not throw the excepted ArgumentException.");
            }
            catch
            {
                // We expect an exception to be thrown.
            }
        }

        [Fact]
        [Description("Calling the non-generic ContainsAny with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionContainsAnyTest26()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 2, 3, 4 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the values 1 and 2.
            set.Count.ShouldBe(2);
            // Because of the use of OddEqualityComparer, set.Contains(3) should return true.
            set.ShouldContain(3, "OddEqualityComparer is implemented incorrectly.");

            ArrayList elements = new ArrayList { 3 };

            // Because the value is not in the initial list, ContainsAny should fail.
            try
            {
                // Call the non-generic ContainsAny<T>(Validator<T>, IEnumerable) overload.
                Condition.Requires(set).ContainsAny(elements);
                Assert.True(false, "ContainsAny did not throw the excepted ArgumentException.");
            }
            catch
            {
                // We expect an exception to be thrown.
            }
        }

        [Fact]
        [Description("Calling ContainsAny with an self-referencing collection should not lead to an StackOverflowException.")]
        public void CollectionContainsAnyTest27()
        {
            // Define an array that contains itself.
            object[] evilArray = new object[1];
            evilArray[0] = evilArray;

            object[] collection = { 1, 2, 3 };

            try
            {
                Condition.Requires(collection).ContainsAny(evilArray);
            }
            catch (Exception ex)
            {
                ex.ShouldBeOfType<ArgumentException>();
            }
        }

        [Fact]
        [Description("Calling ContainsAny on a null collection with a null reference as 'any' collection should succeed when exceptions are suppressed.")]
        public void CollectionContainsAnyTest28()
        {
            Collection<int> c = null;
            int[] elements = null;
            Condition.Requires(c).SuppressExceptionsForTest().ContainsAny(elements);
        }
    }
}
