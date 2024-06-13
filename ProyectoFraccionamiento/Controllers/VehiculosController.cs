
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFraccionamiento;
using ProyectoFraccionamiento.Controllers;
using ProyectoFraccionamiento.Entities;
using ProyectoFraccionamiento.Models;
public class VehiculosController : Controller
{
    private readonly ApplicationDBContext _context;

    public VehiculosController(ApplicationDBContext context)
    {
        _context = context;
    }

    public IActionResult VehiculosList()
    {
        // VehiculoEntity vehiculo = new VehiculoEntity();
        // vehiculo.Modelo="Mazda 3";
        // vehiculo.Marca="Mazda";
        // vehiculo.Owner="Jaime Nuñez";
        // vehiculo.Placas="E8ST4S7";
        // vehiculo.Direccion="La Paloma #123";
        // this._context.Vehiculos.Add(vehiculo);
        // this._context.SaveChanges();

        List<VehiculoModel> list =_context.Vehiculos.Select(v => new VehiculoModel
        {
            Id = v.Id,
            Owner=v.Owner,
            Marca=v.Marca,
            Modelo=v.Modelo,
            Direccion=v.Direccion,
            Placas=v.Placas

        }).ToList();

        return View(list);
    }

    public IActionResult EditVehiculos()
    {
        return View();
    }

    public IActionResult DeleteVehiculos()
    {
        return View();
    }

    public IActionResult AddVehiculos()
    {
        return View();
    }
}

