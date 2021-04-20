using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bikeShop.Modelos.Context;
using bikeShop.Modelos.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bikeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly Contexto contexto;
        public OrdenesController(Contexto context)
        {
            this.contexto = context;
        }

        [HttpGet]
        public ActionResult<List<Orden>> AllOrdenes()
        {
            var ordenes = contexto.Orden.Include(c => c.Detalles).ToList();
            if (ordenes == null)
            {
                return NotFound();
            }
            return ordenes;
        }

        [HttpGet("{id}")]
        public ActionResult<Orden> GeyById(int id)
        {
            var orden = contexto.Orden.Include(c => c.Detalles).FirstOrDefault(t => t.Codigo == id);
            if (orden == null)
            {
                return NotFound();
            }
            return orden;
        }

        [HttpPost]
        public ActionResult<Orden> CrearOrden([FromBody] Orden orden)
        {
            try
            {
                contexto.Orden.Add(orden);
                contexto.SaveChanges();
                return orden;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}/{estado}")]
        public ActionResult<Orden> ActualizarEstado(int id, string estado)
        {
            try
            {
                var orden = contexto.Orden.Find(id);
                if(orden == null)
                {
                    return NotFound();
                }
                orden.Estado = estado;
                contexto.Entry(orden).State = EntityState.Modified;
                contexto.SaveChanges();
                return orden;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Orden> EliminarOrden(int id)
        {
            try
            {
                var orden = contexto.Orden.Find(id);
                if (orden == null)
                {
                    return NotFound();
                }
                contexto.Remove(orden);
                contexto.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
