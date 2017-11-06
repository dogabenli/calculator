using System.Diagnostics;

using Calculator.Definition.Entities;
using Calculator.Definition.Enums;
using Calculator.Definition.Resources;

namespace Calculator.Engine.FileParserManager
{
    /// <summary>
    ///  This class is responsible to create file parser objects by file format
    /// </summary>
    public class FileParserFactory
    {
        public static IFileParserManager Create(FileFormat fileFormat)
        {
            IFileParserManager manager;

            switch (fileFormat)
            {
                case FileFormat.Txt:
                    manager = new TxtFileParserManager();
                    break;
                default:
                    //Only supports Txt files but later on it can be easly supported other formats 
                    throw new BusinessException(ErrorMessages.FileFormatNotSupported, TraceLevel.Info);
            }

            return manager;
        }
    }
}
