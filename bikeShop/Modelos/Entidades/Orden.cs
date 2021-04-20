using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bikeShop.Modelos.Entidades
{
    public class Orden
    {
        [Key]
        public int Codigo { get; set; }
        public int Proveedor { get; set; } = -1;
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Descripcion { get; set; }

        [JsonIgnore]
        public virtual ICollection<DetalleOrden> Detalles { get; set; }

        [ForeignKey("Proveedor")]
        [JsonIgnore]
        public virtual Proveedor proveedor { get; set; }

    }

}
