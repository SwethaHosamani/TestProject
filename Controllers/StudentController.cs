using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using StudentProject.Models;

namespace StudentProject.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
   

    private readonly TestDemoContext _DBContext;

    public StudentController(TestDemoContext dBContext)
    {
        this._DBContext=dBContext;
    }

    

    [HttpGet("GetAll")]
public IActionResult GetAll()
{
    var students = this._DBContext.StudentData.ToList();

    if (students == null || students.Count == 0)
    {
        return NotFound("No students found");
    }

    return Ok(students);
}




[HttpGet("GetByStudentId/{studentId}")]
public IActionResult GetByStudentId(string studentId)
{
    if (string.IsNullOrEmpty(studentId) || studentId.Length != 8 || !studentId.StartsWith("STDN"))
    {
        return BadRequest("Invalid Student ID format. It must start with 'STDN' followed by 4 digits.");
    }

    var student = _DBContext.StudentData.FirstOrDefault(s => s.StudentId == studentId);

    if (student == null)
    {
        return NotFound("Student not found");
    }

    return Ok(student);
}







[HttpPost("AddStudent")]
[ProducesResponseType(typeof(StudentDatum), StatusCodes.Status201Created)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public IActionResult AddStudent([FromBody] StudentDatum student)
{
    if (student == null)
    {
        return BadRequest("Invalid data");
    }

    _DBContext.StudentData.Add(student);

    try
    {
        _DBContext.SaveChanges();
    }
    catch (Exception)
    {
        return BadRequest("Error occurred while adding the student");
    }

    if (_DBContext.StudentData.Any(s => s.StudentId == student.StudentId))
    {
        return CreatedAtAction(nameof(GetByStudentId), new { studentId = student.StudentId }, student);
    }

    return BadRequest("Student was not added successfully");
}



[HttpPut("UpdateStudent")]
[ProducesResponseType(typeof(StudentDatum), StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public IActionResult UpdateStudent([FromBody] StudentDatum student)
{
    if (student == null)
    {
        return BadRequest("Invalid data");
    }

    var existingStudent = _DBContext.StudentData.FirstOrDefault(s => s.StudentId == student.StudentId);

    if (existingStudent == null)
    {
        return NotFound("Student not found");
    }

    // Update the properties of existingStudent with values from the incoming student object
    existingStudent.Gender = student.Gender;
    existingStudent.Nationlity = student.Nationlity;
    existingStudent.PlaceOfBirth = student.PlaceOfBirth;
    existingStudent.StageId = student.StageId;
    existingStudent.GradeId = student.GradeId;
    existingStudent.SectionId = student.SectionId;
    existingStudent.Topic = student.Topic;
    existingStudent.Semester = student.Semester;
    existingStudent.Relation = student.Relation;
    existingStudent.RaisedHands = student.RaisedHands;
    existingStudent.VisitedResources = student.VisitedResources;
    existingStudent.AnnouncementsView = student.AnnouncementsView;
    existingStudent.Discussion = student.Discussion;
    existingStudent.ParentAnsweringSurvey = student.ParentAnsweringSurvey;
    existingStudent.ParentschoolSatisfaction = student.ParentschoolSatisfaction;
    existingStudent.StudentAbsenceDays = student.StudentAbsenceDays;
    existingStudent.StudentMarks = student.StudentMarks;
    existingStudent.Classes = student.Classes;

    // Validate the updated student
    var validationContext = new ValidationContext(existingStudent, null, null);
    var validationResults = new List<ValidationResult>();
    if (!Validator.TryValidateObject(existingStudent, validationContext, validationResults, true))
    {
        return BadRequest(validationResults.Select(r => r.ErrorMessage));
    }

    _DBContext.SaveChanges();

    return Ok(existingStudent);
}


   
 


[HttpDelete("DeleteByStudentId/{studentId}")]
[ProducesResponseType(StatusCodes.Status204NoContent)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public IActionResult DeleteByStudentId(string studentId)
{
    var student = _DBContext.StudentData.SingleOrDefault(s => s.StudentId == studentId);

    if (student == null)
    {
        return NotFound("Student not found");
    }

    _DBContext.StudentData.Remove(student);

    try
    {
        _DBContext.SaveChanges();
        return NoContent();
    }
    catch (Exception)
    {
        return BadRequest("Error occurred while deleting the student");
    }
}




[HttpDelete("DeleteAll")]
[ProducesResponseType(StatusCodes.Status204NoContent)]
public IActionResult DeleteAll()
{
    var allStudents = _DBContext.StudentData.ToList();

    if (allStudents != null && allStudents.Any())
    {
        _DBContext.StudentData.RemoveRange(allStudents);

        try
        {
            _DBContext.SaveChanges();
            return NoContent();
        }
        catch (Exception)
        {
            return BadRequest("Error occurred while deleting the students");
        }
    }

    return NoContent(); // If there are no students to delete, return NoContent.
}

}
