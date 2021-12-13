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
    public class GroupSubjectsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GroupSubjectsController(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("assign-subject")]
        public async Task<IActionResult> AssignGroupSubjects([FromBody] AssignGroupSubjectDTO dto)
        {
            try
            {
                var result = _mapper.Map<IList<GroupSubject>>(dto.GroupSubjects);
                await _unitOfWork.GroupSubjects.InsertRange(result);
                await _unitOfWork.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(AssignGroupSubjects)}, Message: {ex}", statusCode: 500);
            }
        }

        //[HttpDelete]
        //public async Task<IActionResult> DeleteGroupSubject([FromBody] AssignGroupSubjectDTO dto)
        //{
        //    try
        //    {
                
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem($"Something went wrong in {nameof(DeleteGroupSubject)}, Message: {ex}", statusCode: 500);
        //    }
        //}
    }
}
