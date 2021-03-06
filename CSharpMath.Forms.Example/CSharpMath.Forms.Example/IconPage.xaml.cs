using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace CSharpMath.Forms.Example {
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class IconPage : ContentPage {
    public IconPage() {
      InitializeComponent();
      var v = new SKCanvasView();
      v.VerticalOptions = v.HorizontalOptions = LayoutOptions.FillAndExpand;
      v.PaintSurface += PaintSurface;
      Content = v;
    }

    SkiaSharp.MathPainter painter;
    readonly SKPaint black = new SKPaint { Color = SKColors.Black };
    readonly SKPaint white = new SKPaint { Color = SKColors.White };
    void Temp(object sender, SKPaintSurfaceEventArgs e) {
      for (int i = 0; i < 10; i++) {
        e.Surface.Canvas.DrawCircle(e.Info.Width / 2, e.Info.Height / 2 - 50,
            5, new SKPaint { Color = SKColors.Black });
        e.Surface.Canvas.RotateDegrees(360 / 10, e.Info.Width / 2, e.Info.Height / 2);
      }
    }
    private void PaintSurface(object sender, SKPaintSurfaceEventArgs e) {
      const int count = 10; //number of digits in outer circle
      const float r = 100f; //outer circle radius
      const float f = 40f; //font size in points
      const float thicknessAdjust = 2 * f / 3; //thickness adjust of the two circles
      const float θ = 360f / count; //angle to rotate when drawing each digit
      painter ??= new SkiaSharp.MathPainter { FontSize = f }; //{ GlyphBoxColor = (SKColors.Red, SKColors.Red) };
      var cx = e.Info.Width / 2;
      var cy = e.Info.Height / 2;
      var c = e.Surface.Canvas;
      //draw outer circle
      c.DrawCircle(cx, cy, r + thicknessAdjust, black);
      painter.TextColor = SKColors.White;
      for (int i = 0; i < count; i++) {
        painter.LaTeX = i.ToString();
        var m = painter.Measure().Value;
        painter.Draw(c, cx - m.Width / 2, cy - r - m.Y / 2);
        c.RotateDegrees(θ, cx, cy);
      }
      //draw inner circle
      c.DrawCircle(cx, cy, r - thicknessAdjust, white);
      painter.TextColor = SKColors.Black;
      painter.LaTeX = @"\raisebox{25mu}{\text{\kern.7222emC\#}\\Math}"; //.7222em is 13/18em
      painter.Draw(c);
    }
  }
}