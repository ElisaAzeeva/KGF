using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KGfck
{
    public class Axis : Control
    {
        double[][] pointsStartAxis = new double[4][];
        double[][] pointsAxis = new double[4][];

        //constructor
        public Axis()
        {
            DefaultTransform();
        }
        void DefaultTransform()
        {
            //create axes
            pointsStartAxis = new double[][] {
                // 0
                new double[] { 0, 0, 0, 1 },
                //OX,OY,OZ
                new double[] { 200, 0, 0, 1 },
                new double[] { 0, 200, 0, 1 },
                new double[] { 0, 0, 200, 1 },
            };
            pointsAxis = pointsStartAxis;
            Point p = new Point(9 * Math.PI / 8, 0);
            for (int i = 0; i < 4; i++)
            {
                Rotation.RotationTransformZ(ref pointsAxis[i], 5 * Math.PI / 4);
                Rotation.RotationTransformX(ref pointsAxis[i], p);
            }
        }
        public void Draw(DrawingContext dc)
        {
            Pen pen = new Pen(Brushes.Black, 2);
            //draw axes
            for (int i = 1; i < pointsAxis.Length; i++)
            {
                var p0 = new Point(pointsAxis[0][0], pointsAxis[0][2]);
                var p1 = new Point(pointsAxis[i][0], pointsAxis[i][2]);
                dc.DrawLine(pen, p1, p0);

            }
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            Draw(drawingContext);
            //magic for sign axes
            for (int i = 1; i < pointsAxis.Length; i++)
            {
                drawingContext.DrawEllipse(Brushes.Black, null, new Point(pointsAxis[i][0] / 2, pointsAxis[i][1] / 2 - 40), 4, 4);
                drawingContext.DrawEllipse(Brushes.Black, null, new Point(pointsAxis[i][0], pointsAxis[i][1] - 80), 4, 4);
            }
            drawingContext.DrawEllipse(Brushes.Black, null, new Point(pointsAxis[0][0] / 2, pointsAxis[0][0] / 2 - 90), 4, 4);
            drawingContext.DrawEllipse(Brushes.Black, null, new Point(pointsAxis[0][0], pointsAxis[0][0] - 180), 4, 4);

            //variable containing text for signe axes
            FormattedText xText = new FormattedText("X", CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface("Segoe UI"), 26, Brushes.Black);
            FormattedText yText = new FormattedText("Y", CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface("Segoe UI"), 26, Brushes.Black);
            FormattedText zText = new FormattedText("Z", CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface("Segoe UI"), 26, Brushes.Black);
            FormattedText oText = new FormattedText("O", CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface("Segoe UI"), 26, Brushes.Black);
            
            //signing axes
            drawingContext.DrawText(xText,new Point(pointsAxis[1][0], pointsAxis[1][1] - 80));
            drawingContext.DrawText(yText, new Point(pointsAxis[2][0], pointsAxis[2][1] - 80));
            drawingContext.DrawText(zText, new Point(pointsAxis[0][0], pointsAxis[0][1] - 180));
            drawingContext.DrawText(oText, new Point(pointsAxis[3][0], pointsAxis[3][1] - 80));
        }
    }
}

