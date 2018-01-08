using System;
using System.ComponentModel;
using Envoice.Conditions;
using Xunit;

namespace Envoice.Conditions.Tests
{
    public class FluentUsageTests
    {
        [Fact]
        [Description("Calling IsNotNull on null should fail.")]
        public void IsNotNullFluently()
        {
            object o = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                o.Requires().IsNotNull();
            });
        }
    }
}
