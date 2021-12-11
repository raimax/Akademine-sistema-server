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
    public class StudentsController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public StudentsController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var students = await _userManager.GetUsersInRoleAsync("Student");
                var result = _mapper.Map<IList<StudentDTO>>(students);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(GetStudents)}, Message: {ex}", statusCode: 500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(string id)
        {
            try
            {
                var student = await _userManager.FindByIdAsync(id);
                var result = _mapper.Map<LecturerDTO>(student);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(GetStudent)}, Message: {ex}", statusCode: 500);
            }
        }
    }
}
