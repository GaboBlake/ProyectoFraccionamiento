
using Microsoft.AspNetCore.Mvc;
using ProyectoFraccionamiento;
using ProyectoFraccionamiento.Models;

public class SocialAreaController : Controller
{
    private readonly ApplicationDBContext _context;

    public SocialAreaController (ApplicationDBContext context)
    {
        _context = context;
    }

    public IActionResult SocialAreaList()
    {
        List<SocialAreaModel> list =_context.AreasSociales.Select(x => new SocialAreaModel
        {
            Id = x.Id,
            Name=x.Name,
            Apellido=x.Apellido,
            FechaReserva=x.FechaReserva
        }).ToList();

        return View(list);
    }
}