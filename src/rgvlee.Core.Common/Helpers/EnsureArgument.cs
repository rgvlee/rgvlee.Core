using System;
using System.Collections.Generic;
using System.Linq;
#if NET6_0_OR_GREATER
using System.Runtime.CompilerServices;
#endif

namespace rgvlee.Core.Common.Helpers
{
    /// <summary>
    ///     A helper to perform checks on arguments.
    /// </summary>
    public static class EnsureArgument
    {
        /// <summary>
        ///     Ensures that a string argument is not null or empty.
        /// </summary>
        /// <param name="argument">The string argument.</param>
        /// <param name="argumentExpression">The argument expression.</param>
        /// <returns>The string argument.</returns>
        /// <exception cref="ArgumentNullException">If the string argument is null.</exception>
        /// <exception cref="ArgumentException">If the string argument is empty.</exception>
        public static string IsNotNullOrEmpty(
            string argument,
#if NET6_0_OR_GREATER
            [CallerArgumentExpression("argument")]
#endif
            string argumentExpression = default)
        {
            if (!string.IsNullOrEmpty(argument))
            {
                return argument;
            }

            IsNotNullOrEmpty(argumentExpression, nameof(argumentExpression));
            var ex = argument == null ? new ArgumentNullException(argumentExpression) : new ArgumentException(argumentExpression);
            throw ex;
        }

        /// <summary>
        ///     Ensures that an object argument is not null.
        /// </summary>
        /// <typeparam name="T">The object argument type.</typeparam>
        /// <param name="argument">The object argument.</param>
        /// <param name="argumentExpression">The argument expression.</param>
        /// <returns>The object argument.</returns>
        /// <exception cref="ArgumentNullException">If the object argument is null.</exception>
        public static T IsNotNull<T>(
            T argument,
#if NET6_0_OR_GREATER
            [CallerArgumentExpression("argument")]
#endif
            string argumentExpression = default)
            where T : class
        {
            if (argument != null)
            {
                return argument;
            }

            IsNotNullOrEmpty(argumentExpression, nameof(argumentExpression));
            var ex = new ArgumentNullException(argumentExpression);
            throw ex;
        }

        /// <summary>
        ///     Ensures that a sequence argument is not empty.
        /// </summary>
        /// <typeparam name="T">The sequence argument item type.</typeparam>
        /// <param name="argument">The sequence argument.</param>
        /// <param name="argumentExpression">The argument expression.</param>
        /// <returns>The sequence argument.</returns>
        /// <exception cref="ArgumentException">If the sequence argument is empty.</exception>
        public static IEnumerable<T> IsNotEmpty<T>(
            IEnumerable<T> argument,
#if NET6_0_OR_GREATER
            [CallerArgumentExpression("argument")]
#endif
            string argumentExpression = default)
        {
            IsNotNull(argument, argumentExpression);

            if (argument.Any())
            {
                return argument;
            }

            IsNotNullOrEmpty(argumentExpression, nameof(argumentExpression));
            var ex = new ArgumentException(argumentExpression);
            throw ex;
        }
    }
}