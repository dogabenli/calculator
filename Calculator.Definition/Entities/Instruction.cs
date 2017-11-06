using System.Collections.Generic;

using Calculator.Definition.Enums;

namespace Calculator.Definition.Entities
{
    public class InstructionsResult
    {
        public IEnumerable<Instruction> Instructions { get; set; }

        public decimal InitialNumber { get; set; }
    }

    public class Instruction
    {
        public InstructionType InstructionType { get; set; }

        public decimal Number { get; set; }
    }
}
