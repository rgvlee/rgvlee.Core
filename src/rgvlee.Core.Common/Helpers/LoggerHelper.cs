using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace rgvlee.Core.Common.Helpers
{
    /// <summary>
    ///     Logging helper methods.
    /// </summary>
    public static class LoggingHelper
    {
        private static ILoggerFactory _factory;

        /// <summary>
        ///     Gets or sets the logger factory used to create loggers.
        /// </summary>
        public static ILoggerFactory LoggerFactory {
            get => _factory ?? (_factory = new LoggerFactory());
            set => _factory = value;
        }

        /// <summary>
        ///     Creates a new logger instance using the full name of the specified type.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>A new logger instance.</returns>
        public static ILogger<T> CreateLogger<T>()
        {
            Debug.Print("CreateLogger: start");
            Debug.Print($"T: {typeof(T)}");
            return LoggerFactory.CreateLogger<T>();
        }

        /// <summary>
        ///     Creates a new logger instance using the full name of the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>A new logger instance.</returns>
        public static ILogger CreateLogger(Type type)
        {
            Debug.Print("CreateLogger: start");

            EnsureArgument.IsNotNull(type, nameof(type));

            Debug.Print($"type: {type}");

            return LoggerFactory.CreateLogger(type);
        }
    }
}