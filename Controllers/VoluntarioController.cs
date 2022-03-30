using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Meadote.Models;


namespace Meadote.Controllers
{
    public class VoluntarioController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public VoluntarioController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Cadastro(Voluntario v)
        {
            try
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

                return Json(new { status = "Cadastro Realizado com sucesso" });
                
            }
            catch (Exception e)
            {
                _logger.LogError("Erro " + e.Message);
                return Json(new { status = "Erro", mensagem = "Falha ao gravar" });
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
