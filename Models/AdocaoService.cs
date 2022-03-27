using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Meadote.Models
{
    public class AdocaoService
    {
        public void Inserir (Adocao a)
        {
            using (MeadoteContext mc = new MeadoteContext())
            {
                mc.Adocaos.Add(a);
                mc.SaveChanges();
            }
        }

        public void Atualizar (Adocao a)
        {
            using (MeadoteContext mc = new MeadoteContext())
            {
                Adocao adocao = mc.Adocaos.Find(a.Id);
                adocao.Nome = a.Nome;
                adocao.Email = a.Email;
                adocao.Telefone = a.Telefone;
                adocao.DataNascimento = a.DataNascimento;
                adocao.Endereco = a.Endereco;
                adocao.Cidade = a.Cidade;
                adocao.Estado = a.Estado;
                adocao.Cep = a.Cep;
                adocao.Animal = a.Animal;

                mc.SaveChanges();
            }
        }

        public ICollection<Adocao> ListarTodos (FiltrosAdocao filtro)
        {
            using (MeadoteContext mc = new MeadoteContext())
            {
                IQueryable<Adocao> query;

                if (filtro != null)
                {
                    switch (filtro.TipoFiltro)
                    {
                        case "Nome":
                            query = mc.Adocaos.Where(a => a.Nome.ToLower().Contains(filtro.Filtro.ToLower()));
                        break;

                        case "Animal":
                            query = mc.Adocaos.Where(a => a.Animal.ToLower().Contains(filtro.Filtro.ToLower()));
                        break;

                        default:
                            query = mc.Adocaos;
                        break;
                    }
                }
                else
                {
                    query = mc.Adocaos;
                }

                return query.OrderBy (a => a.Animal).ToList();
            }
        }

        public Adocao ObterPorId (int Id)
        {
            using (MeadoteContext mc = new MeadoteContext())
            {
                return mc.Adocaos.Find(Id);
            }
        }

        public Adocao ListarId (int Id)
        {
            using (MeadoteContext mc = new MeadoteContext())
            {
                return (mc.Adocaos.Find(Id));
            }
        }

        public void Deletar (Adocao a)
        {
            using (MeadoteContext mc = new MeadoteContext())
            {
                mc.Remove(a);
                mc.SaveChanges();
            }
        }
    }
}
