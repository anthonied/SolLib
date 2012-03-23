using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SOL.IO
{
    /// <summary>
    /// Provides a set of static methods for manipulating <see cref="FileInfo"/> objects.
    /// </summary>
    public static class FileInfoExtensions
    {
        /// <summary>
        /// Opens a text file, reads all lines of the file into a string, and then closes the file.
        /// </summary>
        /// <param name="fileInfo">The <see cref="FileInfo"/> indicating which file to open for reading.</param>
        /// <returns>A string containing all lines of the file.</returns>
        public static string ReadAllText(this FileInfo fileInfo)
        {
            using (StreamReader reader = fileInfo.OpenText())
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Opens a text file, reads all text into a byte array using UTF8 encoding, and then closes the file.
        /// </summary>
        /// <param name="fileInfo">The <see cref="FileInfo"/> indicating which file to open for reading.</param>
        /// <returns>A UTF8 byte array representing all text in the file.</returns>
        public static byte[] ReadAllTextAsBytes(this FileInfo fileInfo)
        {
            string allText = fileInfo.ReadAllText();
            return Encoding.UTF8.GetBytes(allText);
        }

        /// <summary>
        /// Opens a binary file, reads the contents of the file into a byte array, and then closes the file.
        /// </summary>
        /// <param name="fileInfo">The <see cref="FileInfo"/> indicating which file to open for reading.</param>
        /// <returns>A byte array containing the contents of the file.</returns>
        public static byte[] ReadAllBytes(this FileInfo fileInfo)
        {
            using (FileStream fs = fileInfo.OpenRead())
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, bytesRead);
                    }

                    return ms.ToArray();
                }
            }
        }
    }
}
