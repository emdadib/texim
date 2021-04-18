using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace texim.Helper
{
    public class ImageService
    {
   

        //Have to test it. 
        public static  async Task<string> ImageSave(IFormFile file, string rootpath = "")
        {
            var imagePath = "";
            if (file != null && file.Length > 0)
            {
 
                var pathWithFolderName = Path.Combine(rootpath, "upload\\blog");

                var fileName = Path.GetFileName(file.FileName);
                var generator = new Random();
                var randKey = generator.Next(0, 1000000).ToString("D6");
                var renamedFileName = randKey + "_image_" + Regex.Replace(fileName, @"\s+", "");
                var filePath = Path.Combine(rootpath, "upload\\blog", renamedFileName);

                if (!Directory.Exists(pathWithFolderName))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(pathWithFolderName);
                }


                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileSteam);
                }

                imagePath = filePath;
            }

            return imagePath;
        }

     
        public static void ImageRemove(string imagePath)
        {
            var path = Path.Combine(imagePath);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        //public static string ImageThumbSave(string sourcPath, string fileName, int maxWidth, int maxHight)
        //{
        //    var ImagePath = "";
        //    string rootpath = "/Content/uploads/thumb/";
        //    var filePath = Path.Combine(HttpContext.Current.Server.MapPath(sourcPath));

        //    Image image = Image.FromFile(filePath, false);
        //    Image thumb = image.GetThumbnailImage(maxWidth, maxHight, () => false, IntPtr.Zero);

        //    var generator = new Random();
        //    var randKey = generator.Next(0, 1000000).ToString("D6");
        //    var fileNameFinal = randKey + "_image_" + Regex.Replace(fileName, @"\s+", "");

        //    var path = Path.Combine(HttpContext.Current.Server.MapPath("~" + rootpath), fileNameFinal);
        //    thumb.Save(path);

        //    ImagePath = rootpath + fileNameFinal;


        //    Image image = Image.FromStream(file.OpenReadStream(), true, true);
        //    var newImage = new Bitmap(1024, 768);
        //    using (var g = Graphics.FromImage(newImage))
        //    {
        //        g.DrawImage(image, 0, 0, 1024, 768);
        //    }
        //    return ImagePath;
        //}

        public static bool HasImageExtension(string source)
        {
            return (source.EndsWith(".png") || source.EndsWith(".jpg") || source.EndsWith(".jpeg") || source.EndsWith(".gif"));
        }

    }
}