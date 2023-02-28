using api.Dtos;
using api.Dtos.Authentication;
using api.Exceptions;
using api.Models;
using api.Services;
using api.Utilities.Accessors;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IEnvironmentVariablesAccessor _environmentVariablesAccessor;

        public AuthorizationController(IMapper mapper, IUserService userService, IEnvironmentVariablesAccessor environmentVariablesAccessor)
        {
            _mapper = mapper;
            _userService = userService;
            _environmentVariablesAccessor = environmentVariablesAccessor;
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<UserSignResponseDto>> SignUp(UserSignUpRequestDto userSignUpRequestDto)
        {
            bool isEmailTaken = await _userService.IsEmailTakenAsync(userSignUpRequestDto.Email);
            if (isEmailTaken) throw new HttpBadRequestException("Email adress is taken!");

            User user = _mapper.Map<User>(userSignUpRequestDto);
            await _userService.AddAsync(user);

            string jwtSecret = _environmentVariablesAccessor.GetVariable(EnvironmentVariables.JWT_SECRET);
            UserSignResponseDto response = new()
            {
                Jwt = user.CreateJwt(jwtSecret)
            };

            return Ok(response);
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult<UserSignResponseDto>> SignIn(UserSignInRequestDto userSignInRequestDto)
        {
            string invalidCredentialsMessage = "Invalid credentials!";

            User? user = await _userService.GetByEmailAsync(userSignInRequestDto.Email);
            if (user == null) throw new HttpBadRequestException(invalidCredentialsMessage);
            bool isPasswordValid = user.ComparePassword(userSignInRequestDto.Password);
            if (!isPasswordValid) throw new HttpBadRequestException(invalidCredentialsMessage);

            string jwtSecret = _environmentVariablesAccessor.GetVariable(EnvironmentVariables.JWT_SECRET);
            UserSignResponseDto response = new()
            {
                Jwt = user.CreateJwt(jwtSecret)
            };

            return Ok(response);
        }

    }
}
