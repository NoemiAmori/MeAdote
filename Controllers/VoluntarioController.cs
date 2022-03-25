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

        [HttpPost]

        public IActionResult Cadastro (Voluntario v)
        {
            VoluntarioService voluntarioService = new VoluntarioService ();

            if (v.Id == 0)
            {
                voluntarioService.Inserir(v);
            }
            else
            {
                voluntarioService.Atualizar(v);
            }

            return RedirectToAction ("Listagem");
        }

        public IActionResult Listagem (string tipoFiltro, string filtro)
        {
            FiltrosVoluntario objFiltro = null;
            if (!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosVoluntario();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }
            VoluntarioService voluntarioService = new VoluntarioService();
            return View (voluntarioService.ListarTodos(objFiltro));
        }

        public IActionResult Edicao (int id)
        {
            VoluntarioService vs = new VoluntarioService();
            Voluntario v = vs.ObterPorId(id);
            return View (v);
        }

        public IActionResult Excluir (int id)
        {
            VoluntarioService vs = new VoluntarioService();
            Voluntario v = vs.ObterPorId(id);

            return View (v);
        }
    }
}
