using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;


namespace KGfck
{
    public class Dipyramid: Control
    {
        static int NumberOfDots = 12;
        //double point with 12-angle
        double[][] points = new double[NumberOfDots + 2][];
        double Angle;
        //public static void RotationY(double phi, double[][] point)
        //{
        //    point = { { Math.Cos(phi),    0, -Math.Sin(phi),  0 },{ 0,              1,              0,  0 },{ Math.Sin(phi),    0,  Math.Cos(phi),  0 },{ 0,              0,              0,  1 }};
        //}
        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawRectangle(Background, null, new Rect(0, 0, ActualWidth, ActualHeight));
           // base.OnRender(drawingContext);

            //Dipyramid d = new Dipyramid();          
            //RotationY(Math.PI/4);
            Angle = rotAngle.Y;
            DefultTransform();
            Apply();
            Draw(drawingContext);


            //var result = new double[points.Length][];
            //for (int i = 0; i < points.Length; i++)
            //    result[i] = TransformPoint(points[i], Matrix.RotationX(0.86));
        }
        public void DefultTransform()
        {
            double angle = 2 * Math.PI / NumberOfDots;
            double R = 100;
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
            }
            points[NumberOfDots] = new double[] { 1, 1, 1, 1 };
            points[NumberOfDots][0] = 120;
            points[NumberOfDots][1] = 120;
            points[NumberOfDots][2] = 120;
            points[NumberOfDots][3] = 1;

            points[NumberOfDots + 1] = new double[] { 1, 1, 1, 1 };
            points[NumberOfDots + 1][0] = 120;
            points[NumberOfDots + 1][1] = -120;
            points[NumberOfDots + 1][2] = 120;
            points[NumberOfDots + 1][3] = 1;
        }
        public void Draw(DrawingContext dc)
        {
            Pen pen = new Pen(Brushes.ForestGreen, 1);
            //centre top
            var p3 = new Point(points[NumberOfDots][0], points[NumberOfDots][2]);
            //center bottom
            var p4 = new Point(points[NumberOfDots + 1][0], points[NumberOfDots + 1][2]);

            for (int i = 0; i < NumberOfDots; i++)
            {
                if (i == NumberOfDots - 1)
                {
                    var p1 = new Point(points[0][0] + 120, points[0][2] + 120);
                    var p2 = new Point(points[i][0] + 120, points[i][2] + 120);
                    dc.DrawLine(pen, p1, p2);
                    dc.DrawLine(pen, p2, p3);
                    dc.DrawLine(pen, p2, p4);
                    //temp solution
                    var ptemp = new Point(points[i-1][0] + 120, points[i-1][2] + 120);
                    dc.DrawLine(pen, p2, ptemp);
                    dc.DrawLine(pen, p3, ptemp);
                    dc.DrawLine(pen, p4, ptemp);
                    //end temp solution
                }
                else if(i != 0)
                {
                    var p1 = new Point(points[i - 1][0] + 120, points[i - 1][2] + 120);
                    var p2 = new Point(points[i][0] + 120, points[i][2] + 120);
                    dc.DrawLine(pen, p1, p2);
                    dc.DrawLine(pen, p1, p3);
                    dc.DrawLine(pen, p1, p4);

                }
            }

        }
        public double[][] GetTransformMatrix()
        {
            var cos = Math.Cos(Angle);
            var sin = Math.Sin(Angle);
            //x
                    return new double[][] {
                        new double[] {  1,    0,   0,  0 },
                        new double[] {  0,  cos, sin,  0 },
                        new double[] {  0, -sin, cos,  0 },
                        new double[] {  0,    0,   0,  1 }
                    };
        }
        protected void TransformPoint(ref double[] point, double[][] transform)
        {
            var result = new double[4];
            for (int i = 0; i < 4; i++)
            {
                result[i] = 0;

                // Unroll loop.
                //for (int j = 0; j < 4; j++)
                //    result[i] += transform[j][i] * point[j];

                result[i] += transform[0][i] * point[0]
                           + transform[1][i] * point[1]
                           + transform[2][i] * point[2]
                           + transform[3][i] * point[3];
            }
            point = result;
        }
        public virtual void Apply()
        {
            for (int i = 0; i < NumberOfDots+1; i++)
                TransformPoint(ref points[i], GetTransformMatrix());
        }
        Point rotAngle = new Point(-Math.PI / 4, Math.PI / 8);
        Point startRotAngle = new Point(-Math.PI / 4, Math.PI / 8);
        Point startMousePos;
        double scale = 1;

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            Mouse.Capture(this);
            startMousePos = Mouse.GetPosition(this);
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
            startRotAngle = rotAngle;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (Mouse.Captured != this)
                return;
            rotAngle = startRotAngle + (e.GetPosition(this) - startMousePos) * 0.01;
            InvalidateVisual();
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            scale = Math.Max(scale + e.Delta * 0.001, 0.5);
            InvalidateVisual();
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
