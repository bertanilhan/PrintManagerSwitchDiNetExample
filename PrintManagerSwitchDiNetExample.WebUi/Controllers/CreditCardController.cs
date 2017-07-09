using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrintManagerSwitchDiNetExample.Business.Abstract;

namespace PrintManagerSwitchDiNetExample.WebUi.Controllers
{
    public class CreditCardController : Controller
    {
        private readonly ICreditCardService _cardService;

        public CreditCardController(ICreditCardService cardService)
        {
            _cardService = cardService;
        }

        public string Index()
        {
            return _cardService.Pay();
        }
    }
}