using AutoFixture;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using rgvlee.Core.Common.Helpers;

namespace rgvlee.Core.Common.Tests
{
    [TestFixture]
    public abstract class BaseForTests
    {
        [SetUp]
        public virtual void SetUp()
        {
            //LoggingHelper.LoggerFactory = LoggerFactory.Create(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Debug));
            LoggingHelper.LoggerFactory = new LoggerFactory().AddConsole();

            Fixture = new Fixture();
        }

        protected Fixture Fixture;

        protected static readonly ILogger Logger = LoggingHelper.CreateLogger(typeof(BaseForTests));
    }
}