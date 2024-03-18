using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNet_ProjetoClix.Models;
using AspNet_ProjetoClix.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNet_ProjetoClix.Controllers;

public class C1Controller : Controller
{

    public readonly ApplicationDbContext _context;

    public C1Controller(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Clientes = await ListarClientes(0); 

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(int idCliente)
    {
        ViewBag.Clientes = await ListarClientes(idCliente); 
        ViewBag.ListaItems = await BuscarItensCliente(idCliente);

        return View();
    }

    public async Task<SelectList> ListarClientes(int selected)
    {
        var listaClientes = new SelectList(await BuscarClientes(), "Id", "NomeCliente");

        if (selected != 0)
        {
            foreach (var cliente in listaClientes)
            {
                if(Convert.ToInt16(cliente.Value) == selected){
                    cliente.Selected = true;
                }
            }
        }

        return listaClientes; 
    }

    public async Task<List<Cliente>> BuscarClientes()
    {
        return await _context.Clientes.ToListAsync(); 
    }

    public async Task<List<Item>> BuscarItensCliente(int idCliente)
    {
        return await _context.Items.Where(e => e.ClienteId == idCliente)
            .ToListAsync();
    }
}
