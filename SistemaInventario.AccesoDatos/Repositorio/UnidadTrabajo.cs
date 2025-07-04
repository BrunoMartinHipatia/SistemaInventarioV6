﻿using SistemaInventario.AccesoDatos.Data;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    internal class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public IBodegaRepositorio Bodega { get; private set; }

        public UnidadTrabajo(ApplicationDbContext db)
        {
             _db = db;
            Bodega = new BodegaRepositorio(db);
        }
        public  void Dispose()
        {
            _db.Dispose();
        }

        public async  Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}
