using api.Models;
using api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using AutoMapper;
using api.Dtos.Contact;
using api.Exceptions;
using System.Security;
using api.Utilities.Accessors;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContactService _contactService;
        private readonly IContextAccessor _contextAccessor;

        public ContactController(IMapper mapper, IContactService contactService, IContextAccessor contextAccessor)
        {
            _mapper = mapper;
            _contactService = contactService;
            _contextAccessor = contextAccessor;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactResponseDto>>> GetMany()
        {
            IEnumerable<Contact> contacts = await _contactService.GetManyAsync();

            IEnumerable<ContactResponseDto> response = _mapper.Map<IEnumerable<ContactResponseDto>>(contacts);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ContactResponseDto>> Get(int id)
        {
            Contact? contact = await _contactService.GetAsync(id);
            if (contact == null) throw new HttpNotFoundException("Contact not found!");

            ContactResponseDto response = _mapper.Map<ContactResponseDto>(contact);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ContactResponseDto>> Add(ContactRequestDto contactRequestDto)
        {
            User user = _contextAccessor.GetUser();
            Contact contact = _mapper.Map<Contact>(contactRequestDto);
            contact.Owner = user;
            await _contactService.AddAsync(contact);

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ContactResponseDto>> Update(int id, ContactRequestDto contactRequestDto)
        {
            User user = _contextAccessor.GetUser();
            Contact? contact = await _contactService.GetAsync(id);
            if (contact == null) throw new HttpNotFoundException("Contact not found!");

            if (contact.Owner.Id != user.Id) throw new HttpBadRequestException("This contact belongs to another user!");

            _mapper.Map(contactRequestDto, contact);
            await _contactService.UpdateAsync(contact);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Remove(int id)
        {
            Contact? contact = await _contactService.GetAsync(id);
            if (contact == null) throw new HttpNotFoundException("Contact not found!");

            await _contactService.RemoveAsync(contact);
            return Ok();
        }
    }
}
