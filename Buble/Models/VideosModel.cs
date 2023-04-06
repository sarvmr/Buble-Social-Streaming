using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Buble.Models
{
    public class VideosModel
    {
        public string ID { get; set; }
        public ImageSource Thumbnail { get; set; }
        public int likes { get; set; }
        public int dislikes { get; set; }
        public string title { get; set; }
        public string channel { get; set; }
        public string URL { get; set; }
    }
}
