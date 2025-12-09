using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Vector
{
    private double[] components;
    public Vector(params double[] elements)
    {
        components = elements;
    }
    public static double operator *(Vector v1, Vector v2)
    {
        int length = Math.Min(v1.components.Length, v2.components.Length);
        double sum = 0;
        for (int i = 0; i < length; i++)
        {
            sum += v1.components[i] * v2.components[i];
        }
        return sum;
    }
    public double this[int index]
    {
        get
        {
            if (index < 0 || index >= components.Length)
                throw new IndexOutOfRangeException();
            return components[index];
        }
        set
        {
            if (index < 0 || index >= components.Length)
                throw new IndexOutOfRangeException();
            components[index] = value;
        }
    }
    public override string ToString()
    {
        return "[" + string.Join(", ", components) + "]";
    }
}
class Program
{
    static void Main()
    {
        var v1 = new Vector(1, 2, 3);
        var v2 = new Vector(4, 5, 6);

        Console.WriteLine(v1 * v2);
        v1[1] = 10;
        Console.WriteLine(v1);
    }
}