using System.Collections.Generic;
using System.IO;

using Calculator.Definition.Entities;

namespace Calculator.Engine.FileParserManager
{
    public interface IFileParserManager
    {
        InstructionsResult Execute(Stream file);
    }
}
