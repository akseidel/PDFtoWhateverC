// Copyright 2013-2018 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.
using System.IO;
using System.Windows.Forms;
using ImageMagick;

namespace PDFtoWhateverC
{
    /// <summary>
    /// You need to install the latest version of GhostScript before you can convert a pdf using
    /// Magick.NET. Make sure you only install the version of GhostScript with the same platform. If
    /// you use the 64-bit version of Magick.NET you should also install the 64-bit version of 
    /// Ghostscript. You can use the 32-bit version together with the 64-version but you will get a
    /// better performance if you keep the platforms the same.
    /// </summary>
    public static class ConvertPDF
    {
        public static void ConvertPDFToMultipleImagesAKS(string sourceFile, string targetFolder, string cutSuffixText, string outPutExtType) {

            MagickReadSettings settings = new MagickReadSettings {
                // Settings the density to 300 dpi will create an image with a better quality
                Density = new Density(300, 300)
            };

            try {
                using (MagickImageCollection images = new MagickImageCollection()) {
                    string justPDFName = Path.GetFileName(sourceFile);
                    string justPDFNameNoExt = Path.GetFileNameWithoutExtension(sourceFile);
                    images.Read(sourceFile, settings);
                    int page = 1;
                    foreach (MagickImage image in images) {
                        switch (outPutExtType) {
                            case ".jpg":
                                image.Format = MagickFormat.Jpg;
                                image.Alpha(ImageMagick.AlphaOption.Remove);
                                break;
                            case ".png":
                                image.Format = MagickFormat.Png;
                                image.Alpha(ImageMagick.AlphaOption.Remove);
                                break;
                            case ".gif":
                                image.Format = MagickFormat.Gif;
                                image.Alpha(ImageMagick.AlphaOption.Remove);
                                break;
                            case ".tif":
                                image.Format = MagickFormat.Tif;
                                image.Alpha(ImageMagick.AlphaOption.Remove);
                                break;
                            case ".bmp":
                                image.Format = MagickFormat.Bmp;
                                image.Alpha(ImageMagick.AlphaOption.Remove);
                                break;
                            default:
                                image.Format = MagickFormat.Jpg;
                                image.Alpha(ImageMagick.AlphaOption.Remove);
                                break;
                        }
                        //image.Format = MagickFormat.Jpg;
                        image.Write(targetFolder + "/" + justPDFNameNoExt + cutSuffixText + page.ToString("D2") + outPutExtType);
                        page++;
                    }
                }
            }
            // Catch any MagickException
            catch (MagickException exception) {
                MessageBox.Show(exception.Message);
            }
        }

        //public static void ConvertPDFToMultipleImages()
        //{
        //    MagickReadSettings settings = new MagickReadSettings();
        //    // Settings the density to 300 dpi will create an image with a better quality
        //    settings.Density = new Density(300, 300);

        //    using (MagickImageCollection images = new MagickImageCollection())
        //    {
        //        // Add all the pages of the pdf file to the collection
        //        images.Read(SampleFiles.SnakewarePdf, settings);

        //        int page = 1;
        //        foreach (MagickImage image in images)
        //        {
        //            // Write page to file that contains the page number
        //            image.Write(SampleFiles.OutputDirectory + "Snakeware.Page" + page + ".png");
        //            // Writing to a specific format works the same as for a single image
        //            image.Format = MagickFormat.Ptif;
        //            image.Write(SampleFiles.OutputDirectory + "Snakeware.Page" + page + ".tif");
        //            page++;
        //        }
        //    }
        //}

        //public static void ConvertPDFTOneImage()
        //{
        //    MagickReadSettings settings = new MagickReadSettings();
        //    // Settings the density to 300 dpi will create an image with a better quality
        //    settings.Density = new Density(300);

        //    using (MagickImageCollection images = new MagickImageCollection())
        //    {
        //        // Add all the pages of the pdf file to the collection
        //        images.Read(SampleFiles.SnakewarePdf, settings);

        //        // Create new image that appends all the pages horizontally
        //        using (IMagickImage horizontal = images.AppendHorizontally())
        //        {
        //            // Save result as a png
        //            horizontal.Write(SampleFiles.OutputDirectory + "Snakeware.horizontal.png");
        //        }

        //        // Create new image that appends all the pages horizontally
        //        using (IMagickImage vertical = images.AppendVertically())
        //        {
        //            // Save result as a png
        //            vertical.Write(SampleFiles.OutputDirectory + "Snakeware.vertical.png");
        //        }
        //    }
        //}

        //public static void CreatePDFFromTwoImages()
        //{
        //    using (MagickImageCollection collection = new MagickImageCollection())
        //    {
        //        // Add first page
        //        collection.Add(new MagickImage(SampleFiles.SnakewareJpg));
        //        // Add second page
        //        collection.Add(new MagickImage(SampleFiles.SnakewareJpg));

        //        // Create pdf file with two pages
        //        collection.Write(SampleFiles.OutputDirectory + "Snakeware.pdf");
        //    }
        //}

        //public static void CreatePDFFromSingleImage()
        //{
        //    // Read image from file
        //    using (MagickImage image = new MagickImage(SampleFiles.SnakewareJpg))
        //    {
        //        // Create pdf file with a single page
        //        image.Write(SampleFiles.OutputDirectory + "Snakeware.pdf");
        //    }
        //}

        //public static void ReadSinglePageFromPDF()
        //{
        //    using (MagickImageCollection collection = new MagickImageCollection())
        //    {
        //        MagickReadSettings settings = new MagickReadSettings();
        //        settings.FrameIndex = 0; // First page
        //        settings.FrameCount = 1; // Number of pages

        //        // Read only the first page of the pdf file
        //        collection.Read(SampleFiles.SnakewarePdf, settings);

        //        // Clear the collection
        //        collection.Clear();

        //        settings.FrameCount = 2; // Number of pages

        //        // Read the first two pages of the pdf file
        //        collection.Read(SampleFiles.SnakewarePdf, settings);
        //    }
        //}
    }
}