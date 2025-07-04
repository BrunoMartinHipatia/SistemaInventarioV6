﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Modelos
{
    public class Bodega
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es requerido")]
        [MaxLength(60, ErrorMessage ="Nombre debe ser maximo 60 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Descipcion es requerido")]
        [MaxLength(100, ErrorMessage = "Nombre debe ser maximo 100 caracteres")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Estado es requerido")]
        public bool Estado { get; set; }
    }
}
