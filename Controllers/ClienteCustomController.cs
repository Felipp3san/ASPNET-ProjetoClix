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

    public async Task<IActionResult> Index(string ordenarPor, string? nomeCliente)
    {
        ViewData["NomeCliente"] = nomeCliente;        

        switch(ordenarPor)
        {
            case "Id":
                ViewBag.ordenarPor = "Id";

                if(nomeCliente != null) 
                    return View(await _context.Clientes.Where(e => e.NomeCliente.Contains(nomeCliente)).OrderBy(e => e.Id).ToListAsync());
                else
                    return View(await _context.Clientes.OrderBy(e => e.Id).ToListAsync());
            case "IdDesc":
                ViewBag.ordenarPor = "IdDesc";

                if(nomeCliente != null) 
                    return View(await _context.Clientes.Where(e => e.NomeCliente.Contains(nomeCliente)).OrderByDescending(e => e.Id).ToListAsync());
                else
                    return View(await _context.Clientes.OrderByDescending(e => e.Id).ToListAsync());
            case "Nome":
                ViewBag.ordenarPor = "Nome";

                if(nomeCliente != null) 
                    return View(await _context.Clientes.Where(e => e.NomeCliente.Contains(nomeCliente)).OrderBy(e => e.NomeCliente).ToListAsync());
                else
                    return View(await _context.Clientes.OrderBy(e => e.NomeCliente).ToListAsync());
            case "NomeDesc":
                ViewBag.ordenarPor = "NomeDesc";

                if(nomeCliente != null) 
                    return View(await _context.Clientes.Where(e => e.NomeCliente.Contains(nomeCliente)).OrderByDescending(e => e.NomeCliente).ToListAsync());
                else
                    return View(await _context.Clientes.OrderByDescending(e => e.NomeCliente).ToListAsync());
            case "Referencia":
                ViewBag.ordenarPor = "Referencia";

                if(nomeCliente != null) 
                    return View(await _context.Clientes.Where(e => e.NomeCliente.Contains(nomeCliente)).OrderBy(e => e.Referencia).ToListAsync());
                else
                    return View(await _context.Clientes.OrderBy(e => e.Referencia).ToListAsync());
            case "ReferenciaDesc":
                ViewBag.ordenarPor = "ReferenciaDesc";

                if(nomeCliente != null) 
                    return View(await _context.Clientes.Where(e => e.NomeCliente.Contains(nomeCliente)).OrderByDescending(e => e.Referencia).ToListAsync());
                else
                    return View(await _context.Clientes.OrderByDescending(e => e.Referencia).ToListAsync());
            default:
                if(nomeCliente != null) 
                    return View(await _context.Clientes.Where(e => e.NomeCliente.Contains(nomeCliente)).ToListAsync());
                else
                    return View(await _context.Clientes.ToListAsync());
        }
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