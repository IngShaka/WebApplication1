using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddendaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AddendaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Addenda>> Get()
        {
            return _context.Addendas.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Addenda> Get(Guid id)
        {
            var addenda = _context.Addendas.Find(id);
            if (addenda == null)
            {
                return NotFound();
            }
            return addenda;
        }

        [HttpPost]
        public ActionResult<Addenda> Post(Addenda addenda)
        {
            _context.Addendas.Add(addenda);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = addenda.IdAddenda }, addenda);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Addenda addenda)
        {
            if (id != addenda.IdAddenda)
            {
                return BadRequest();
            }

            _context.Entry(addenda).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var addenda = _context.Addendas.Find(id);
            if (addenda == null)
            {
                return NotFound();
            }

            // Cambiar el estado de la entidad a false en lugar de eliminarla
            addenda.Estado = false;
            _context.SaveChanges();

            return NoContent();
        }
    }
}
