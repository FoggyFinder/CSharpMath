using P = System.IO.Path;

namespace CSharpMath.DevUtils {
  static class Paths {
    /// <summary>
    /// The path of the global CSharpMath folder
    /// </summary>
    public static readonly string Global = ((System.Func<string>)(() => {
      var L = typeof(Paths).Assembly.Location;
      while (P.GetFileName(L) != nameof(CSharpMath)) L = P.GetDirectoryName(L);
      return L;
    }))();

    /// <summary>
    /// The path of Reference Fonts folder
    /// </summary>
    public static readonly string ReferenceFontsFolder =
      P.Combine(Global, nameof(CSharpMath) + ".Rendering", "Reference Fonts");
    /// <summary>
    /// The path of the MoreExamples.cs file, which stores examples from iosMath
    /// </summary>
    public static readonly string iosMathExamplesFile =
      P.Combine(Global,
        "CSharpMath.Forms.Example", "CSharpMath.Forms.Example", "MoreExamples.cs");
    /// <summary>
    /// The path of the IosMathViewController.cs file,
    /// which stores the examples in the CSharpMath.Ios project
    /// </summary>
    public static readonly string IosMathViewController =
      P.Combine(Global,
        "CSharpMath.IosExample", "ViewController", "IosMathViewController.cs");
    /// <summary>
    /// The path of the ExamplesPage.xaml.cs file,
    /// which stores the CSharpMath.Forms examples mirrored from CSharpMath.Ios 
    /// </summary>
    public static readonly string FormsMathExamplesFile =
      P.Combine(Global,
        "CSharpMath.Forms.Example", "CSharpMath.Forms.Example", "ExamplesPage.xaml.cs");
  }
}
