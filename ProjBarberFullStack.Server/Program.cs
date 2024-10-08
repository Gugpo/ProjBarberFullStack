using Microsoft.EntityFrameworkCore;
using ProjBarberFullStack.Server.DataContext;
using ProjBarberFullStack.Server.Services.SchedulingService;
using ProjBarberFullStack.Server.Services.ServiceSchedule;
using ProjBarberFullStack.Server.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserInterface, UserService>();
builder.Services.AddScoped<ISchedulingInterface, Scheduling>();
builder.Services.AddScoped<IScheduleInterface, Schedule>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));	

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
