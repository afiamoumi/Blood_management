using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bloodbank
{
    public partial class homewindow : UserControl
    {
        public homewindow()
        {
            InitializeComponent();
        }

        // Image Slider

        private int imageNumber = 1;

        private void LoadNextImage()
        {
            if (imageNumber == 10)
            {
                imageNumber = 1;
            }
            sliderpic.ImageLocation = string.Format(@"Images\{0}.jpg",imageNumber);
            imageNumber++;
        }

        private void slider_timer_Tick(object sender, EventArgs e)
        {
            LoadNextImage();
        }
    }
}
