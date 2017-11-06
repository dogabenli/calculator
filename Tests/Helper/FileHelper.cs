using System;
using System.IO;
using System.Reflection;

namespace Tests.Helper
{
    public class FileHelper
    {
        public static Stream GetTestFileStream(string sampleFile)
        {
            var asm = Assembly.GetExecutingAssembly();

            var resource = string.Format("Tests.SampleFiles.{0}", sampleFile);

            var stream = asm.GetManifestResourceStream(resource);

            if (stream == null) throw new Exception("Test exception: stream is null");

            return stream;
        }
    }
}
