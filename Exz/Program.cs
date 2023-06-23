using Exz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

Console.WriteLine("Littleendin");

var list1LE = new List<double>();
var list2LE = new List<double>();

int n = 60;
using (BinaryReader reader = new BinaryReader(File.Open("polynomTest2LE.dat", FileMode.Open)))
{
    for (int i = 0; i < n; i++)
    {
        double num = reader.ReadDouble();
        if (i < n / 2)
        {
            list1LE.Add(num);
        }
        else
        {
            list2LE.Add(num);
        }
    }
}

Console.WriteLine();

Console.WriteLine("Naive " + Scala.NaiveScalarProduct(list1LE, list2LE));
Console.WriteLine("Naive Fma  " + Scala.FmaScalarProduct(list1LE, list2LE));
Console.WriteLine("Ogita Rump Oishi  " + Scala.OgitaRumpOishiDotProduct(list1LE, list2LE));

Console.WriteLine("Errors");

Console.WriteLine("Absolute Error " + Scala.AbsoluteError(Scala.NaiveScalarProduct(list1LE, list2LE), Scala.OgitaRumpOishiDotProduct(list1LE, list2LE)));
Console.WriteLine("Relative Error " + Scala.RelativeError(Scala.NaiveScalarProduct(list1LE, list2LE), Scala.OgitaRumpOishiDotProduct(list1LE, list2LE)));
Console.WriteLine("Ulp Error " + Scala.UlpError(Scala.NaiveScalarProduct(list1LE, list2LE), Scala.OgitaRumpOishiDotProduct(list1LE, list2LE)));