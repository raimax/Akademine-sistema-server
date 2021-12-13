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
    public class StudentGroupsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public StudentGroupsController(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("assign-group")]
        public async Task<IActionResult> AssignGroup([FromBody] AssignGroupDTO dto)
        {
            try
            {
                var result = _mapper.Map<StudentGroup>(dto);
                var existingSubject = await _unitOfWork.StudentGroups.Get(q => q.UserId == result.UserId);

                if (existingSubject == null)
                {
                    await _unitOfWork.StudentGroups.Insert(result);
                    await _unitOfWork.Save();
                    return Ok();
                }

                existingSubject.GroupId = result.GroupId;
                _unitOfWork.StudentGroups.Update(existingSubject);
                await _unitOfWork.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(AssignGroup)}, Message: {ex}", statusCode: 500);
            }
        }
    }
}
