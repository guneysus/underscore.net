using System;
using System.Diagnostics.Contracts;
using System.IO;

namespace fs.net
{
    public static class Fs
    {
        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        public static void writeall(string path, string content)
        {
            if (path.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(path));
            }

            File.WriteAllText(path, content);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [Pure]
        public static string readall(string path)
        {
            if (path.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0 || path.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(path));
            }

            return File.ReadAllText(path);
        }

        /// <summary>
        /// TODO #Doc 
        /// </summary>
        /// <returns></returns>
        [Pure]
        public static string tmpfile() => Path.GetTempFileName();
    }
}
