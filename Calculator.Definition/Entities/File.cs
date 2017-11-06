using System.IO;

namespace Calculator.Definition.Entities
{
    public class File
    {
        public string Name { get; set; }

        public Stream Stream { get; set; }
    }
}
