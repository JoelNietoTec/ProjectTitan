using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebAPI.CustomObjects;
using WebAPI.Models.Users;
using Microsoft.EntityFrameworkCore;
using WebAPI.Filters;

namespace WebAPI.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UsersContext _context;
        private IHttpContextAccessor _accessor;

        public AuthController(UsersContext context, IHttpContextAccessor accesor) 
        {
            _context = context;
            _accessor = accesor;
        }

        [SkipActionFilter]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login log)
        {
            log.UserName = log.UserName.ToLower();

            User user;
            UsersInfo loggedUser;

            user = await _context.Users.Where(x => x.Email.ToLower() == log.UserName || x.UserName.ToLower() == log.UserName).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound(new ApiResponse(404, "Usuario no encontrado"));
            }

            if (user.Password != log.Password)
            {
                return NotFound(new ApiResponse(401, "Contraseña incorrecta"));
            }

            var sessionId = GetSessionId(20);

            Session userSession = new Session
            {
                SessionId = sessionId,
                UserId = user.Id,
                LoginTime = DateTime.Now,
                IP = _accessor.HttpContext.Connection.RemoteIpAddress.ToString()
            };

            _context.Sessions.Add(userSession);

            await _context.SaveChangesAsync();

            _context.Entry(userSession).Reference(x => x.User).Load();

            loggedUser = await _context.UsersInfo.FindAsync(user.Id);

            return Ok(userSession);
        }

        [SkipActionFilter]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] string sessionID)
        {
            var _session = await _context.Sessions.Where(x => x.SessionId == sessionID).FirstOrDefaultAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_session == null)
            {
                return NotFound(new ApiResponse(404, "Sesión inexistente"));
            }

            if (_session.LogoutTime != null)
            {
                return Ok(new ApiResponse(202, "Sesión ya estaba terminada"));
            }

            _session.LogoutTime = DateTime.Now;

            _context.Entry(_session).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {

                throw;
            }

            return Ok(new ApiResponse(200, "Sesión finalizada exitosamente"));
        }

        public static string GetSessionId(int maxSize)
        {
            char[] chars = new char[62];
            chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
    }
}