using Microsoft.EntityFrameworkCore;
using ProjBarberFullStack.Server.DataContext;
using ProjBarberFullStack.Server.Models;

namespace ProjBarberFullStack.Server.Services.SchedulingService
{
	public class Scheduling : ISchedulingInterface
	{
		private readonly ApplicationDbContext _context;
		public Scheduling(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<ServiceResponseModel<List<SchedulingModel>>> GetScheduling()
		{
			ServiceResponseModel<List<SchedulingModel>> serviceResponse = new ServiceResponseModel<List<SchedulingModel>>();

			try
			{
				serviceResponse.Data = _context.Scheduling.ToList();

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
		public async Task<ServiceResponseModel<SchedulingModel>> GetSchedulingById(int? id)
		{
			ServiceResponseModel<SchedulingModel> serviceResponse = new ServiceResponseModel<SchedulingModel>();

			try
			{
				SchedulingModel? scheduling = _context.Scheduling.FirstOrDefault(x => x.Id == id);
				serviceResponse.Data = scheduling;

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
		public async Task<ServiceResponseModel<SchedulingModel>> CreateScheduling(SchedulingModel newScheduling)
		{
			ServiceResponseModel<SchedulingModel> serviceResponse = new ServiceResponseModel<SchedulingModel>();

			try
			{
				if (newScheduling == null)
				throw new Exception("Inform user data");

				_context.Scheduling.Add(newScheduling);
				await _context.SaveChangesAsync();

				serviceResponse.Data = newScheduling;

				return serviceResponse;
			}
			catch (Exception ex)
			{
				serviceResponse.Message = ex.Message;
				serviceResponse.Success = false;

				return serviceResponse;
			}
		}
		public async Task<ServiceResponseModel<SchedulingModel>> UpdateScheduling(SchedulingModel updatedScheduling)
		{
			ServiceResponseModel<SchedulingModel> serviceResponse = new ServiceResponseModel<SchedulingModel>();

			try
			{
				SchedulingModel? scheduling = _context.Scheduling.AsNoTracking().FirstOrDefault(x => x.Id == updatedScheduling.Id);

				if (scheduling == null)
					throw new Exception("User not found");

				serviceResponse.Data = updatedScheduling;
				updatedScheduling.ChangeDate = DateTime.Now.ToLocalTime();

				_context.Scheduling.Update(updatedScheduling);
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
		public async Task<ServiceResponseModel<SchedulingModel>> DeleteScheduling(int? id)
		{
			ServiceResponseModel<SchedulingModel> serviceResponse = new ServiceResponseModel<SchedulingModel>();

			try
			{
				SchedulingModel? scheduling = _context.Scheduling.FirstOrDefault(x => x.Id == id);
				serviceResponse.Data = scheduling;

				if (serviceResponse.Data == null)
					throw new Exception("User not found");

				_context.Scheduling.Remove(scheduling);
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
