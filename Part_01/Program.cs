
class MyMatrix
{
    public int Min = 0;
    public int Max = 100;
    readonly int _rows;
    readonly int _columns;
    readonly int[,] _matrixArray;
    public MyMatrix(int a, int b)
    {
        _rows = a;
        _columns = b;
        Random rand = new Random();
        _matrixArray = new int[a,b];
        for (int i = 0; i<a; i++)
        {
            for (int j = 0; j<b; j++)
            {
                _matrixArray[i, j] = rand.Next(Min, Max);
            }
        }
    }
    public static MyMatrix operator +(MyMatrix a, MyMatrix b)
    {
        
        if (a._rows != b._rows || a._columns != b._columns)
        {
            throw new ArgumentException("error argv");

        }
        MyMatrix obj = new MyMatrix(a._rows, a._columns);
        for (int i = 0; i < a._rows; i++)
        {
            for (int j = 0; j < b._columns; j++)
            {
                obj[i, j] = a[i, j] + b[i, j];
            }
        }
        return obj;
    }
    public static MyMatrix operator -(MyMatrix a, MyMatrix b)
    {

        if (a._rows != b._rows || a._columns != b._columns)
        {
            throw new ArgumentException("error argv");

        }
        MyMatrix obj = new MyMatrix(a._rows, a._columns);
        for (int i = 0; i < a._rows; i++)
        {
            for (int j = 0; j < b._columns; j++)
            {
                obj[i, j] = a[i, j] - b[i, j];
            }
        }
        return obj;
    }
    public static MyMatrix operator *(MyMatrix a, int b)
    {
        MyMatrix obj = new MyMatrix(a._rows, a._columns);
        for (int i = 0; i < a._rows; i++)
        {
            for (int j = 0; j < a._columns; j++)
            {
                obj[i, j] = a[i, j] * b;
            }
        }
        return obj;
    }
    public static MyMatrix operator /(MyMatrix a, int b)
    {
        MyMatrix obj = new MyMatrix(a._rows, a._columns);
        for (int i = 0; i < a._rows; i++)
        {
            for (int j = 0; j < a._columns; j++)
            {
                obj[i, j] = a[i, j] / b;
            }
        }
        return obj;
    }
    public static MyMatrix operator *(MyMatrix a, MyMatrix b)
    {

        if (a._rows != b._columns)
        {
            throw new ArgumentException("error argv");

        }
        MyMatrix resMatrix = new MyMatrix(a._rows, b._columns);

        for (int i = 0; i < a._rows; i++)
        {
            for (int j = 0; j < b._columns; j++)
            {
                int sum = 0;
                for (int l = 0; l < a._columns; l++)
                {
                    sum += a[i, l] * b[l, j];
                }
                resMatrix[i, j] = sum;
            }

        }
        return resMatrix;
    }
    public int this[int row, int columns]
    {
        get
        { 
            return _matrixArray[row, columns]; 
        }
        set
        {
            _matrixArray[row, columns] = value;
        }
    }
    public void Print()
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                Console.Write($"{_matrixArray[i, j].ToString()} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

class Programm
{
    static void Main()
    {
        MyMatrix m1 = new MyMatrix(5, 5);
        m1.Print();
        MyMatrix m2 = new MyMatrix(5, 5);
        m2.Print();
        MyMatrix m3 = new MyMatrix(5, 3);
        m3.Print();

        MyMatrix sum_m = m1 + m2;
        sum_m.Print();

        MyMatrix diff_m = m1 - m2;
        diff_m.Print();

        MyMatrix mul_m = m1 * m2;
        mul_m.Print();
    }

}