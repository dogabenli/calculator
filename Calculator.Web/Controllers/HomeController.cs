using System;
using System.Diagnostics;
using System.Web.Mvc;

using Calculator.Definition.Entities;
using Calculator.Definition.Resources;
using Calculator.Engine.CalculatorManager;
using Calculator.Engine.CommonManager;

using Ninject;

namespace Calculator.Web.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        public ICalculatorExecutionManager CalculatorExecutionManager { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Calculate()
        {
            var file = Request.Files["UploadedFile"];

            //Exceptions handles by HandleExceptionFilter
            //Error messages have been defined as resourse file, it is important for language support
            //Later on, if we want to support Czech, only we need to do create ErrorMessages.cs.resx file
            if (file == null || file.ContentLength <= 0) throw new BusinessException(ErrorMessages.NoFile, TraceLevel.Info);

            var result = CalculatorExecutionManager.Process(new File { Name = file.FileName, Stream = file.InputStream });

            return Json(new BaseResponse { IsSuccess = true, Data = result });
        }
    }
}