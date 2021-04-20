using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bikeShop.Modelos.Entidades
{
    public class Proveedor
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Telefono { get; set; }
        public string Email { get; set; }
        [Required]
        public string Direccion { get; set; }

        [JsonIgnore]
        public virtual ICollection<Orden> Ordenes { get; set; }
    }
}
