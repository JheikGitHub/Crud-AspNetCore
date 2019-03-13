using Crud.API.DataContext;
using Crud.API.Models;
using Crud.API.Models.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.API.Repositorio
{
    public class ClienteRepositorio : IClinteRepositorio
    {
        private CrudContext _context;

        public ClienteRepositorio(CrudContext context)
        {
            _context = context;
        }

        public void Adiciona(Cliente cliente)
        {
            cliente.ValidaCPF(cliente.CnpjCpf);
            cliente.ValidaCliente();

            _context.Add(cliente);
            _context.SaveChanges();
        }

        public void Atualizar(Cliente cliente)
        {
            cliente.ValidaCPF(cliente.CnpjCpf);
            cliente.ValidaCliente();

            _context.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public Cliente BuscaPorCPF(string CnpjCpf)
        {
            return _context.Clientes.Where(c => c.CnpjCpf == CnpjCpf).FirstOrDefault();
        }

        public Cliente BuscaPorCodigo(int codigo)
        {
            return _context.Clientes.Where(c => c.Id == codigo).FirstOrDefault();
        }

        public void Excluir(Cliente cliente)
        {
            cliente.ValidaCliente();

            _context.Remove(cliente);
            _context.SaveChanges();
        }
        
        public IEnumerable<Cliente> BuscaTodos()
        {
            return _context.Clientes.ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
