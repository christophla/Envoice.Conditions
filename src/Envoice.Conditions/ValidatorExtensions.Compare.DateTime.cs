﻿using System;

namespace Envoice.Conditions
{
    // Comparable checks for DateTime
    public static partial class ValidatorExtensions
    {
        /// <summary>
        ///     Checks whether the given value is equal to the specified <paramref name="value" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="value">The valid value to compare with.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is not equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is not equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsEqualTo(this ConditionValidator<DateTime> validator, DateTime value)
        {
            if (!(validator.Value == value))
            {
                Throw.ValueShouldBeEqualTo(validator, value, null);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is equal to the specified <paramref name="value" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="value">The valid value to compare with.</param>
        /// <param name="conditionDescription">
        ///     The description of the condition that should hold. The string may hold the placeholder '{0}' for
        ///     the <see cref="ConditionValidator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is not equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is not equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsEqualTo(this ConditionValidator<DateTime> validator, DateTime value,
            string conditionDescription)
        {
            if (!(validator.Value == value))
            {
                Throw.ValueShouldBeEqualTo(validator, value, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is greater or equal to the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is smaller than <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is smaller than <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsGreaterOrEqual(this ConditionValidator<DateTime> validator,
            DateTime minValue)
        {
            if (!(validator.Value >= minValue))
            {
                Throw.ValueShouldBeGreaterThanOrEqualTo(validator, minValue, null);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is greater or equal to the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <param name="conditionDescription">
        ///     The description of the condition that should hold. The string may hold the placeholder '{0}' for
        ///     the <see cref="ConditionValidator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is smaller than <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is smaller than <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsGreaterOrEqual(this ConditionValidator<DateTime> validator,
            DateTime minValue,
            string conditionDescription)
        {
            if (!(validator.Value >= minValue))
            {
                Throw.ValueShouldBeGreaterThanOrEqualTo(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is greater than the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is smaller or equal to <paramref name="minValue" />, while the
        ///     specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is smaller or equal to <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsGreaterThan(this ConditionValidator<DateTime> validator,
            DateTime minValue)
        {
            if (!(validator.Value > minValue))
            {
                Throw.ValueShouldBeGreaterThan(validator, minValue, null);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is greater than the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <param name="conditionDescription">
        ///     The description of the condition that should hold. The string may hold the placeholder '{0}' for
        ///     the <see cref="ConditionValidator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is smaller or equal to <paramref name="minValue" />, while the
        ///     specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is smaller or equal to <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsGreaterThan(this ConditionValidator<DateTime> validator,
            DateTime minValue,
            string conditionDescription)
        {
            if (!(validator.Value > minValue))
            {
                Throw.ValueShouldBeGreaterThan(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is between <paramref name="minValue" /> and
        ///     <paramref name="maxValue" /> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is not in the specified range, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is not in the specified range, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsInRange(this ConditionValidator<DateTime> validator,
            DateTime minValue, DateTime maxValue)
        {
            var value = validator.Value;

            if (!(value >= minValue && value <= maxValue))
            {
                Throw.ValueShouldBeBetween(validator, minValue, maxValue, null);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is between <paramref name="minValue" /> and
        ///     <paramref name="maxValue" /> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <param name="conditionDescription">
        ///     The description of the condition that should hold. The string may hold the placeholder '{0}' for
        ///     the <see cref="ConditionValidator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is not in the specified range, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is not in the specified range, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsInRange(this ConditionValidator<DateTime> validator,
            DateTime minValue, DateTime maxValue,
            string conditionDescription)
        {
            var value = validator.Value;

            if (!(value >= minValue && value <= maxValue))
            {
                Throw.ValueShouldBeBetween(validator, minValue, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is smaller or equal to the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is greater than <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is greater than <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsLessOrEqual(this ConditionValidator<DateTime> validator,
            DateTime maxValue)
        {
            if (!(validator.Value <= maxValue))
            {
                Throw.ValueShouldBeSmallerThanOrEqualTo(validator, maxValue, null);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is smaller or equal to the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <param name="conditionDescription">
        ///     The description of the condition that should hold. The string may hold the placeholder '{0}' for
        ///     the <see cref="ConditionValidator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is greater than <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is greater than <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsLessOrEqual(this ConditionValidator<DateTime> validator,
            DateTime maxValue,
            string conditionDescription)
        {
            if (!(validator.Value <= maxValue))
            {
                Throw.ValueShouldBeSmallerThanOrEqualTo(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is less than the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is greater or equal to <paramref name="maxValue" />, while the
        ///     specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is greater or equal to <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsLessThan(this ConditionValidator<DateTime> validator,
            DateTime maxValue)
        {
            if (!(validator.Value < maxValue))
            {
                Throw.ValueShouldBeSmallerThan(validator, maxValue, null);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is less than the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <param name="conditionDescription">
        ///     The description of the condition that should hold. The string may hold the placeholder '{0}' for
        ///     the <see cref="ConditionValidator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is greater or equal to <paramref name="maxValue" />, while the
        ///     specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is greater or equal to <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsLessThan(this ConditionValidator<DateTime> validator,
            DateTime maxValue,
            string conditionDescription)
        {
            if (!(validator.Value < maxValue))
            {
                Throw.ValueShouldBeSmallerThan(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is unequal to the specified <paramref name="value" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="value">The invalid value to compare with.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsNotEqualTo(this ConditionValidator<DateTime> validator,
            DateTime value)
        {
            if (validator.Value == value)
            {
                Throw.ValueShouldBeUnequalTo(validator, value, null);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is unequal to the specified <paramref name="value" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="value">The invalid value to compare with.</param>
        /// <param name="conditionDescription">
        ///     The description of the condition that should hold. The string may hold the placeholder '{0}' for
        ///     the <see cref="ConditionValidator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsNotEqualTo(this ConditionValidator<DateTime> validator,
            DateTime value,
            string conditionDescription)
        {
            if (validator.Value == value)
            {
                Throw.ValueShouldBeUnequalTo(validator, value, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not greater or equal to the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is greater or equal to <paramref name="maxValue" />, while the
        ///     specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is greater or equal to <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsNotGreaterOrEqual(this ConditionValidator<DateTime> validator,
            DateTime maxValue)
        {
            if (validator.Value >= maxValue)
            {
                Throw.ValueShouldNotBeGreaterThanOrEqualTo(validator, maxValue, null);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not greater or equal to the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <param name="conditionDescription">
        ///     The description of the condition that should hold. The string may hold the placeholder '{0}' for
        ///     the <see cref="ConditionValidator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is greater or equal to <paramref name="maxValue" />, while the
        ///     specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is greater or equal to <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsNotGreaterOrEqual(this ConditionValidator<DateTime> validator,
            DateTime maxValue,
            string conditionDescription)
        {
            if (validator.Value >= maxValue)
            {
                Throw.ValueShouldNotBeGreaterThanOrEqualTo(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not greater than the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is greater than <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is greater than <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsNotGreaterThan(this ConditionValidator<DateTime> validator,
            DateTime maxValue)
        {
            if (validator.Value > maxValue)
            {
                Throw.ValueShouldNotBeGreaterThan(validator, maxValue, null);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not greater than the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest valid value.</param>
        /// <param name="conditionDescription">
        ///     The description of the condition that should hold. The string may hold the placeholder '{0}' for
        ///     the <see cref="ConditionValidator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is greater than <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is greater than <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsNotGreaterThan(this ConditionValidator<DateTime> validator,
            DateTime maxValue,
            string conditionDescription)
        {
            if (validator.Value > maxValue)
            {
                Throw.ValueShouldNotBeGreaterThan(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not between <paramref name="minValue" /> and
        ///     <paramref name="maxValue" /> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest invalid value.</param>
        /// <param name="maxValue">The highest invalid value.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is in the specified range, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is in the specified range, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsNotInRange(this ConditionValidator<DateTime> validator,
            DateTime minValue, DateTime maxValue)
        {
            var value = validator.Value;

            if (value >= minValue && value <= maxValue)
            {
                Throw.ValueShouldNotBeBetween(validator, minValue, maxValue, null);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not between <paramref name="minValue" /> and
        ///     <paramref name="maxValue" /> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest invalid value.</param>
        /// <param name="maxValue">The highest invalid value.</param>
        /// <param name="conditionDescription">
        ///     The description of the condition that should hold. The string may hold the placeholder '{0}' for
        ///     the <see cref="ConditionValidator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is in the specified range, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is in the specified range, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsNotInRange(this ConditionValidator<DateTime> validator,
            DateTime minValue, DateTime maxValue,
            string conditionDescription)
        {
            var value = validator.Value;

            if (value >= minValue && value <= maxValue)
            {
                Throw.ValueShouldNotBeBetween(validator, minValue, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not smaller or equal to the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is smaller or equal to <paramref name="minValue" />, while the
        ///     specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is smaller or equal to <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsNotLessOrEqual(this ConditionValidator<DateTime> validator,
            DateTime minValue)
        {
            if (validator.Value <= minValue)
            {
                Throw.ValueShouldNotBeSmallerThanOrEqualTo(validator, minValue, null);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not smaller or equal to the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <param name="conditionDescription">
        ///     The description of the condition that should hold. The string may hold the placeholder '{0}' for
        ///     the <see cref="ConditionValidator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is smaller or equal to <paramref name="minValue" />, while the
        ///     specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is smaller or equal to <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsNotLessOrEqual(this ConditionValidator<DateTime> validator,
            DateTime minValue,
            string conditionDescription)
        {
            if (validator.Value <= minValue)
            {
                Throw.ValueShouldNotBeSmallerThanOrEqualTo(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not less than the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is smaller than <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is smaller than <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsNotLessThan(this ConditionValidator<DateTime> validator,
            DateTime minValue)
        {
            if (validator.Value < minValue)
            {
                Throw.ValueShouldNotBeSmallerThan(validator, minValue, null);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not less than the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <param name="conditionDescription">
        ///     The description of the condition that should hold. The string may hold the placeholder '{0}' for
        ///     the <see cref="ConditionValidator{T}.ArgumentName">ArgumentName</see>.
        /// </param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is smaller than <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is smaller than <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<DateTime> IsNotLessThan(this ConditionValidator<DateTime> validator,
            DateTime minValue,
            string conditionDescription)
        {
            if (validator.Value < minValue)
            {
                Throw.ValueShouldNotBeSmallerThan(validator, minValue, conditionDescription);
            }

            return validator;
        }
    }
}