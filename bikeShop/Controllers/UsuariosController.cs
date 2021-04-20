using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using bikeShop.Modelos.Context;
using bikeShop.Modelos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace bikeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly Contexto contexto;

        public UsuariosController(Contexto contex)
        {
            this.contexto = contex;
        }

        [HttpPost]
        public ActionResult<Usuario> Login([FromBody] Usuario Usuario)
        {
            var temp = contexto.Usuario.FirstOrDefault(u => u.Nombre == Usuario.Nombre && u.Password == Usuario.Password);
            if(temp == null)
            {
                return NotFound();
            }
            return temp;
        }

        //metodo que ingresar 2 registros a la base de datos si no hay usuario ingresados
        [HttpGet("verificacion")]
        public void verificacion()
        {
            var temp = contexto.Usuario.FirstOrDefault(u => u.Nombre == "admin" && u.Password == "admin");
            if(temp == null)
            {
                Usuario usuario1 = new Usuario();
                usuario1.Nombre = "admin";
                usuario1.Password = "admin";
                usuario1.Puesto = "Administrador";
                contexto.Usuario.Add(usuario1);
                contexto.SaveChanges();
            }
            var temp2 = contexto.Usuario.FirstOrDefault(u => u.Nombre == "operador" && u.Password == "operador");
            if (temp2 == null)
            {
                Usuario usuario1 = new Usuario();
                usuario1.Nombre = "operador";
                usuario1.Password = "operador";
                usuario1.Puesto = "Operador";
                contexto.Usuario.Add(usuario1);
                contexto.SaveChanges();
            }
        }

        [HttpPost("Add")]
        public ActionResult<Usuario> AgregarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var temp = contexto.Usuario.FirstOrDefault(u => u.Nombre == usuario.Nombre);
                if(temp != null)
                {
                    return NotFound();
                }
                contexto.Usuario.Add(usuario);
                contexto.SaveChanges();
                return usuario;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
