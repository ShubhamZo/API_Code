using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsAPI.Models;

namespace StudentsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public static List<Students> students = new List<Students>
        {

            new Students { Id = 1, Name = "Shreya Singh", Address = "Jaipur" },

            new Students { Id = 2, Name = "Rana Pratap",Address = "Assam" },

            new Students { Id = 3, Name = "Shubham Agarwal", Address = "Maharashtra" }

        };

        // GET : api/Students
        [HttpGet]
        public ActionResult<IEnumerable<Students>> GetALL()
        {
            return Ok(students);
        }

        //GET Student details with ID
        [HttpGet] 
        [Route("{id}")]
        public ActionResult<IEnumerable<Students>> GetById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        //GET Studend details using Name
        /*[HttpGet]
        [Route("{name}")]
        public ActionResult<IEnumerable<Students>> GetByName(string name)
        {
            var student = students.FirstOrDefault(s => s.Name == name);
            if (student == null)
                return NotFound();
            return Ok(student);
        }*/
        [HttpPost]

        public ActionResult<Students> Create(Students newStudent)

        {
            newStudent.Id = students.Max(p => p.Id) + 1;
            students.Add(newStudent);
            return CreatedAtAction(nameof(GetById), new { id = newStudent.Id }, newStudent);

        }

        [HttpPut("Update Students Details")]
        public ActionResult Update(int id, Students updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();
            student.Name = updatedStudent.Name;
            student.Address = updatedStudent.Address;
            return NoContent();
        }

        [HttpDelete("Delete Student Details")]
        public ActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();
            students.Remove(student);
             return NoContent();
        }

    }
}
