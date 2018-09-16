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
            var items = await adventureService.getOngoingAdventuresAsync();

            var model = new AdventureViewModel() {
                adventures = items
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAventure(Adventure adv) {
            if (!ModelState.IsValid) {
                return RedirectToAction("Index");
            }

            var success = await adventureService.AddAdventure(adv);
            if (!success) return BadRequest(new {error = "not adding the adventure"});
            return RedirectToAction("Index");
        }
    }
}