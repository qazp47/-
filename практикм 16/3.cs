using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Temperature
{
    public int Degrees { get; }

    public Temperature(int degrees)
    {
        Degrees = degrees;
    }
    public static bool operator >(Temperature t1, Temperature t2)
    {
        return t1.Degrees > t2.Degrees;
    }
    public static bool operator <(Temperature t1, Temperature t2)
    {
        return t1.Degrees < t2.Degrees;
    }
    public static bool operator ==(Temperature t1, Temperature t2)
    {
        if (ReferenceEquals(t1, t2))
            return true;
        if (t1 is null || t2 is null)
            return false;
        return t1.Degrees == t2.Degrees;
    }

    public static bool operator !=(Temperature t1, Temperature t2)
    {
        return !(t1 == t2);
    }
    public override bool Equals(object obj)
    {
        if (obj is Temperature)
        {
            var other = (Temperature)obj;
            return this.Degrees == other.Degrees;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return Degrees.GetHashCode();
    }
    public override string ToString()
    {
        return $"{Degrees}°C";
    }
}
class Program
{
    static void Main()
    {
        var t1 = new Temperature(25);
        var t2 = new Temperature(30);

        Console.WriteLine(t1);
        Console.WriteLine(t2 > t1);
        Console.WriteLine(t1 == new Temperature(25));
    }
}