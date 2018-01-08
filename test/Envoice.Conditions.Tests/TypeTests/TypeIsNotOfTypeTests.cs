using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xunit;

namespace Envoice.Conditions.Tests.TypeTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNotOfType method.
    /// </summary>
    public class TypeIsNotOfTypeTests
    {
        [Fact]
        [Description("Calling IsNotOfType on null reference should pass.")]
        public void IsNotOfTypeTest00()
        {
            object o = null;

            // Null objects have no type, so check must always succeed.
            Condition.Requires(o).IsNotOfType(typeof(object));
        }

        [Fact]
        [Description("Calling IsNotOfType on a down-casted object tested to be the down-casted type should fail.")]
        public void IsNotOfTypeTest01()
        {
            object o = "String";

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(o).IsNotOfType(typeof(object));
            });
        }

        [Fact]
        [Description("Calling IsNotOfType on a down-casted object tested to be the real type should fail.")]
        public void IsNotOfTypeTest02()
        {
            object o = "String";

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(o).IsNotOfType(typeof(object));
            });
        }

        [Fact]
        [Description("Calling IsNotOfType on an object tested to be the parent type should fail.")]
        public void IsNotOfTypeTest03()
        {
            string s = "String";

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(s).IsNotOfType(typeof(object));
            });
        }

        [Fact]
        [Description("Calling IsNotOfType on a down-casted object tested to be the down-casted type should fail.")]
        public void IsNotOfTypeTest04()
        {
            string s = "String";

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(s).IsNotOfType(typeof(string));
            });
        }

        [Fact]
        [Description("Calling IsNotOfType on a System.Object tested to be System.Object type should fail.")]
        public void IsNotOfTypeTest05()
        {
            object o = new object();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(o).IsNotOfType(typeof(object));
            });
        }

        [Fact]
        [Description("Calling IsNotOfType on a down-casted object tested to be an incomparable type should pass.")]
        public void IsNotOfTypeTest06()
        {
            object o = "String";

            Condition.Requires(o).IsNotOfType(typeof(EventArgs));
        }

        [Fact]
        [Description("Calling IsNotOfType on an object tested to be an incomparable type should pass.")]
        public void IsNotOfTypeTest07()
        {
            string s = "String";

            Condition.Requires(s).IsNotOfType(typeof(EventArgs));
        }

        [Fact]
        [Description("Calling IsNotOfType on an object implementing ICollection tested not to implement ICollection should fail.")]
        public void IsNotOfTypeTest08()
        {
            ICollection o = new Collection<int>();

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(o).IsNotOfType(typeof(ICollection));
            });
        }

        [Fact]
        [Description("Calling IsNotOfType on a DayOfWeek tested to implement DayOfWeek should fail with an ArgumentException.")]
        public void IsNotOfTypeTest09()
        {
            object day = DayOfWeek.Monday;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(day).IsNotOfType(typeof(DayOfWeek));
            });
        }

        [Fact]
        [Description("Calling IsNotOfType on a down-casted object tested to be the down-casted type should succed when exceptions are suppressed.")]
        public void IsNotOfTypeTest10()
        {
            object o = "String";

            Condition.Requires(o).SuppressExceptionsForTest().IsNotOfType(typeof(object));
        }
    }
}
