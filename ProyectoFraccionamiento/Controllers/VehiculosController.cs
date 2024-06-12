
using Microsoft.AspNetCore.Mvc;

public class VehiculosController : Controller
{
    public IActionResult VehiculosList()
    {
        return View();
    }
}