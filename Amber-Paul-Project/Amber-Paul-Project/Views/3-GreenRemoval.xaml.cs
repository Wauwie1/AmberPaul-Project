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
    public partial class _3_GreenRemoval : UserControl
    {
        //Fields
            //Parent
            private View_Controller view_Controller;
        public _3_GreenRemoval(View_Controller view)
        {
            InitializeComponent();

            //Sets Parent
            view_Controller = view;
        }
    }
}
