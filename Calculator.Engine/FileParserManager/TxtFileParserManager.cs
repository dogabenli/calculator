using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

using Calculator.Definition.Entities;
using Calculator.Definition.Enums;
using Calculator.Definition.Resources;

namespace Calculator.Engine.FileParserManager
{
    public class TxtFileParserManager : IFileParserManager
    {
        public InstructionsResult Execute(Stream stream)
        {
            var items = (from line in ReadLine(stream)
                         let item = ParseLine(line)
                         select item).ToList();

            if (!items.Any()) throw new BusinessException(ErrorMessages.FileIsEmpty, TraceLevel.Info);

            //apply instruction should be 1, if not warn the user
            if (items.Count(x => x.InstructionType == InstructionType.Apply) != 1) throw new BusinessException(ErrorMessages.InvalidNumberOfApply, TraceLevel.Info);

            var applyLine = items.LastOrDefault();

            //apply instruction should be at the end, if not warn the user
            if (applyLine?.InstructionType != InstructionType.Apply) throw new BusinessException(ErrorMessages.LastLineNotApply, TraceLevel.Info);

            //no need apply instruction any more, so it can be removed
            //by removing it, we won't need to use if condition in instructions loop
            items.RemoveAt(items.Count-1);

            var result = new InstructionsResult
            {
                InitialNumber = applyLine.Number,
                Instructions =  items
            };

            return result;
        }

        static IEnumerable<string> ReadLine(Stream file)
        {
            using (var txtReader = new StreamReader(file))
            {
                string line;

                while ((line = txtReader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }


        static Instruction ParseLine(string line)
        {
            var parsedStr = line.Split(' ');

            //Array length is expected as 2, if not it means line has invalid data
            if (parsedStr.Length != 2) throw new BusinessException(ErrorMessages.FileIncludesInvalidData, TraceLevel.Warning);

            var result = new Instruction
            {
                InstructionType = GetInstructionType(parsedStr[0]),
                Number = GetNumber(parsedStr[1])
            };

            return result;
        }

        static InstructionType GetInstructionType(string instructionAsStr)
        {
            InstructionType instructionType;

            Enum.TryParse(instructionAsStr, true, out instructionType);

            //if invalid instruction comes, throw ex
            if (instructionType == InstructionType.Undefined) throw new BusinessException(string.Format(ErrorMessages.FileIncludesInvalidInstruction, instructionAsStr), TraceLevel.Warning);

            return instructionType;
        }

        static decimal GetNumber(string numberAsStr)
        {
            decimal number;

            if (!decimal.TryParse(numberAsStr, out number)) throw new BusinessException(string.Format(ErrorMessages.FileIncludesInvalidNumber, numberAsStr), TraceLevel.Warning);

            return number;
        }
    }
}
