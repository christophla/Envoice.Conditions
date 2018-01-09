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
    /// Tests the ValidatorExtensions.Contains method.
    /// </summary>
    public class CollectionContainsTests
    {
        // Calling Contains on an array should compile.
        internal static void CollectionContainsShouldCompileTest01()
        {
            int[] c = { 1 };
            Condition.Requires(c).Contains(1);
        }

        // Calling Contains on a Collection should compile.
        internal static void CollectionContainsShouldCompileTest02()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).Contains(1);
        }

        // Calling Contains on an IEnumerable should compile.
        internal static void CollectionContainsShouldCompileTest03()
        {
            IEnumerable<int> c = new Collection<int> { 1 };
            Condition.Requires(c).Contains(1);
        }

        [Fact]
        [Description("Calling Contains on null reference should fail.")]
        public void CollectionContainsTest01()
        {
            Collection<int> c = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(c).Contains(1);
            });
        }

        [Fact]
        [Description("Calling Contains on an empty collection should fail.")]
        public void CollectionContainsTest02()
        {
            Collection<int> c = new Collection<int>();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).Contains(1);
            });
        }

        [Fact]
        [Description("Calling Contains on an Collection that contains the tested value should pass.")]
        public void CollectionContainsTest03()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).Contains(1);
        }

        [Fact]
        [Description("Calling Contains on an non-generic Collection that contains the tested value should pass.")]
        public void CollectionContainsTest04()
        {
            ArrayList c = new ArrayList { 1 };
            Condition.Requires(c).Contains((object)1);
        }

        [Fact]
        [Description("Calling Contains on an typed Collection that contains the tested non-generic value should pass.")]
        public void CollectionContainsTest05()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).Contains((object)1);
        }

        [Fact]
        [Description("Calling Contains on an typed Collection that doesn't contain the tested non-generic value should fail.")]
        public void CollectionContainsTest06()
        {
            Collection<int> c = new Collection<int> { 1 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).Contains(new object());
            });
        }

        [Fact]
        [Description("Calling Contains on a type that doesn't implement ICollection or ICollection<T>, but contains the tested value should pass.")]
        public void CollectionContainsTest07()
        {
            IEnumerable c = Enumerable.Range(1, 1000);
            Condition.Requires(c).Contains((object)1000);
        }

        [Fact]
        [Description("Calling Contains on a type that doesn't implement ICollection or ICollection<T> and doesn't contain the tested value should fail.")]
        public void CollectionContainsTest08()
        {
            IEnumerable c = Enumerable.Range(1, 1000);

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).Contains((object)1001);
            });
        }

        [Fact]
        [Description("Calling Contains on a type that implements IEnumerable<T> but no ICollection<T>, but contains the tested value should pass.")]
        public void CollectionContainsTest09()
        {
            IEnumerable<int> c = Enumerable.Range(1, 10);
            Condition.Requires(c).Contains(10);
        }

        [Fact]
        [Description("Calling Contains on a type that implements IEnumerable<T> but no ICollection<T>, but doesn't contain the tested value should fail.")]
        public void CollectionContainsTest10()
        {
            IEnumerable<int> c = Enumerable.Range(1, 10);

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).Contains(11);
            });
        }

        [Fact]
        [Description("Calling Contains while supplying the optional conditionsDescription should pass.")]
        public void CollectionContainsTest11()
        {
            IEnumerable<int> c = Enumerable.Range(1, 10);
            Condition.Requires(c).Contains(10, "{0} should contain the value 10");
        }

        [Fact]
        [Description("Calling a failing Contains with a generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionContainsTest12()
        {
            IEnumerable<int> c = Enumerable.Range(1, 10);
            try
            {
                Condition.Requires(c, "c").Contains(11, "{0} should contain the integer 11");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("c should contain the integer 11");
            }
        }

        [Fact]
        [Description("Calling Contains while supplying the optional conditionsDescription should pass.")]
        public void CollectionContainsTest13()
        {
            ArrayList c = new ArrayList(Enumerable.Range(1, 10).ToArray());
            object value = 10;
            Condition.Requires(c).Contains(value, "{0} should contain the value 10");
        }

        [Fact]
        [Description("Calling a failing Contains with a non generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionContainsTest14()
        {
            ArrayList c = new ArrayList(Enumerable.Range(1, 10).ToArray());
            try
            {
                object value = 11;
                Condition.Requires(c, "c").Contains(value, "{0} should contain the integer 11");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("c should contain the integer 11");
            }
        }

        [Fact]
        [Description("Calling the generic Contains with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionContainsTest15()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 2, 3, 4 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the values 1 and 2.
            set.Count.ShouldBe(2);
            // Because of the use of OddEqualityComparer, set.Contains should return true.
            set.ShouldContain(3, "OddEqualityComparer is implemented incorrectly.");

            // Because the value is not in the initial list, Contains should fail.
            // Otherwise this behavior would be inconsistent with the non-generic overload of Contains.
            try
            {
                // Call the generic Contains<C, E>(Validator<C>, E) overload.
                Condition.Requires(set).Contains(3);
                Assert.True(false, "Contains did not throw the excepted ArgumentException.");
            }
            catch
            {
                // We expect an exception to be thrown.
            }
        }

        [Fact]
        [Description("Calling the non-generic Contains with an element that's not in the list while enumerating it, should fail.")]
        public void CollectionContainsTest16()
        {
            // Defines a set with a special equality comparer.
            HashSet<int> set = new HashSet<int>(new[] { 1, 2, 3, 4 }, new OddEqualityComparer());

            // Because of the use of OddEqualityComparer, the collection only contains the values 1 and 2.
            set.Count.ShouldBe(2);
            // Because of the use of OddEqualityComparer, set.Contains should return true.
            set.ShouldContain(3, "OddEqualityComparer is implemented incorrectly.");

            // Because the value is not in the initial list, Contains should fail.
            try
            {
                // Call the non-generic Contains<T>(Validator<T>, object) overload.
                Condition.Requires(set).Contains((object)3);
                Assert.True(false, "Contains did not throw the excepted ArgumentException.");
            }
            catch
            {
                // We expect an exception to be thrown.
            }
        }

        [Fact]
        [Description("Calling Contains on an a null reference should succeed when exceptions are suppressed.")]
        public void CollectionContainsTest17()
        {
            Collection<int> c = null;
            Condition.Requires(c).SuppressExceptionsForTest().Contains(1);
        }
    }
}
