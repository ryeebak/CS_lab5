using System;

class MyMatrix
{
    private int[,] matrix;
    private int rows;
    private int columns;
    private Random random = new Random();

    public MyMatrix(int rows, int columns, int minValue, int maxValue)
    {
        this.rows = rows;
        this.columns = columns;
        matrix = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue + 1);
            }
        }
    }

    public void ChangeSize(int newRows, int newColumns, int minValue, int maxValue)
    {
        if (newRows == rows && newColumns == columns)
            return;

        int[,] newMatrix = new int[newRows, newColumns];

        for (int i = 0; i < Math.Min(rows, newRows); i++)
        {
            for (int j = 0; j < Math.Min(columns, newColumns); j++)
            {
                newMatrix[i, j] = matrix[i, j];
            }
        }

        if (newRows > rows || newColumns > columns)
        {
            for (int i = 0; i < newRows; i++)
            {
                for (int j = 0; j < newColumns; j++)
                {
                    if (i >= rows || j >= columns)
                    {
                        newMatrix[i, j] = random.Next(minValue, maxValue);
                    }
                }
            }
        }

        matrix = newMatrix;
        rows = newRows;
        columns = newColumns;
    }

    public void PrintPartialy(int startRow, int endRow, int startColumn, int endColumn)
    {
        for (int i = startRow; i <= endRow && i < rows; i++)
        {
            for (int j = startColumn; j <= endColumn && j < columns; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public void Print()
    {
        PrintPartialy(0, rows - 1, 0, columns - 1);
    }

    public int this[int index1, int index2]
    {
        get
        {
            if (index1 >= 0 && index1 - 1 < rows && index2 >= 0 && index2 - 1 < columns)
            {
                return matrix[index1 - 1, index2 - 1];
            }
            else
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
        }
        set
        {
            if (index1 >= 0 && index1 - 1 < rows && index2 >= 0 && index2 - 1 < columns)
            {
                matrix[index1 - 1, index2 - 1] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
        }
    }
}

class lab5task1
{
    static void Main()
    {
        Console.Write("Enter the number of rows: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of columns: ");
        int columns = int.Parse(Console.ReadLine());

        Console.Write("Enter the minimum value: ");
        int minValue = int.Parse(Console.ReadLine());

        Console.Write("Enter the maximum value: ");
        int maxValue = int.Parse(Console.ReadLine());

        MyMatrix matrix = new MyMatrix(rows, columns, minValue, maxValue);

        Console.WriteLine("Our matrix:");
        matrix.Print();

        Console.WriteLine("\nChanging the matrix size.");
        Console.Write("Enter the new number of rows: ");
        int newRows = int.Parse(Console.ReadLine());

        Console.Write("Enter the new number of columns: ");
        int newColumns = int.Parse(Console.ReadLine());

        matrix.ChangeSize(newRows, newColumns, minValue, maxValue);

        Console.WriteLine("New matrix:");
        matrix.Print();

        Console.WriteLine("\nDisplaying a portion of the matrix 2x2:");
        matrix.PrintPartialy(0, 1, 0, 1);

        Console.WriteLine("\nChanging an element of the matrix.");
        Console.Write("Enter the row index: ");
        int rowIndex = int.Parse(Console.ReadLine());

        Console.Write("Enter the column index: ");
        int columnIndex = int.Parse(Console.ReadLine());

        Console.Write("Enter the new value: ");
        int newValue = int.Parse(Console.ReadLine());

        matrix[rowIndex, columnIndex] = newValue;

        Console.WriteLine("Modified matrix:");
        matrix.Print();
    }
}
