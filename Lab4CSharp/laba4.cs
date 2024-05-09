using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Choose the task1");
        string input = Console.ReadLine();
        int taskNumber;

        if (int.TryParse(input, out taskNumber) && taskNumber == 1)
        {
            Task1();
        }
        else
        {
            Console.WriteLine("Номер завдання повинен бути 1.");
        }
    }

    static void Task1()
    {
        Romb romb = new Romb(5, 7, 1);
        romb.DisplayLengths();
        Console.WriteLine($"Периметр: {romb.CalculatePerimeter()}");
        Console.WriteLine($"Площа: {romb.CalculateArea()}");
        Console.WriteLine($"Чи є квадратом: {romb.IsSquare()}");
    }
}

public class Romb
{
    // Захищені поля
    protected int a, d1, c;

    // Конструктор
    public Romb(int a, int d1, int c)
    {
        this.a = a;
        this.d1 = d1;
        this.c = c;
    }

    // Індексатор
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return a;
                case 1: return d1;
                case 2: return c;
                default: throw new ArgumentException("Невірний індекс");
            }
        }
        set
        {
            switch (index)
            {
                case 0: a = value; break;
                case 1: d1 = value; break;
                case 2: c = value; break;
                default: throw new ArgumentException("Невірний індекс");
            }
        }
    }

    // Метод для виведення довжин на екран
    public void DisplayLengths()
    {
        Console.WriteLine($"Сторона: {a}, Діагональ: {d1}");
    }

    // Метод для розрахунку периметра ромба
    public double CalculatePerimeter()
    {
        return 4 * a;
    }

    // Метод для розрахунку площі ромба
    public double CalculateArea()
    {
        return 0.5 * a * d1;
    }

    // Метод, що дозволяє встановити, чи є даний ромб є квадратом
    public bool IsSquare()
    {
        return a == d1;
    }

    // Перевантаження операцій
    public static Romb operator ++(Romb r)
    {
        r.a++;
        r.d1++;
        return r;
    }

    public static Romb operator --(Romb r)
    {
        r.a--;
        r.d1--;
        return r;
    }

    public static bool operator true(Romb r)
    {
        return r.IsSquare();
    }

    public static bool operator false(Romb r)
    {
        return !r.IsSquare();
    }

    public static Romb operator *(Romb r, int scalar)
    {
        r.a *= scalar;
        r.d1 *= scalar;
        return r;
    }

    // Перетворення типів
    public static explicit operator string(Romb r)
    {
        return $"Romb: a = {r.a}, d1 = {r.d1}, c = {r.c}";
    }

    public static explicit operator Romb(string s)
    {
        string[] parts = s.Split(',');
        int a = int.Parse(parts[0].Split('=')[1]);
        int d1 = int.Parse(parts[1].Split('=')[1]);
        int c = int.Parse(parts[2].Split('=')[1]);
        return new Romb(a, d1, c);
    }

    // Властивості
    public int Side
    {
        get { return a; }
        set { a = value; }
    }

    public int Diagonal
    {
        get { return d1; }
        set { d1 = value; }
    }

    public int Color
    {
        get { return c; }
        set { c = value; }
    }
}
