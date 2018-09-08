using System;
using System.Threading.Tasks;
using aboutRPGs.Models;
using aboutRPGs.Services;
using Microsoft.AspNetCore.Mvc;

namespace aboutRPGs.Controllers {
    public class AdventureController : Controller {
        private readonly IAdventureService adventureService;

        public AdventureController(IAdventureService service)
        {
            adventureService = service;
        }
        public async Task<IActionResult> Index() {
            var items = await adventureService.getAdventuresAsync();

            var model = new AdventureViewModel() {
                adventures = items
            };

            return View(model);
        }
    }
}