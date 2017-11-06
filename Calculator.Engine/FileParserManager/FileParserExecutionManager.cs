using System;
using System.Diagnostics;
using System.IO;

using Calculator.Definition.Entities;
using Calculator.Definition.Enums;
using Calculator.Definition.Resources;

using File = Calculator.Definition.Entities.File;

namespace Calculator.Engine.FileParserManager
{
    public class FileParserExecutionManager : IFileParserExecutionManager
    {
        public InstructionsResult Process(File file)
        {
            //validations for file object
            if (file == null) throw new ArgumentNullException(ErrorMessages.FileIsNull);

            if (string.IsNullOrEmpty(file.Name)) throw new BusinessException(ErrorMessages.FileNameIsInvalid, TraceLevel.Verbose);

            var extension = Path.GetExtension(file.Name).Replace(".","");

            FileFormat fileFormat;

            Enum.TryParse(extension, true, out fileFormat);

            //FileParserFactory creates responsible parser manager based on file format
            var responsibleParserManager = FileParserFactory.Create(fileFormat);

            var result = responsibleParserManager.Execute(file.Stream);

            return result;
        }
    }
}
