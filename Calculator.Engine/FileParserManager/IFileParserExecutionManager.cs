using System.Collections.Generic;

using Calculator.Definition.Entities;

namespace Calculator.Engine.FileParserManager
{
    public interface IFileParserExecutionManager
    {
        InstructionsResult Process(File file);
    }
}
