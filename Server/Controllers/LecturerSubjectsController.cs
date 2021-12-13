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
    public class LecturerSubjectsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LecturerSubjectsController(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("assign-subject")]
        public async Task<IActionResult> AssignSubject([FromBody] AssignSubjectDTO dto)
        {
            try
            {
                var result = _mapper.Map<LecturerSubject>(dto);
                var existingSubject = await _unitOfWork.LecturerSubjects.Get(q => q.Id == result.Id);

                if (existingSubject == null)
                {
                    await _unitOfWork.LecturerSubjects.Insert(result);
                    await _unitOfWork.Save();
                    return Ok();
                }

                existingSubject.SubjectId = result.SubjectId;
                _unitOfWork.LecturerSubjects.Update(existingSubject);
                await _unitOfWork.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(AssignSubject)}, Message: {ex}", statusCode: 500);
            }
        }
    }
}
