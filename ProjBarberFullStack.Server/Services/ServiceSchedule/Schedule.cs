using Microsoft.EntityFrameworkCore;
using ProjBarberFullStack.Server.DataContext;
using ProjBarberFullStack.Server.Models;

namespace ProjBarberFullStack.Server.Services.ServiceSchedule
{
	public class Schedule : IScheduleInterface
	{
		private readonly ApplicationDbContext _context;
		public Schedule(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<ServiceResponseModel<List<ScheduleModel>>> GetSchedule()
		{
			ServiceResponseModel<List<ScheduleModel>> serviceResponse = new ServiceResponseModel<List<ScheduleModel>>();

			try
			{
				serviceResponse.Data = _context.Schedule.ToList();

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
		public async Task<ServiceResponseModel<ScheduleModel>> GetScheduleById(int? id)
		{
			ServiceResponseModel<ScheduleModel> serviceResponse = new ServiceResponseModel<ScheduleModel>();

			try
			{
				ScheduleModel? scheduling = _context.Schedule.FirstOrDefault(x => x.Id == id);
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
		public async Task<ServiceResponseModel<ScheduleModel>> CreateSchedule(ScheduleModel newScheduling)
		{
			ServiceResponseModel<ScheduleModel> serviceResponse = new ServiceResponseModel<ScheduleModel>();

			try
			{
				if (newScheduling == null)
					throw new Exception("Inform user data");

				_context.Schedule.Add(newScheduling);
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
		public async Task<ServiceResponseModel<ScheduleModel>> UpdateSchedule(ScheduleModel updatedScheduling)
		{
			ServiceResponseModel<ScheduleModel> serviceResponse = new ServiceResponseModel<ScheduleModel>();

			try
			{
				ScheduleModel? scheduling = _context.Schedule.AsNoTracking().FirstOrDefault(x => x.Id == updatedScheduling.Id);

				if (scheduling == null)
					throw new Exception("User not found");

				serviceResponse.Data = updatedScheduling;
				updatedScheduling.ChangeDate = DateTime.Now.ToLocalTime();

				_context.Schedule.Update(updatedScheduling);
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
		public async Task<ServiceResponseModel<ScheduleModel>> DeleteSchedule(int? id)
		{
			ServiceResponseModel<ScheduleModel> serviceResponse = new ServiceResponseModel<ScheduleModel>();

			try
			{
				ScheduleModel? scheduling = _context.Schedule.FirstOrDefault(x => x.Id == id);
				serviceResponse.Data = scheduling;

				if (serviceResponse.Data == null)
					throw new Exception("User not found");

				_context.Schedule.Remove(scheduling);
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

