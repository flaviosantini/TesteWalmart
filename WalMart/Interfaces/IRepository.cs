using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Walmart.Interfaces
{
    public interface IRepository<T> where T : class
    {
        bool Adiciona(T entity);
        bool Atualiza(T entity);
        bool Deleta(int Id);
        T Seleciona(T entity);
        List<T> Lista();
    }
}
