using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amber_Paul_Project.Views
{
    public class View_Controller
    {
        //Fields

            //Parent
            private App_Controller app_Controller;
            //Children
            private _1_Start start;
            private _2_TakePicture takepic;

        private object currentview;

        public object CurrentView
        {
            get { return currentview; }
        }
        //Constructor 1
        public View_Controller(object parent)
        {
            SetObjects(parent);
        }

        private void SetObjects(object parent)
        {
            //Set parent
            app_Controller = (App_Controller)parent;

            //Set Children
            start = new _1_Start(this);
            takepic = new _2_TakePicture(this);

            currentview = start;
        }

        public void GoToNextView()
        {
            //Checks the view it is on and
            //sets the next view
            if (currentview == start)
            {
                currentview = takepic;
                app_Controller.UpdateCurrentView();
            }
        }
    }

}
