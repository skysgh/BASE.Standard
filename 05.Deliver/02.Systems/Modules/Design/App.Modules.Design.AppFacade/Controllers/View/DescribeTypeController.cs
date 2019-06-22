// Copyright MachineBrains, Inc. 2019

using App.Modules.Design.Infrastructure.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Design.AppFacade.Controllers.View
{
    /// <summary>
    ///     <para>
    ///         Note: because it is an MVC Controller,
    ///         we're using default routes.
    ///         (If it had been an API controller, would have used
    ///         Attribute routing).
    ///     </para>
    /// </summary>
    //[Area("Diagnostics")]
    //[Route("views/diagnostics/[controller]")]
    public class DescribeTypesController : Controller
    {
        private readonly INetClassPlantUmlDiagramService _netClassPlantUmlDiagramService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DescribeTypesController" /> class.
        /// </summary>
        /// <param name="netClassPlantUmlDiagramService">The net class plant uml diagram service.</param>
        public DescribeTypesController(INetClassPlantUmlDiagramService netClassPlantUmlDiagramService)
        {
            _netClassPlantUmlDiagramService = netClassPlantUmlDiagramService;
        }


        [AcceptVerbs("GET")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public IActionResult Index(string id, string type = null)
        {
            var results =
                _netClassPlantUmlDiagramService.Document(id, "https://localhost:5001/describetypes/get?id={0}");


            ViewBag.Assembly = results.Title;
            ViewBag.FullName = id;
            ViewBag.PlantUmlText = results.Response.DiagramText;
            ViewBag.svg = results.Response.DiagramSvg;

            return View("~/Views/Ha/Index.cshtml");
        }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}