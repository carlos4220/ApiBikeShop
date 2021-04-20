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
    public class ProductosController : ControllerBase
    {
        private readonly Contexto contexto;
        public ProductosController(Contexto context)
        {
            this.contexto = context;
        }

        [HttpGet]
        public ActionResult<List<Producto>> AllProductos()
        {
            var products = contexto.Producto.ToList();
            if(products == null)
            {
                return NotFound();
            }
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> GeyById(int id)
        {
            var producto = contexto.Producto.Find(id);
            if(producto == null)
            {
                return NotFound();
            }
            return producto;
        }

        [HttpPost]
        public ActionResult<Producto> CrearProducto([FromBody] Producto producto)
        {
            try
            {
                contexto.Producto.Add(producto);
                contexto.SaveChanges();
                return producto;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Producto> ActualizarProducto([FromBody] Producto producto, int id)
        {
            try
            {
                if (id == producto.Codigo)
                {
                    contexto.Entry(producto).State = EntityState.Modified;
                    contexto.SaveChanges();
                    return producto;
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

        [HttpPut("Sumar/{id}")]
        public ActionResult<Producto> SumarCantidad([FromBody] int cantidad, int id)
        {
            try
            {
                var producto = contexto.Producto.Find(id);
                if(producto == null)
                {
                    return NotFound();
                }
                producto.Existencia += cantidad;
                contexto.Entry(producto).State = EntityState.Modified;
                contexto.SaveChanges();
                return producto;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("Restar/{id}")]
        public ActionResult<Producto> RestarCantidad([FromBody] int cantidad, int id)
        {
            try
            {
                var producto = contexto.Producto.Find(id);
                if (producto == null)
                {
                    return NotFound();
                }
                producto.Existencia -= cantidad;
                contexto.Entry(producto).State = EntityState.Modified;
                contexto.SaveChanges();
                return producto;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Producto> EliminarProducto(int id)
        {
            try
            {
                var prod = contexto.Producto.Find(id);
                if (prod == null)
                {
                    return NotFound();
                }
                contexto.Remove(prod);
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
