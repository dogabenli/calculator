using Calculator.Engine.CalculatorManager;
using Calculator.Engine.FileParserManager;

using Ninject.Modules;

namespace Calculator.Engine.CommonManager
{
    public class DependencyInjectionModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICalculatorExecutionManager>().To<CalculatorExecutionManager>();

            Bind<IFileParserExecutionManager>().To<FileParserExecutionManager>();

        }
    }
}
