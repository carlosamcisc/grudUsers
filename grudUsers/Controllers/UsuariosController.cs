using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using grudUsers.Models;
using grudUsers.Data;
using Microsoft.AspNetCore.Components;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using System.Linq;

namespace grudUsers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly GrudusersContext _context;
        public UsuariosController(GrudusersContext context)
        {
            _context = context;
        }

        //GET : api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        //Get: api/Usuarios/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if(usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // GET: api/Usuarios/ByName/Carlos
        [HttpGet("ByName/{nombreUsuario}")]
        public async Task<ActionResult<Usuario>> GetUsuarioByNombre(string nombreUsuario) //No usar IEnumerable<Usuario> porque solo se espera un resultado|
        {
            var usuario = await _context.Usuarios
                                        .FirstOrDefaultAsync(u => u.Nombre == nombreUsuario);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }




        //POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction
                (
                    nameof(GetUsuario),
                    new { id = usuario.IdUser},
                    usuario
                );
        }
        //Put: api/Usuarios/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if(id != usuario.IdUser)
            {
                return BadRequest();
            }
            _context.Entry(usuario).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!UsuarioExists(id))
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

        //Delete: api/Usuarios/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if(usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUser == id);
        }
    }
}
