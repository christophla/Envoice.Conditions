﻿using System;
using System.ComponentModel;

namespace Envoice.Conditions
{
    // Fallback checks for all IComparable types that don't have an explicit overload
    public static partial class ValidatorExtensions
    {
        /// <summary>
        ///     Checks whether the given value is equal to the specified <paramref name="value" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="value">The valid value to compare with.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is not equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is a null reference and <paramref name="value" /> is not a null reference,
        ///     while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is an <see cref="System.Enum">Enum</see> type and not equal to
        ///     <paramref name="value" />, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is not equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsEqualTo<T>(this ConditionValidator<T> validator, T value)
            where T : IComparable
        {
            return IsEqualTo(validator, value, null);
        }

        /// <summary>
        ///     Checks whether the given value is equal to the specified <paramref name="value" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is a null reference and <paramref name="value" /> is not a null reference,
        ///     while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is an <see cref="System.Enum">Enum</see> type and not equal to
        ///     <paramref name="value" />, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is not equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsEqualTo<T>(this ConditionValidator<T> validator, T value,
            string conditionDescription)
            where T : IComparable
        {
            var defaultComparer = DefaultComparer<T>.Default;

            if (!(defaultComparer.Compare(validator.Value, value) == 0))
            {
                Throw.ValueShouldBeEqualTo(validator, value, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is equal to the specified <paramref name="value" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="value">The valid value to compare with.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is not equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is a null reference and <paramref name="value" /> is not a null reference,
        ///     while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is not equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T?> IsEqualTo<T>(this ConditionValidator<T?> validator,
            T? value)
            where T : struct
        {
            return IsEqualTo(validator, value, null);
        }

        /// <summary>
        ///     Checks whether the given value is equal to the specified <paramref name="value" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is a null reference and <paramref name="value" /> is not a null reference,
        ///     while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is not equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T?> IsEqualTo<T>(this ConditionValidator<T?> validator,
            T? value, string conditionDescription)
            where T : struct
        {
            var defaultComparer = DefaultComparer<T?>.Default;

            if (!(defaultComparer.Compare(validator.Value, value) == 0))
            {
                Throw.ValueShouldBeEqualTo(validator, value, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is equal to the specified <paramref name="value" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="value">The valid value to compare with.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is not equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is a null reference and <paramref name="value" /> is not a null reference,
        ///     while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is not equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T?> IsEqualTo<T>(this ConditionValidator<T?> validator,
            T value)
            where T : struct
        {
            return IsEqualTo(validator, value, null);
        }

        /// <summary>
        ///     Checks whether the given value is equal to the specified <paramref name="value" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is a null reference and <paramref name="value" /> is not a null reference,
        ///     while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is not equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T?> IsEqualTo<T>(this ConditionValidator<T?> validator,
            T value, string conditionDescription)
            where T : struct
        {
            var defaultComparer = DefaultComparer<T?>.Default;

            var valueIsValid = defaultComparer.Compare(validator.Value, value) == 0;

            if (!valueIsValid)
            {
                Throw.ValueShouldBeEqualTo(validator, value, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is greater or equal to the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is smaller than <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is smaller than <paramref name="minValue" /> and is an
        ///     <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is smaller than <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsGreaterOrEqual<T>(this ConditionValidator<T> validator, T minValue)
            where T : IComparable
        {
            return IsGreaterOrEqual(validator, minValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is greater or equal to the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is smaller than <paramref name="minValue" /> and is an
        ///     <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is smaller than <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsGreaterOrEqual<T>(this ConditionValidator<T> validator, T minValue,
            string conditionDescription) where T : IComparable
        {
            if (!(DefaultComparer<T>.Default.Compare(validator.Value, minValue) >= 0))
            {
                Throw.ValueShouldBeGreaterThanOrEqualTo(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is greater or equal to the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsGreaterOrEqual<T>(this ConditionValidator<T?> validator,
            T? minValue)
            where T : struct
        {
            return IsGreaterOrEqual(validator, minValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is greater or equal to the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsGreaterOrEqual<T>(this ConditionValidator<T?> validator,
            T? minValue, string conditionDescription)
            where T : struct
        {
            if (!(DefaultComparer<T?>.Default.Compare(validator.Value, minValue) >= 0))
            {
                Throw.ValueShouldBeGreaterThanOrEqualTo(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is greater or equal to the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsGreaterOrEqual<T>(this ConditionValidator<T?> validator,
            T minValue)
            where T : struct
        {
            return IsGreaterOrEqual(validator, minValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is greater or equal to the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsGreaterOrEqual<T>(this ConditionValidator<T?> validator,
            T minValue, string conditionDescription)
            where T : struct
        {
            var comparer = DefaultComparer<T?>.Default;

            var valueIsValid = comparer.Compare(validator.Value, minValue) >= 0;

            if (!valueIsValid)
            {
                Throw.ValueShouldBeGreaterThanOrEqualTo(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is greater than the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is smaller or equal to <paramref name="minValue" />, while the
        ///     specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is smaller or equal to <paramref name="minValue" /> and is an
        ///     <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is smaller or equal to <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsGreaterThan<T>(this ConditionValidator<T> validator, T minValue)
            where T : IComparable
        {
            return IsGreaterThan(validator, minValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is greater than the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is smaller or equal to <paramref name="minValue" /> and is an
        ///     <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is smaller or equal to <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsGreaterThan<T>(this ConditionValidator<T> validator, T minValue,
            string conditionDescription)
            where T : IComparable
        {
            if (!(DefaultComparer<T>.Default.Compare(validator.Value, minValue) > 0))
            {
                Throw.ValueShouldBeGreaterThan(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is greater than the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsGreaterThan<T>(this ConditionValidator<T?> validator,
            T? minValue)
            where T : struct
        {
            return IsGreaterThan(validator, minValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is greater than the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsGreaterThan<T>(this ConditionValidator<T?> validator,
            T? minValue, string conditionDescription)
            where T : struct
        {
            if (!(DefaultComparer<T?>.Default.Compare(validator.Value, minValue) > 0))
            {
                Throw.ValueShouldBeGreaterThan(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is greater than the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsGreaterThan<T>(this ConditionValidator<T?> validator,
            T minValue)
            where T : struct
        {
            return IsGreaterThan(validator, minValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is greater than the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsGreaterThan<T>(this ConditionValidator<T?> validator,
            T minValue, string conditionDescription)
            where T : struct
        {
            var comparer = DefaultComparer<T?>.Default;

            var valueIsValid = comparer.Compare(validator.Value, minValue) > 0;

            if (!valueIsValid)
            {
                Throw.ValueShouldBeGreaterThan(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is between <paramref name="minValue" /> and
        ///     <paramref name="maxValue" /> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is not in the specified range and is an
        ///     <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is not in the specified range, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsInRange<T>(this ConditionValidator<T> validator, T minValue, T maxValue)
            where T : IComparable
        {
            return IsInRange(validator, minValue, maxValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is between <paramref name="minValue" /> and
        ///     <paramref name="maxValue" /> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is not in the specified range and is an
        ///     <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is not in the specified range, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsInRange<T>(this ConditionValidator<T> validator, T minValue, T maxValue,
            string conditionDescription)
            where T : IComparable
        {
            var defaultComparer = DefaultComparer<T>.Default;

            var value = validator.Value;

            var valueIsValid =
                defaultComparer.Compare(value, minValue) >= 0 &&
                defaultComparer.Compare(value, maxValue) <= 0;

            if (!valueIsValid)
            {
                Throw.ValueShouldBeBetween(validator, minValue, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is between <paramref name="minValue" /> and
        ///     <paramref name="maxValue" /> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsInRange<T>(this ConditionValidator<T?> validator,
            T? minValue, T? maxValue)
            where T : struct
        {
            return IsInRange(validator, minValue, maxValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is between <paramref name="minValue" /> and
        ///     <paramref name="maxValue" /> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsInRange<T>(this ConditionValidator<T?> validator,
            T? minValue, T? maxValue, string conditionDescription)
            where T : struct
        {
            var defaultComparer = DefaultComparer<T?>.Default;

            var value = validator.Value;

            var valueIsValid =
                defaultComparer.Compare(value, minValue) >= 0 &&
                defaultComparer.Compare(value, maxValue) <= 0;

            if (!valueIsValid)
            {
                Throw.ValueShouldBeBetween(validator, minValue, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is between <paramref name="minValue" /> and
        ///     <paramref name="maxValue" /> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsInRange<T>(this ConditionValidator<T?> validator,
            T minValue, T maxValue)
            where T : struct
        {
            return IsInRange(validator, minValue, maxValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is between <paramref name="minValue" /> and
        ///     <paramref name="maxValue" /> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsInRange<T>(this ConditionValidator<T?> validator,
            T minValue, T maxValue, string conditionDescription)
            where T : struct
        {
            var defaultComparer = DefaultComparer<T?>.Default;

            var value = validator.Value;

            var valueIsValid =
                defaultComparer.Compare(value, minValue) >= 0 &&
                defaultComparer.Compare(value, maxValue) <= 0;

            if (!valueIsValid)
            {
                Throw.ValueShouldBeBetween(validator, minValue, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is smaller or equal to the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is greater than <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is an <see cref="System.Enum">Enum</see> type and is greater than
        ///     <paramref name="maxValue" />, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is greater than <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsLessOrEqual<T>(this ConditionValidator<T> validator, T maxValue)
            where T : IComparable
        {
            return IsLessOrEqual(validator, maxValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is smaller or equal to the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is an <see cref="System.Enum">Enum</see> type and is greater than
        ///     <paramref name="maxValue" />, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is greater than <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsLessOrEqual<T>(this ConditionValidator<T> validator, T maxValue,
            string conditionDescription)
            where T : IComparable
        {
            if (!(DefaultComparer<T>.Default.Compare(validator.Value, maxValue) <= 0))
            {
                Throw.ValueShouldBeSmallerThanOrEqualTo(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is smaller or equal to the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsLessOrEqual<T>(this ConditionValidator<T?> validator,
            T? maxValue)
            where T : struct
        {
            return IsLessOrEqual(validator, maxValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is smaller or equal to the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsLessOrEqual<T>(this ConditionValidator<T?> validator,
            T? maxValue, string conditionDescription)
            where T : struct
        {
            if (!(DefaultComparer<T?>.Default.Compare(validator.Value, maxValue) <= 0))
            {
                Throw.ValueShouldBeSmallerThanOrEqualTo(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is smaller or equal to the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsLessOrEqual<T>(this ConditionValidator<T?> validator,
            T maxValue)
            where T : struct
        {
            return IsLessOrEqual(validator, maxValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is smaller or equal to the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsLessOrEqual<T>(this ConditionValidator<T?> validator,
            T maxValue, string conditionDescription)
            where T : struct
        {
            var comparer = DefaultComparer<T?>.Default;

            var valueIsValid = comparer.Compare(validator.Value, maxValue) <= 0;

            if (!valueIsValid)
            {
                Throw.ValueShouldBeSmallerThanOrEqualTo(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is less than the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is greater or equal to <paramref name="maxValue" />, while the
        ///     specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is an <see cref="System.Enum">Enum</see> type and is greater or equal
        ///     to <paramref name="maxValue" />, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is greater or equal to <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsLessThan<T>(this ConditionValidator<T> validator, T maxValue)
            where T : IComparable
        {
            return IsLessThan(validator, maxValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is less than the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is an <see cref="System.Enum">Enum</see> type and is greater or equal
        ///     to <paramref name="maxValue" />, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is greater or equal to <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsLessThan<T>(this ConditionValidator<T> validator, T maxValue,
            string conditionDescription)
            where T : IComparable
        {
            if (!(DefaultComparer<T>.Default.Compare(validator.Value, maxValue) < 0))
            {
                Throw.ValueShouldBeSmallerThan(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is less than the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsLessThan<T>(this ConditionValidator<T?> validator,
            T? maxValue)
            where T : struct
        {
            return IsLessThan(validator, maxValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is less than the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsLessThan<T>(this ConditionValidator<T?> validator,
            T? maxValue, string conditionDescription)
            where T : struct
        {
            if (!(DefaultComparer<T?>.Default.Compare(validator.Value, maxValue) < 0))
            {
                Throw.ValueShouldBeSmallerThan(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is less than the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsLessThan<T>(this ConditionValidator<T?> validator,
            T maxValue)
            where T : struct
        {
            return IsLessThan(validator, maxValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is less than the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsLessThan<T>(this ConditionValidator<T?> validator,
            T maxValue, string conditionDescription)
            where T : struct
        {
            var comparer = DefaultComparer<T?>.Default;

            var valueIsValid = comparer.Compare(validator.Value, maxValue) < 0;

            if (!valueIsValid)
            {
                Throw.ValueShouldBeSmallerThan(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is unequal to the specified <paramref name="value" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="value">The invalid value to compare with.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> and the <paramref name="value" /> are both null references, while the
        ///     specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is equal to <paramref name="value" /> and are of type
        ///     <see cref="System.Enum">Enum</see>, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsNotEqualTo<T>(this ConditionValidator<T> validator, T value)
            where T : IComparable
        {
            return IsNotEqualTo(validator, value, null);
        }

        /// <summary>
        ///     Checks whether the given value is unequal to the specified <paramref name="value" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> and the <paramref name="value" /> are both null references, while the
        ///     specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is equal to <paramref name="value" /> and are of type
        ///     <see cref="System.Enum">Enum</see>, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsNotEqualTo<T>(this ConditionValidator<T> validator, T value,
            string conditionDescription)
            where T : IComparable
        {
            if (DefaultComparer<T>.Default.Compare(validator.Value, value) == 0)
            {
                Throw.ValueShouldBeUnequalTo(validator, value, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is unequal to the specified <paramref name="value" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="value">The invalid value to compare with.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> and the <paramref name="value" /> are both null references, while the
        ///     specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T?> IsNotEqualTo<T>(this ConditionValidator<T?> validator,
            T? value)
            where T : struct
        {
            return IsNotEqualTo(validator, value, null);
        }

        /// <summary>
        ///     Checks whether the given value is unequal to the specified <paramref name="value" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> and the <paramref name="value" /> are both null references, while the
        ///     specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is equal to <paramref name="value" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T?> IsNotEqualTo<T>(this ConditionValidator<T?> validator,
            T? value, string conditionDescription)
            where T : struct
        {
            if (DefaultComparer<T?>.Default.Compare(validator.Value, value) == 0)
            {
                Throw.ValueShouldBeUnequalTo(validator, value, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is unequal to the specified <paramref name="value" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsNotEqualTo<T>(this ConditionValidator<T?> validator,
            T value)
            where T : struct
        {
            return IsNotEqualTo(validator, value, null);
        }

        /// <summary>
        ///     Checks whether the given value is unequal to the specified <paramref name="value" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsNotEqualTo<T>(this ConditionValidator<T?> validator,
            T value, string conditionDescription)
            where T : struct
        {
            var comparer = DefaultComparer<T?>.Default;

            var valueIsInvalid = comparer.Compare(validator.Value, value) == 0;

            if (valueIsInvalid)
            {
                Throw.ValueShouldBeUnequalTo(validator, value, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not greater or equal to the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is greater or equal to <paramref name="maxValue" />, while the
        ///     specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is greater or equal to <paramref name="maxValue" /> and is an
        ///     <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is greater or equal to <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsNotGreaterOrEqual<T>(this ConditionValidator<T> validator, T maxValue)
            where T : IComparable
        {
            return IsNotGreaterOrEqual(validator, maxValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is not greater or equal to the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is greater or equal to <paramref name="maxValue" /> and is an
        ///     <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is greater or equal to <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsNotGreaterOrEqual<T>(this ConditionValidator<T> validator, T maxValue,
            string conditionDescription)
            where T : IComparable
        {
            if (DefaultComparer<T>.Default.Compare(validator.Value, maxValue) >= 0)
            {
                Throw.ValueShouldNotBeGreaterThanOrEqualTo(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not greater or equal to the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsNotGreaterOrEqual<T>(this ConditionValidator<T?> validator,
            T? maxValue)
            where T : struct
        {
            return IsNotGreaterOrEqual(validator, maxValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is not greater or equal to the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsNotGreaterOrEqual<T>(this ConditionValidator<T?> validator,
            T? maxValue, string conditionDescription)
            where T : struct
        {
            if (DefaultComparer<T?>.Default.Compare(validator.Value, maxValue) >= 0)
            {
                Throw.ValueShouldNotBeGreaterThanOrEqualTo(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not greater or equal to the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsNotGreaterOrEqual<T>(this ConditionValidator<T?> validator,
            T maxValue)
            where T : struct
        {
            return IsNotGreaterOrEqual(validator, maxValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is not greater or equal to the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsNotGreaterOrEqual<T>(this ConditionValidator<T?> validator,
            T maxValue, string conditionDescription)
            where T : struct
        {
            var comparer = DefaultComparer<T?>.Default;

            var valueIsInvalid = comparer.Compare(validator.Value, maxValue) >= 0;

            if (valueIsInvalid)
            {
                Throw.ValueShouldNotBeGreaterThanOrEqualTo(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not greater than the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is greater than <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is greater than <paramref name="maxValue" /> and is an
        ///     <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is greater than <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsNotGreaterThan<T>(this ConditionValidator<T> validator, T maxValue)
            where T : IComparable
        {
            return IsNotGreaterThan(validator, maxValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is not greater than the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is greater than <paramref name="maxValue" /> and is an
        ///     <see cref="System.Enum">Enum</see> type, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is greater than <paramref name="maxValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsNotGreaterThan<T>(this ConditionValidator<T> validator, T maxValue,
            string conditionDescription) where T : IComparable
        {
            if (DefaultComparer<T>.Default.Compare(validator.Value, maxValue) > 0)
            {
                Throw.ValueShouldNotBeGreaterThan(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not greater than the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsNotGreaterThan<T>(this ConditionValidator<T?> validator,
            T? maxValue)
            where T : struct
        {
            return IsNotGreaterThan(validator, maxValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is not greater than the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsNotGreaterThan<T>(this ConditionValidator<T?> validator,
            T? maxValue, string conditionDescription)
            where T : struct
        {
            if (DefaultComparer<T?>.Default.Compare(validator.Value, maxValue) > 0)
            {
                Throw.ValueShouldNotBeGreaterThan(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not greater than the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsNotGreaterThan<T>(this ConditionValidator<T?> validator,
            T maxValue)
            where T : struct
        {
            return IsNotGreaterThan(validator, maxValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is not greater than the specified <paramref name="maxValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsNotGreaterThan<T>(this ConditionValidator<T?> validator,
            T maxValue, string conditionDescription)
            where T : struct
        {
            var comparer = DefaultComparer<T?>.Default;

            var valueIsInvalid = comparer.Compare(validator.Value, maxValue) > 0;

            if (valueIsInvalid)
            {
                Throw.ValueShouldNotBeGreaterThan(validator, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not between <paramref name="minValue" /> and
        ///     <paramref name="maxValue" /> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is in the specified range and a null reference, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is in the specified range, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsNotInRange<T>(this ConditionValidator<T> validator, T minValue, T maxValue)
            where T : IComparable
        {
            return IsNotInRange(validator, minValue, maxValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is not between <paramref name="minValue" /> and
        ///     <paramref name="maxValue" /> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is in the specified range and a null reference, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is in the specified range, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsNotInRange<T>(this ConditionValidator<T> validator, T minValue, T maxValue,
            string conditionDescription) where T : IComparable
        {
            var defaultComparer = DefaultComparer<T>.Default;

            var value = validator.Value;

            var valueIsInvalid =
                defaultComparer.Compare(value, minValue) >= 0 &&
                defaultComparer.Compare(value, maxValue) <= 0;

            if (valueIsInvalid)
            {
                Throw.ValueShouldNotBeBetween(validator, minValue, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not between <paramref name="minValue" /> and
        ///     <paramref name="maxValue" /> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is in the specified range and a null reference, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is in the specified range and an <see cref="System.Enum">Enum</see>
        ///     type, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is in the specified range, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T?> IsNotInRange<T>(this ConditionValidator<T?> validator,
            T? minValue, T? maxValue)
            where T : struct
        {
            return IsNotInRange(validator, minValue, maxValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is not between <paramref name="minValue" /> and
        ///     <paramref name="maxValue" /> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is in the specified range and a null reference, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is in the specified range and an <see cref="System.Enum">Enum</see>
        ///     type, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is in the specified range, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T?> IsNotInRange<T>(this ConditionValidator<T?> validator,
            T? minValue, T? maxValue, string conditionDescription) where T : struct
        {
            var defaultComparer = DefaultComparer<T?>.Default;

            var value = validator.Value;

            var valueIsInvalid =
                defaultComparer.Compare(value, minValue) >= 0 &&
                defaultComparer.Compare(value, maxValue) <= 0;

            if (valueIsInvalid)
            {
                Throw.ValueShouldNotBeBetween(validator, minValue, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not between <paramref name="minValue" /> and
        ///     <paramref name="maxValue" /> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is in the specified range and a null reference, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is in the specified range, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T?> IsNotInRange<T>(this ConditionValidator<T?> validator,
            T minValue, T maxValue)
            where T : struct
        {
            return IsNotInRange(validator, minValue, maxValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is not between <paramref name="minValue" /> and
        ///     <paramref name="maxValue" /> (including those values). An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is in the specified range and a null reference, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is in the specified range, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T?> IsNotInRange<T>(this ConditionValidator<T?> validator,
            T minValue, T maxValue, string conditionDescription) where T : struct
        {
            var defaultComparer = DefaultComparer<T?>.Default;

            var value = validator.Value;

            var valueIsInvalid =
                defaultComparer.Compare(value, minValue) >= 0 &&
                defaultComparer.Compare(value, maxValue) <= 0;

            if (valueIsInvalid)
            {
                Throw.ValueShouldNotBeBetween(validator, minValue, maxValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not smaller or equal to the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is smaller or equal to <paramref name="minValue" />, while the
        ///     specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is an <see cref="System.Enum">Enum</see> type and is smaller or equal
        ///     to <paramref name="minValue" />, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is smaller or equal to <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsNotLessOrEqual<T>(this ConditionValidator<T> validator, T minValue)
            where T : IComparable
        {
            return IsNotLessOrEqual(validator, minValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is not smaller or equal to the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is an <see cref="System.Enum">Enum</see> type and is smaller or equal
        ///     to <paramref name="minValue" />, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is smaller or equal to <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsNotLessOrEqual<T>(this ConditionValidator<T> validator, T minValue,
            string conditionDescription)
            where T : IComparable
        {
            if (DefaultComparer<T>.Default.Compare(validator.Value, minValue) <= 0)
            {
                Throw.ValueShouldNotBeSmallerThanOrEqualTo(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not smaller or equal to the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsNotLessOrEqual<T>(this ConditionValidator<T?> validator,
            T? minValue)
            where T : struct
        {
            return IsNotLessOrEqual(validator, minValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is not smaller or equal to the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsNotLessOrEqual<T>(this ConditionValidator<T?> validator,
            T? minValue, string conditionDescription)
            where T : struct
        {
            if (DefaultComparer<T?>.Default.Compare(validator.Value, minValue) <= 0)
            {
                Throw.ValueShouldNotBeSmallerThanOrEqualTo(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not smaller or equal to the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsNotLessOrEqual<T>(this ConditionValidator<T?> validator,
            T minValue)
            where T : struct
        {
            return IsNotLessOrEqual(validator, minValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is not smaller or equal to the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsNotLessOrEqual<T>(this ConditionValidator<T?> validator,
            T minValue, string conditionDescription)
            where T : struct
        {
            var comparer = DefaultComparer<T?>.Default;

            var valueIsInvalid = comparer.Compare(validator.Value, minValue) <= 0;

            if (valueIsInvalid)
            {
                Throw.ValueShouldNotBeSmallerThanOrEqualTo(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not less than the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
        /// <param name="validator">The <see cref="ConditionValidator{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="validator" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is smaller than <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Requires{T}(T,string)">Requires</see>
        ///     extension method.
        /// </exception>
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is an <see cref="System.Enum">Enum</see> type and smaller than
        ///     <paramref name="minValue" />, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is smaller than <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsNotLessThan<T>(this ConditionValidator<T> validator, T minValue)
            where T : IComparable
        {
            return IsNotLessThan(validator, minValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is not less than the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        /// <exception cref="InvalidEnumArgumentException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of
        ///     the specified <paramref name="validator" /> is an <see cref="System.Enum">Enum</see> type and smaller than
        ///     <paramref name="minValue" />, while the specified <paramref name="validator" /> is created using the
        ///     <see cref="Condition.Requires{T}(T,string)">Requires</see> extension method.
        /// </exception>
        /// <exception cref="PostconditionException">
        ///     Thrown when the <see cref="ConditionValidator{T}.Value">Value</see> of the
        ///     specified <paramref name="validator" /> is smaller than <paramref name="minValue" />, while the specified
        ///     <paramref name="validator" /> is created using the <see cref="Condition.Ensures{T}(T,string)">Ensures</see>
        ///     extension method.
        /// </exception>
        public static ConditionValidator<T> IsNotLessThan<T>(this ConditionValidator<T> validator, T minValue,
            string conditionDescription)
            where T : IComparable
        {
            if (DefaultComparer<T>.Default.Compare(validator.Value, minValue) < 0)
            {
                Throw.ValueShouldNotBeSmallerThan(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not less than the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsNotLessThan<T>(this ConditionValidator<T?> validator,
            T? minValue)
            where T : struct
        {
            return IsNotLessThan(validator, minValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is not less than the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsNotLessThan<T>(this ConditionValidator<T?> validator,
            T? minValue, string conditionDescription)
            where T : struct
        {
            if (DefaultComparer<T?>.Default.Compare(validator.Value, minValue) < 0)
            {
                Throw.ValueShouldNotBeSmallerThan(validator, minValue, conditionDescription);
            }

            return validator;
        }

        /// <summary>
        ///     Checks whether the given value is not less than the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsNotLessThan<T>(this ConditionValidator<T?> validator,
            T minValue)
            where T : struct
        {
            return IsNotLessThan(validator, minValue, null);
        }

        /// <summary>
        ///     Checks whether the given value is not less than the specified <paramref name="minValue" />.
        ///     An exception is thrown otherwise.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the <see cref="ConditionValidator{T}.Value">Value</see> of the specified
        ///     <paramref name="validator" />.
        /// </typeparam>
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
        public static ConditionValidator<T?> IsNotLessThan<T>(this ConditionValidator<T?> validator,
            T minValue, string conditionDescription)
            where T : struct
        {
            var comparer = DefaultComparer<T?>.Default;

            var valueIsInvalid = comparer.Compare(validator.Value, minValue) < 0;

            if (valueIsInvalid)
            {
                Throw.ValueShouldNotBeSmallerThan(validator, minValue, conditionDescription);
            }

            return validator;
        }
    }
}
