using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Meadote.Models
{
    public class FaleService
    {
        public void Inserir (Fale f)
        {
            using (MeadoteContext mc = new MeadoteContext())
            {
                mc.Fales.Add(f);
                mc.SaveChanges();
            }
        }

        public void Atualizar (Fale f)
        {
            using (MeadoteContext mc = new MeadoteContext())
            {
                Fale fale = mc.Fales.Find(f.Id);
                fale.Nome = f.Nome;
                fale.Email = f.Email;
                fale.Mensagem = f.Mensagem;

                mc.SaveChanges();
            }
        }

        public ICollection<Fale> ListarTodos(FiltrosFale filtro =null)
        {
            using (MeadoteContext mc = new MeadoteContext())
            {
                IQueryable<Fale> query;

                if (filtro != null)
                {
                    switch (filtro.TipoFiltro)
                    {
                        case "Nome":
                            query = mc.Fales.Where(f => f.Nome.Contains(filtro.Filtro));
                        break;

                        default:
                            query = mc.Fales;
                        break;
                    }
                }
                else
                {
                    query = mc.Fales;
                }

                return query.OrderBy(f => f.Nome).ToList();
            }
        }

        public Fale ObterPorId (int id)
        {
            using (MeadoteContext mc = new MeadoteContext())
            {
                return mc.Fales.Find(id);
            }
        }
    }
}
