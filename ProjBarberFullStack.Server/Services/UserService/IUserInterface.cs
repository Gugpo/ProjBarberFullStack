using ProjBarberFullStack.Server.Models;

namespace ProjBarberFullStack.Server.Services.UserService
{
	public interface IUserInterface
	{
		Task<ServiceResponse<List<UserModel>>> GetUser();
		Task<ServiceResponse<UserModel>> GetUserById(int? id);
		Task<ServiceResponse<UserModel>> CreateUser(UserModel newUser);
		Task<ServiceResponse<UserModel>> UpdateUser(UserModel updatedUser);
		Task<ServiceResponse<UserModel>> DeleteUser(int? id);
	}
}
