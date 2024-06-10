using ProjBarberFullStack.Server.Models;

namespace ProjBarberFullStack.Server.Services.UserService
{
	public interface IUserInterface
	{
		Task<ServiceResponseModel<List<UserModel>>> GetUser();
		Task<ServiceResponseModel<UserModel>> GetUserById(int? id);
		Task<ServiceResponseModel<UserModel>> CreateUser(UserModel newUser);
		Task<ServiceResponseModel<UserModel>> UpdateUser(UserModel updatedUser);
		Task<ServiceResponseModel<UserModel>> DeleteUser(int? id);
	}
}
