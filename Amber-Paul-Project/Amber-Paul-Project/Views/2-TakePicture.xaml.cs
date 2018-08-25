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

namespace Amber_Paul_Project.Views
{


    public partial class _2_TakePicture : UserControl
    {
        private View_Controller view_Controller;
        public _2_TakePicture(View_Controller view)
        {
            InitializeComponent();
            view_Controller = view;
        }
    }
}
