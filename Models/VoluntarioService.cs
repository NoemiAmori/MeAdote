using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Meadote.Models
{
    public class VoluntarioService
    {
        public void Inserir (Voluntario voluntario)
        {
            using (MeadoteContext mc = new MeadoteContext())
            {
                mc.Voluntarios.Add(voluntario);
                mc.SaveChanges();
            }
        }

        public void Atualizar (Voluntario voluntario)
        {
            using (MeadoteContext mc = new MeadoteContext())
            {
                Voluntario v = mc.Voluntarios.Find(voluntario.Id);
                v.Nome = voluntario.Nome;
                v.Email = voluntario.Email;
                v.Telefone = voluntario.Telefone;
                v.DataNascimento = voluntario.DataNascimento;
                v.Sexo = voluntario.Sexo;
                
                mc.SaveChanges();
            }
        }

        public ICollection<Voluntario> ListarTodos (FiltrosVoluntario filtro)
        {
            using (MeadoteContext mc = new MeadoteContext())
            {
                IQueryable<Voluntario> query;

                if (filtro != null)
                {
                    switch (filtro.TipoFiltro)
                    {
                        case "Nome":
                            query = mc.Voluntarios.Where(v => v.Nome.Contains(filtro.Filtro));
                        break;

                        case "Sexo":
                            query = mc.Voluntarios.Where(v => v.Sexo.Contains(filtro.Filtro));
                        break;

                        default:
                            query = mc.Voluntarios;
                        break;
                    }
                }
                else
                {
                    query = mc.Voluntarios;
                }
                return query.OrderBy(v => v.Nome).ToList();
            }
        }

        public Voluntario ObterPorId (int id)
        {
            using (MeadoteContext mc = new MeadoteContext())
            {
                return mc.Voluntarios.Find(id);
            }
        }
    }
}
