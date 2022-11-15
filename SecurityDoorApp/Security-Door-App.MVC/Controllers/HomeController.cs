using Microsoft.AspNetCore.Mvc;
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
            var IdCard = await _cardRepo.GetCardByUniqueNumber(request.CardUniqueNumber);
            var IdDoorReader = await _drRepo.GetDoorReaderBySerialNumber(request.DoorReaderSerialNumber);
            if (IdCard == -1)
            {
                ViewBag.Message = "Not Found Card!!";
                return View();
            }
            if (IdDoorReader == -1)
            {
                ViewBag.Message = "Not Found Door!!";
                return View();
            }


            var doorActionDto = new CreateDoorActionDTO
            {
                IdCard = IdCard,
                IdDoorReader = IdDoorReader,
                Status = "Success",
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