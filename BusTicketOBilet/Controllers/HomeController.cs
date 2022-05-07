using BusTicketOBilet.Models;
using BusTicketOBilet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicketOBilet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITicketService _service;
        public HomeController(ITicketService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IndexVM locationResponse = _service.GetLocation(new SessionModel()
            {
                IpAddress = HttpContext.Connection.RemoteIpAddress.ToString(),
                Port = HttpContext.Connection.RemotePort.ToString(),
                Type = 7,
                BrowserName = "Chrome",
                BrowserVersion = "103.0"
            });


            if (String.IsNullOrEmpty(locationResponse.UserMessage) && String.IsNullOrEmpty(locationResponse.ErrorMessage))
            {
                return View(locationResponse);
            }
            else
            {
                TempData["Message"] = locationResponse.UserMessage;
                TempData["Message"] += locationResponse.ErrorMessage;

                return RedirectToAction("Index");

            }


        }


        [HttpPost]
        public IActionResult Journey(IndexVM model)
        {

            JourneyVM journeyResponse = _service.GetJourney(model);

            if (String.IsNullOrEmpty(journeyResponse.UserMessage) && String.IsNullOrEmpty(journeyResponse.ErrorMessage))
            {
                return View(journeyResponse);
            }
            else
            {
                TempData["Message"] = journeyResponse.UserMessage;
                TempData["Message"] += journeyResponse.ErrorMessage;

                return RedirectToAction("Index");
            }

        }

    }
}
