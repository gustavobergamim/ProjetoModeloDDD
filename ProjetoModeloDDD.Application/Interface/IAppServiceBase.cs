using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IAppServiceBase <TEntity> where TEntity : class 
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
