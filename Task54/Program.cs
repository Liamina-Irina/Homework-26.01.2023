// Задача 54: Задайте двумерный массив. 
// Напишите программу, которая упорядочит 
// по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

int[,] matrix = CreateMatrixRndInt(5, 5, -10, 10);
PrintMatrix(matrix);
Console.WriteLine(String.Empty);

int[,] sortedRows = SortedRowsMatrix(matrix);
PrintMatrix(sortedRows);

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

int[,] SortedRowsMatrix(int[,] matrixSortedRows)
{
    for (int i = 0; i < matrixSortedRows.GetLength(0); i++)
    {
        for (int j = 0; j < matrixSortedRows.GetLength(1) - 1; j++)
        {
            for (int k = 0; k < matrixSortedRows.GetLength(1) - 1 - j; k++)
            {
                if (matrixSortedRows[i, k] < matrixSortedRows[i, k + 1])
                {
                    int temp = matrixSortedRows[i, k];
                    matrixSortedRows[i, k] = matrixSortedRows[i, k + 1];
                    matrixSortedRows[i, k + 1] = temp;
                }
            }
        }
    }
    return matrixSortedRows;
}
