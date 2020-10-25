using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
 
        public List<Aluno> Alunos = new List<Aluno>{
            new Aluno(){
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Almeida",
                Telefone = "888"
            },
             new Aluno(){
                Id = 2,
                Nome = "Marta",
                Sobrenome = "Garcia",
                Telefone = "999"
            },
             new Aluno(){
                Id = 3,
                Nome = "Lucas",
                Sobrenome = "Silva",
                Telefone = "777"
            }
        };

        public AlunoController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null) return BadRequest();

            return Ok(aluno);
        }

        [HttpGet("GetByName/{nome}/{sobreNome}")]
        public IActionResult GetByName(string nome, string sobreNome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome == nome && a.Sobrenome == sobreNome);

            if (aluno == null) return BadRequest();

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {           

            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
           

            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           
            return Ok(id);
        }

         [HttpPatch("{id}")]
        public IActionResult Patch(int id)
        {
           
            return Ok(id);
        }

    }
}