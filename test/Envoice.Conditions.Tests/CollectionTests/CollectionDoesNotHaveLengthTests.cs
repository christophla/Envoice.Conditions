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
    /// Tests the ValidatorExtensions.DoesNotHaveLength method.
    /// </summary>
    public class CollectionDoesNotHaveLengthTests
    {
        [Fact]
        [Description("Calling DoesNotHaveLength(0) with an non-generic collection containing no elements should fail.")]
        public void CollectionDoesNotHaveLengthTest01()
        {
            // Queue only implements ICollection, no generic ICollection<T>
            Queue queue = new Queue();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(queue).DoesNotHaveLength(0);
            });
        }

        [Fact]
        [Description("Calling DoesNotHaveLength(0) with an typed collection containing no elements should fail.")]
        public void CollectionDoesNotHaveLengthTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(set).DoesNotHaveLength(0);
            });
        }

        [Fact]
        [Description("Calling DoesNotHaveLength(1) with an non-generic collection containing one element should fail.")]
        public void CollectionDoesNotHaveLengthTest03()
        {
            // Queue only implements ICollection, no generic ICollection<T>
            Queue queue = new Queue();
            queue.Enqueue(1);

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(queue).DoesNotHaveLength(1);
            });
        }

        [Fact]
        [Description("Calling DoesNotHaveLength(1) with an typed collection containing one element should fail.")]
        public void CollectionDoesNotHaveLengthTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(set).DoesNotHaveLength(1);
            });
        }

        [Fact]
        [Description("Calling DoesNotHaveLength(0) with a collection containing one element should pass.")]
        public void CollectionDoesNotHaveLengthTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            Condition.Requires(set).DoesNotHaveLength(0);
        }

        [Fact]
        [Description("Calling DoesNotHaveLength with the condtionDescription parameter should pass.")]
        public void CollectionDoesNotHaveLengthTest06()
        {
            IEnumerable list = null;

            Condition.Requires(list).DoesNotHaveLength(1, string.Empty);
        }

        [Fact]
        [Description("Calling a failing DoesNotHaveLength should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionDoesNotHaveLengthTest07()
        {
            IEnumerable list = null;
            try
            {
                Condition.Requires(list, "list").DoesNotHaveLength(0, "the given {0} should not have 0 elements");
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("the given list should not have 0 elements");
            }
        }

        [Fact]
        [Description("Calling DoesNotHaveLength(0) with an non-generic collection containing no elements should succeed when exceptions are suppressed.")]
        public void CollectionDoesNotHaveLengthTest08()
        {
            // Queue only implements ICollection, no generic ICollection<T>
            Queue queue = new Queue();

            Condition.Requires(queue).SuppressExceptionsForTest().DoesNotHaveLength(0);
        }
    }
}
