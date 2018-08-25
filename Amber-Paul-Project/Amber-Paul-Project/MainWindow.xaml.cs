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
using Amber_Paul_Project.ViewModels;
using Amber_Paul_Project.Views;

namespace Amber_Paul_Project
{
    public partial class MainWindow : Window
    {
        //Fields

            //Child
            private App_Controller app_Controller;

        public MainWindow()
        {
            InitializeComponent();

            //Initializes the app_controller child and sets the current
            //view to start.
            app_Controller = new App_Controller(this);
            DataContext = app_Controller.CurrentView;
        }

    }
}
