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
    public class AdocaoController : Controller
    {
        public IActionResult Pets()
        {
            
            return View();
        }
        public IActionResult Cadastro()
        {
            
            return View();
        }
        //editar
        public IActionResult Editar(int Id)
        {
            AdocaoRepository ar = new AdocaoRepository();
            Adocao adEncontrado = ar.BuscarPorId(Id);
            return View(adEncontrado);
        }
        [HttpPost]
        public IActionResult Editar(Adocao ad)
        {
            AdocaoRepository ar = new AdocaoRepository();
            ar.Editar(ad);
            return RedirectToAction("Listagem","Adocao");
        }

        //excluir
        public IActionResult Excluir(int Id)
        {
            AdocaoRepository ar = new AdocaoRepository();
            Adocao adEncontrdo = ar.BuscarPorId(Id);
            ar.Excluir(adEncontrdo);//metodo excluir recebe objeto
            return RedirectToAction ("Listagem","Adocao");
        }
             
        [HttpPost]
        public IActionResult Cadastro(Adocao ad)
        {
            AdocaoRepository ar = new AdocaoRepository();
            ar.Cadastrar(ad);
            return RedirectToAction("Listagem","Adocao");
        }
        public IActionResult Listagem()
        {
            AdocaoRepository ar = new AdocaoRepository();
            List<Adocao> Lista = ar.Listar();
            return View(Lista);
        }
    }
}
