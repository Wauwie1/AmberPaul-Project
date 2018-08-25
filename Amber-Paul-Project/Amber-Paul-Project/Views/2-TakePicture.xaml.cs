using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.IO;
using System.Threading;

using Microsoft.Win32;
using WebEye.Controls.Wpf;

namespace Amber_Paul_Project.Views
{


    public partial class _2_TakePicture : UserControl
    {
        //Fields
        private View_Controller view_Controller;
        private Camera_Controller camera_Controller;
        public _2_TakePicture(View_Controller view)
        {
            InitializeComponent();
            view_Controller = view;
            camera_Controller = new Camera_Controller(webCameraControl);
           
            
        }

        private void Button_capture_Click(object sender, RoutedEventArgs e)
        {
            camera_Controller.Capture();
        }

        private void Button_continue_Click(object sender, RoutedEventArgs e)
        {

        }

        private void webCameraControl_Loaded(object sender, RoutedEventArgs e)
        {
            camera_Controller.ActivateCamera();
        }
    }
}
