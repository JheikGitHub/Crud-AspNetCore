using Crud.API.Validation;
using System;

namespace Crud.API.Models
{
    public class Cliente
    {

        #region Construtores
        protected Cliente()
        {

        }

        public Cliente(string nome,string idade,string endereco)
        {
            Nome = nome;
            Idade = idade;
            Endereco = endereco;
        }
        #endregion


        #region Propriedades
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Idade { get; set; }

        public string CnpjCpf { get; set; }

        public string Endereco { get; set; }

        public string TipoPessoa { get; set; }

        #endregion


        #region Metodos

        public void ValidaCliente()
        {
            Validacoes.AssertArgumentNotEmpty(Nome,"Nome inválido");
            Validacoes.AssertArgumentNotEmpty(Idade, "Idade inválido");
            Validacoes.AssertArgumentNotEmpty(Endereco, "Idade inválido");
        }

        public void ValidaCPF(string cpf)
        {
            Validacoes.AssertArgumentNotEmpty(cpf, "CPF/CNPJ Inválido");

            bool Cpfvalido = ValidaCPFCNPJ.IsCpf(cpf);

            if (Cpfvalido)
            {
                CnpjCpf = cpf;
                TipoPessoa = "Pessoa Física";
            }
                

            bool cnpjValido = ValidaCPFCNPJ.IsCnpj(cpf);

            if (cnpjValido)
            {
                CnpjCpf = cpf;
                TipoPessoa = "Pessoa Jurídica";
            }
                
            
        }

        #endregion
    }
}
