using Domain.Interfaces;

namespace Application.Matrix.Factories;

public class MatrixStringFactory : IMatrixStringFactory
{
    public IMatrixString Create(int rows, int columns, string value)
    {
        return new MatrixString(rows, columns, value);
    }
}
