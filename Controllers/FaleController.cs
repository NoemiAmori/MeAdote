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

        [HttpPost]
        public IActionResult Cadastro (Fale f)
        {
            FaleService faleService = new FaleService();

            if(f.Id == 0)
            {
                faleService.Inserir(f);
            }
            else
            {
                faleService.Atualizar(f);
            }
            return RedirectToAction("Listagem");
        }

        public IActionResult Listagem (string tipoFiltro, string filtro)
        {
            FiltrosFale objFiltro = null;
            if (!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosFale();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }
            FaleService faleService = new FaleService();
            return View (faleService.ListarTodos(objFiltro));
        }

        public IActionResult Editar (int id)
        {
            FaleService faleService = new FaleService();
            Fale f = faleService.ObterPorId(id);
            return View(f);
        }
    }
}
