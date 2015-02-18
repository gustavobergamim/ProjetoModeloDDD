using System.Data.Entity;
using ProjetoModeloDDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using ProjetoModeloDDD.Infra.Data.EntityConfig;

namespace ProjetoModeloDDD.Infra.Data.Contexto
{
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext() :base("ProjetoModeloDD")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            
            //Define que quando tiver um nome+Id será a primary key da tabela;
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType + "Id")
                .Configure(p => p.IsKey());

            //Para todas as colunas do Tipo string crie no BD comoo varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            //Caso não informe o tamanho da string será varchar(100)
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfiguration());

            modelBuilder.Configurations.Add(new ProdutoConfiguration());

        }


        //Feito um override onde tiver o Data cadastro setar datetime.now se for inserção
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry=> entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added) 
                {
                    entry.Property("DataCadastro").CurrentValue = System.DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
                
            }

            return base.SaveChanges();
        }
    }
}
