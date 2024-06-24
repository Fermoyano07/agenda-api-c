using GestordeContactosApi.Context;
using GestordeContactosApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestordeContactosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosApiController : Controller
    {
        private readonly ContactosApiDbContext context;
        public ContactosApiController(ContactosApiDbContext context)
        {
            this.context = context;
        }
    

        // GET: api/<UsuariosApiController>
        [HttpGet]
        public IActionResult Get()
        {
            try 
            {
                return Ok(context.Contacto.ToList());
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<UsuariosApiController>/5
        [HttpGet("{id}", Name = "GetContacto")]
        public IActionResult Get(int id)
        {
            try 
            { 
                var ContactosApi = context.Contacto.FirstOrDefault( x => x.Id == id);
                return Ok(ContactosApi);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<UsuariosApiController>
        [HttpPost]
        public IActionResult Post([FromBody] Contacto Contacto)
        {
            try
            {
                context.Contacto.Add(Contacto);
                context.SaveChanges();
                return CreatedAtRoute("GetContacto", new { Id = Contacto.Id }, Contacto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsuariosApiController>/5
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] Contacto Contacto)
        {
            try
            {
                if (Contacto.Id == Id)
                {
                    context.Entry(Contacto).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetContacto", new { Id = Contacto.Id }, Contacto);
                }
                else 
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                var innerExceptionMessage = ex.InnerException?.Message;
                var innerExceptionStackTrace = ex.InnerException?.StackTrace;
                return StatusCode(500, $"An error occurred while saving the entity changes: {innerExceptionMessage}");
            }
        }

        // DELETE api/<UsuariosApiController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var contacto = context.Contacto.FirstOrDefault(x => x.Id == id);
                if (contacto != null) 
                {
                    context.Contacto.Remove(contacto);
                    context.SaveChanges();
                    return Ok(id);
                }
                else 
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
