
using System.Collections.Generic;



namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IServiceBase <TEntity> where TEntity : class 
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
