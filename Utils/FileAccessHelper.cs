using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ednavarrT5.Utils
{
    public class FileAccessHelper
    {
        public static string GetFolderPath (string filename)
            {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
        }
    }
}
