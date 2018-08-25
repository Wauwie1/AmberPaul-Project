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
            //Parent
            private View_Controller view_Controller;

        private bool inPreview = false;
        private Camera_Controller camera_Controller;
        public _2_TakePicture(View_Controller view)
        {
            InitializeComponent();
            view_Controller = view;
            camera_Controller = new Camera_Controller(webCameraControl);
           
            
        }

        private void Capture()
        {
            //Takes Photo
            camera_Controller.Capture();
            //Freezes the camera and show preview of photo
            //Shows taken picture
            Image_preview.Source = camera_Controller.TakenPhoto;

            //Changes button and label
            Button_capture.Content = new BitmapImage(new Uri(@"/Amber-Paul-Project;component/Resources/UI/But_redo.png", UriKind.Relative));

            inPreview = true;

            Label_tevreden.Visibility = Visibility.Visible;
            Button_continue.Visibility = Visibility.Visible;
        }

        private void ResetCamera()
        {
            //Resets the camera
            camera_Controller.Reset();

            //Disables and hides the preview
            Image_preview.Source = null;
            inPreview = false;

            //Returns buttons and labels to their original state
            Button_capture.Content = new BitmapImage(new Uri(@"/Amber-Paul-Project;component/Resources/UI/But_TakePic.png", UriKind.Relative));
            Label_tevreden.Visibility = Visibility.Hidden;
            Button_continue.Visibility = Visibility.Hidden;
        }

        private void Button_capture_Click(object sender, RoutedEventArgs e)
        {
            if (!inPreview)
            {
                Capture();

            }
            else if (inPreview)
            {
                ResetCamera();
            }
        }

        private void Button_continue_Click(object sender, RoutedEventArgs e)
        {
            //Resets Camera for the next user
            ResetCamera();
            view_Controller.GoToNextView();
        }

        private void webCameraControl_Loaded(object sender, RoutedEventArgs e)
        {
            camera_Controller.ActivateCamera();
        }
    }
}
