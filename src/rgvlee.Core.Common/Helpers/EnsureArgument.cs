using System;
using System.Collections.Generic;
using System.Linq;

namespace rgvlee.Core.Common.Helpers
{
    /// <summary>
    ///     A helper to perform checks on arguments.
    /// </summary>
    public static class EnsureArgument
    {
        /// <summary>
        ///     Ensures that a string is not null or empty.
        /// </summary>
        /// <param name="argument">The string.</param>
        /// <param name="argumentExpression">The argument expression.</param>
        /// <returns>The string.</returns>
        /// <exception cref="ArgumentNullException">If the string is null.</exception>
        /// <exception cref="ArgumentException">If the string is empty.</exception>
        public static string IsNotNullOrEmpty(
            string argument,
#if NET6_0_OR_GREATER
            [CallerArgumentExpression("argument")]
#endif
            string argumentExpression = default)
        {
            if (!string.IsNullOrEmpty(argument)) return argument;

            IsNotNullOrEmpty(argumentExpression, nameof(argumentExpression));
            var ex = argument == null
                ? new ArgumentNullException(argumentExpression)
                : new ArgumentException("Value cannot be empty.", argumentExpression);
            throw ex;
        }

        /// <summary>
        ///     Ensures that an object is not null.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="argument">The object.</param>
        /// <param name="argumentExpression">The argument expression.</param>
        /// <returns>The object.</returns>
        /// <exception cref="ArgumentNullException">If the object is null.</exception>
        public static T IsNotNull<T>(
            T argument,
#if NET6_0_OR_GREATER
            [CallerArgumentExpression("argument")]
#endif
            string argumentExpression = default)
            where T : class
        {
            if (argument != null) return argument;

            IsNotNullOrEmpty(argumentExpression, nameof(argumentExpression));
            var ex = new ArgumentNullException(argumentExpression);
            throw ex;
        }

        /// <summary>
        ///     Ensures that a sequence is not empty.
        /// </summary>
        /// <typeparam name="T">The sequence item type.</typeparam>
        /// <param name="argument">The sequence.</param>
        /// <param name="argumentExpression">The argument expression.</param>
        /// <returns>The sequence.</returns>
        /// <exception cref="ArgumentException">If the sequence is empty.</exception>
        public static IEnumerable<T> IsNotEmpty<T>(
            IEnumerable<T> argument,
#if NET6_0_OR_GREATER
            [CallerArgumentExpression("argument")]
#endif
            string argumentExpression = default)
        {
            IsNotNull(argument, argumentExpression);

            if (argument.Any()) return argument;

            IsNotNullOrEmpty(argumentExpression, nameof(argumentExpression));
            var ex = new ArgumentException(argumentExpression);
            throw ex;
        }
    }
}