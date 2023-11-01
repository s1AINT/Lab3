using System;

class Program
{
    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static Tuple<int, int, int> GCDEx(int a, int b)
    {
        int x0 = 1, y0 = 0;
        int x1 = 0, y1 = 1;
        while (b != 0)
        {
            int q = a / b;
            int temp = b;
            b = a % b;
            a = temp;
            int x2 = x0 - q * x1;
            int y2 = y0 - q * y1;
            x0 = x1;
            y0 = y1;
            x1 = x2;
            y1 = y2;
        }
        return new Tuple<int, int, int>(a, x0, y0);
    }

    static int InverseElement(int a, int n)
    {
        Tuple<int, int, int> result = GCDEx(a, n);
        int d = result.Item1;
        int x = result.Item2;
        int y = result.Item3;

        if (d != 1)
        {
            throw new Exception("The inverse element does not exist.");
        }

        while (x < 0)
        {
            x += n;
        }

        return x;
    }

    static int Phi(int m)
    {
        int result = m;
        for (int p = 2; p * p <= m; p++)
        {
            if (m % p == 0)
            {
                while (m % p == 0)
                {
                    m /= p;
                }
                result -= result / p;
            }
        }
        if (m > 1)
        {
            result -= result / m;
        }
        return result;
    }

    static int InverseElement2(int a, int p)
    {
        int phiP = Phi(p);
        return (int)Math.Pow(a, phiP - 1) % p;
    }

    static void Main()
    {
        int a = 612;
        int b = 342;
        Tuple<int, int, int> gcdexResult = GCDEx(a, b);
        Console.WriteLine($"GCDEx({a}, {b}) = ({gcdexResult.Item1}, {gcdexResult.Item2}, {gcdexResult.Item3})");

        int a2 = 5;
        int n2 = 18;
        int inverseResult = InverseElement(a2, n2);
        Console.WriteLine($"InverseElement({a2}, {n2}) = {inverseResult}");

        int m = 10; //  m тут
        int phiResult = Phi(m);
        Console.WriteLine($"Phi({m}) = {phiResult}");

        int a3 = 5;
        int p = 18;
        int inverse2Result = InverseElement2(a3, p);
        Console.WriteLine($"InverseElement2({a3}, {p}) = {inverse2Result}");
    }
}
