using Crud.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.API.DataContext.Maps
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            //Chave primaria
            builder.HasKey(x => x.Id);

            //Propriedades
            builder.Property(x=>x.CnpjCpf).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Idade).IsRequired().HasMaxLength(3);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(150);
            builder.Property(x => x.TipoPessoa).IsRequired().HasMaxLength(20);

            //Tabela e mapeamento de coluna
            builder.ToTable("Cliente");
        }
    }
}
