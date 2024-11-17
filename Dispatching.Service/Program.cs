using System.Reflection;
using Dispatching.Dal;
using Dispatching.Dal.Persistence.CircuitBoards;
using Dispatching.Domain.CircuitBoards;
using Dispatching.Service;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
//services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddDbContext<WriteDbContext>();
services.AddMediatR(Assembly.GetExecutingAssembly());
services.AddScoped<ICircuitBoardRepository, CircuitBoardRepository>();
services.AddControllers();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<WriteDbContext>();
	db.Database.Migrate();
}

app.UseExceptionHandler(errorApp =>
{
	errorApp.Run(ExceptionHandler.HandleAsync);
});
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseRouting()
   .UseEndpoints(t => t.MapControllers());
app.UseCors(t => t.AllowAnyOrigin());
//app.UseHttpsRedirection();

app.Run();
