using System;
using System.Windows;
using System.Windows.Controls;

namespace KGfck
{
    public partial class MainWindow : Window
    {
        public Dipyramid dip;
        public Axis axis;
        //rotation
        private double sliderXAngle_last_value = 0.0;
        private double sliderYAngle_last_value = 0.0;
        private double sliderZAngle_last_value = 0.0;
        //zoom
        private double sliderXZoom_last_value = 1;
        private double sliderYZoom_last_value = 1;
        private double sliderZZoom_last_value = 1;
        //move
        private double sliderXMove_last_value = 0.0;
        private double sliderYMove_last_value = 0.0;
        private double sliderZMove_last_value = 0.0;
        private double scale = 100;
        public MainWindow()
        {
            dip = new Dipyramid();
            axis = new Axis();
            axis.Margin = new Thickness(900, 600, 0, 0);
            InitializeComponent();
            gr1.Children.Add(dip);
            gr1.Children.Add(axis);
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            //this.InvalidateVisual();

        }

        private void SliderOX_rotate_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sl = (Slider)sender;
            //if (sl.Value < 0)
            //{
            //    dip.rotAngle.X = sliderXAngle_last_value - sl.Value;
            //}
            //else
            //{
            //    dip.rotAngle.X = sl.Value - sliderXAngle_last_value;
            //}
            //get angle for rotation about OX in radians, as the difference between current and previous value

            dip.rotAngle.X = sl.Value * Math.PI / 180 - sliderXAngle_last_value ;
            dip.reDraw();
            sliderXAngle_last_value = sl.Value * Math.PI / 180;
        }

        private void SliderOY_rotate_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sl = (Slider)sender;
            //if (sl.Value < 0)
            //{
            //    dip.rotAngle.Y = sliderYAngle_last_value - sl.Value;
            //}
            //else
            //{
            //    dip.rotAngle.Y = sl.Value - sliderYAngle_last_value;
            //}
            //get angle for rotation about OY in radians, as the difference between current and previous value
            dip.rotAngle.Y = sl.Value * Math.PI / 180 - sliderYAngle_last_value;
            dip.reDraw();
            sliderYAngle_last_value = sl.Value * Math.PI / 180;
        }

        private void SliderOZ_rotate_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sl = (Slider)sender;
            //if (sl.Value < 0)
            //{
            //    dip.rotAngleZ = sliderZAngle_last_value - sl.Value;
            //}
            //else
            //{
            //    dip.rotAngleZ = sl.Value - sliderZAngle_last_value;
            //}
            //get angle for rotation about OZ in radians, as the difference between current and previous value
            dip.rotAngleZ = sl.Value * Math.PI / 180 - sliderZAngle_last_value;
            dip.reDraw();
            sliderZAngle_last_value = sl.Value * Math.PI / 180;
        }

        //stretch X
        private void SliderOX_delatate_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sl = (Slider)sender;
            //get scale for delatation about OX, as the difference between current and previous value
            dip.scaleX = sl.Value - sliderXZoom_last_value+1;
            dip.reDraw();
            sliderXZoom_last_value= sl.Value;
        }
        //stretch Y
        private void SliderOY_delatate_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sl = (Slider)sender;
            dip.scaleY = sl.Value - sliderYZoom_last_value+1;
            dip.reDraw();
            sliderYZoom_last_value = sl.Value;
        }
        //stretch Z
        private void SliderOZ_delatate_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sl = (Slider)sender;
            dip.scaleZ = sl.Value - sliderZZoom_last_value + 1;
            dip.reDraw();
            sliderZZoom_last_value = sl.Value;
        }


        //MoveX
        private void SliderOX_translate_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sl = (Slider)sender;
            dip.moveX = sl.Value*scale - sliderXMove_last_value;
            dip.reDraw();
            sliderXMove_last_value = sl.Value * scale;
        }
        //MoveY
        private void SliderOY_translate_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sl = (Slider)sender;
            dip.moveY = sl.Value * scale - sliderYMove_last_value;
            dip.reDraw();
            sliderYMove_last_value = sl.Value * scale;
        }
        //MoveZ
        private void SliderOZ_translate_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sl = (Slider)sender;
            dip.moveZ = sl.Value * scale - sliderZMove_last_value;
            dip.reDraw();
            sliderZMove_last_value = sl.Value * scale;
        }

        private void ButtonDefault_Click(object sender, RoutedEventArgs e)
        {
            //reset options
            //reset rotate angle
            OX_rotate.Value = 0;
            OY_rotate.Value = 0;
            OZ_rotate.Value = 0;
            //reset zoom
            OX_delatate.Value = 1;
            OY_delatate.Value = 1;
            OZ_delatate.Value = 1;
            //reset move
            OX_translate.Value = 0;
            OY_translate.Value = 0;
            OZ_translate.Value = 0;
            //reset mirror
            MirrorOX.IsChecked = false;
            MirrorOY.IsChecked = false;
            MirrorOZ.IsChecked = false;
            //delete dipyramid
            gr1.Children.Remove(dip);
            //create and add new dipyramid
            dip = new Dipyramid();
            gr1.Children.Add(dip);
            dip.reDraw();
        }

        private void CheckBoxMirrorOX_Checked(object sender, RoutedEventArgs e)
        {
            dip.ReflectX();
            dip.reDraw();
        }

        private void CheckBoxMirrorOY_Checked(object sender, RoutedEventArgs e)
        {
            dip.ReflectY();
            dip.reDraw();
        }

        private void CheckBoxMirrorOZ_Checked(object sender, RoutedEventArgs e)
        {
            dip.ReflectZ();
            dip.reDraw();
        }
    }
}
