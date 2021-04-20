using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bikeShop.Modelos.Entidades
{
    public class DetalleOrden
    {
        public int correlativo { get; set; }
        public int Id_Orden { get; set; }
        public int CodigoProducto { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int Cantida { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal PrecioCompra { get; set; }

        [JsonIgnore]
        [ForeignKey("CodigoProducto")]
        public virtual Producto producto { get; set; }

        [JsonIgnore]
        [ForeignKey("Id_Orden")]
        public virtual Orden orden { get; set; }
    }
}
