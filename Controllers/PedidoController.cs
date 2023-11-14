using Microsoft.AspNetCore.Mvc;
using Aula29MVCDB.Models;

namespace Aula29MVCDB.Controllers;

public class PedidoController : Controller
{
    private readonly MvcDBContext _context;

    public PedidoController(MvcDBContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {

        return View(_context.Pedidos);
    }

    public IActionResult Show(int pedidoid)
    {
        Pedido? pedido =_context.Pedidos.Find(pedidoid);

        if(pedido == null)
        {
            return NotFound();
        }
        return View(pedido);
    }

    public IActionResult Create(){
                
        return View();
    }

    public IActionResult CreateResult(int pedidoid, int empregadoid, string datapedido, string peso, int codtransportadora, int pedidoclienteid)
    {
        if(_context.Pedidos.Find(pedidoid) == null)
        {
            _context.Pedidos.Add(new Pedido(pedidoid, empregadoid, datapedido, peso, codtransportadora, pedidoclienteid));
            _context.SaveChanges();
            return RedirectToAction("Create");
        }
        else
        {
           return Content("Já existe um pedido com esse id");
        }
       
    }

    public IActionResult Delete(int pedidoid){
        _context.Pedidos.Remove(_context.Pedidos.Find(pedidoid));
        _context.SaveChanges();
        return View();
    }

    public IActionResult Update(int pedidoid)
    {
        Pedido pedido = _context.Pedidos.Find(pedidoid);
        if(pedido == null)
        {
            return Content("Esse pedido não existe!");
        }
        else
        {
           return View(pedido);
        }
    }

    public IActionResult UpdateResult(int pedidoid, int empregadoid, string datapedido, string peso, int codtransportadora, int pedidoclienteid)
    {
        Pedido pedido = _context.Pedidos.Find(pedidoid);

        pedido.PedidoId             = pedidoid;
        pedido.EmpregadoId          = empregadoid;
        pedido.DataPedido           = datapedido;
        pedido.Peso                 = peso;
        pedido.CodTransportadora    = codtransportadora;
        pedido.PedidoClienteId      = pedidoclienteid;
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    
}