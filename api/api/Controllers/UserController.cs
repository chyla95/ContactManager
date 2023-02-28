using api.Dtos.User;
using api.Exceptions;
using api.Models;
using api.Services;
using api.Utilities.Accessors;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IContextAccessor _contextAccessor;

        public UserController(IMapper mapper, IUserService userService, IContextAccessor contextAccessor)
        {
            _mapper = mapper;
            _userService = userService;
            _contextAccessor = contextAccessor;
        }


        [HttpGet]
        public ActionResult<UserResponseDto> GetOne()
        {
            User user = _contextAccessor.GetUser();

            UserResponseDto response = _mapper.Map<UserResponseDto>(user);
            return Ok(response);
        }

    }
}
