using System;

namespace Envoice.Conditions
{
    /// <summary>
    ///     The RequiresValidator can be used for precondition checks.
    /// </summary>
    /// <typeparam name="T">The type of the argument to be validated</typeparam>
    internal class RequiresValidator<T> : ConditionValidator<T>
    {
        internal RequiresValidator(string argumentName, T value) : base(argumentName, value)
        {
        }

        internal virtual Exception BuildExceptionBasedOnViolationType(ConstraintViolationType type, string message)
        {
            switch (type)
            {
                case ConstraintViolationType.OutOfRangeViolation:
                    return new ArgumentOutOfRangeException(ArgumentName, message);

                case ConstraintViolationType.InvalidEnumViolation:
                    var enumMessage = BuildInvalidEnumArgumentExceptionMessage(message);
                    return new ArgumentException(enumMessage);

                default:
                    if (Value != null)
                    {
                        return new ArgumentException(message, ArgumentName);
                    }
                    return new ArgumentNullException(ArgumentName, message);
            }
        }

        private static string BuildExceptionMessage(string condition, string additionalMessage)
        {
            if (!string.IsNullOrEmpty(additionalMessage))
            {
                return condition + ". " + additionalMessage;
            }
            return condition + ".";
        }

        private string BuildInvalidEnumArgumentExceptionMessage(string message)
        {
            var argumentException = new ArgumentException(message, ArgumentName);

            // Returns the message formatted according to the current culture.
            // Note that the 'Parameter name' part of the message is culture sensitive.
            return argumentException.Message;
        }

        /// <summary>Throws an exception.</summary>
        /// <param name="condition">
        ///     Describes the condition that doesn't hold, e.g., "Value should not be
        ///     null".
        /// </param>
        /// <param name="additionalMessage">
        ///     An additional message that will be appended to the exception
        ///     message, e.g. "The actual value is 3.". This value may be null or empty.
        /// </param>
        /// <param name="type">
        ///     Gives extra information on the exception type that must be build. The actual
        ///     implementation of the validator may ignore some or all values.
        /// </param>
        protected override void ThrowExceptionCore(string condition, string additionalMessage,
            ConstraintViolationType type)
        {
            var message = BuildExceptionMessage(condition, additionalMessage);

            var exceptionToThrow = BuildExceptionBasedOnViolationType(type, message);

            throw exceptionToThrow;
        }
    }
}