using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrintManagerSwitchDiNetExample.Business.Abstract;

namespace PrintManagerSwitchDiNetExample.WebUi.Controllers
{
    public class PrintController : Controller
    {
        private readonly IPrintService _printService;

        public PrintController(IPrintService printService)
        {
            _printService = printService;
        }

        public string Index()
        {
            return _printService.Print();
        }
    }
}