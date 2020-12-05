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
    public class ProfessorController : ControllerBase
    {

        private readonly DataContext _context;

        public ProfessorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_context.Professores);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var Professor = _context.Professores.FirstOrDefault(a => a.Id == id);

            if (Professor == null) return BadRequest();

            return Ok(Professor);
        }

        [HttpGet("GetByName/{nome}/{sobreNome}")]
        public IActionResult GetByName(string nome)
        {
            var Professor = _context.Professores.FirstOrDefault(a => a.Nome == nome);

            if (Professor == null) return BadRequest();

            return Ok(Professor);
        }

        [HttpPost]
        public IActionResult Post(Professor model)
        {
            _context.Add(model);
            _context.Entry(model).State = EntityState.Added;
            _context.SaveChanges();
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor model)
        {
            var Professor = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (Professor == null) return BadRequest("Professor não encontrado");

            _context.Add(model);
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Professor = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (Professor == null) return BadRequest("Professor não encontrado");

            _context.Add(Professor);
            _context.Entry(Professor).State = EntityState.Deleted;
            _context.SaveChanges();

            return Ok(id);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor model)
        {

            var Professor = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (Professor == null) return BadRequest("Professor não encontrado");

            _context.Add(model);
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(model);
        }

    }
}