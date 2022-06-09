using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Repositories
{
    public class CommonImageRepository
    {
        public string MakeImage(string image)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(image);
            string newImage = guid + extension;
            return newImage;
        }
    }
}
