using AppleAccounts.Data.Services;
using AppleAccounts.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppleAccounts.Controllers;

public class AppleIdController(IAppleIdService service) : Controller
{
    private readonly IAppleIdService _service = service;

    public async Task<IActionResult> Index(string? status, string? expired, string? searchPhrase)
    {
        bool expiredIsOn = false;

        if (expired is not null) expiredIsOn = expired.Equals("on");

        ViewBag.expired = expiredIsOn;
        ViewBag.search = string.Empty;

        if (searchPhrase is not null) ViewBag.search = searchPhrase;

        return View(await _service.GetAppleIds(expiredIsOn, status, searchPhrase));
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

            return RedirectToAction(nameof(Index));
        }
        return View(appleId);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var appleIdDetails = await _service.GetAppleId(id);
        if (appleIdDetails == null) return View("NotFound");
        return View(appleIdDetails);
    }


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

