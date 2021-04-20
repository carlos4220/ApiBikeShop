using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bikeShop.Modelos.Context;
using bikeShop.Modelos.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bikeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesController : ControllerBase
    {
        private readonly Contexto contexto;
        public DetallesController(Contexto context)
        {
            this.contexto = context;
        }

        [HttpGet("{id}")]
        public ActionResult<List<DetalleOrden>> GeyById(int id)
        {
            var detalles = contexto.DetalleOrden.Where(temp => temp.Id_Orden == id).ToList();
            if (detalles == null)
            {
                return NotFound();
            }
            return detalles;
        }

        [HttpPost]
        public ActionResult<List<DetalleOrden>> AgregarDetalles([FromBody] List<DetalleOrden> detalles)
        {
            try
            {
                contexto.DetalleOrden.AddRange(detalles);
                contexto.SaveChanges();
                return detalles;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
