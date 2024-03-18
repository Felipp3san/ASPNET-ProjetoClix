using AspNet_ProjetoClix.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNet_ProjetoClix.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNet_ProjetoClix.Controllers;

public class C2Controller : Controller
{

    public readonly ApplicationDbContext _context;
    public readonly ILogger<C2Controller> _logger;

    public C2Controller(ApplicationDbContext context, ILogger<C2Controller> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string txtNomeCliente){
        
        ViewBag.NomesClientes = await ListarClientes(txtNomeCliente);

        return View();
    }

    async Task<SelectList> ListarClientes(string nomeCliente)
    {
        var listaClientes = new SelectList(await BuscarClientes(nomeCliente), "Id", "NomeCliente");

        return listaClientes;
    }

    async Task<List<Cliente>> BuscarClientes(string nomeCliente)
    {
        return await _context.Clientes.Where(e => e.NomeCliente.Contains(nomeCliente))
            .ToListAsync();
    }
}