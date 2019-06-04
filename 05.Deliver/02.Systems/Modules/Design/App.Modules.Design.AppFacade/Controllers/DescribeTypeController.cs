using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using App.Modules.Core.Infrastructure.Services;
using LamarCodeGeneration.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage.Shared.Protocol;

namespace App.Modules.Core.AppFacade.Controllers
{
    /// <summary>
    /// <para>
    /// Note: because it is an MVC Controller, 
    /// we're using default routes. 
    /// (If it had been an API controller, would have used
    /// Attribute routing).
    /// </para>
    /// </summary>
    //[Area("Diagnostics")]
    //[Route("views/diagnostics/[controller]")]
    public class DescribeTypesController : Controller
    {
        private readonly INetClassPlantUmlDiagramService _netClassPlantUmlDiagramService;

        public DescribeTypesController(INetClassPlantUmlDiagramService netClassPlantUmlDiagramService)
        {
            _netClassPlantUmlDiagramService = netClassPlantUmlDiagramService;
        }




        [AcceptVerbs("GET")]
        public IActionResult Index(string id, string type=null)
        {

            var results = _netClassPlantUmlDiagramService.Document(id, "https://localhost:5001/describetypes/get?id={0}");


            this.ViewBag.Assembly = results.Title;
            this.ViewBag.FullName = id;
            this.ViewBag.PlantUmlText = results.Response.DiagramText;
            this.ViewBag.svg = results.Response.DiagramSvg;

            return View("~/Views/Ha/Index.cshtml");
        }
    }
}
