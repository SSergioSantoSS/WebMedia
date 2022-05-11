using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursoMed.Entities;

namespace WebApiCursoMed.Mappings
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            //NOME DA TABELA NO BANCO
            builder.ToTable("ALUNO");

            //Chave Primaria
            builder.HasKey(a => a.IdAluno);

            //Demais Campos da Tabela
            builder.Property(a => a.IdAluno)
                .HasColumnName("IDALUNO")
                .IsRequired();

            builder.Property(a => a.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(200)               
                .IsRequired();

            builder.Property(a => a.Matricula)
                .HasColumnName("MATRICULA")
                .HasMaxLength(8)
                .IsRequired();


            builder.Property(c => c.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100)
                .IsRequired();


            builder.Property(c => c.Senha)
                .HasColumnName("SENHA")
                .HasMaxLength(50)
                .IsRequired();

            //Mapeamento de índices
            //Definindo campos únicos (UNIQUE) na tabela

            //MATRICULA como campo UNIQUE
            builder.HasIndex(a => a.Matricula)
                .IsUnique(true);



        }
    }
}
//builder.Property(p => p.IdCliente)
//            .HasColumnName("IDCLIENTE")
//            .IsRequired();





////Mapeamento de relacionamento
////Cardinalidade: 1 para muitos


//builder.HasOne(p => p.Cliente) //Pedido TEM-1 Cliente
//    .WithMany(c => c.Pedidos) //Cliente TEM-MUITOS Pedidos
//    .HasForeignKey(p => p.IdCliente); //Chave Estrangeira
