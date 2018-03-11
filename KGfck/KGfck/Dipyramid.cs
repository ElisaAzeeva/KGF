using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KGfck
{
    public class Dipyramid: Control
    {

        //public static void RotationY(double phi, double[][] point)
        //{

        //    point = { { Math.Cos(phi),    0, -Math.Sin(phi),  0 },{ 0,              1,              0,  0 },{ Math.Sin(phi),    0,  Math.Cos(phi),  0 },{ 0,              0,              0,  1 }};
            
        //}
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            //Dipyramid d = new Dipyramid();
            int NumberOfDots = 12;
            double angle = 2 * Math.PI / NumberOfDots;
            double R = 100;

            double[][] points = new double[NumberOfDots + 2][];

            //double point with 12-angle
            for (int i = 0; i < NumberOfDots; i++)
            {
                double a = i * angle;
                double x = R * Math.Cos(a);
                double y = R * Math.Sin(a);
                Pen pen = new Pen(Brushes.ForestGreen, 1);
                points[i] = new double[] { x, 1, y, 1 };
                //Pen pen = new Pen(Color.Black, 1);

                //izometr
                double xAngle = Math.PI / 6;
                double yAngle = Math.PI / 4;
                double zAngle3 = Math.PI / 3.55;


                if (i!=0)
                {
                    var p1 = new Point(points[i-1][0]+120, points[i-1][2] + 120);
                    var p2 = new Point(points[i][0] + 120, points[i][2] + 120);
                    //centre
                    //var p3 = new Point(120, 120);
                    drawingContext.DrawLine(pen, p1, p2);
                }
                if(i == NumberOfDots-1)
                {
                    var p1 = new Point(points[0][0] + 120, points[0][2] + 120);
                    var p2 = new Point(points[i][0] + 120, points[i][2] + 120);
                    //centre
                    //var p3 = new Point(120, 120);
                    drawingContext.DrawLine(pen, p1, p2);
                    points[NumberOfDots] = new double[] { x, 1, y, 1 };
                    points[NumberOfDots][0] = 120;
                    points[NumberOfDots][1] = 120;
                    points[NumberOfDots][2] = 120;
                    points[NumberOfDots][3] = 1;

                    points[NumberOfDots+1] = new double[] { x, 1, y, 1 };
                    points[NumberOfDots+1][0] = 120;
                    points[NumberOfDots+1][1] = -120;
                    points[NumberOfDots+1][2] = 120;
                    points[NumberOfDots+1][3] = 1;

                }          
            }
            //RotationY(Math.PI/4);
            for (int i = 0; i < NumberOfDots; i++)
            {
                double a = i * angle;
                double x = R * Math.Cos(a);
                double y = R * Math.Sin(a);
                //centre top
                var p3 = new Point(points[NumberOfDots][0], points[NumberOfDots][2]);
                //center bottom
                var p4 = new Point(points[NumberOfDots + 1][0], points[NumberOfDots + 1][2]);
                Pen pen = new Pen(Brushes.ForestGreen, 1);
                if (i != 0)
                {
                    var p1 = new Point(points[i - 1][0] + 120, points[i - 1][2] + 120);
                    var p2 = new Point(points[i][0] + 120, points[i][2] + 120);
                    drawingContext.DrawLine(pen, p1, p2);                   
                    drawingContext.DrawLine(pen, p1, p3);
                    drawingContext.DrawLine(pen, p3, p2);

                }
                if (i == NumberOfDots - 1)
                {
                    var p1 = new Point(points[0][0] + 120, points[0][2] + 120);
                    var p2 = new Point(points[i][0] + 120, points[i][2] + 120);
                    drawingContext.DrawLine(pen, p1, p2);
                    drawingContext.DrawLine(pen, p3, p2);
                    drawingContext.DrawLine(pen, p1, p3);
                }

            }
            //var result = new double[points.Length][];
            //for (int i = 0; i < points.Length; i++)
            //    result[i] = TransformPoint(points[i], Matrix.RotationX(0.86));
        }
        //protected double[] TransformPoint(double[] point, double[][] transform)
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
