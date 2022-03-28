using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public IActionResult Cadastro(Adocao a)
        {
            if (!string.IsNullOrEmpty(a.Nome) && !string.IsNullOrEmpty(a.Telefone) && !string.IsNullOrEmpty(a.Animal))
            {
                AdocaoService asv = new AdocaoService();

                if (a.Id == 0)
                {
                    asv.Inserir(a);
                }
                else
                {
                    asv.Atualizar(a);
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
            FiltrosAdocao objFiltro = null;
            if (!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosAdocao();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }

            ViewData["adocoesPorPagina"] = (string.IsNullOrEmpty(itensPorPagina) ? 10 : int.Parse(itensPorPagina));
            ViewData["PaginaAtual"] = (PaginaAtual != 0 ? PaginaAtual : 1);

            AdocaoService asv = new AdocaoService();
            return View(asv.ListarTodos(objFiltro));
        }

        //editar
        public IActionResult Editar(int id)
        {
            AdocaoService asv = new AdocaoService();
            Adocao a = asv.ObterPorId(id);
            return View(a);
        }

        public IActionResult Remover(int Id)
        {
            AdocaoService asv = new AdocaoService();
            Adocao a = asv.ObterPorId(Id);

            return View(a);
        }

        [HttpPost]
        public IActionResult Remover(Adocao a)
        {
            AdocaoService asv = new AdocaoService();
            asv.Deletar(a);

            return RedirectToAction("Listagem");
        }
    }
}

