using Microsoft.AspNetCore.Mvc;
using NotificationFeatureProject.Models;
using NotificationFeatureProject.Repositories.Implementaions;
using NotificationFeatureProject.Repositories.Interfaces;

namespace NotificationFeatureProject.Controllers;

public class PetsController : Controller
{
    private readonly IPetRepository _petRepository;
    public PetsController(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public IActionResult Index()
    {
        var pets = _petRepository.GetAllPets();
        return View(pets);
    }

    public IActionResult Details(int id)
    {
        var pet = _petRepository.GetById(id);
        return View(pet);
    }

    [HttpGet]
    public IActionResult New()
    {
        ViewBag.IsEditMode = "false";
        return View(new Pet());
    }

    [HttpPost]
    public IActionResult New(Pet pet, string IsEditMode)
    {
        if (IsEditMode.Equals("true"))
            _petRepository.Edit(pet);
        else
            _petRepository.Create(pet);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        ViewBag.IsEditMode = "true";
        return View(nameof(New), _petRepository.GetById(id));
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _petRepository.Delete(id);
        return Json(new { success = true, message = "Deleted successfully" });
    }
}