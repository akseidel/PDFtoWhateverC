using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDFtoWhateverC
{
    class ClassForPathCombine
    {
        public static string Combine(string path1, string path2)
        {
            // Ensure neither end of path1 or beginning of path2 have slashes
            path1 = path1.Trim().TrimEnd(System.IO.Path.DirectorySeparatorChar);
            path2 = path2.Trim().TrimStart(System.IO.Path.DirectorySeparatorChar);

            // Handle drive letters
            if (path1.Substring(path1.Length - 1, 1) == ":")
                path1 += System.IO.Path.DirectorySeparatorChar;

            return System.IO.Path.Combine(path1, path2);
        }
    }
}
