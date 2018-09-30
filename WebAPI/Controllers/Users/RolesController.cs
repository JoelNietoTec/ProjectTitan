using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Filters;
using WebAPI.Models.Users;

namespace WebAPI.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly UsersContext _context;

        public RolesController(UsersContext context)
        {
            _context = context;
        }

        [SkipActionFilter]
        [HttpGet]
        public IEnumerable<Role> GetRoles() => _context.Roles;
    }
}