using System;
using rgvlee.Core.Common.Helpers;

namespace rgvlee.Core.Common.Extensions
{
    /// <summary>
    ///     <see cref="Type" /> extensions.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        ///     Gets the default value for the specified type.
        /// </summary>
        /// <param name="type">The type to get the default value for.</param>
        /// <returns>The default value for the specified type.</returns>
        public static object GetDefaultValue(this Type type)
        {
            EnsureArgument.IsNotNull(type, nameof(type));

            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }

        public static bool HasParameterlessConstructor(this Type type)
        {
            EnsureArgument.IsNotNull(type, nameof(type));

            return type.HasConstructor();
        }

        public static bool HasConstructor(this Type type, params Type[] parameterTypes)
        {
            EnsureArgument.IsNotNull(type, nameof(type));
            EnsureArgument.IsNotNull(parameterTypes, nameof(parameterTypes));

            return type.IsValueType || type.GetConstructor(parameterTypes ?? new Type[] { }) != null;
        }
    }
}