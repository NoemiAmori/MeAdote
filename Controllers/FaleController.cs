using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Cadastro(Fale f)
        {
            if (!string.IsNullOrEmpty(f.Nome) && !string.IsNullOrEmpty(f.Email))
            {
                FaleService fs = new FaleService();

                if (f.Id == 0)
                {
                    fs.Inserir(f);
                }
                else
                {
                    fs.Atualizar(f);
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
            FiltrosFale objFiltro = null;
            if (!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosFale();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }

            ViewData["falePorPagina"] = (string.IsNullOrEmpty(itensPorPagina) ? 10 : int.Parse(itensPorPagina));
            ViewData["PaginaAtual"] = (PaginaAtual != 0 ? PaginaAtual : 1);

            FaleService faleService = new FaleService();
            return View(faleService.ListarTodos(objFiltro));
        }

        public IActionResult Editar(int id)
        {
            FaleService faleService = new FaleService();
            Fale f = faleService.ObterPorId(id);
            return View(f);
        }
    }
}
