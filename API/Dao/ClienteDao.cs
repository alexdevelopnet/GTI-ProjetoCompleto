using API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API.Dao
{
    public class ClienteDao
    {
        public void Adiciona(Cliente produto)
        {
            using (var context = new BancoContext())
            {
                context.Clientes.Add(produto);
                context.SaveChanges();
            }
        }

        public IEnumerable<Cliente> Lista()
        {
            using (var contexto = new BancoContext())
            {
                return contexto.Clientes.ToList();
            }
        }

        public Cliente BuscaPorId(int id)
        {
            using (var contexto = new BancoContext())
            {
                return contexto.Clientes
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }
        }


        public void Remover(int id)
        {
            Cliente cliente = BuscaPorId(id);
            using (var contexto = new BancoContext())
            {
                contexto.Entry(cliente).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public void Atualiza(int id)
        {
            Cliente cliente = BuscaPorId(id);

            using (var contexto = new BancoContext())
            {
                contexto.Entry(cliente).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}