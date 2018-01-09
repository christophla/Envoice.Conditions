using System;
using System.ComponentModel;
using Envoice.Conditions;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests.EntryPointTests
{
    /// <summary>
    /// Tests the Condition.Ensures method.
    /// </summary>
    public class EntryPointEnsuresTests
    {
        [Fact]
        [Description("Checks whether the validator returned from Ensures() will fail with an PostconditionException.")]
        public void EnsuresTest01()
        {
            int a = 3;

            Assert.Throws<PostconditionException>(() =>
            {
                Condition.Ensures(a).IsEqualTo(4);
            });
        }

        [Fact]
        [Description("Checks whether the parameterName on the Ensures() will be used.")]
        public void EnsuresTest02()
        {
            int a = 3;
            try
            {
                Condition.Ensures(a, "foobar").IsGreaterThan(a);
            }
            catch (Exception ex)
            {
                ex.Message.ShouldContain("foobar");
            }
        }

        [Fact]
        [Description("Checks whether supplying an invalid ConstraintViolationType results in the return of the default exception.")]
        public void EnsuresTest03()
        {
            ConditionValidator<int> ensuresValidator = Condition.Ensures(3);

            const string ValidCondition = "valid condition";
            const string ValidAdditionalMessage = "valid additional message";
            const ConstraintViolationType InvalidConstraintViolationType = (ConstraintViolationType)666;

            const string AssertMessage = "EnsuresValidator.ThrowException should throw an " +
                                         "ArgumentException when an invalid ConstraintViolationType is supplied.";

            try
            {
                ensuresValidator.ThrowException(ValidCondition, ValidAdditionalMessage, InvalidConstraintViolationType);

                Assert.True(false, AssertMessage);
            }
            catch (Exception ex)
            {
                ex.GetType().ShouldBe(typeof(PostconditionException));
                ex.Message.ShouldContain(ValidCondition, "The exception message does not contain the condition.");
            }
        }
    }
}
