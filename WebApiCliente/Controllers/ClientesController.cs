using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using WebApiCliente.Models;

namespace WebApiCliente.Controllers
{
    [CustomExceptionFilter]
    public class ClientesController : ApiController
    {
        private readonly ClientesDbContext _context = new ClientesDbContext();

        [HttpPost]
        public IHttpActionResult CreateCliente(Cliente cliente)
        {
            if (!IsValidEmail(cliente.Email))
            {
                Trace.TraceError($"Excepción: El correo {cliente.Email} propocionado no tiene un formato válido");
                throw new InvalidEmailFormatException("Formato de correo electrónico no válido");
            }

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = cliente.ID }, cliente);
        }

        [HttpGet]
        public IHttpActionResult GetCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPut]
        public IHttpActionResult UpdateCliente(int id, Cliente cliente)
        {
            if (!IsValidEmail(cliente.Email))
            {
                throw new InvalidEmailFormatException("Formato de correo electrónico no válido");
            }


            if (id != cliente.ID)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }

}