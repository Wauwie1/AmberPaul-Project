using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amber_Paul_Project.Views
{
    class App_Controller
    {
        //Fields
            //Parent
            private MainWindow main;
            //Child
            private View_Controller view_controller;
            private object currentview;

        public object CurrentView
        {
            get { UpdateCurrentView();
                  return currentview; }
        }

        public App_Controller(object parent)
        {
            //Sets objects
            SetObjects(parent);

        }

        private void SetObjects(object parent)
        {
            //Set parent
            main = (MainWindow)parent;

            //Set Child
            view_controller = new View_Controller(this);


            currentview = new object();
        }

        public void UpdateCurrentView()
        {
            //Updates the view to the current view
            currentview = view_controller.CurrentView;
            main.DataContext = currentview;
        }
    }
}
