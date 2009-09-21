using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace TestUtilities
{
    public interface IMethodExpectation<T>
    {
        IMethodOptions<R> IsToldTo<R>(Function<T, R> something);
    }

    internal class MethodExpectation<T> : IMethodExpectation<T> where T : class
    {
        private readonly T t;

        public MethodExpectation(T t)
        {
            this.t = t;
        }

        public IMethodOptions<R> IsToldTo<R>(Function<T, R> something)
        {
            return t.Stub(something);
        }
    }
}