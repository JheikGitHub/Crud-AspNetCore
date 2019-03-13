using System;
using System.Collections.Generic;

namespace Crud.API.Models.Contratos
{
    public interface IClinteRepositorio : IDisposable
    {
        Cliente BuscaPorCodigo(int codigo);

        Cliente BuscaPorCPF(string CnpjCpf);

        IEnumerable<Cliente> BuscaTodos();

        void Adiciona(Cliente cliente);

        void Atualizar(Cliente cliente);

        void Excluir(Cliente cliente);

    }
}
