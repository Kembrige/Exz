using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exz
{
    public static class Scala
    {

        public static (double, double) TwoSum(double a, double b)
        {
            var s = a + b;
            var bs = s - a;
            var at = s - bs;
            var t = (b - bs) + (a - at);
            return (s, t);
        }
        public static double NaiveScalarProduct(List<double> x, List<double> y)
        {
            var s = 0.0;
            for (var i = 0; i < x.Count; i++)
            {
                s += x[i] * y[i];
            }
            
            return s;
        }

        public static float NaiveScalarProduct(List<float> x, List<float> y)
        {
            var s = 0f;
            for (var i = 0; i < x.Count; i++)
            {
                s += x[i] * y[i];
            }

            return s;
        }

        public static double FmaScalarProduct(List<double> x, List<double> y)
        {
            var s = 0.0;
            for (var i = 0; i < x.Count; i++)
            {
                s = Math.FusedMultiplyAdd(x[i], y[i], s);
            }

            return s;
        }

        public static (double, double) FmaProductTwo(double a, double b)
        {
            var p = a * b;
            var t = Math.FusedMultiplyAdd(a, b, -p);
            return (p, t);
        }

        public static double OgitaRumpOishiDotProduct(List<double> x, List<double> y)
        {
            var s = 0.0;
            var c = 0.0;
            for (int i = 0; i < x.Count; i++)
            {
                var (p, pi) = FmaProductTwo(x[i], y[i]);
                (s, var t) = TwoSum(p, s);
                c += pi + t;
            }

            return s + c;
        }
        public static double Ulp(double value)
        {
            var bits = BitConverter.DoubleToInt64Bits(value);
            var nextValue = BitConverter.Int64BitsToDouble(bits + 1);
            return nextValue - value;
        }

        public static double AbsoluteError(double x, double x_exact)
        {
            return Math.Abs(x - x_exact);
        }

        public static double RelativeError(double x, double x_exact)
        {
            return Math.Abs(x - x_exact) / Math.Abs(x_exact) * 100;
        }

        public static double UlpError(double x, double x_exact)
        {
            return Math.Abs(x - x_exact) / Ulp(x_exact);
        }

        public static string ToBinary(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            string binary = "";
            for (int i = bytes.Length - 1; i >= 0; i--)
            {
                binary += Convert.ToString(bytes[i], 2).PadLeft(8, '0');
            }
            return binary;
        }

        public static float FromBinary(string binaryString)
        {
            var intValue = Convert.ToInt32(binaryString, 2);
            return BitConverter.ToSingle(BitConverter.GetBytes(intValue), 0);
        }

    }
}
