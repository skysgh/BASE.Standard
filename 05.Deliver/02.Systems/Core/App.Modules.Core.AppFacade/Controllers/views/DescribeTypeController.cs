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
        public async Task<IActionResult> Get(string id, string type=null)
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
