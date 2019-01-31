using System.Linq;

namespace Omar.Utilities.Arrays
{
    public static class MultiDArrayHelper
    {
        /// <summary>
        /// Returns an array with all the values from the given column number.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="columnNumber"></param>
        /// <returns></returns>
        public static string[] GetColumn(this string[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }

        /// <summary>
        /// Returns an array with all the values from the given row number.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="rowNumber"></param>
        /// <returns></returns>
        public static string[] GetRow(this string[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }
    }
}
