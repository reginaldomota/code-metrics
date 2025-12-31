using Application.Matrix.Exceptions;
using Domain.Interfaces;

namespace Application.Matrix;

public class MatrixString : IMatrixString
{
    private string[,] m;

    public MatrixString(int rows, int columns, string value)
    {
        if (rows <= 0 || columns <= 0)
            throw new ArgumentException("O número de linhas e colunas deve ser maior que zero");

        m = new string[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                m[i, j] = value;
            }
        }
    }

    public void Set(int row, int column, string value)
    {
        if (row < 0 || row >= m.GetLength(0) || column < 0 || column >= m.GetLength(1))
            throw new MatrixException("Índices fora dos limites da matriz");

        m[row, column] = value;
    }

    public string RowToString(int index, string separator)
    {
        if (index < 0 || index >= m.GetLength(0))
            throw new MatrixException("Índice da linha fora dos limites da matriz");

        if (separator == null)
            throw new MatrixException("Separador não pode ser nulo");

        string[] rowElements = new string[m.GetLength(1)];
        for (int j = 0; j < m.GetLength(1); j++)
        {
            rowElements[j] = m[index, j];
        }

        return string.Join(separator, rowElements);
    }
}
