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
		public async Task<ServiceResponse<List<SchedulingModel>>> GetScheduling()
		{
			ServiceResponse<List<SchedulingModel>> serviceResponse = new ServiceResponse<List<SchedulingModel>>();

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
		public async Task<ServiceResponse<SchedulingModel>> GetSchedulingById(int? id)
		{
			ServiceResponse<SchedulingModel> serviceResponse = new ServiceResponse<SchedulingModel>();

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
		public async Task<ServiceResponse<SchedulingModel>> CreateScheduling(SchedulingModel newScheduling)
		{
			ServiceResponse<SchedulingModel> serviceResponse = new ServiceResponse<SchedulingModel>();

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
		public async Task<ServiceResponse<SchedulingModel>> UpdateScheduling(SchedulingModel updatedScheduling)
		{
			ServiceResponse<SchedulingModel> serviceResponse = new ServiceResponse<SchedulingModel>();

			try
			{
				SchedulingModel? scheduling = _context.Scheduling.AsNoTracking().FirstOrDefault(x => x.Id == updatedScheduling.Id);
				serviceResponse.Data = scheduling;

				if (serviceResponse.Data == null)
					throw new Exception("User not found");

				scheduling.ChangeDate = DateTime.Now.ToLocalTime();

				_context.Scheduling.Update(scheduling);

				return serviceResponse;
			}
			catch (Exception ex)
			{
				serviceResponse.Message = ex.Message;
				serviceResponse.Success = false;

				return serviceResponse;
			}
		}
		public async Task<ServiceResponse<SchedulingModel>> DeleteScheduling(int? id)
		{
			ServiceResponse<SchedulingModel> serviceResponse = new ServiceResponse<SchedulingModel>();

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
