using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.IRepository;
using Server.Models;

namespace Server.Controllers
{
    [Authorize(Roles = "Administrator")]
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
                return Ok(await _unitOfWork.Groups.GetAll());
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

                return CreatedAtAction("GetGroup", new { id = group.Id });
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(CreateGroup)}, Message: {ex}", statusCode: 500);
            }
        }
    }
}
