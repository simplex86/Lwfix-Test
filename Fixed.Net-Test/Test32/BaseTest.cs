using Lwkit.Fixed;
using System.Diagnostics;

namespace Test
{
    /// <summary>
    /// 
    /// </summary>
    internal abstract class BaseTest<T> where T : IFixed<T>
    {
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
            Debug.Assert(delta <= 0.00001f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        protected void Assert(T a, double b)
        {
            var delta = Math.Abs(a.ToDouble() - b);
            Debug.Assert(delta <= 0.0000001);
        }
    }
}
