using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjBarberFullStack.Server.Models;
using ProjBarberFullStack.Server.Services.UserService;

namespace ProjBarberFullStack.Server.Controllers
{
	[Route("api/user")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserInterface _userInterface;
		public UserController(IUserInterface userInterface)
		{
			_userInterface = userInterface;
		}

		[HttpGet]
		[Route("GetUser")]
		public async Task<ActionResult<ServiceResponseModel<List<UserModel>>>> GetUser()
		{
			return Ok(await _userInterface.GetUser());
		}

		[HttpGet]
		[Route("GetUserById")]
		public async Task<ActionResult<ServiceResponseModel<UserModel>>> GetUserById(int id)
		{
			return Ok(await _userInterface.GetUserById(id));
		}

		[HttpPost]
		[Route("CreateUser")]
		public async Task<ActionResult<ServiceResponseModel<UserModel>>> CreateUser(UserModel newUser)
		{
			return Ok(await _userInterface.CreateUser(newUser));
		}

		[HttpPut]
		[Route("UpdateUser")]
		public async Task<ActionResult<ServiceResponseModel<UserModel>>> UpdateUser(UserModel updateUser)
		{
			return Ok(await _userInterface.UpdateUser(updateUser));
		}

		[HttpDelete]
		[Route("DeleteUser")]
		public async Task<ActionResult<ServiceResponseModel<UserModel>>> DeleteUser(int id)
		{
			return Ok(await _userInterface.DeleteUser(id));
		}
	}
}
