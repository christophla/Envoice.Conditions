using System;
using System.ComponentModel;
using Xunit;

namespace Envoice.Conditions.Tests.UseCases
{
    public class NullTestUseCases
    {
        [Fact]
        [Description("Use Case code should match with use of IsNotNull.")]
        public void CheckIsNotNull01()
        {
            object param = new object();

            UseCaseTestHelper.Test(() =>
            {
                // Use Case: this is what the user would write without conditions.
                if (param == null)
                {
                    throw new ArgumentNullException("param");
                }
            },
                () =>
                {
                    // This is what the user should write with conditions.
                    Condition.Requires(param, "param").IsNotNull();
                });
        }

        [Fact]
        [Description("Use Case code should match with use of IsNotNull.")]
        public void CheckIsNotNull02()
        {
            object param = null;

            UseCaseTestHelper.Test(() =>
            {
                // Use Case: this is what the user would write without conditions.
                if (param == null)
                {
                    throw new ArgumentNullException("param");
                }
            },
                () =>
                {
                    // This is what the user should write with conditions.
                    Condition.Requires(param, "param").IsNotNull();
                });
        }

        [Fact]
        [Description("Use Case code should match with use of IsNull.")]
        public void CheckIsNull01()
        {
            object param = new object();

            UseCaseTestHelper.Test(() =>
            {
                // Use Case: this is what the user would write without conditions.
                if (param != null)
                {
                    throw new ArgumentException("param should not be null.", "param");
                }
            },
                () =>
                {
                    // This is what the user should write with conditions.
                    Condition.Requires(param, "param").IsNull();
                });
        }

        [Fact]
        [Description("Use Case code should match with use of IsNull.")]
        public void CheckIsNull02()
        {
            object param = null;

            UseCaseTestHelper.Test(() =>
            {
                // Use Case: this is what the user would write without conditions.
                if (param != null)
                {
                    throw new ArgumentException("param should not be null.", "param");
                }
            },
                () =>
                {
                    // This is what the user should write with conditions.
                    Condition.Requires(param, "param").IsNull();
                });
        }
    }
}
