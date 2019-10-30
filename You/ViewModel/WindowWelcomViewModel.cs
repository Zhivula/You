using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using You.Properties;

namespace You.ViewModel
{
    class WindowWelcomViewModel
    {
        public WindowWelcomViewModel()
        {
            PathUserPhoto = Settings.Default["PathPhotoUser"].ToString();
        }

        public object PathUserPhoto { get; set; }
    }
}
