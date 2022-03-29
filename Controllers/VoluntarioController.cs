using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Cadastro(Voluntario v)
        {
            if (!string.IsNullOrEmpty(v.Nome) && !string.IsNullOrEmpty(v.Telefone) && !string.IsNullOrEmpty(v.Email))
            {
                VoluntarioService vs = new VoluntarioService();

                if (v.Id == 0)
                {
                    vs.Inserir(v);
                }
                else
                {
                    vs.Atualizar(v);
                }

                return RedirectToAction("Listagem");

            }
            else
            {
                ViewData["Mensagem"] = "Preencha todos os campos";
                return View();
            }
        }

        public IActionResult Listagem(string tipoFiltro, string filtro, string itensPorPagina, int NumDaPagina, int PaginaAtual)
        {
            FiltrosVoluntario objFiltro = null;
            if (!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosVoluntario();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }

            ViewData["voluntariosPorPagina"] = (string.IsNullOrEmpty(itensPorPagina) ? 10 : int.Parse(itensPorPagina));
            ViewData["PaginaAtual"] = (PaginaAtual != 0 ? PaginaAtual : 1);

            VoluntarioService vs = new VoluntarioService();
            return View(vs.ListarTodos(objFiltro));
        }

        public IActionResult Editar(int id)
        {
            VoluntarioService vs = new VoluntarioService();
            Voluntario v = vs.ObterPorId(id);
            return View(v);
        }
    }
}
