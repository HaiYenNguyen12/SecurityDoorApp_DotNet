using Microsoft.AspNetCore.Mvc;
using Security_Door_App.Data.Enums;
using Security_Door_App.Logic.DTOs;
using Security_Door_App.Logic.Interface;
using Security_Door_App.MVC.Models;
using System;
using System.Diagnostics;

namespace Security_Door_App.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICard _cardRepo;
        private readonly IDoorReader _drRepo;
        private readonly IDoorAction _actionRepo;

        public HomeController(ILogger<HomeController> logger,ICard card, IDoorReader rd, IDoorAction actionRepo)
        {
            _logger = logger;
            _cardRepo = card;
            _drRepo = rd;
            _actionRepo = actionRepo;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ViewResult Form()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Result(FormModel request)
        {
            var cardVM = await _cardRepo.GetCardByUniqueNumber(request.CardUniqueNumber);
            if (cardVM == null)
            {
                ViewBag.Message = "Not Found Card!!";
                return View();
            }
            var DoorReaderVM = await _drRepo.GetDoorReaderBySerialNumber(request.DoorReaderSerialNumber);
            
            if (DoorReaderVM == null)
            {
                ViewBag.Message = "Not Found Door!!";
                return View();
            }
            var doorActionStatus = "success";

            if (cardVM.CardStatus == "locked" || cardVM.CardStatus == "unknow")
            {
                doorActionStatus = "error";
                ViewBag.ErrorCard = "Card invalid. Please check your card!!!";
            }

            if (DoorReaderVM.DoorStatus != "active")
            {
                ViewBag.ErrorDoor = "Door is not active!!!";
                doorActionStatus = "error";
            }
            Level doorLevel, cardLevel;
            Enum.TryParse(DoorReaderVM.DoorLevel, out doorLevel);
            Enum.TryParse(cardVM.CardLevel, out cardLevel);
            if (cardLevel < doorLevel)
            {
                ViewBag.ErrorLevel = "You don't have permission to access through door!!!";
                doorActionStatus = "denied";
            }

            var doorActionDto = new CreateDoorActionDTO
            {
                IdCard = cardVM.Id,
                IdDoorReader = DoorReaderVM.Id,
                Status = doorActionStatus,
                TimeStamp = DateTime.Now,
            };
            await _actionRepo.CreateDoorActionAsync(doorActionDto);
            ViewBag.Message = "Record!!";
            return View();
          
        }
            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}