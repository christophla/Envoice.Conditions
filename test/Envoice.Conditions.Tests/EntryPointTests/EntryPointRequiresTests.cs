using System;
using System.ComponentModel;
using Envoice.Conditions;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests.EntryPointTests
{
    /// <summary>
    /// Tests the Condition.Requires method.
    /// </summary>
    public class EntryPointRequiresTests
    {
        [Fact]
        [Description("Checks whether the validator returned from Requires() will fail with an ArgumentException.")]
        public void RequiresTest01()
        {
            int a = 3;

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.Requires(a).IsEqualTo(4);
            });
        }

        [Fact]
        [Description("Checks whether the parameterName on the Requires() will be used.")]
        public void RequiresTest02()
        {
            int a = 3;
            try
            {
                Condition.Requires(a, "foobar").IsEqualTo(4);
            }
            catch (Exception ex)
            {
                ex.Message.ShouldContain("foobar");
            }
        }

        [Fact]
        [Description("Checks whether supplying an invalid ConstraintViolationType results in the return of the default exception.")]
        public void RequiresTest03()
        {
            ConditionValidator<int> requiresValidator = Condition.Requires(3);

            const string ValidCondition = "valid condition";
            const string ValidAdditionalMessage = "valid additional message";
            const ConstraintViolationType InvalidConstraintViolationType = (ConstraintViolationType)666;

            const string AssertMessage = "RequiresValidator.ThrowException should throw an " +
                                         "ArgumentException when an invalid ConstraintViolationType is supplied.";

            try
            {
                requiresValidator.ThrowException(ValidCondition, ValidAdditionalMessage, InvalidConstraintViolationType);

                Assert.True(false, AssertMessage);
            }
            catch (Exception ex)
            {
                ex.GetType().ShouldBe(typeof(ArgumentException));
                ex.Message.ShouldContain(ValidCondition, "The exception message does not contain the condition.");
            }
        }
    }
}
