using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.IRepository;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentGradesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public StudentGradesController(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetStudentGrades(string userId)
        {
            try
            {
                return Ok(await _unitOfWork.StudentGrades.GetAll(q => q.UserId == userId, null, new List<string> { "Subject" }));
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(GetStudentGrades)}, Message: {ex}", statusCode: 500);
            }
        }

        [HttpGet("{subjectId:int}")]
        public async Task<IActionResult> GetStudentGrades(int subjectId)
        {
            try
            {
                return Ok(await _unitOfWork.StudentGrades.GetAll(q => q.SubjectId == subjectId, null, new List<string> { "Subject", "User" }));
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(GetStudentGrades)}, Message: {ex}", statusCode: 500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddGrade([FromBody] AddGradeDTO dto)
        {
            try
            {
                var grade = _mapper.Map<StudentGrade>(dto);
                await _unitOfWork.StudentGrades.Insert(grade);
                await _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(AddGrade)}, Message: {ex}", statusCode: 500);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> AddGrade(int id)
        {
            try
            {
                await _unitOfWork.StudentGrades.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(AddGrade)}, Message: {ex}", statusCode: 500);
            }
        }
    }
}
