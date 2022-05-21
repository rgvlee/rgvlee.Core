using System;
using NUnit.Framework;
using rgvlee.Core.Common.Extensions;

namespace rgvlee.Core.Common.Tests.Extensions
{
    public class TypeExtensionsTests : BaseForTests
    {
        [Test]
        public void GetDefaultValue_Guid_ReturnsDefaultGuid()
        {
            Assert.That(typeof(Guid).GetDefaultValue(), Is.EqualTo(default(Guid)));
        }

        [Test]
        public void GetDefaultValue_Int_ReturnsDefaultInt()
        {
            Assert.That(typeof(int).GetDefaultValue(), Is.EqualTo(default(int)));
        }

        [Test]
        public void GetDefaultValue_Bool_ReturnsDefaultBool()
        {
            Assert.That(typeof(bool).GetDefaultValue(), Is.EqualTo(default(bool)));
        }

        [Test]
        public void GetDefaultValue_String_ReturnsDefaultString()
        {
            Assert.That(typeof(string).GetDefaultValue(), Is.EqualTo(default(string)));
        }

        [Test]
        public void GetDefaultValue_TypeWithParameterlessConstructor_ReturnsNull()
        {
            Assert.That(typeof(TypeWithParameterlessConstructor).GetDefaultValue(), Is.Null);
        }

        [Test]
        public void HasParameterlessConstructor_TypeWithParameterlessConstructor_ReturnsTrue()
        {
            Assert.That(typeof(TypeWithParameterlessConstructor).HasParameterlessConstructor(), Is.True);
        }

        [Test]
        public void GetConstructor_LiskovSubstitutionPrinciple_ReturnsConstructor()
        {
            var type = typeof(Baz);
            var ci1 = type.GetConstructor(new[] { typeof(Foo) });
            var ci2 = type.GetConstructor(new[] { typeof(Bar) });
            var ci3 = type.GetConstructor(new[] { typeof(Guid) });

            Assert.Multiple(() =>
            {
                Assert.That(ci3, Is.Null); //Control test
                Assert.That(ci1, Is.Not.Null);
                Assert.That(ci2, Is.Not.Null);
                Assert.That(ci1, Is.EqualTo(ci2));
            });
        }

        private class TypeWithParameterlessConstructor { }

        private class Foo { }

        private class Bar : Foo { }

        private class Baz
        {
            public Baz(Foo foo) { }
        }
    }
}