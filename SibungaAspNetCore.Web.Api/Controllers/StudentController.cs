using Microsoft.AspNetCore.Mvc;
using SibungaAspNetCore.Web.Api.Models;
using SibungaAspNetCore.Web.Api.Services;

namespace SibungaAspNetCore.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _service;

        public StudentController(StudentService service)
        {
            _service = service;
        }

        [HttpGet("fulltime")]
        public ActionResult<bool> GetFullTime()
        {
            try
            {
                var s = _service.Get();
                return Ok(s.FullTime);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("fullname")]
        public ActionResult<string> GetFullName()
        {
            try
            {
                var s = _service.Get();
                return Ok(s.FullName);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("idno")]
        public ActionResult<string> GetIdNo()
        {
            try
            {
                var s = _service.Get();
                return Ok(s.IdNo);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("program")]
        public ActionResult<string> GetProgram()
        {
            try
            {
                var s = _service.Get();
                return Ok(s.Program);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("birthdate")]
        public ActionResult<string?> GetBirthDate()
        {
            try
            {
                var s = _service.Get();
                return Ok(s.BirthDate?.ToString("yyyy-MM-dd"));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("age")]
        public ActionResult<int?> GetAge()
        {
            try
            {
                var s = _service.Get();
                return Ok(s.Age);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // POST to set full-time status
        [HttpPost("set-fulltime")]
        public ActionResult SetFullTime([FromBody] bool fullTime)
        {
            try
            {
                _service.SetFullTime(fullTime);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("set-idno")]
        public ActionResult SetIdNo([FromBody] string idno)
        {
            try
            {
                _service.SetIdNo(idno);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("set-program")]
        public ActionResult SetProgram([FromBody] string program)
        {
            try
            {
                _service.SetProgram(program);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("set-birthdate")]
        public ActionResult SetBirthDate([FromBody] string birthDate)
        {
            try
            {
                if (DateOnly.TryParse(birthDate, out var d))
                {
                    _service.SetBirthDate(d);
                    return NoContent();
                }
                return BadRequest("Invalid date format. Use yyyy-MM-dd.");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // Optional: set full name via POST
        [HttpPost("set-fullname")]
        public ActionResult SetFullName([FromBody] string fullname)
        {
            try
            {
                _service.SetFullName(fullname);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
