using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.IRepository;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;
        private readonly IUnitOfWork _unitOfWork;

        public AuthController(UserManager<User> userManager, IMapper mapper, IAuthManager authManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _mapper = mapper;
            _authManager = authManager;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
        {
            try
            {
                var user = _mapper.Map<User>(registerDto);
                var result = await _userManager.CreateAsync(user, registerDto.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    return BadRequest(ModelState);
                }

                await _userManager.AddToRolesAsync(user, registerDto.Roles);
                return Accepted();
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(Register)}, Message: {ex}", statusCode: 500);
            }
        }
        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                if (!await _authManager.ValidateUser(loginDTO))
                {
                    return Unauthorized();
                }

                User user = await _unitOfWork.Users.Get(u => u.UserName == loginDTO.Username);
                IList<string> role = await _userManager.GetRolesAsync(user);
                var result = _mapper.Map<UserDTO>(user);
                result.Role = role[0];

                return Accepted(new { User = result, Token = await _authManager.CreateToken() });
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in {nameof(Login)}, Message: {ex}", statusCode: 500);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("isAuthed")]
        public IActionResult IsAuthed()
        {
            return Ok();
        }
    }
}
