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
    public class ProveedoresController : ControllerBase
    {
        private readonly Contexto contexto;
        public ProveedoresController(Contexto context)
        {
            this.contexto = context;
        }

        [HttpGet]
        public ActionResult<List<Proveedor>> AllProvedores()
        {
            var proveedor = contexto.Proveedor.ToList();
            if (proveedor == null)
            {
                return NotFound();
            }
            return proveedor;
        }

        [HttpGet("{id}")]
        public ActionResult<Proveedor> GeyById(int id)
        {
            var proveedor = contexto.Proveedor.Find(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return proveedor;
        }

        [HttpPost]
        public ActionResult<Proveedor> CrearProducto([FromBody] Proveedor proveedor)
        {
            try
            {
                contexto.Proveedor.Add(proveedor);
                contexto.SaveChanges();
                return proveedor;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Proveedor> ActualizarProveedor([FromBody] Proveedor proveedor, int id)
        {
            try
            {
                if (id == proveedor.Codigo)
                {
                    contexto.Entry(proveedor).State = EntityState.Modified;
                    contexto.SaveChanges();
                    return proveedor;
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Proveedor> EliminarProveedor(int id)
        {
            try
            {
                var proveedor = contexto.Proveedor.Find(id);
                if (proveedor == null)
                {
                    return NotFound();
                }
                contexto.Remove(proveedor);
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
