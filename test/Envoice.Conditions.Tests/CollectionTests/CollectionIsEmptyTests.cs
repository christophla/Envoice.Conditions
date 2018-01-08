using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Envoice.Conditions;
using Xunit;

namespace Envoice.Conditions.Tests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsEmpty method.
    /// </summary>
    public class CollectionIsEmptyTests
    {
        [Fact]
        [Description("Calling IsEmpty on a null reference to ICollection should pass.")]
        public void IsEmptyTest01()
        {
            ICollection c = null;
            Condition.Requires(c).IsEmpty();
        }

        [Fact]
        [Description("Calling IsEmpty on an empty collection should pass.")]
        public void IsEmptyTest02()
        {
            Collection<int> c = new Collection<int>();
            Condition.Requires(c).IsEmpty();
        }

        [Fact]
        [Description("Calling IsEmpty on a null reference to IEnumerable should pass.")]
        public void IsEmptyTest03()
        {
            IEnumerable c = null;
            Condition.Requires(c).IsEmpty();
        }

        [Fact]
        [Description("Calling IsEmpty on an empty IEnumerable should pass.")]
        public void IsEmptyTest04()
        {
            EmptyTestEnumerable c = new EmptyTestEnumerable();
            Condition.Requires(c).IsEmpty();
        }

        [Fact]
        [Description("Calling IsEmpty on an non empty ICollection should fail.")]
        public void IsEmptyTest05()
        {
            Collection<int> c = new Collection<int> { 1 };

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).IsEmpty();
            });
        }

        [Fact]
        [Description("Calling IsEmpty on an non empty IEnumerable should fail.")]
        public void IsEmptyTest06()
        {
            NonEmptyTestEnumerable c = new NonEmptyTestEnumerable();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).IsEmpty();
            });
        }

        [Fact]
        [Description("Calling IsEmpty with the conditionDescription argument should pass.")]
        public void IsEmptyTest07()
        {
            EmptyTestEnumerable c = new EmptyTestEnumerable();
            Condition.Requires(c).IsEmpty("condition should hold");
        }

        [Fact]
        [Description("Calling a failing IsEmpty with a non generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsEmptyTest08()
        {
            NonEmptyTestEnumerable c = new NonEmptyTestEnumerable();
            try
            {
                Condition.Requires(c, "c").IsEmpty("{0} should have one, two or at least some elements :-)");
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("c should have one, two or at least some elements :-)"));
            }
        }

        [Fact]
        [Description("Calling IsEmpty on an non empty IEnumerable should succeed when exceptions are suppressed.")]
        public void IsEmptyTest09()
        {
            NonEmptyTestEnumerable c = new NonEmptyTestEnumerable();
            Condition.Requires(c).SuppressExceptionsForTest().IsEmpty();
        }
    }
}
