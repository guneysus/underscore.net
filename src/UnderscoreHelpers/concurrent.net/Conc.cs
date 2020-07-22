using System;
using System.Buffers;

namespace concurrent.net
{
    public static class Conc
    {
        /// <summary>
        /// TODO DOC
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static Lazy<T> lazy<T>(Func<T> factory)
        {
            return new Lazy<T>(factory, System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);
        }

        /// <summary>
        /// TODO TEST
        /// Borrows an array from Pool
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="minimumLength"></param>
        /// <returns></returns>
        public static T[] borrow<T>(int minimumLength) => ArrayPool<T>.Shared.Rent(minimumLength);

        /// <summary>
        /// TODO TEST
        /// Returns the buffer to the pool
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static bool give<T>(T[] buffer)
        {
            ArrayPool<T>.Shared.Return(buffer, clearArray: true);
            return true;
        }

        /// <summary>
        /// Borrows an
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="minBufferSize"></param>
        /// <returns></returns>
        public static IMemoryOwner<T> memory<T>(int minBufferSize) => MemoryPool<T>.Shared.Rent(minBufferSize);


    }
}
