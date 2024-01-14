using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentEaseLibrary.Models;

namespace PropertyRentingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepo UserRepo;
        public UserController(IUserRepo  userRepo)
        {
            UserRepo = userRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<User> users=await UserRepo.GetAllUser();
            return Ok(users);
        }

        [HttpGet("{UserName}")]

        public async Task<ActionResult>GetByUserName(string UserName)
        {
            try
            {
                User user = await UserRepo.GetUserByUserName(UserName);
                return Ok(user);
            }
            catch (Exception )
            {
                throw new Exception("No such UserName is Found");
            }
        }

        [HttpPost("{Login}")]

        public async Task<ActionResult>Login(User user)
        {
            try
            {
                await UserRepo.Login(user);
                return Ok("Login Suscccesfull");
            }
            catch (Exception)
            {
                throw new Exception("Login Failed");
            }
        }

        [HttpPost]

        public async Task<ActionResult>InsertUser(User user)
        {
            await UserRepo.InsertUser(user);
            return Created($"api/user/{user.UserName}", user);

        }

        [HttpDelete("{UserName}")]

        public async Task<ActionResult>DelteUser(string username)
        {
            await UserRepo.DeleteUserByUserName(username);
            return Ok();
        }
    }
}
