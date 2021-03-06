using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.IRepository;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GroupsController(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            try
            {
                var groups = await _unitOfWork.Groups.GetAll(null, null, new List<string> { "GroupSubjects" });
                foreach (var group in groups)
                {
                    foreach (var groupSubject in group.GroupSubjects)
                    {
                        groupSubject.Subject = await _unitOfWork.Subjects.Get(q => q.Id == groupSubject.SubjectId);
                    }
                }
                var result = _mapper.Map<List<GroupDTO>>(groups);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(GetGroups)}, Message: {ex}", statusCode: 500);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGroup(int id)
        {
            try
            {
                var group = await _unitOfWork.Groups.Get(g => g.Id == id);
                return Ok(group);
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(GetGroups)}, Message: {ex}", statusCode: 500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] CreateGroupDTO dto)
        {
            try
            {
                var group = _mapper.Map<Group>(dto);
                await _unitOfWork.Groups.Insert(group);
                await _unitOfWork.Save();

                return CreatedAtAction("GetGroup", new { id = group.Id }, group);
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(CreateGroup)}, Message: {ex}", statusCode: 500);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            try
            {
                await _unitOfWork.Groups.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(DeleteGroup)}, Message: {ex}", statusCode: 500);
            }
        }
    }
}
