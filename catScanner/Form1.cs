using Yolov5Net.Scorer;
using Yolov5Net.Scorer.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Image = SixLabors.ImageSharp.Image;

namespace catScanner
{
    public partial class Form1 : Form
    {

        private readonly YoloScorer<catModel> scorer;

        private objectLabeler labeler;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
