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
        private const double PRECISION = 0.00001;

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
        protected void Assert(T a, double b)
        {
            var delta = Math.Abs(a.ToDouble() - b);
            Debug.Assert(delta <= PRECISION);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="precision"></param>
        protected void Assert(T a, double b, double precision)
        {
            var delta = Math.Abs(a.ToDouble() - b);
            Debug.Assert(delta <= precision);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        protected void Assert(bool a, bool b)
        {
            Debug.Assert(a == b);
        }
    }
}
