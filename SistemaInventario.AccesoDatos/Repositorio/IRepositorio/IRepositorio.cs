using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio.IRepositorio
{
    public interface IRepositorio <T> where T : class
    {
        public    Task<T> Obtener(int id);

        public Task<IEnumerable<T>> ObtenerTodos(
            Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string incluirPropiedades = null, bool istracking = true
            );
        public Task<T> ObtenerPrimero(
            Expression<Func<T, bool>> filtro = null, string incluirPropiedades = null, bool istracking = true
            );
        public Task Agregar(T entidad);
        public void Remover(T entidad);
        public void RemoverRango(IEnumerable<T> entidad);


    }
}
