// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет 
// находить строку с наименьшей суммой элементов.

// Например, задан массив:

// 1 4 7 2

// 5 9 2 3

// 8 4 2 4

// 5 2 6 7

// Программа считает сумму элементов 
// в каждой строке и выдаёт номер строки 
// с наименьшей суммой элементов: 1 строка

int[,] matrix = CreateMatrixRndInt(5, 5, -10, 10);
PrintMatrix(matrix);
Console.WriteLine(String.Empty);

Console.WriteLine("Сумма элементов в каждой строке:");

int[,] sumInRow = SumInRow(matrix);
PrintMatrix(sumInRow);

FindMinSumRow(sumInRow);

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

int[,] SumInRow(int[,] array)
{
    int[,] sumArray = new int[array.GetLength(0), 1];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        int sumInRow = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sumInRow += array[i, j];
            sumArray[i, 0] = sumInRow;
        }
    }
    return sumArray;
}

void FindMinSumRow(int[,] array)
{
    int minSumInRowIndex = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        if (array[minSumInRowIndex, 0] >= array[i, 0]) minSumInRowIndex = i;
    }
    Console.WriteLine(String.Empty);
    Console.WriteLine($"{minSumInRowIndex + 1} строка");
}