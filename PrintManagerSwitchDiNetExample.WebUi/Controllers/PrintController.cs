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
        private readonly ICreditCardService _cardService;

        public PrintController(IPrintService printService, ICreditCardService cardService)
        {
            _printService = printService;
            _cardService = cardService;
        }

        public string Index()
        {
            return _printService.Print();
        }

        public string PrintPay()
        {
            return $"{_cardService.Pay()} and {_printService.Print()}";
        }
    }
}