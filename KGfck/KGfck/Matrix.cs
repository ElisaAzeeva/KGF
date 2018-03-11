using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGfck
{
    public static class Matrix
    {
        public static double[][] Move(double lambda, double mu, double nu)
        {
            return new double[][] {
                new double[] {      1,   0,   0,  0 },
                new double[] {      0,   1,   0,  0 },
                new double[] {      0,   0,   1,  0 },
                new double[] { lambda,  mu,  nu,  1 }
            };
        }

        public static double[][] Scale(double alpha, double betta, double gamma)
        {
            return new double[][] {
                new double[] {  alpha,     0,     0,  0 },
                new double[] {      0, betta,     0,  0 },
                new double[] {      0,     0, gamma,  0 },
                new double[] {      0,     0,      0,  1 }
            };
        }

        public static double[][] RotationX(double phi)
        {
            return new double[][] {
                new double[] {  1,              0,             0,  0 },
                new double[] {  0,  Math.Cos(phi), Math.Sin(phi),  0 },
                new double[] {  0, -Math.Sin(phi), Math.Cos(phi),  0 },
                new double[] {  0,              0,             0,  1 }
            };
        }

        public static double[][] RotationY(double phi)
        {
            return new double[][] {
                new double[] { Math.Cos(phi),    0, -Math.Sin(phi),  0 },
                new double[] {   0,              1,              0,  0 },
                new double[] { Math.Sin(phi),    0,  Math.Cos(phi),  0 },
                new double[] {   0,              0,              0,  1 }
            };
        }

        public static double[][] RotationZ(double phi)
        {
            return new double[][] {
                new double[] {  Math.Cos(phi), Math.Sin(phi),   0,  0 },
                new double[] { -Math.Sin(phi), Math.Cos(phi),   0,  0 },
                new double[] {              0,             0,   1,  0 },
                new double[] {              0,             0,   0,  1 }
            };
        }
        //public static double[] TransformPoint(double[] point, double[][] transform)
        //{
        //    var result = new double[4];
        //    for (int i = 0; i < 4; i++)
        //    {
        //        result[i] = 0;
        //        for (int j = 0; j < 4; j++)
        //            result[i] += transform[j][i] * point[j];
        //    }
        //    return result;
        //}
    }
}
