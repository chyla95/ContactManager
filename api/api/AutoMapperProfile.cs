using api.Dtos.Authentication;
using api.Dtos.Category;
using api.Dtos.Contact;
using api.Dtos.Exception;
using api.Dtos.Subcategory;
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

            CreateMap<Contact, ContactResponseDto>();
            CreateMap<ContactResponseDto, Contact>();
            CreateMap<ContactRequestDto, Contact>();

            CreateMap<Category, CategoryResponseDto>();
            CreateMap<Subcategory, SubcategoryResponseDto>();

            // DTOs - system
            CreateMap<HttpException, HttpExceptionDto>();
            CreateMap<HttpExceptionMessage, HttpExceptionMessageDto>();
        }
    }
}
