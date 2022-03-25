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
    public class VoluntarioController : Controller
    {
        public IActionResult Cadastro()
        {
            
            return View();
        }
        //editar
        public IActionResult Editar(int Id)
        {
            VoluntarioRepository vr = new VoluntarioRepository();
            Voluntario volEncontrado = vr.BuscarPorId(Id);
            return View(volEncontrado);
        }
        [HttpPost]
        public IActionResult Editar(Voluntario vol)
        {
            VoluntarioRepository vr = new VoluntarioRepository();
            vr.Editar(vol);
            return RedirectToAction("Listagem","Voluntario");
        }

        //excluir
        public IActionResult Excluir(int Id)
        {
            VoluntarioRepository vr = new VoluntarioRepository();
            Voluntario volEncontrado = vr.BuscarPorId(Id);
            vr.Excluir(volEncontrado);//metodo excluir recebe objeto
            return RedirectToAction ("Listagem","Voluntario");
        }
             
        [HttpPost]
        public IActionResult Cadastro(Voluntario vol)
        {
            VoluntarioRepository vr = new VoluntarioRepository();
            vr.Cadastrar(vol);
            return RedirectToAction("Listagem","Voluntario");
        }
        
        public IActionResult Listagem()
        {
            VoluntarioRepository vr = new VoluntarioRepository();
            List<Voluntario> Lista = vr.Listar();
            return View(Lista);
        }
    }
}
