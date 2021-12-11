using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.IRepository;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LecturersController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetLecturers()
        {
            try
            {
                var lecturers = await _userManager.GetUsersInRoleAsync("Lecturer");
                var result = _mapper.Map<IList<LecturerDTO>>(lecturers);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(GetLecturers)}, Message: {ex}", statusCode: 500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLecturer(string id)
        {
            try
            {
                var lecturer = await _userManager.FindByIdAsync(id);
                var result = _mapper.Map<LecturerDTO>(lecturer);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(GetLecturer)}, Message: {ex}", statusCode: 500);
            }
        }
    }
}
