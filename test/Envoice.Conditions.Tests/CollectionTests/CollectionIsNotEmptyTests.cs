using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Envoice.Conditions;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNotEmpty method.
    /// </summary>
    public class CollectionIsNotEmptyTests
    {
        [Fact]
        [Description("Calling IsNotEmpty on null reference should fail.")]
        public void IsNotEmptyTest1()
        {
            ICollection c = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(c).IsNotEmpty();
            });
        }

        [Fact]
        [Description("Calling IsNotEmpty on an empty ICollection should fail.")]
        public void IsNotEmptyTest2()
        {
            Collection<int> c = new Collection<int>();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).IsNotEmpty();
            });
        }

        [Fact]
        [Description("Calling IsNotEmpty on null reference should fail.")]
        public void IsNotEmptyTest3()
        {
            IEnumerable c = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Condition.Requires(c).IsNotEmpty();
            });
        }

        [Fact]
        [Description("Calling IsNotEmpty on an not empty IEnumerable should fail.")]
        public void IsNotEmptyTest4()
        {
            EmptyTestEnumerable c = new EmptyTestEnumerable();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(c).IsNotEmpty();
            });
        }

        [Fact]
        [Description("Calling IsNotEmpty on an not empty ICollection should pass.")]
        public void IsNotEmptyTest5()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).IsNotEmpty();
        }

        [Fact]
        [Description("Calling IsNotEmpty on an not empty IEnumerable should pass.")]
        public void IsNotEmptyTest6()
        {
            NonEmptyTestEnumerable c = new NonEmptyTestEnumerable();
            Condition.Requires(c).IsNotEmpty();
        }

        [Fact]
        [Description("Calling IsNotEmpty with conditional description parameter on an not empty ICollection should pass.")]
        public void IsNotEmptyTest7()
        {
            NonEmptyTestEnumerable c = new NonEmptyTestEnumerable();
            Condition.Requires(c).IsNotEmpty("conditionDescription");
        }

        [Fact]
        [Description("Calling a failing IsNotEmpty with a non generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNotEmptyTest8()
        {
            EmptyTestEnumerable c = new EmptyTestEnumerable();
            try
            {
                Condition.Requires(c, "c").IsNotEmpty("{0} should have no elements what so ever");
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("c should have no elements what so ever");
            }
        }

        [Fact]
        [Description("Calling IsNotEmpty on null reference should succeed when exceptions are suppressed.")]
        public void IsNotEmptyTest9()
        {
            ICollection c = null;
            Condition.Requires(c).SuppressExceptionsForTest().IsNotEmpty();
        }
    }
}
