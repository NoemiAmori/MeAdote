using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Meadote.Models;

namespace Meadote.Controllers
{
    public class FaleController : Controller
    {
        public IActionResult Cadastro()
        {
            
            return View();
        }
        //editar
        public IActionResult Editar(int Id)
        {
            FaleRepository fr = new FaleRepository();
            Fale flEncontrado = fr.BuscarPorId(Id);
            return View(flEncontrado);
        }
        [HttpPost]
        public IActionResult Editar(Fale fl)
        {
            FaleRepository fr = new FaleRepository();
            fr.Editar(fl);
            return RedirectToAction("Listagem","Fale");
        }

        //excluir
        public IActionResult Excluir(int Id)
        {
            FaleRepository fr = new FaleRepository();
            Fale flEncontrado = fr.BuscarPorId(Id);
            fr.Excluir(flEncontrado);//metodo excluir recebe objeto
            return RedirectToAction ("Listagem","Fale");
        }
             
        [HttpPost]
        public IActionResult Cadastro(Fale fl)
        {
            FaleRepository fr = new FaleRepository();
            fr.Cadastrar(fl);
            return RedirectToAction("Listagem","Fale");
        }
        
        public IActionResult Listagem()
        {
            FaleRepository fl = new FaleRepository();
            List<Fale> Lista = fl.Listar();
            return View(Lista);
        }
    }
}
