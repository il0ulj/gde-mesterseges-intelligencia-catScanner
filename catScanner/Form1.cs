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
            scorer = new YoloScorer<catModel>("macska.onnx");
            labeler = new objectLabeler();
        }

        private async void button1_Click(object sender, EventArgs args)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPG (*.JPG)|*.jpg";

            DialogResult result = ofd.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            textBox1.Text = ofd.FileName;

            if (!File.Exists(ofd.FileName))
            {
                MessageBox.Show(
                    "Hiba a k�p bet�lt�se k�zben " + ofd.FileName + ":\n" + "A f�jl nem l�tezik vagy nincs megfelel� jogosults�ga hozz�..",
                    "Hiba a k�p bet�lt�se k�zben"
                    );

                return;
            }

            Image<Rgba32> img;

            try
            {
                img = await Image.LoadAsync<Rgba32>(ofd.FileName);
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "Hiba a k�p bet�lt�se k�zben " + ofd.FileName + ":\n" + e.Message,
                    "Hiba a k�p bet�lt�se k�zben"
                    );

                return;
            }

            List<YoloPrediction> predictions = scorer.Predict(img);

            labeler.label(img, predictions);

            pictureBox1.BackgroundImage = img.ToArray().ToDrawingImage();

        }

    }
}
