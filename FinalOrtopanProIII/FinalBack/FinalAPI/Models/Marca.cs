using System;
using System.Collections.Generic;

#nullable disable

namespace FinalAPI.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int Id { get; set; }
        public string Marca1 { get; set; }

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
