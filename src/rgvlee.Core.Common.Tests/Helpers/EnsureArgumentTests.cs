using System;
using FluentAssertions;
using NUnit.Framework;
using rgvlee.Core.Common.Helpers;
using static FluentAssertions.FluentActions;

namespace rgvlee.Core.Common.Tests.Helpers
{
    public class EnsureArgumentTests : BaseForTests
    {
        [TestCase(null)]
        public void IsNotNullOrEmpty_NullString_ThrowsArgumentNullException(string nullString)
        {
#if NET6_0_OR_GREATER
            Invoking(() => EnsureArgument.IsNotNullOrEmpty(nullString)).Should()
#else
            Invoking(() => EnsureArgument.IsNotNullOrEmpty(nullString, nameof(nullString))).Should()
#endif
                .ThrowExactly<ArgumentNullException>()
#if NETCOREAPP3_1_OR_GREATER
                .WithMessage($"Value cannot be null. (Parameter '{nameof(nullString)}')");
#else
                .WithMessage($"Value cannot be null.\nParameter name: {nameof(nullString)}");
#endif
        }

        [TestCase("")]
        public void IsNotNullOrEmpty_EmptyString_ThrowsArgumentException(string emptyString)
        {
#if NET6_0_OR_GREATER
            Invoking(() => EnsureArgument.IsNotNullOrEmpty(emptyString)).Should()
#else
            Invoking(() => EnsureArgument.IsNotNullOrEmpty(emptyString, nameof(emptyString))).Should()
#endif
                .ThrowExactly<ArgumentException>()
#if NETCOREAPP3_1_OR_GREATER
                .WithMessage($"Value cannot be empty. (Parameter '{nameof(emptyString)}')");
#else
                .WithMessage($"Value cannot be empty.\nParameter name: {nameof(emptyString)}");
#endif
        }
    }
}