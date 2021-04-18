using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DTO_Automapper_Template.Data;
using DTO_Automapper_Template.DTOs;
using DTO_Automapper_Template.Models;
using Microsoft.AspNetCore.Mvc;

namespace DTO_Automapper_Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DummyDatabase _database;
        private readonly IMapper _mapper;
        public UsersController(DummyDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<UserDTO>>(_database.userList));
        }

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<UserDTO> Get(string id)
        {
            return Ok(_mapper.Map<UserDTO>(_database.userList.Where(u => u.Id == id).FirstOrDefault()));
        }

        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            var newUser = _database.AddUser(user);
            var newUserDTO = _mapper.Map<UserDTO>(newUser);

            return new CreatedAtRouteResult("GetUser", new { id = newUserDTO.Id }, newUserDTO);
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] User user)
        {
            _database.UpdateUser(id, user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _database.RemoveUser(id);
        }
    }
}