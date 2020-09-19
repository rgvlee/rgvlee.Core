using System;
using rgvlee.Core.Common.Helpers;

namespace rgvlee.Core.Common.Extensions
{
    /// <summary>
    ///     <see cref="string" /> extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Checks to see if the target string contains the search for string using the specified string comparer.
        /// </summary>
        /// <param name="string">The string to search.</param>
        /// <param name="searchFor">The string to search for within the string to search.</param>
        /// <param name="comparer">The string comparer.</param>
        /// <returns>true if the string to search contains the string to search for using the specified string comparer.</returns>
        public static bool Contains(this string @string, string searchFor, StringComparison comparer)
        {
            EnsureArgument.IsNotNull(@string, nameof(@string));
            EnsureArgument.IsNotNull(searchFor, nameof(searchFor));

            return @string.IndexOf(searchFor, 0, comparer) != -1;
        }
    }
}