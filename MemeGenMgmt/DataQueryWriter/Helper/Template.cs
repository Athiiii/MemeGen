using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DataQueryWriter.Interfaces;
using Newtonsoft.Json;


namespace DataQueryWriter.Helper
{
    internal class Template : ITemplate
    {
        public string CreateDataQuery(string path)
        {
            var dataQueries = string.Empty;
            var files = Directory.GetFiles(path);
            files = files.Select(x =>
            {
                x = Path.GetFileName(x);
                return x;
            }).ToArray();
            files.ToList().ForEach(x => dataQueries += $"INSERT INTO `mgm`.`template` (`ImagePath`, `Name`) VALUES ('template/{x}', '{Path.GetFileNameWithoutExtension(x)}');\n");

            return dataQueries;
        }

        public void GenerateLazyImages(string from, string to)
        {
            var files = Directory.GetFiles(from);
            var pairs = new List<Base64Pair>();
            foreach (var fileName in files)
            {
                var img = Image.FromFile(fileName);
                var height = img.Height / (img.Width / 10);
                var bitmap = new Bitmap(img, new Size(10, height));
                using (var stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Jpeg);
                    var byteImg = stream.ToArray();
                    var content = "data:image/jpeg;base64," + Convert.ToBase64String(byteImg);
                    pairs.Add(new Base64Pair
                    {
                        Data = content,
                        Name = Path.GetFileName(fileName)
                    });
                }
            }

            File.WriteAllText(Path.Combine(to, "lazyLoad.json"), JsonConvert.SerializeObject(pairs));
        }
    }

    struct Base64Pair
    {
        public string Data { get; set; }
        public string Name { get; set; }
    }
}
