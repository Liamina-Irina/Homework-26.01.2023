// Задача 58: Задайте две матрицы. 
// Напишите программу, которая будет 
// находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int[,] matrixA = CreateMatrixRndInt(2, 2, 1, 5);
PrintMatrix(matrixA);
Console.WriteLine(String.Empty);
int[,] matrixB = CreateMatrixRndInt(2, 4, 1, 5);
PrintMatrix(matrixB);
Console.WriteLine(String.Empty);

if (matrixA.GetLength(1) == matrixB.GetLength(0))
{
    int[,] multipliedMatrix = MultipliedMatrices(matrixA, matrixB);
    PrintMatrix(multipliedMatrix);
}
else Console.WriteLine("Такие матрицы нельзя перемножить, так как количество столбцов матрицы А не равно количеству строк матрицы B.");

int[,] CreateMatrixRndInt(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(min, max + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write("[");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j],5},");
            else Console.Write($"{matrix[i, j],5}  ");
        }
        Console.WriteLine("]");
    }
}

int[,] MultipliedMatrices(int[,] firstMatrix, int[,] secondMatrix)
{
    int[,] result = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];

    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            result[i, j] = 0;

            for (int k = 0; k < firstMatrix.GetLength(1); k++)
            {
                result[i, j] = result[i, j] + firstMatrix[i, k] * secondMatrix[k, j];
            }
        }
    }
    return result;
}
