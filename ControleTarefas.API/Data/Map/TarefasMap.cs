using ControleTarefas.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleTarefas.API.Data.Map
{
    public class TarefasMap : IEntityTypeConfiguration<Tarefa>
    {
       public void Configure(EntityTypeBuilder<Tarefa> builder)
       {
          //builder.HasKey(x => x.UsuarioId);
          // builder.Property(x => x.Login).IsRequired().HasMaxLength(200);
          // builder.Property(x => x.Senha).IsRequired().HasMaxLength(50);
          // builder.Property(x => x.TipoSenha).IsRequired();

       }
    }
}
