﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValidation.Internal.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// <auto-generated>
//   Sourced from NuGet package. Will be overwritten with package update except in OBeautifulCode.Validation source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Validation.Recipes
{
    using System;
    using System.Collections;

    /// <summary>
    /// Contains all validations that can be applied to a <see cref="Parameter"/>.
    /// </summary>
#if !OBeautifulCodeValidationRecipesProject
    internal
#else
    public
#endif
        static partial class ParameterValidation
    {
        private delegate void ValueValidationHandler(string validationName, object value, Type valueType, string parameterName, string because, bool isElementInEnumerable, params ValidationParameter[] validationParameters);

        private static void BeNullInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            if (!ReferenceEquals(value, null))
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, BeNullExceptionMessageSuffix, failingValue: value);
                throw new ArgumentException(exceptionMessage);
            }
        }

        private static void NotBeNullInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            if (ReferenceEquals(value, null))
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, NotBeNullExceptionMessageSuffix);
                if (isElementInEnumerable)
                {
                    throw new ArgumentException(exceptionMessage);
                }
                else
                {
                    throw new ArgumentNullException(null, exceptionMessage);
                }
            }
        }

        private static void BeTrueInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            var shouldThrow = ReferenceEquals(value, null) || ((bool)value != true);
            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, BeTrueExceptionMessageSuffix, failingValue: value ?? NullValueToString);
                throw new ArgumentException(exceptionMessage);
            }
        }

        private static void NotBeTrueInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            var shouldNotThrow = ReferenceEquals(value, null) || ((bool)value == false);
            if (!shouldNotThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, NotBeTrueExceptionMessageSuffix);
                throw new ArgumentException(exceptionMessage);
            }
        }

        private static void BeFalseInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            var shouldThrow = ReferenceEquals(value, null) || (bool)value;
            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, BeFalseExceptionMessageSuffix, failingValue: value ?? NullValueToString);
                throw new ArgumentException(exceptionMessage);
            }
        }

        private static void NotBeFalseInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            var shouldNotThrow = ReferenceEquals(value, null) || (bool)value;
            if (!shouldNotThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, NotBeFalseExceptionMessageSuffix);
                throw new ArgumentException(exceptionMessage);
            }
        }

        private static void NotBeNullNorWhiteSpaceInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            NotBeNullInternal(validationName, value, valueType, parameterName, because, isElementInEnumerable);

            var shouldThrow = string.IsNullOrWhiteSpace((string)value);
            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, NotBeNullNorWhiteSpaceExceptionMessageSuffix, failingValue: value);
                throw new ArgumentException(exceptionMessage);
            }
        }

        private static void BeEmptyGuidInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            var shouldThrow = ReferenceEquals(value, null) || ((Guid)value != Guid.Empty);
            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, BeEmptyGuidExceptionMessageSuffix, failingValue: value ?? NullValueToString);
                throw new ArgumentException(exceptionMessage);
            }
        }

        private static void NotBeEmptyGuidInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            var shouldThrow = (!ReferenceEquals(value, null)) && ((Guid)value == Guid.Empty);
            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, NotBeEmptyGuidExceptionMessageSuffix);
                throw new ArgumentException(exceptionMessage);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1820:TestForEmptyStringsUsingStringLength", Justification = "string.IsNullOrEmpty does not work here")]
        private static void BeEmptyStringInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            var shouldThrow = (string)value != string.Empty;

            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, BeEmptyStringExceptionMessageSuffix, failingValue: value ?? NullValueToString);
                throw new ArgumentException(exceptionMessage);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1820:TestForEmptyStringsUsingStringLength", Justification = "string.IsNullOrEmpty does not work here")]
        private static void NotBeEmptyStringInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            var shouldThrow = (string)value == string.Empty;

            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, NotBeEmptyStringExceptionMessageSuffix);
                throw new ArgumentException(exceptionMessage);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "unused", Justification = "Cannot iterate without a local")]
        private static void BeEmptyEnumerableInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            NotBeNullInternal(validationName, value, valueType, parameterName, because, isElementInEnumerable);

            var valueAsEnumerable = value as IEnumerable;
            var shouldThrow = false;

            // ReSharper disable once PossibleNullReferenceException
            foreach (var unused in valueAsEnumerable)
            {
                shouldThrow = true;
                break;
            }

            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, BeEmptyEnumerableExceptionMessageSuffix);
                throw new ArgumentException(exceptionMessage);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "unused", Justification = "Cannot iterate without a local")]
        private static void NotBeEmptyEnumerableInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            NotBeNullInternal(validationName, value, valueType, parameterName, because, isElementInEnumerable);

            var valueAsEnumerable = value as IEnumerable;
            var shouldThrow = true;

            // ReSharper disable once PossibleNullReferenceException
            foreach (var unused in valueAsEnumerable)
            {
                shouldThrow = false;
                break;
            }

            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, NotBeEmptyEnumerableExceptionMessageSuffix);
                throw new ArgumentException(exceptionMessage);
            }
        }

        private static void ContainSomeNullsInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            NotBeNullInternal(validationName, value, valueType, parameterName, because, isElementInEnumerable);

            var valueAsEnumerable = value as IEnumerable;
            var shouldThrow = true;

            // ReSharper disable once PossibleNullReferenceException
            foreach (var unused in valueAsEnumerable)
            {
                if (ReferenceEquals(unused, null))
                {
                    shouldThrow = false;
                    break;
                }
            }

            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, ContainSomeNullsExceptionMessageSuffix);
                throw new ArgumentException(exceptionMessage);
            }
        }

        private static void NotContainAnyNullsInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            NotBeNullInternal(validationName, value, valueType, parameterName, because, isElementInEnumerable);

            var valueAsEnumerable = value as IEnumerable;
            var shouldThrow = false;

            // ReSharper disable once PossibleNullReferenceException
            foreach (var unused in valueAsEnumerable)
            {
                if (ReferenceEquals(unused, null))
                {
                    shouldThrow = true;
                    break;
                }
            }

            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, NotContainAnyNullsExceptionMessageSuffix);
                throw new ArgumentException(exceptionMessage);
            }
        }

        private static void BeDefaultInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            var defaultValue = GetDefaultValue(valueType);
            var shouldThrow = !EqualUsingDefaultEqualityComparer(valueType, value, defaultValue);
            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, BeDefaultExceptionMessageSuffix, genericType: valueType, failingValue: value ?? NullValueToString);
                throw new ArgumentException(exceptionMessage);
            }
        }

        private static void NotBeDefaultInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            var defaultValue = GetDefaultValue(valueType);
            var shouldThrow = EqualUsingDefaultEqualityComparer(valueType, value, defaultValue);
            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, NotBeDefaultExceptionMessageSuffix, genericType: valueType);
                throw new ArgumentException(exceptionMessage);
            }
        }

        private static void BeLessThanInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            var shouldThrow = CompareUsingDefaultComparer(valueType, value, validationParameters[0].Value) != CompareOutcome.Value1LessThanValue2;
            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, BeLessThanExceptionMessageSuffix, genericType: valueType, failingValue: value ?? NullValueToString);

                if (isElementInEnumerable)
                {
                    throw new ArgumentException(exceptionMessage);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(exceptionMessage, (Exception)null);
                }
            }
        }

        private static void NotBeLessThanInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            var shouldThrow = CompareUsingDefaultComparer(valueType, value, validationParameters[0].Value) == CompareOutcome.Value1LessThanValue2;
            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, NotBeLessThanExceptionMessageSuffix, genericType: valueType, failingValue: value ?? NullValueToString);

                if (isElementInEnumerable)
                {
                    throw new ArgumentException(exceptionMessage);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(exceptionMessage, (Exception)null);
                }
            }
        }

        private static void BeGreaterThanInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            var shouldThrow = CompareUsingDefaultComparer(valueType, value, validationParameters[0].Value) != CompareOutcome.Value1GreaterThanValue2;
            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, BeGreaterThanExceptionMessageSuffix, genericType: valueType, failingValue: value ?? NullValueToString);

                if (isElementInEnumerable)
                {
                    throw new ArgumentException(exceptionMessage);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(exceptionMessage, (Exception)null);
                }
            }
        }

        private static void NotBeGreaterThanInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            var shouldThrow = CompareUsingDefaultComparer(valueType, value, validationParameters[0].Value) == CompareOutcome.Value1GreaterThanValue2;
            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, NotBeGreaterThanExceptionMessageSuffix, genericType: valueType, failingValue: value ?? NullValueToString);

                if (isElementInEnumerable)
                {
                    throw new ArgumentException(exceptionMessage);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(exceptionMessage, (Exception)null);
                }
            }
        }

        private static void BeLessThanOrEqualToInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            var shouldThrow = CompareUsingDefaultComparer(valueType, value, validationParameters[0].Value) == CompareOutcome.Value1GreaterThanValue2;
            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, BeLessThanOrEqualToExceptionMessageSuffix, genericType: valueType, failingValue: value ?? NullValueToString);

                if (isElementInEnumerable)
                {
                    throw new ArgumentException(exceptionMessage);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(exceptionMessage, (Exception)null);
                }
            }
        }

        private static void NotBeLessThanOrEqualToInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            var shouldThrow = CompareUsingDefaultComparer(valueType, value, validationParameters[0].Value) != CompareOutcome.Value1GreaterThanValue2;
            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, NotBeLessThanOrEqualToExceptionMessageSuffix, genericType: valueType, failingValue: value ?? NullValueToString);

                if (isElementInEnumerable)
                {
                    throw new ArgumentException(exceptionMessage);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(exceptionMessage, (Exception)null);
                }
            }
        }

        private static void BeGreaterThanOrEqualToInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            var shouldThrow = CompareUsingDefaultComparer(valueType, value, validationParameters[0].Value) == CompareOutcome.Value1LessThanValue2;
            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, BeGreaterThanOrEqualToExceptionMessageSuffix, genericType: valueType, failingValue: value ?? NullValueToString);

                if (isElementInEnumerable)
                {
                    throw new ArgumentException(exceptionMessage);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(exceptionMessage, (Exception)null);
                }
            }
        }

        private static void NotBeGreaterThanOrEqualToInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            var shouldThrow = CompareUsingDefaultComparer(valueType, value, validationParameters[0].Value) != CompareOutcome.Value1LessThanValue2;
            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, NotBeGreaterThanOrEqualToExceptionMessageSuffix, genericType: valueType, failingValue: value ?? NullValueToString);

                if (isElementInEnumerable)
                {
                    throw new ArgumentException(exceptionMessage);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(exceptionMessage, (Exception)null);
                }
            }
        }

        private static void BeEqualToInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            var shouldThrow = !EqualUsingDefaultEqualityComparer(valueType, value, validationParameters[0].Value);
            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, BeEqualToExceptionMessageSuffix, genericType: valueType, failingValue: value ?? NullValueToString);
                if (isElementInEnumerable)
                {
                    throw new ArgumentException(exceptionMessage);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(exceptionMessage, (Exception)null);
                }
            }
        }

        private static void NotBeEqualToInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            var shouldThrow = EqualUsingDefaultEqualityComparer(valueType, value, validationParameters[0].Value);
            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, NotBeEqualToExceptionMessageSuffix, genericType: valueType);
                if (isElementInEnumerable)
                {
                    throw new ArgumentException(exceptionMessage);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(exceptionMessage, (Exception)null);
                }
            }
        }

        private static void BeInRangeInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            ThrowIfMalformedRange(validationParameters);

            var shouldThrow = (CompareUsingDefaultComparer(valueType, value, validationParameters[0].Value) == CompareOutcome.Value1LessThanValue2) ||
                              (CompareUsingDefaultComparer(valueType, value, validationParameters[1].Value) == CompareOutcome.Value1GreaterThanValue2);

            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, BeInRangeExceptionMessageSuffix, genericType: valueType, failingValue: value ?? NullValueToString);

                if (isElementInEnumerable)
                {
                    throw new ArgumentException(exceptionMessage);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(exceptionMessage, (Exception)null);
                }
            }
        }

        private static void NotBeInRangeInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            ThrowIfMalformedRange(validationParameters);

            var shouldThrow = (CompareUsingDefaultComparer(valueType, value, validationParameters[0].Value) != CompareOutcome.Value1LessThanValue2) &&
                              (CompareUsingDefaultComparer(valueType, value, validationParameters[1].Value) != CompareOutcome.Value1GreaterThanValue2);

            if (shouldThrow)
            {
                var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, NotBeInRangeExceptionMessageSuffix, genericType: valueType);

                if (isElementInEnumerable)
                {
                    throw new ArgumentException(exceptionMessage);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(exceptionMessage, (Exception)null);
                }
            }
        }

        private static void ContainInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            NotBeNullInternal(validationName, value, valueType, parameterName, because, isElementInEnumerable);

            var valueAsEnumerable = (IEnumerable)value;
            var searchForItem = validationParameters[0].Value;
            var elementType = validationParameters[0].ValueType;
            foreach (var element in valueAsEnumerable)
            {
                if (EqualUsingDefaultEqualityComparer(elementType, element, searchForItem))
                {
                    return;
                }
            }

            var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, ContainExceptionMessageSuffix, genericType: elementType);
            throw new ArgumentException(exceptionMessage);
        }

        private static void NotContainInternal(
            string validationName,
            object value,
            Type valueType,
            string parameterName,
            string because,
            bool isElementInEnumerable,
            params ValidationParameter[] validationParameters)
        {
            NotBeNullInternal(validationName, value, valueType, parameterName, because, isElementInEnumerable);

            var valueAsEnumerable = (IEnumerable)value;
            var searchForItem = validationParameters[0].Value;
            var elementType = validationParameters[0].ValueType;
            foreach (var element in valueAsEnumerable)
            {
                if (EqualUsingDefaultEqualityComparer(elementType, element, searchForItem))
                {
                    var exceptionMessage = BuildArgumentExceptionMessage(parameterName, because, isElementInEnumerable, validationParameters, NotContainExceptionMessageSuffix, genericType: elementType);
                    throw new ArgumentException(exceptionMessage);
                }
            }
        }
    }
}
