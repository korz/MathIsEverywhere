using System.Collections.Generic;
using System.IO;

namespace Recursion
{
    public static class FileSystem
    {
        public static IList<string> Walk(string folder)
        {
            var files = new List<string>();

            Walk(folder, files);

            return files;
        }

        private static void Walk(string folder, IList<string> files)
        {
            foreach (var directory in Directory.GetDirectories(folder))
            {
                foreach (var file in Directory.GetFiles(directory))
                {
                    files.Add(file);
                }

                Walk(directory, files);
            }
        }
    }
}
