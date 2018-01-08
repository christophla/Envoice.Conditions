using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Envoice.Conditions;
using Xunit;

namespace Envoice.Conditions.Tests
{
    public sealed class ExtendabilityTests
    {
        [Fact]
        [Description("Tests whether the framework can be extended.")]
        public void ExtendabilityTest01()
        {
            int value = 1;

            Condition.Requires(value).MyExtension(new[] { 1 });
        }

        [Fact]
        [Description("Tests whether the framework can be extended. This method should fail.")]
        public void ExtendabilityTest02()
        {
            int value = 1;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(value).MyExtension(new[] { 2 });
            });
        }

        [Fact]
        [Description("Tests whether the framework can be extended. This method should fail.")]
        public void ExtendabilityTest03()
        {
            int value = 1;

            Assert.Throws<PostconditionException>(() =>
            {
                Condition.Ensures(value).MyExtension(new[] { 2 });
            });
        }

        [Fact]
        [Description("Tests whether the API works without the use of extension methods.")]
        public void ExtendabilityTest04()
        {
            int value = 1;
            ValidatorExtensions.IsGreaterOrEqual(Condition.Requires(value, "value"), 0);
        }
    }
}
