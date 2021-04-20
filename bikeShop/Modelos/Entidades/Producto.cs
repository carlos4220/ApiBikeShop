using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace bikeShop.Modelos.Entidades
{
    public class Producto
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
        public string Imagen { get; set; }
        public string Marca { get; set; }

        [JsonIgnore]
        public virtual ICollection<DetalleOrden> detalles { get; set; }
    }
}
