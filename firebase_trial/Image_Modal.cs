using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firebase_trial
{
    class Image_Modal
    {
        public String Img
        {
            get;set;
        }

        public static implicit operator Image_Modal(Bitmap v)
        {
            throw new NotImplementedException();
        }
    }
}
