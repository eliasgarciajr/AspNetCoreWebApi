using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase   {
        
        private readonly DataContext _context;

        public AlunoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_context.Alunos);
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null) return BadRequest();

            return Ok(aluno);
        }

        [HttpGet("GetByName/{nome}/{sobreNome}")]
        public IActionResult GetByName(string nome, string sobreNome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome == nome && a.Sobrenome == sobreNome);

            if (aluno == null) return BadRequest();

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno model)        
        {
            _context.Add(model);
            _context.Entry(model).State = EntityState.Added;
            _context.SaveChanges();
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno model)                
        {
            var aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _context.Add(model);
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");            

            _context.Add(aluno);
            _context.Entry(aluno).State = EntityState.Deleted;
            _context.SaveChanges();

            return Ok(id);
        }

         [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno model)        {

            var aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _context.Add(model);
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(model);
        }

    }
}