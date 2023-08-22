using CadastroUsuarios.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuarios.Data
{
    public class BancoContext : DbContext
    {

        public DbSet<CadastroModel> Usuarios { get; set; }

        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        
        //Configuração padrão do contexto do Banco de Dados
        //1 - criar o construtor, que irá receber o mesmo nome da classe;
        //1.1 - injetar, como parâmetro de entrada, o DbContextOptions;
        //1.2 - tipar o DbContext injetado com a nossa própria classe <BancoContext>;
        //1.3 - dar um nome para a nossa injeção. No caso, demos o nome de options;
        //1.4 - passar para dentro da lib DbContext a informação do options através do ": base(options)" 

        //2 - configurar a entidade CadastroModel.cs dentro do nosso contexto "BancoContext"
        //o contexto BancoContext pode ter várias tabelas
        //no momento faremos apenas a tabela de usuários

    }
}
