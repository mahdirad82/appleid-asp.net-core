using AppleAccounts.Data.Enums;
using AppleAccounts.Data.Services;
using AppleAccounts.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppleAccounts.Controllers;

public class AppleIdController(IAppleIdService service) : Controller
{
    private readonly IAppleIdService _service = service;

    public async Task<IActionResult> Index(string? status, string? expired, string? searchPhrase, string? order)
    {
        bool expiredIsOn = false;

        if (expired is not null) expiredIsOn = expired.Equals("on");
        ViewBag.status = "-- Status --";
        ViewBag.statusVal = "";
        ViewBag.expired = expiredIsOn;
        ViewBag.search = string.Empty;

        if (searchPhrase is not null) ViewBag.search = searchPhrase;
        if (int.TryParse(status, out var id))
        {
            ViewBag.status = (AppleIdStatus)id;
            ViewBag.statusVal = id.ToString();
        }

        return View(await _service.GetAppleIds(expiredIsOn, status, searchPhrase, order));
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
            return RedirectToAction(nameof(Index)); 
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

