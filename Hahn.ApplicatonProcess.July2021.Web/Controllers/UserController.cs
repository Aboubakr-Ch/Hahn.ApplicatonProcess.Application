using Hahn.ApplicatonProcess.July2021.Data.UnitOfWork;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Web.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserController> _logger;
        public UserController(IUnitOfWork unitOfWork, ILogger<UserController> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// return an User with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>the specific User with the given id </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            _logger.LogInformation("calling the Get User method");
            return await _unitOfWork.Users.GetById(id);
        }
        /// <summary>
        /// create an new User  
        /// </summary>
        /// <param name="user"></param>
        /// <returns>return the created user</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            _logger.LogInformation("calling the Create User method");
            var newUser = await _unitOfWork.Users.Create(user);
            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
        }
        /// <summary>
        /// update an User if changes 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns>return the updated User</returns>
        [HttpPut]
        public async Task<ActionResult> PutUser(int id, [FromBody] User user)
        {
            _logger.LogInformation("calling the Update User method");
            if (id != user.Id)
            {
                return BadRequest();
            }
            await _unitOfWork.Users.Update(user);
            return NoContent();
        }
        /// <summary>
        /// delete an user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return if deletion is successful</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            _logger.LogInformation("calling the Delete User method");
            var user = await _unitOfWork.Users.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            await _unitOfWork.Users.Delete(id);
            return NoContent();
        }
    }
}
