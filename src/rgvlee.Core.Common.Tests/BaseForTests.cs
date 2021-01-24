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
            //LoggingHelper.LoggerFactory = LoggerFactory.Create(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Trace));
            LoggingHelper.LoggerFactory = new LoggerFactory().AddConsole(LogLevel.Trace);

            Fixture = new Fixture();
        }

        [TearDown]
        public virtual void TearDown()
        {
            LoggingHelper.LoggerFactory.Dispose();
        }

        protected Fixture Fixture;
    }
}