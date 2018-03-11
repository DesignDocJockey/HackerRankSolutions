using System;
using System.Collections.Generic;
using System.Text;

namespace MathAlgorithms
{
    public class MatrixItem
    {
        public int RowNumber;
        public IEnumerable<int> ColumnValues;
    }

    public class Matrix
    {
        public List<MatrixItem> GenerateMatrix(int rows)
        {
            var matrix = new List<MatrixItem>();
            for (var i = 0; i < rows; i++)
            {
                var rowMatrix = new MatrixItem()
                {
                    RowNumber = i,
                    ColumnValues = GenerateColumnValues(rows)
                };
                matrix.Add(rowMatrix);
            }
            return matrix;
        }

        private IEnumerable<int> GenerateColumnValues(int numberOfColumns)
        {
            var rowValues = new List<int>();
            var randomNumberGenerator = new Random();

            for (int i = 0; i < numberOfColumns; i++)
                rowValues.Add(randomNumberGenerator.Next(5));

            return rowValues;
        }
    }
}
