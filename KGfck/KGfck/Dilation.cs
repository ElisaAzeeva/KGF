using System;
using System.Collections.Generic;
namespace KGfck
{
    public static class Dilation
    {
        public static void StretchTransformX(ref double[] point,double scaleX)
        {
            var result = new double[4];
            //int scale = 10;
            double[][] matrixX = new double[][] {
                new double[] { scaleX,   0,   0,  0 },
                new double[] {   0,  1,   0,  0 },
                new double[] {   0,   0,  1,  0 },
                new double[] {   0,   0,   0,  1 }
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
        public static void StretchTransformY(ref double[] point, double scaleY)
        {
            var result = new double[4];
            //int scale = 10;
            double[][] matrixY = new double[][] {
                new double[] {  1,   0,   0,  0 },
                new double[] {   0, scaleY,   0,  0 },
                new double[] {   0,   0,  1,  0 },
                new double[] {   0,   0,   0,  1 }
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

        public static void StretchTransformZ(ref double[] point, double scaleZ)
        {
            var result = new double[4];
            //int scale = 10;
            double[][] matrixZ = new double[][] {
                new double[] {  1,   0,   0,  0 },
                new double[] {   0,  1,   0,  0 },
                new double[] {   0,   0, scaleZ,  0 },
                new double[] {   0,   0,   0,  1 }
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
