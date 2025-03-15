using Lwkit.Fixed;
using System.Diagnostics;

namespace Test
{
    /// <summary>
    /// 
    /// </summary>
    interface ITest
    {
        void Run();
    }

    /// <summary>
    /// 
    /// </summary>
    internal class TestAttribute : Attribute
    {

    }

    /// <summary>
    /// 
    /// </summary>
    internal abstract class BaseTest<T> : ITest where T : IFixed<T>
    {
        private const float  SINGLE_PRECISION = 0.00001f;
        private const double DOUBLE_PRECISION = SINGLE_PRECISION;

        /// <summary>
        /// 
        /// </summary>
        public abstract void Run();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        protected void Assert(T a, int b)
        {
            var delta = Math.Abs(a.ToInt() - b);
            Debug.Assert(delta == 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        protected void Assert(T a, float b)
        {
            var delta = Math.Abs(a.ToFloat() - b);
            Debug.Assert(delta <= SINGLE_PRECISION);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        protected void Assert(T a, double b)
        {
            var delta = Math.Abs(a.ToDouble() - b);
            Debug.Assert(delta <= DOUBLE_PRECISION);
        }
    }
}
