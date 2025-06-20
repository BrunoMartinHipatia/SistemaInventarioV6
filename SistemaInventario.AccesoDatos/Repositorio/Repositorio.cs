using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaInventario.AccesoDatos.Data;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class


    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
      public async Task Agregar(T entidad)
        {
         await dbSet.AddAsync(entidad); // insert into table
        }

        public async Task<T> Obtener(int id)
        {
           return await dbSet.FindAsync(id); // select * from id
        }

        public async Task<T> ObtenerPrimero(Expression<Func<T, bool>> filtro, string incluirPropiedades, bool istracking)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro); // select * from where
            }
            if (incluirPropiedades!=null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp); // ejemplo "categoria, marca"
                }
            }
   
            if (!istracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync();
        }

        public async  Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>> filtro, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string incluirPropiedades = null, bool istracking = true)
        {
            IQueryable<T> query = dbSet;
            if(filtro != null)
            {
                query = query.Where(filtro); // select * from where
            }
            if (incluirPropiedades!=null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp); // ejemplo "categoria, marca"
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (!istracking)
            {
                query = query.AsNoTracking();
            }
            return  await query.ToListAsync();
        }

        public void Remover(T entidad)
        {
            dbSet.Remove(entidad);
        }

        public void RemoverRango(IEnumerable<T> entidad)
        {
            dbSet.RemoveRange(entidad);
        }
    }
}
