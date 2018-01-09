using System;
using System.Collections.Generic;
using System.ComponentModel;
using Envoice.Conditions;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests
{
    public class AlternativeExceptionConditionTests
    {
        [Fact]
        [Description("WithExceptionOnFailure called multiple times with the same exception type, always returns the same instance.")]
        public void WithExceptionOnFailure_CalledMultipleTimesWithTheSameExceptionType_ReturnsTheSameInstance()
        {
            // Act
            var condition1 = Condition.WithExceptionOnFailure<InvalidOperationException>();
            var condition2 = Condition.WithExceptionOnFailure<InvalidOperationException>();

            // Assert
            string assertMessage = "Two calls to WithExceptionOnFailure for the same exception type are " +
                                   "expected to return the same instance for performance reasons.";

            condition1.ShouldBeSameAs(condition2, assertMessage);
        }

        [Fact]
        [Description("WithExceptionOnFailure called multiple times with the different exception type, always returns different instances.")]
        public void WithExceptionOnFailure_CalledWithDifferentExceptionType_ReturnsDifferentInstances()
        {
            // Act
            var condition1 = Condition.WithExceptionOnFailure<InvalidOperationException>();
            var condition2 = Condition.WithExceptionOnFailure<ObjectDisposedException>();

            // Assert
            string assertMessage = "Two calls to WithExceptionOnFailure for different exception type are " +
                                   "expected to return different instances, because each type will get its own condition type.";

            condition1.ShouldNotBeSameAs(condition2, assertMessage);
        }

        [Fact]
        [Description("WithExceptionOnFailure called with an abstract exception type throws an exception of type ArgumentException.")]
        public void WithExceptionOnFailure_WithAbstractExceptionType_ThrowsExpectedExceptionType()
        {
            // Act

            Assert.Throws<ArgumentException>(() =>
            {
                Condition.WithExceptionOnFailure<AbstractException>();
            });
        }

        [Fact]
        [Description("WithExceptionOnFailure called with an invalid exception throws an exception with the expected message.")]
        public void WithExceptionOnFailure_WithInvalidExceptionType_ThrowsExceptionWithExpectedMessage()
        {
            // Arrange
            string expectedMessage = "The type must be concrete and have a public constructor with a single string argument.";

            try
            {
                // Act
                Condition.WithExceptionOnFailure<NoValidConstructorException>();

                // Assert
                Assert.True(false, "Exception was expected.");
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain(expectedMessage, "Invalid exception message: " + ex.Message);
            }
        }

        [Fact]
        [Description("WithExceptionOnFailure called with an invalid exception throws an exception with the expected parameter name.")]
        public void WithExceptionOnFailure_WithInvalidExceptionType_ThrowsExceptionWithExpectedParamName()
        {
            // Arrange
            string expectedParamName = "TException";

            try
            {
                // Act
                Condition.WithExceptionOnFailure<NoValidConstructorException>();

                // Assert
                Assert.True(false, "Exception was expected.");
            }
            catch (ArgumentException ex)
            {
                expectedParamName.ShouldBe(ex.ParamName);
            }
        }

        [Fact]
        [Description("WithExceptionOnFailure called with a valid exception type does not return null.")]
        public void WithExceptionOnFailure_WithValidExceptionType_ReturnsAnInstance()
        {
            // Act
            var condition = Condition.WithExceptionOnFailure<InvalidOperationException>();

            // Assert
            condition.ShouldNotBeNull();
        }

        [Fact]
        [Description("WithExceptionOnFailure called with a valid exception throws that same type in case of a validation failure.")]
        public void WithExceptionOnFailure_WithValidExceptionType1_ThrowsSpecifiedExceptionOnValidationFailure()
        {
            // Arrange
            string value = null;

            // Act
            Assert.Throws<ObjectDisposedException>(() =>
            {
                Condition.WithExceptionOnFailure<ObjectDisposedException>().Requires(value).IsNotNull();
            });
        }

        [Fact]
        [Description("WithExceptionOnFailure called with a valid exception throws that same type in case of a validation failure.")]
        public void WithExceptionOnFailure_WithValidExceptionType2_ThrowsSpecifiedExceptionOnValidationFailure()
        {
            // Arrange
            string value = null;

            // First call WithExceptionOnFailure for another exception type.
            Condition.WithExceptionOnFailure<KeyNotFoundException>();

            // Act
            Assert.Throws<ApplicationException>(() =>
            {
                Condition.WithExceptionOnFailure<ApplicationException>().Requires(value).IsNotNull();
            });
        }

        public abstract class AbstractException : Exception
        {
            public AbstractException(string message)
            {
            }
        }

        public class NoValidConstructorException : Exception
        {
            // Not enough parameters.
            public NoValidConstructorException()
            {
            }

            // Wrong parameter type.
            public NoValidConstructorException(int n)
            {
            }

            // Too many parameters.
            public NoValidConstructorException(string s, string q = null)
            {
            }

            // Output parameter.
            public NoValidConstructorException(out string s)
            {
                s = null;
            }

            // Reference parameter.
            public NoValidConstructorException(ref string s, string q = null)
            {
            }

            // Private.
            private NoValidConstructorException(string s)
            {
            }
        }
    }
}
