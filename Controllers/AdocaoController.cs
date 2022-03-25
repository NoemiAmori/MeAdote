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
        public IActionResult Cadastro (Adocao a)
        {
            AdocaoService adocaoService = new AdocaoService();
            
            if (a.Id == 0)
            {
                adocaoService.Inserir(a);
            }
            else
            {
                adocaoService.Atualizar(a);
            }

            return RedirectToAction ("Listagem");
        }

        public IActionResult Listagem (string tipoFiltro, string filtro)
        {
            FiltrosAdocao objFiltro = null;
            if (!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosAdocao();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }
            AdocaoService adocaoService = new AdocaoService();
            return View (adocaoService.ListarTodos(objFiltro));
        }

        //editar
        public IActionResult Editar(int id)
        {
            AdocaoService adocaoService = new AdocaoService();
            Adocao a = adocaoService.ObterPorId(id);
            return View(a);
        }  

        public IActionResult Excluir (int id)
        {
            AdocaoService asv = new AdocaoService();
            Adocao a = asv.ObterPorId(id);

            return View (a);
        }
    }
}
