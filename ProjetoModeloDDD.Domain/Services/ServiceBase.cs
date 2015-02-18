using System;
using System.CodeDom;
using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class ServiceBase <TEntity> : IDisposable,IServiceBase<TEntity> where TEntity : class
    {
        //Servico trabalha com o Repositorio
        //Não criar instancia do repositorio
        //Pode se fazer referencia do dominio em varios projetos. Mas o dominio nao deve ter referencia de ninguém
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public ServiceBase()
        {
            // TODO: Complete member initialization
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public TEntity GetById(int id)
        {
           return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
           return _repository.GetAll();
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }
    }
}
