using Microsoft.EntityFrameworkCore;
using ProjBarberFullStack.Server.DataContext;
using ProjBarberFullStack.Server.Models;

namespace ProjBarberFullStack.Server.Services.UserService
{
	public class UserService : IUserInterface
	{
		private readonly ApplicationDbContext _context;
		public UserService(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<ServiceResponseModel<List<UserModel>>> GetUser()
		{
			ServiceResponseModel<List<UserModel>> serviceResponse = new ServiceResponseModel<List<UserModel>>();

			try
			{
				serviceResponse.Data = _context.Users.ToList();

				if (serviceResponse.Data.Count == 0)
					throw new Exception("No users found");

				return serviceResponse;
			}
			catch (Exception ex)
			{
				serviceResponse.Message = ex.Message;
				serviceResponse.Success = false;

				return serviceResponse;
			}
		}
		public async Task<ServiceResponseModel<UserModel>> GetUserById(int? id)
		{
			ServiceResponseModel<UserModel> serviceResponse = new ServiceResponseModel<UserModel>();

			try
			{
				UserModel? user = _context.Users.FirstOrDefault(x => x.Id == id);
				serviceResponse.Data = user;

				if (serviceResponse.Data == null)
					throw new Exception("User not found");

				return serviceResponse;
			}
			catch (Exception ex)
			{
				serviceResponse.Message = ex.Message;
				serviceResponse.Success = false;

				return serviceResponse;
			}
		}
		public async Task<ServiceResponseModel<UserModel>> CreateUser(UserModel newUser)
		{
			ServiceResponseModel<UserModel> serviceResponse = new ServiceResponseModel<UserModel>();

			try
			{
				if (newUser == null)
					throw new Exception ("Inform user data");

				_context.Users.Add(newUser);
				await _context.SaveChangesAsync();

				serviceResponse.Data = newUser;

				return serviceResponse;
			}
			catch (Exception ex)
			{
				serviceResponse.Message = ex.Message;
				serviceResponse.Success = false;

				return serviceResponse;
			}			
		}
		public async Task<ServiceResponseModel<UserModel>> UpdateUser(UserModel updatedUser)
		{
			ServiceResponseModel<UserModel> serviceResponse = new ServiceResponseModel<UserModel>();

			try
			{
				UserModel? user = _context.Users.AsNoTracking().FirstOrDefault(x => x.Id == updatedUser.Id);

				if (user == null)
					throw new Exception("User not found");

				serviceResponse.Data = updatedUser;
				updatedUser.ChangeDate = DateTime.Now.ToLocalTime();

				_context.Users.Update(updatedUser);
				await _context.SaveChangesAsync();

				return serviceResponse;
			}
			catch (Exception ex)
			{
				serviceResponse.Message = ex.Message;
				serviceResponse.Success = false;

				return serviceResponse;
			}
		}
		public async Task<ServiceResponseModel<UserModel>> DeleteUser(int? id)
		{
			ServiceResponseModel<UserModel> serviceResponse = new ServiceResponseModel<UserModel>();

			try
			{
				UserModel? user = _context.Users.FirstOrDefault(x => x.Id == id);
				serviceResponse.Data = user;

				if (serviceResponse.Data == null)
					throw new Exception("User not found");
				
				_context.Users.Remove(user);
				await _context.SaveChangesAsync();

				return serviceResponse;
			}
			catch (Exception ex)
			{
				serviceResponse.Message = ex.Message;
				serviceResponse.Success = false;

				return serviceResponse;
			}
		}
	}
}
