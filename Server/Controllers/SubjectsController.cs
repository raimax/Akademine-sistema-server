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
    public class SubjectsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SubjectsController(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubjects()
        {
            try
            {
                return Ok(await _unitOfWork.Subjects.GetAll());
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(GetSubjects)}, Message: {ex}", statusCode: 500);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSubject(int id)
        {
            try
            {
                var subject = await _unitOfWork.Subjects.Get(g => g.Id == id);
                return Ok(subject);
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(GetSubject)}, Message: {ex}", statusCode: 500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromBody] CreateSubjectDTO dto)
        {
            try
            {
                var subject = _mapper.Map<Subject>(dto);
                await _unitOfWork.Subjects.Insert(subject);
                await _unitOfWork.Save();

                return CreatedAtAction("GetSubject", new { id = subject.Id }, subject);
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(CreateSubject)}, Message: {ex}", statusCode: 500);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            try
            {
                await _unitOfWork.Subjects.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(DeleteSubject)}, Message: {ex}", statusCode: 500);
            }
        }
    }
}
