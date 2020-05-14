using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw10.Models;
using Cw10.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentDbService _context;

        public StudentsController(IStudentDbService context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetStudent()
        {
            return Ok(_context.ZwrocenieListyStudentow());
        }

        [HttpGet("{id}")]
        public IActionResult DeleteStudent(String id)
        {
            int pobrane = _context.UsuniecieStudenta(id);
            if(pobrane>0)return Ok("Usuniety"); else return NotFound("Nie znaleziono");
        }

        [HttpPost]
        public IActionResult ModyfikacjaStudenta(Student dane)
        {
            int pobrane = _context.ModyfikacjaStudenta(dane);
            if (pobrane > 0) return Ok("Zmodyfikowany"); else return NotFound("Nie zmodyfikowany");
        }
    }
}