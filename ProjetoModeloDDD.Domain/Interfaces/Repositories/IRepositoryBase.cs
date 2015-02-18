using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    //Crud padrão
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        //Adicionar objeto
        void Add(TEntity obj);

        //Pegar por ID
        TEntity GetById(int id);
        //Listar todos
        IEnumerable<TEntity> GetAll();

        //Atualizar
        void Update(TEntity obj);

        //Excluir
        void Remove(TEntity obj);

        void Dispose();

    }
}
