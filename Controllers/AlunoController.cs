using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Escola.Context;
using Escola.Models;

namespace Escola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly EscolaContext _context;

        public AlunoController(EscolaContext context)
        {
            _context = context;
        }

        // GET: api/Aluno
        [HttpGet]
        // public async Task<ActionResult<IEnumerable<Aluno>>> GetAluno()
        //{
        //if (_context.Aluno == null)
        // {
        //     return NotFound("Não existe lista de alunos");
        //}
        //  return await _context.Aluno.ToListAsync();
        // }

        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            if (_context.Aluno == null || _context.Aluno.Count() == 0)
            {
                return new JsonResult("Não há nenhum aluno cadastrado neste momento.");
            }
            var alunos = await _context.Aluno.ToListAsync();
            List<Aluno> alunosAtivos = new List<Aluno>();
            foreach ( var aluno in alunos)
            {
                var turma = await _context.Turma.FindAsync(aluno.TurmaId);
                if(turma.Ativo == true)
                {
                    alunosAtivos.Add(new Aluno { Id = aluno.Id, Nome = aluno.Nome, DataNascimento = aluno.DataNascimento, Sexo = aluno.Sexo, TotalFaltas = aluno.TotalFaltas, TurmaId = aluno.TurmaId });
                }
            }
            return alunosAtivos;
           // return new JsonResult(new
           // {
           //     total = alunos.Count,
           //     alunos = alunos
           // });
        }


        // GET: api/Aluno/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
          if (_context.Aluno == null)
          {
              return NotFound();
          }
            var aluno = await _context.Aluno.FindAsync(id);

            if (aluno == null)
            {
                return NotFound($"O aluno{id} não foi encontrado em nossa base de dados.");
            }

            return aluno;
        }

        // PUT: api/Aluno/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
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

        // POST: api/Aluno
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {
          if (_context.Aluno == null)
          {
              return Problem("Entity set 'EscolaContext.Aluno'  is null.");
          }
            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAluno", new { id = aluno.Id }, aluno);
        }

        // DELETE: api/Aluno/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            if (_context.Aluno == null)
            {
                return NotFound();
            }
            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound($"O aluno{id} não foi encontrado em nossa base de dados.");
            }

            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlunoExists(int id)
        {
            return (_context.Aluno?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}




