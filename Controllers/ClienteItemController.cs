using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNet_ProjetoClix.Data;
using AspNet_ProjetoClix.Models;
using AspNet_ProjetoClix.ViewModel;

namespace AspNet_ProjetoClix.Controllers
{
    public class ClienteItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClienteItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? clienteId)
        {
            // Começa carregando a lista apenas com os clientes para exibir na selectlist
            var clientesItems = new ClientesItems(){
                Clientes = new SelectList(await _context.Clientes.ToListAsync(), "Id", "NomeCliente")
            };

            // Caso o cliente tenha sido selecionado, faz um GET dos seus itens e retorna a pagina com a tabela
            if(clienteId != null)
            {
                clientesItems.Items = await _context.Items.Where(e => e.ClienteId == clienteId).ToListAsync();
                clientesItems.Tipos = await _context.Tipos.ToListAsync();

                // O ciclo abaixo serve para manter o cliente selecionado na selectlist
                foreach (var cliente in clientesItems.Clientes)
                {
                    if (cliente.Value == Convert.ToString(clienteId))
                    {
                        cliente.Selected = true;
                    }
                }

                // A ViewBag abaixo serve para transportar o id do cliente para chamar outras páginas
                ViewData["ClienteId"] = clienteId;
            }

            return View(clientesItems);
        }

        public async Task<IActionResult> Adicionar(int clienteId)
        {
            ViewData["ClienteId"] = clienteId;
            ViewData["ListaTipos"] = new SelectList(await _context.Tipos.ToListAsync(), "Id", "Descricao");
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([Bind("Item1", "Item2", "Texto", "ClienteId", "TipoId")] Item item){

            if (ModelState.IsValid)
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", new { clienteId = item.ClienteId});
        }

        public async Task<IActionResult> Editar(int itemId)
        {
            var item = await _context.Items.FindAsync(itemId);

            if (item != null)
            {
                ViewData["ClienteId"] = item.ClienteId;
            }

            ViewData["ListaTipos"] = new SelectList(await _context.Tipos.ToListAsync(), "Id", "Descricao");
            
            return View(item);
        }
        
        [HttpPost]
        public async Task<IActionResult> Editar(Item item)
        {
            if (item != null)
            {
                _context.Items.Update(item);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", new { clienteId = item.ClienteId});
            } 

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Eliminar(int itemId)
        {
            var item = await _context.Items.FindAsync(itemId);

            if(item != null) 
            {
                ViewData["ClienteId"] = item.ClienteId;

                var tipo = await _context.Tipos.FindAsync(item.TipoId);

                if(tipo != null)
                {
                    ViewData["Tipo"] = tipo.Descricao;
                }
            }

            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarPost(int itemId)
        {
            var item = await _context.Items.FindAsync(itemId);

            if(item != null)
            {
                int clienteId = item.ClienteId; 

                _context.Items.Remove(item);
                await _context.SaveChangesAsync(); 
                
                return RedirectToAction("Index", new { clienteId = clienteId});
            }

            return RedirectToAction("Index");
        }
    }
}  