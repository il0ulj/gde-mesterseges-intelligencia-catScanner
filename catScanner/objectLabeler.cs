using Yolov5Net.Scorer;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;

using PointF = SixLabors.ImageSharp.PointF;
using Font = SixLabors.Fonts.Font;
using FontCollection = SixLabors.Fonts.FontCollection;
using Image = SixLabors.ImageSharp.Image;
using Color = SixLabors.ImageSharp.Color;

namespace catScanner
{
    class objectLabeler
    {
        private readonly Font font;

        public objectLabeler()
        {
            font = new Font(new FontCollection().Add("C:/Windows/Fonts/consola.ttf"), 30);
        }

        public void label(Image img, List<YoloPrediction> predictions)
        {
            foreach (YoloPrediction prediction in predictions)
            {
                double score = Math.Round(prediction.Score, 2);

                float x = prediction.Rectangle.Left - -20;
                float y = prediction.Rectangle.Top - -20;

                img.Mutate(a => a.DrawPolygon(
                    new SolidPen(prediction.Label.Color, 6),
                    new PointF(prediction.Rectangle.Left, prediction.Rectangle.Top),
                    new PointF(prediction.Rectangle.Right, prediction.Rectangle.Top),
                    new PointF(prediction.Rectangle.Right, prediction.Rectangle.Bottom),
                    new PointF(prediction.Rectangle.Left, prediction.Rectangle.Bottom)
                    )
                );

                img.Mutate(
                    a => a.DrawText(
                        $"{prediction.Label.Name} ({score})",
                        font,
                        prediction.Label.Color,
                        new PointF(x, y)
                        )
                    );
            }
        }
    }
}
