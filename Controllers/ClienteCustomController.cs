using AspNet_ProjetoClix.Data;
using AspNet_ProjetoClix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

    public IActionResult Adicionar()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar(Cliente cliente)
    {
        if(!ModelState.IsValid){
            return View(cliente);
        }
        
        _context.Add(cliente);
        await _context.SaveChangesAsync();
        
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Editar(int id)
    {
        return View(await _context.Clientes.FindAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Editar(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Eliminar(int? id)
    {
        return View(await _context.Clientes.FindAsync(id));
    }

    [HttpPost, ActionName("Eliminar")]
    public async Task<IActionResult> EliminarPost(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }
}