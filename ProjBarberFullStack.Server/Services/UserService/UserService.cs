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
		public async Task<ServiceResponse<List<UserModel>>> GetUser()
		{
			ServiceResponse<List<UserModel>> serviceResponse = new ServiceResponse<List<UserModel>>();

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
		public async Task<ServiceResponse<UserModel>> GetUserById(int? id)
		{
			ServiceResponse<UserModel> serviceResponse = new ServiceResponse<UserModel>();

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
		public async Task<ServiceResponse<UserModel>> CreateUser(UserModel newUser)
		{
			ServiceResponse<UserModel> serviceResponse = new ServiceResponse<UserModel>();

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
		public async Task<ServiceResponse<UserModel>> UpdateUser(UserModel updatedUser)
		{
			ServiceResponse<UserModel> serviceResponse = new ServiceResponse<UserModel>();

			try
			{
				UserModel? user = _context.Users.AsNoTracking().FirstOrDefault(x => x.Id == updatedUser.Id);
				serviceResponse.Data = user;

				if (serviceResponse.Data == null)
					throw new Exception("User not found");

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
		public async Task<ServiceResponse<UserModel>> DeleteUser(int? id)
		{
			ServiceResponse<UserModel> serviceResponse = new ServiceResponse<UserModel>();

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
