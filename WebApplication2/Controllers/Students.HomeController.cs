using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Context;
using WebApplication2.Models;

namespace EscuelaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly Application _context;

        public EstudiantesController(Application context)
        {
            _context = context;
        }

        // GET:obtiene  a los estudiantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<STUDENT>>> GetEstudiantes()
        {
            return await _context.student.ToListAsync();
        }

        // GET: obtiene  a los estudiantes por id
        [HttpGet("{id}")]
        public async Task<ActionResult<STUDENT>> GetEstudiante(int id)
        {
            var estudiante = await _context.student.FindAsync(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            return estudiante;
        }

        // POST: api/Estudiantes
        [HttpPost]
        public async Task<ActionResult<STUDENT>> PostEstudiante(STUDENT estudiante)
        {
            _context.student.Add(estudiante);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEstudiante), new { id = estudiante.COD_STUDENT }, estudiante);
        }

        // PUT: aqui realiza la actualizacion de data del estudiante
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(int id, STUDENT estudiante)
        {
            if (id != estudiante.COD_STUDENT)
            {
                return BadRequest();
            }

            _context.Entry(estudiante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: aqui lo elimina
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var estudiante = await _context.student.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            _context.student.Remove(estudiante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstudianteExists(int id)
        {
            return _context.student.Any(e => e.COD_STUDENT == id);
        }
    }
}
