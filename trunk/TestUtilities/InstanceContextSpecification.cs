using NUnit.Framework;
using Rhino.Mocks;

namespace TestUtilities
{
    [TestFixture]
    public abstract class InstanceContextSpecification<SUT>
    {
        protected SUT sut;

        [SetUp]
        public void SetUp()
        {
            Arrange();
            sut = CreateSystemUnderTest();
            Act();
        }

        protected virtual void Arrange()
        {
        }

        protected abstract SUT CreateSystemUnderTest();

        protected virtual void Act()
        {
        }

        protected T Dependency<T>() where T : class
        {
            return MockRepository.GenerateStub<T>();
        }

        protected IMethodExpectation<T> When<T>(T t) where T : class
        {
            return new MethodExpectation<T>(t);
        }
    }
}