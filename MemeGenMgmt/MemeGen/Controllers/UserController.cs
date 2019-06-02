using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MGM.CQRS.Interface;
using MGM.CQRS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MemeGen.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUser _userService;

        public UserController(IUser userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _userService.Select();
        }

        [HttpGet("exists")]
        public string[] GetUserByUsernameAndMail(string username, string mail)
        {
            var userExists = _userService.UserExists(username);
            var mailExists = _userService.MailExists(mail);
            var invalidCredentials = new List<string>();
            if (userExists)
                invalidCredentials.Add("user");
            if (mailExists)
                invalidCredentials.Add("mail");
            return invalidCredentials.ToArray();
        }

        [HttpGet("{id}")]
        public User GetUserByUser(int id)
        {
            return _userService.SelectById(id);
        }

        [HttpPost]
        public IActionResult InsertUser([FromBody]User user)
        {
            _userService.Insert(user);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteUser(int userId)
        {
            if (_userService.Delete(null, userId))
                return Ok();
            return NotFound();
        }


        [HttpDelete]
        public IActionResult DeleteUser([FromBody]User user)
        {
            if (_userService.Delete(user))
                return Ok();
            return NotFound();
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] User user, int userId)
        {
            if (userId == 0)
                userId = -1;
            if (_userService.Update(user, userId))
                return Ok();
            return NotFound();
        }
    }
}
