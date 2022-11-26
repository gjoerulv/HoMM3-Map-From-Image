using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

/// <copyright>
/// This code may be used and distributed freely. No warranty is made by the
/// author, implied or otherwise. This code comes as-is with no guarantee.
/// (c) 2007 by Matthew Martin. http://www.usualdosage.com.
/// </copyright>

/// <summary>
/// Contains various static methods for converting an image to an HTML document
/// containing an ASCII representation of the image.
/// </summary>
public static class ASCIIConverter
{
    #region [ Private Members ]

    /// <summary>
    /// These constants are used to convert an image to a "true" ASCII drawing.
    /// Each constant is selected by it's relative grayscale value to represent
    /// a single pixel in a bitmap.
    /// </summary>
    
    public const char BLACK = '@';
    public const char CHARCOAL = '#';
    public const char DARKGRAY = '8';
    public const char MEDIUMGRAY = '&';
    public const char MEDIUM = 'o';
    public const char GRAY = ':';
    public const char SLATEGRAY = '*';
    public const char LIGHTGRAY = '.';
    public const char WHITE = ' ';

    #endregion 

    #region [ Private Methods ]

    /// <summary>
    /// Macro to return one of the ASCII constants based on the relative
    /// "darkness" of the red value.
    /// </summary>
    /// <param name="redValue">The red value of the pixel</param>
    /// <returns>System.String</returns>
    private static char getGrayShade(int redValue)
    {
        char asciival = ' ';

        if (redValue >= 227)
        {
            asciival = WHITE;
        }
        else if (redValue >= 198)
        {
            asciival = LIGHTGRAY;
        }
        else if (redValue >= 170)
        {
            asciival = SLATEGRAY;
        }
        else if (redValue >= 142)
        {
            asciival = GRAY;
        }
        else if (redValue >= 113)
        {
            asciival = MEDIUM;
        }
        else if (redValue >= 85)
        {
            asciival = MEDIUMGRAY;
        }
        else if (redValue >= 57)
        {
            asciival = DARKGRAY;
        }
        else if (redValue >= 28)
        {
            asciival = CHARCOAL;
        }
        else
        {
            asciival = BLACK;
        }

        return asciival;
    }

    #endregion

    #region [ Public Methods ]

    /// <summary>
    /// Converts an image (jpg, gif, etc) to a colored ASCII drawing using
    /// the specified input character.
    /// </summary>
    /// <param name="img">The input image.</param>
    /// <param name="strInputChar">The character to use in the drawing.</param>
    /// <returns>HTML formatted text</returns>
    //public static string ImageToText(System.Drawing.Image img, string strInputChar)
    //{
    //    Bitmap bmp = null;
    //    StringBuilder html = new StringBuilder();

    //    try
    //    {
    //        // Create a bitmap from the image
    //        bmp = new Bitmap(img);

    //        // The text will be enclosed in a paragraph tag <p> with the class
    //        // ascii_art so that we can apply CSS styles to it.
    //        html.Append("<p class='ascii_art'>");

    //        // Loop through each pixel in the bitmap
    //        for (int y = 0; y < bmp.Height; y++)
    //        {
    //            for (int x = 0; x < bmp.Width; x++)
    //            {
    //                // Nest each character inside an anchor tag so we can use
    //                // inline styles to set the color.
    //                html.Append("<a style='color: ");

    //                Color fontColor = bmp.GetPixel(x, y);

    //                // Convert the color to hexadecimal
    //                string color = System.Drawing.ColorTranslator.ToHtml(fontColor);

    //                html.Append(color + ";'>" + strInputChar + "</a>");

    //                // If we're at the width, insert a line break
    //                if (x == bmp.Width - 1)
    //                    html.Append("<br/>");
    //            }
    //        }

    //        // Close the paragraph tag, and return the html string.
    //        html.Append("</p>");
    //        return html.ToString();
    //    }
    //    catch (Exception exc)
    //    {
    //        return exc.ToString();
    //    }
    //    finally
    //    {
    //        bmp.Dispose();
    //    }
    //}

    /// <summary>
    /// Converts an image (jpg, gif, etc) to a grayscale ASCII drawing using
    /// the specified input character.
    /// </summary>
    /// <param name="img">The input image.</param>
    /// <param name="strInputChar">The character to use in the drawing.</param>
    /// <returns>HTML formatted text</returns>
    //public static string GrayscaleImageToText(System.Drawing.Image img, string strInputChar)
    //{
    //    StringBuilder output = new StringBuilder();
    //    Bitmap bmp = null;

    //    try
    //    {
    //        // Create a bitmap from the image
    //        bmp = new Bitmap(img);
            
    //        // The text will be enclosed in a paragraph tag <p> with the class
    //        // ascii_art so that we can apply CSS styles to it.
    //        ///output.Append("<p class='ascii_art'>"); //STAAART

    //        // Loop through each pixel in the bitmap
    //        for (int y = 0; y < bmp.Height; y++)
    //        {
    //            for (int x = 0; x < bmp.Width; x++)
    //            {
    //                // Get the color of the current pixel
    //                Color col = bmp.GetPixel(x, y);

    //                // To convert to grayscale, the easiest method is to add
    //                // the R+G+B colors and divide by three to get the gray
    //                // scaled color.
    //                bmp.SetPixel(x, y,
    //                    Color.FromArgb((col.R + col.G + col.B) / 3,
    //                    (col.R + col.G + col.B) / 3,
    //                    (col.R + col.G + col.B) / 3));

    //                // Nest each character inside an anchor tag so we can use
    //                // inline styles to set the color.
    //                //output.Append("<a style='color: ");

    //                // Get the new pixel color since we changed it to gray
    //                Color fontColor = bmp.GetPixel(x, y);
    //                string color = System.Drawing.ColorTranslator.ToHtml(fontColor.);
    //                output.Append(color + ";'>" + strInputChar + "</a>");

    //                // If we're at the width, insert a line break
    //                if (x == bmp.Width - 1)
    //                    output.Append("\n");
    //            }
    //        }

    //        // Close the paragraph tag, and return the html string.
    //        //output.Append("</p>"); EEEND
    //        return output.ToString();
    //    }
    //    catch (Exception exc)
    //    {
    //        return exc.ToString();
    //    }
    //    finally
    //    {
    //        if (bmp != null) bmp.Dispose();
    //    }
    //}

    public static string GrayscaleImageToASCII(System.Drawing.Image img)
    {
        StringBuilder output = new StringBuilder();
        Bitmap bmp = null;

        try
        {
            // Create a bitmap from the image
            bmp = new Bitmap(img);

            // The text will be enclosed in a paragraph tag <p> with the class
            // ascii_art so that we can apply CSS styles to it.
            //html.Append("<p class='ascii_art'>");//STAAAART

            // Loop through each pixel in the bitmap
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    // Get the color of the current pixel
                    Color col = bmp.GetPixel(x, y);

                    // To convert to grayscale, the easiest method is to add
                    // the R+G+B colors and divide by three to get the gray
                    // scaled color.
                    col = Color.FromArgb((col.R + col.G + col.B) / 3,
                        (col.R + col.G + col.B) / 3,
                        (col.R + col.G + col.B) / 3);

                    // Get the R(ed) value from the grayscale color,
                    // parse to an int. Will be between 0-255.
                    int rValue = int.Parse(col.R.ToString());

                    // Append the "color" using various darknesses of ASCII
                    // character.
                    output.Append(getGrayShade(rValue));

                    // If we're at the width, insert a line break
                    if (x == bmp.Width - 1)
                        output.Append(Environment.NewLine);
                }
            }

            // Close the paragraph tag, and return the html string.
            //html.Append("</p>");//EEEEEENND

            return output.ToString();
        }
        catch (Exception exc)
        {
            throw exc;
        }
        finally
        {
            if (bmp != null) bmp.Dispose();
        }
    }

    #endregion


    public static Bitmap Grayscale(Image image)
    {
        Bitmap btm = new Bitmap(image);
        for (int i = 0; i < btm.Width; i++)
        {
            for (int j = 0; j < btm.Height; j++)
            {
                int ser = (int)(btm.GetPixel(i, j).R * 0.3 + btm.GetPixel(i, j).G * 0.59 + btm.GetPixel(i, j).B * 0.11);

                btm.SetPixel(i, j, Color.FromArgb(ser, ser, ser));
            }
        }
        return btm;
    }

    public static Bitmap ResizeImageAbsolute(Image image, int width, int height) => 
        ResizeImageAbsolute((Bitmap)image, width, height);

    public static Bitmap ResizeImageAbsolute(Bitmap image, int width, int height)
    {
        if (width < 1 || height < 1)
            throw new Exception("Width and/or height too small.");
        return new Bitmap(image, width, height);
    }

    public static Bitmap ScaleImage(Image image, int maxWidth, int maxHeight)
    {
        var ratioX = (double)maxWidth / image.Width;
        var ratioY = (double)maxHeight / image.Height;
        var ratio = Math.Min(ratioX, ratioY);

        var newWidth = (int)(image.Width * ratio);
        var newHeight = (int)(image.Height * ratio);

        var newImage = new Bitmap(newWidth, newHeight);

        using (var graphics = Graphics.FromImage(newImage))
            graphics.DrawImage(image, 0, 0, newWidth, newHeight);

        return new Bitmap(newImage);
    }

    public static Image FromFile(string file)
    {
        if (File.Exists(file))
            return Image.FromFile(file);
        else throw new ArgumentException("Could not work with file: " + (file ?? ""), nameof(file));
    }

    // closed match for hues only:
    public static int ClosestColor1(List<Color> colors, Color target)
    {
        var hue1 = target.GetHue();
        var diffs = colors.Select(n => getHueDistance(n.GetHue(), hue1));
        var diffMin = diffs.Min(n => n);
        return diffs.ToList().FindIndex(n => n == diffMin);
    }

    // closed match in RGB space
    public static int ClosestColor2(List<Color> colors, Color target)
    {
        var colorDiffs = colors.Select(n => ColorDiff(n, target)).Min(n => n);
        return colors.FindIndex(n => ColorDiff(n, target) == colorDiffs);
    }

    // weighed distance using hue, saturation and brightness
    public static int ClosestColor3(List<Color> colors, Color target)
    {
        float hue1 = target.GetHue();
        var num1 = ColorNum(target);
        var diffs = colors.Select(n => Math.Abs(ColorNum(n) - num1) +
                                       getHueDistance(n.GetHue(), hue1));
        var diffMin = diffs.Min(x => x);
        return diffs.ToList().FindIndex(n => n == diffMin);
    }


    // color brightness as perceived:
    static float getBrightness(Color c)
    { return (c.R * 0.299f + c.G * 0.587f + c.B * 0.114f) / 256f; }

    // distance between two hues:
    static float getHueDistance(float hue1, float hue2)
    {
        float d = Math.Abs(hue1 - hue2); return d > 180 ? 360 - d : d;
    }

    //  weighed only by saturation and brightness (from my trackbars)
    static float ColorNum(Color c)
    {
        return c.GetSaturation() * /*factorSat*/ 1f +
                    getBrightness(c) * /*factorBri*/ 1f;
    }

    // distance in RGB space
    static int ColorDiff(Color c1, Color c2)
    {
        return (int)Math.Sqrt((c1.R - c2.R) * (c1.R - c2.R)
                               + (c1.G - c2.G) * (c1.G - c2.G)
                               + (c1.B - c2.B) * (c1.B - c2.B));
    }


    public static int ClosestColor(List<Color> colorArray, Color baseColor)
    {
        var colors = colorArray.Select(x => new { Value = x, Diff = GetDiff(x, baseColor) }).ToList();
        var min = colors.Min(x => x.Diff);
        return colorArray.IndexOf(colors.Find(x => x.Diff == min).Value);
    }

    private static int GetDiff(Color color, Color baseColor)
    {
        int a = color.A - baseColor.A,
            r = color.R - baseColor.R,
            g = color.G - baseColor.G,
            b = color.B - baseColor.B;
        return a * a + r * r + g * g + b * b;
    }
}
