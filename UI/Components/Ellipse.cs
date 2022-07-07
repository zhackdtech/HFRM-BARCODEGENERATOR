using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HFRM_BARCODEGENERATOR.UI.Components
{
    internal class Ellipse : Component
    {
        /// <summary>
        /// declare vcariables that we will need
        /// </summary>

        //the control to be ellipsed
        private Control Target;
        //the radius of the Target
        private int radius = 30;

        //provide entrypoint for Gdi32.dll assembly
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        //The CreateRoundRectRgn function creates a rectangular region with rounded corners.
        /// <summary>
        /// [in] x1
        /// Specifies the x-coordinate of the upper-left corner of the region in device units.
        /// [in] y1
        /// Specifies the y-coordinate of the upper-left corner of the region in device units.
        /// [in] x2
        /// Specifies the x-coordinate of the lower-right corner of the region in device units.
        /// [in] y2
        /// Specifies the y-coordinate of the lower-right corner of the region in device units.
        /// [in] w
        /// Specifies the width of the ellipse used to create the rounded corners in device units.
        /// [in] h
        /// Specifies the height of the ellipse used to create the rounded corners in device units.
        /// </summary>
        private static extern IntPtr CreateRoundRectRgn
            (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse
            );


        /// <summary>
        /// Defines the base class for controls, 
        /// which are components with visual representation.
        /// </summary>

        //Gets and sets the control to change the visual of
        public Control TargetControl
        {
            //return the Control
            get { return Target; }
            set
            {
                //set the value of the Target
                Target = value;
                //Occurs when the Size property value changes.
                Target.SizeChanged += (sender, eventArgs) => Target.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Target.Width, Target.Height, radius, radius));
            }
        }

        //Gets and sets the radius of the control to change the visual of
        public int CornerRadius
        {
            //get the value of radius
            get { return radius; }
            set
            {
                //set the value of radius
                radius = value;
                //check if target is empty
                if (Target != null)
                    //if not empty, execute Region.FromHrgn() with CreateRoundRectRgn() as param
                    Target.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Target.Width, Target.Height, radius, radius));
            }
        }
    }
}
