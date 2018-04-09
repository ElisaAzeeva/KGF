using System;
using System.Windows;

namespace KGfck
{
    public static class Rotation
    {
        public static void RotationTransformX(ref double[] point, Point rotAngle )
        {
            var cosX = Math.Cos(rotAngle.X);
            var sinX = Math.Sin(rotAngle.X);
            var result = new double[4];
            double[][] matrixX = new double[][] {
                        new double[] { 1, 0, 0, 0 },
                        new double[] { 0, cosX, sinX, 0 },
                        new double[] { 0, -sinX, cosX, 0 },
                        new double[] { 0, 0, 0, 1 }
                        };
            for (int i = 0; i < 4; i++)
            {
                result[i] = 0;
                result[i] += matrixX[0][i] * point[0]
                           + matrixX[1][i] * point[1]
                           + matrixX[2][i] * point[2]
                           + matrixX[3][i] * point[3];
            }
            point = result;
        }
        public static void RotationTransformY(ref double[] point, Point rotAngle)
        {
            var cosY = Math.Cos(rotAngle.Y);
            var sinY = Math.Sin(rotAngle.Y);
            var result = new double[4];

            double[][] matrixY = new double[][] {
                        new double[] { cosY,    0, -sinY,  0 },
                        new double[] {   0,    1,    0,  0 },
                        new double[] { sinY,    0,  cosY,  0 },
                        new double[] {   0,    0,    0,  1 }
                        };
            for (int i = 0; i < 4; i++)
            {
                result[i] = 0;
                result[i] += matrixY[0][i] * point[0]
                           + matrixY[1][i] * point[1]
                           + matrixY[2][i] * point[2]
                           + matrixY[3][i] * point[3];
            }
            point = result;
        }
        public static void RotationTransformZ(ref double[] point, double rotAngleZ)
        {
            var cosZ = Math.Cos(rotAngleZ);
            var sinZ = Math.Sin(rotAngleZ);
            var result = new double[4];

            double[][] matrixZ = new double[][] {
                        new double[] {  cosZ, sinZ,   0,  0 },
                        new double[] { -sinZ, cosZ,   0,  0 },
                        new double[] {    0,   0,   1,  0 },
                        new double[] {    0,   0,   0,  1 }
                        };
            for (int i = 0; i < 4; i++)
            {
                result[i] = 0;
                result[i] += matrixZ[0][i] * point[0]
                           + matrixZ[1][i] * point[1]
                           + matrixZ[2][i] * point[2]
                           + matrixZ[3][i] * point[3];
            }
            point = result;
        }
    }
}
