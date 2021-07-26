using System;
using System.Collections.Generic;

#nullable disable

namespace FinalAPI.Models
{
    public partial class Vehiculo
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public double Precio { get; set; }
        public int IdTipo { get; set; }
        public int? IdMarca { get; set; }
        public bool? Estado { get; set; }

        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual Tipo IdTipoNavigation { get; set; }
    }
}
