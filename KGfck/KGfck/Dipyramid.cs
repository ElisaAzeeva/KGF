using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KGfck
{
    public class Dipyramid : Control
    {
        static int NumberOfAngles = 12;
        //double point with 12-angle
        public double[][] points = new double[NumberOfAngles + 2][];
        public double[][] pointsIzometr = new double[NumberOfAngles + 2][];
        public double[][] pointsStart = new double[NumberOfAngles + 2][];
        double[][] pointsAxis = new double[10][];
        //variable for change crystal scale
        public double scaleX = 1;
        public double scaleY = 1;
        public double scaleZ = 1;
        //variable for crystal movement
        public double moveX = 0;
        public double moveY = 0;
        public double moveZ = 0;
        //angle start position
        public Point rotAngle = new Point(0, 0);
        public double rotAngleZ = 0;

        public Dipyramid()
        {
            DefultTransform();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            Apply();
            Draw(drawingContext);
        }
        public void DefultTransform()
        {
            double angle = 2 * Math.PI / NumberOfAngles;
            double R = 50;
            for (int i = 0; i < NumberOfAngles; i++)
            {
                double a = i * angle;
                double x = R * Math.Cos(a);
                double y = R * Math.Sin(a);
                points[i] = new double[] { x , 1, y , 1 };
            }
            points[NumberOfAngles] = new double[] { 1, 50, 1, 1 };
            points[NumberOfAngles + 1] = new double[] { 1, -50, 1, 1 };

            //rotate on 90 degrees about OX
            Point p = new Point(Math.PI / 2, 0);
            for (int i = 0; i < NumberOfAngles + 2; i++)
                Rotation.RotationTransformX(ref points[i], p);
            
            points.CopyTo(pointsIzometr, 0);
        }
        private void GetIzometr()
        {
            Point p = new Point(9*Math.PI / 8, 0);
            for (int i = 0; i < NumberOfAngles+2; i++)
            {
                Rotation.RotationTransformZ(ref pointsIzometr[i], 5*Math.PI / 4);
                Rotation.RotationTransformX(ref pointsIzometr[i], p);
                Translation.MoveTransformPoint(ref pointsIzometr[i],900,0,600);
            }
        }
        public void Draw(DrawingContext dc)
        {
            Pen pen = new Pen(Brushes.Magenta, 1);
            GetIzometr();
            //centre top
            var p3 = new Point(pointsIzometr[NumberOfAngles][0], pointsIzometr[NumberOfAngles][2]);
            //center bottom
            var p4 = new Point(pointsIzometr[NumberOfAngles + 1][0], pointsIzometr[NumberOfAngles + 1][2]);
            //loop for connection of dipyramid lines
            for (int i = 0; i < NumberOfAngles; i++)
            {
                if (i == NumberOfAngles - 1)
                {
                    var p1 = new Point(pointsIzometr[0][0], pointsIzometr[0][2]);
                    var p2 = new Point(pointsIzometr[i][0], pointsIzometr[i][2]);
                    dc.DrawLine(pen, p1, p2);
                    dc.DrawLine(pen, p2, p3);
                    dc.DrawLine(pen, p2, p4);
                    var ptemp = new Point(pointsIzometr[i - 1][0], pointsIzometr[i - 1][2]);
                    dc.DrawLine(pen, p2, ptemp);
                    dc.DrawLine(pen, p3, ptemp);
                    dc.DrawLine(pen, p4, ptemp);
                }
                else if (i != 0)
                {
                    var p1 = new Point(pointsIzometr[i - 1][0], pointsIzometr[i - 1][2]);
                    var p2 = new Point(pointsIzometr[i][0], pointsIzometr[i][2]);
                    dc.DrawLine(pen, p1, p2);
                    dc.DrawLine(pen, p1, p3);
                    dc.DrawLine(pen, p1, p4);

                }
            }    
        }       
        public void Apply()
        {
            for (int i = 0; i <= NumberOfAngles + 1; i++)
            {
                if (rotAngle.X != 0)
                {
                    Rotation.RotationTransformX(ref points[i], rotAngle);                    
                }
                if (rotAngle.Y != 0)
                {
                    Rotation.RotationTransformY(ref points[i], rotAngle);                    
                }
                if (rotAngleZ != 0)
                {
                    Rotation.RotationTransformZ(ref points[i], rotAngleZ);                    
                }
                if(scaleX != 1)
                {
                    Dilation.StretchTransformX(ref points[i], scaleX);                    
                }
                if (scaleY != 1)
                {
                    Dilation.StretchTransformY(ref points[i], scaleY);                    
                }
                if (scaleZ != 1)
                {
                    Dilation.StretchTransformZ(ref points[i], scaleZ);                    
                }
                if ((moveX != 0)||(moveY !=0 )||(moveZ != 0))
                {
                    Translation.MoveTransformPoint(ref points[i], moveX, moveY, moveZ);
                }
            }

            //avoid accumulation angle, distance and zoom
            rotAngle.X = 0;
            rotAngle.Y = 0;
            rotAngleZ = 0;
            scaleX = 1;
            scaleY = 1;
            scaleZ = 1;
            moveX = 0;
            moveY = 0;
            moveZ = 0;
            points.CopyTo(pointsIzometr, 0);
        }

        public void ReflectX()
        {
            for (int i = 0; i <= NumberOfAngles + 1; i++)
            {
                Mirror.MirrorTransformX(ref points[i]);
            }

        }
        public void ReflectY()
        {
            for (int i = 0; i <= NumberOfAngles + 1; i++)
            {
                Mirror.MirrorTransformY(ref points[i]);
            }

        }
        public void ReflectZ()
        {
            for (int i = 0; i <= NumberOfAngles + 1; i++)
            {
                Mirror.MirrorTransformZ(ref points[i]);
            }

        }
        public void reDraw()
        {
            InvalidateVisual();
        }
    }
}
