using AspNet_ProjetoClix.Data;
using AspNet_ProjetoClix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNet_ProjetoClix.Controllers;

public class ClienteCustomController : Controller
{
    private readonly ApplicationDbContext _context;

    public ClienteCustomController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Clientes.ToListAsync());
    }

    public async Task<IActionResult> Adicionar()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar(string nomeCliente, string referenciaCliente)
    {
        var cliente = new Cliente
        {
            NomeCliente = nomeCliente,
            Referencia = referenciaCliente
        };

        _context.Add(cliente);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}