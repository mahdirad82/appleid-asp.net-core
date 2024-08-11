using AppleAccounts.Data.Services;
using AppleAccounts.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppleAccounts.Controllers
{
    public class AppleIdController(IAppleIdService service) : Controller
    {
        private readonly IAppleIdService _service = service;

        public async Task<IActionResult> Index(string status, string expired)
        {
            bool expiredIsOn = !(string.IsNullOrEmpty(expired) || expired.Equals("off"));

            if (string.IsNullOrEmpty(status))
                return View(await _service.GetAppleIds(expiredIsOn));

            return View(await _service.GetAppleIds(int.Parse(status), expiredIsOn));
        }

        public async Task<IActionResult> Details(int id)
        {
            var appleIdDetails = await _service.GetAppleId(id);
            ViewData["Message"] = "Apple id does not exist";
            if (appleIdDetails == null) return View("NotFound");
            return View(appleIdDetails);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: AppleId/Create  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppleId appleId)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(appleId);

                return RedirectToAction(nameof(Index)); // Assumes you have an Index action  
            }
            return View(appleId);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var appleIdDetails = await _service.GetAppleId(id);
            if (appleIdDetails == null) return View("NotFound");
            return View(appleIdDetails);
        }

        // POST: AppleId/Create  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AppleId appleId)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, appleId);
                return RedirectToAction(nameof(Index)); // Assumes you have an Index action  
            }
            return View(appleId);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var appleIdDetails = await _service.GetAppleId(id);
            if (appleIdDetails == null) return View("NotFound");
            return View(appleIdDetails);
        }

        // POST: AppleId/Create  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appleIdDetails = await _service.GetAppleId(id);
            if (appleIdDetails == null)
                return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }

}