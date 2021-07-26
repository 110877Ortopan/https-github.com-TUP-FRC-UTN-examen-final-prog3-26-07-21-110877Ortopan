using System;
using System.Collections.Generic;

#nullable disable

namespace FinalAPI.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
