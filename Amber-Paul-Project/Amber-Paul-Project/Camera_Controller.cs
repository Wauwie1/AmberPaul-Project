﻿using System;
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
using System.Windows.Threading;


using Microsoft.Win32;
using WebEye.Controls.Wpf;

namespace Amber_Paul_Project
{
    class Camera_Controller
    {
        //Fields
        DispatcherTimer starttimer = new DispatcherTimer();

        private bool inPreview = false;
        private BitmapImage takenPhoto;
        IEnumerable<WebCameraId> idList;

        private WebCameraControl webCameraControl;

        public WebCameraControl WebCameraControl
        {
            get { return webCameraControl; }
        }

        //Constructor
        public Camera_Controller(WebCameraControl webcam)
        {
            webCameraControl = webcam;

            //Sets timer
            starttimer.Tick += new EventHandler(starttimer_Tick);
            starttimer.Interval = new TimeSpan(0, 0, 3);
            //starttimer.Start();
        }

        //Custom methods
        public void ActivateCamera()
        {
            //Gets a list of all available webcams and selects the first one
            idList = webCameraControl.GetVideoCaptureDevices();
            var Id = idList.ElementAt(0);
            //Activates the webcam
            webCameraControl.StartCapture(Id);
        }
        public void Capture()
        {
            //Takes picture and converts it to a WriteableBitmap
            Bitmap photoBitmap = webCameraControl.GetCurrentImage();
            BitmapImage photoImage = BitmapToImageSource(photoBitmap);
            takenPhoto = photoImage;
            WriteableBitmap photoWriteable = new WriteableBitmap(photoImage);

            photoBitmap.Save(@"C:\Users\Paul_Laptop\Documents\Fontys\Overig\Overige Repos\Aesthetic\Aesthetic\Resources\Temp\temp.png", System.Drawing.Imaging.ImageFormat.Png);


            //Stops and hides camera
            webCameraControl.StopCapture();
            webCameraControl.Visibility = System.Windows.Visibility.Hidden;

        }

        public void Reset()
        {
            ActivateCamera();
            webCameraControl.Visibility = Visibility.Visible;
        }

        private BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        //Events
        private void starttimer_Tick(object sender, EventArgs e)
        {
            ActivateCamera();
            starttimer.Stop();
        }

    }
}
