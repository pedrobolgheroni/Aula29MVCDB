using Microsoft.AspNetCore.Mvc;
using Aula29MVCDB.Models;
namespace Aula29MVCDB.Controllers;
public class ClienteController : Controller
{
    private readonly MvcDBContext _context;

    public ClienteController(MvcDBContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Clientes);
    }

    public IActionResult Show(int clienteid)
    {
        Cliente? cliente =_context.Clientes.Find(clienteid);

        if(cliente == null)
        {
            return NotFound();
        }
        return View(cliente);
    }

    public IActionResult Create()
    {      
        return View();
    }

    public IActionResult CreateResult(int clienteid, string endereco, string cidade, string regiao, string codigopostal, string pais, string telefone)
    {
        if(_context.Clientes.Find(clienteid) == null)
        {
            _context.Clientes.Add(new Cliente(clienteid, endereco, cidade, regiao, codigopostal, pais, telefone));
            _context.SaveChanges();
            return RedirectToAction("Create");
        }
        else
        {
           return Content("Já existe um cliente com esse id.");
        }
       
    }

    public IActionResult Delete(int clienteid)
    {
        _context.Clientes.Remove(_context.Clientes.Find(clienteid));
        _context.SaveChanges();
        return View();
    }

    public IActionResult Update(int clienteid)
    {
        Cliente cliente = _context.Clientes.Find(clienteid);
        if(cliente == null)
        {
            return Content("Esse cliente não existe.");
        }
        else
        {
           return View(cliente);
        }
    }

    public IActionResult UpdateResult(int clienteid, string endereco, string cidade, string regiao, string codigopostal, string pais, string telefone)
    {
        Cliente cliente = _context.Clientes.Find(clienteid);

        cliente.Endereco        = endereco;
        cliente.Cidade          = cidade;
        cliente.Endereco        = endereco;
        cliente.Regiao          = regiao;
        cliente.CodigoPostal    = codigopostal;
        cliente.Pais            = pais;
        cliente.Telefone        = telefone;
        _context.SaveChanges();
        return RedirectToAction("Index");
    }   
}
