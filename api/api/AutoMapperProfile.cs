using api.Dtos.Authentication;
using api.Dtos.Exception;
using api.Dtos.User;
using api.Exceptions;
using api.Models;
using AutoMapper;

namespace api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            // DTOs - business
            CreateMap<UserSignUpRequestDto, User>();

            CreateMap<User, UserResponseDto>();


            // DTOs - system
            CreateMap<HttpException, HttpExceptionDto>();
            CreateMap<HttpExceptionMessage, HttpExceptionMessageDto>();
        }
    }
}
